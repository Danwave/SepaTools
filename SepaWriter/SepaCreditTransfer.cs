﻿using System;
using System.Text;
using System.Xml;
using FinancialFileFormats.SEPA.Utils;
using System.Linq;

namespace FinancialFileFormats.SEPA
{
    /// <summary>
    ///     Manage SEPA (Single Euro Payments Area) CreditTransfer for SEPA or international order.
    ///     Only one PaymentInformation is managed but it can manage multiple transactions.
    /// </summary>
    public class SepaCreditTransfer : SepaTransfer<SepaCreditTransferTransaction>
    {
        /// <summary>
        ///     Debtor account ISO currency code (default is EUR)
        /// </summary>
        public string DebtorAccountCurrency { get; set; }

        /// <summary>
        /// Create a Sepa Credit Transfer using Pain.001.001.03 schema
        /// </summary>
        public SepaCreditTransfer()
        {
            DebtorAccountCurrency = Constant.EuroCurrency;
            schema = SepaSchema.Pain00100103;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SepaCreditTransfer"/> class.
        /// </summary>
        /// <param name="debitorAccountCurrencyCode">The currency code.</param>
        /// <exception cref="SepaRuleException">Currency has to be a valid 3 character code in ISO format.</exception>
        public SepaCreditTransfer(string debitorAccountCurrencyCode)
        {
            if (string.IsNullOrWhiteSpace(debitorAccountCurrencyCode) || debitorAccountCurrencyCode.Length != 3)
            {
                throw new SepaRuleException("Currency has to be a valid 3 character code in ISO format.");
            }
            DebtorAccountCurrency = debitorAccountCurrencyCode.ToUpper();
            schema = SepaSchema.Pain00100103;
        }

       

        public static SepaPaymentNormalization operator -(SepaCreditTransfer completeSepa, SepaCreditTransfer partialSepa)
        {
            SepaPaymentNormalization ResultSepa = new SepaPaymentNormalization(completeSepa, partialSepa);
            return ResultSepa;
        }
        /// <summary>
        ///     Debtor IBAN data
        /// </summary>
        /// <exception cref="SepaRuleException">If debtor to set is not valid.</exception>
        public SepaIbanData Debtor
        {
            get { return SepaIban; }
            set
            {
                if (!value.IsValid || value.UnknownBic)
                    throw new SepaRuleException("Debtor IBAN data are invalid.");
                SepaIban = value;
            }
        }

        /// <summary>
        ///     Is Mandatory data set ? Otherwise a SepaRuleException will be thrown
        /// </summary>
        /// <exception cref="SepaRuleException">If mandatory data is missing.</exception>
        protected override void CheckMandatoryData()
        {
            base.CheckMandatoryData();

            if (Debtor == null)
            {
                throw new SepaRuleException("The debtor is mandatory.");
            }
        }

        /// <summary>
        ///     Add an existing transfer transaction
        /// </summary>
        /// <param name="transfer"></param>
        /// <exception cref="ArgumentNullException">If transfert is null.</exception>
        public void AddCreditTransfer(SepaCreditTransferTransaction transfer)
        {
            if (transactions.Any(t => t.Creditor.Iban == transfer.Creditor.Iban))
                transactions.Single(t => t.Creditor.Iban == transfer.Creditor.Iban).Amount += transfer.Amount;
            else
                AddTransfer(transfer);
        }
    
        /// <summary>
        ///     Generate the XML structure
        /// </summary>
        /// <returns></returns>
        protected override XmlDocument GenerateXml()
        {
            CheckMandatoryData();

            var xml = new XmlDocument();
            xml.AppendChild(xml.CreateXmlDeclaration("1.0", Encoding.UTF8.BodyName, "yes"));
            var el = (XmlElement)xml.AppendChild(xml.CreateElement("Document"));
            el.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            el.SetAttribute("xmlns", "urn:iso:std:iso:20022:tech:xsd:" + SepaSchemaUtils.SepaSchemaToString(schema));
            el.NewElement("CstmrCdtTrfInitn");

            // Part 1: Group Header
            var grpHdr = XmlUtils.GetFirstElement(xml, "CstmrCdtTrfInitn").NewElement("GrpHdr");
            grpHdr.NewElement("MsgId", MessageIdentification);
            grpHdr.NewElement("CreDtTm", StringUtils.FormatDateTime(CreationDate));
            grpHdr.NewElement("NbOfTxs", numberOfTransactions);
            grpHdr.NewElement("CtrlSum", StringUtils.FormatAmount(headerControlSum));
            grpHdr.NewElement("InitgPty").NewElement("Nm", InitiatingPartyName);

            if (InitiatingPartyId != null)
            {
                XmlUtils.GetFirstElement(grpHdr, "InitgPty").
                    NewElement("Id").NewElement("OrgId").
                    NewElement("Othr").NewElement("Id", InitiatingPartyId);
            }

            // Part 2: Payment Information
            var pmtInf = XmlUtils.GetFirstElement(xml, "CstmrCdtTrfInitn").NewElement("PmtInf");
            pmtInf.NewElement("PmtInfId", PaymentInfoId ?? MessageIdentification);

            pmtInf.NewElement("PmtMtd", Constant.CreditTransfertPaymentMethod);
            pmtInf.NewElement("NbOfTxs", numberOfTransactions);
            pmtInf.NewElement("CtrlSum", StringUtils.FormatAmount(paymentControlSum));
            pmtInf.NewElement("PmtTpInf").NewElement("SvcLvl").NewElement("Cd", "SEPA");
            if (LocalInstrumentCode != null)
                XmlUtils.GetFirstElement(pmtInf, "PmtTpInf").NewElement("LclInstr")
                        .NewElement("Cd", LocalInstrumentCode);

            if (CategoryPurposeCode != null)
            {
                XmlUtils.GetFirstElement(pmtInf, "PmtTpInf").
                    NewElement("CtgyPurp").
                    NewElement("Cd", CategoryPurposeCode);
            }

            pmtInf.NewElement("ReqdExctnDt", StringUtils.FormatDate(RequestedExecutionDate));
            pmtInf.NewElement("Dbtr").NewElement("Nm", Debtor.Name);
            if (InitiatingPartyId != null)
            {
                XmlUtils.GetFirstElement(pmtInf, "Dbtr").
                    NewElement("Id").NewElement("OrgId").
                    NewElement("Othr").NewElement("Id", InitiatingPartyId);
            }


            var dbtrAcct = pmtInf.NewElement("DbtrAcct");
            dbtrAcct.NewElement("Id").NewElement("IBAN", Debtor.Iban);
            dbtrAcct.NewElement("Ccy", DebtorAccountCurrency);

            pmtInf.NewElement("DbtrAgt").NewElement("FinInstnId").NewElement("BIC", Debtor.Bic);
            pmtInf.NewElement("ChrgBr", "SLEV");

            // Part 3: Credit Transfer Transaction Information
            foreach (var transfer in transactions)
            {
                GenerateTransaction(pmtInf, transfer);
            }

            return xml;
        }

        /// <summary>
        /// Generate the Transaction XML part
        /// </summary>
        /// <param name="pmtInf">The root nodes for a transaction</param>
        /// <param name="transfer">The transaction to generate</param>
        private static void GenerateTransaction(XmlElement pmtInf, SepaCreditTransferTransaction transfer)
        {
            var cdtTrfTxInf = pmtInf.NewElement("CdtTrfTxInf");
            var pmtId = cdtTrfTxInf.NewElement("PmtId");
            if (transfer.Id != null)
                pmtId.NewElement("InstrId", transfer.Id);
            pmtId.NewElement("EndToEndId", transfer.EndToEndId);
            cdtTrfTxInf.NewElement("Amt")
                       .NewElement("InstdAmt", StringUtils.FormatAmount(transfer.Amount))
                       .SetAttribute("Ccy", transfer.Currency.ToUpper());
            XmlUtils.CreateBic(cdtTrfTxInf.NewElement("CdtrAgt"), transfer.Creditor);
            cdtTrfTxInf.NewElement("Cdtr").NewElement("Nm", transfer.Creditor.Name);

            cdtTrfTxInf.NewElement("CdtrAcct").NewElement("Id").NewElement("IBAN", transfer.Creditor.Iban);

            if (!string.IsNullOrEmpty(transfer.Purpose))
            {
                cdtTrfTxInf.NewElement("Purp").NewElement("Cd", transfer.Purpose);
            }

            if (!string.IsNullOrEmpty(transfer.RemittanceInformation))
            {
                cdtTrfTxInf.NewElement("RmtInf").NewElement("Ustrd", transfer.RemittanceInformation);
            }
        }
        protected override bool CheckSchema(SepaSchema aSchema)
        {
            return aSchema == SepaSchema.Pain00100103 || aSchema == SepaSchema.Pain00100104;
        }
    }
}
