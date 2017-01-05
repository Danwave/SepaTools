using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using FinancialFileFormats.SEPA.Utils;
using FinancialFileFormats.SEPA;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace FinancialFileFormats.SEPA
{
    /// <summary>
    ///     Manage SEPA (Single Euro Payments Area) CreditTransfer for SEPA or international order.
    ///     Only one PaymentInformation is managed but it can manage multiple transactions.
    /// </summary>
    public class SepaDebitTransfer : SepaTransfer<SepaDebitTransferTransaction>
    {
        private bool AllowDuplicated = false;

        /// <summary>
        ///     creditor account ISO currency code (default is EUR)
        /// </summary>
        public string CreditorAccountCurrency { get; set; }

        /// <summary>
        ///     Unique and unambiguous identification of a person. SEPA creditor
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Create a Sepa Debit Transfer using Pain.008.001.02 schema
        /// </summary>
        public SepaDebitTransfer()
        {
            CreditorAccountCurrency = Constant.EuroCurrency;
            LocalInstrumentCode = "CORE";
            CreationDate = DateTime.Now;
            schema = SepaSchema.Pain00800102;
        }
        public SepaDebitTransfer(string N19File, string creditorAccountCurrencyCode = "EUR")
        {
            AllowDuplicated = true;
            if (string.IsNullOrWhiteSpace(creditorAccountCurrencyCode) || creditorAccountCurrencyCode.Length != 3)
            {
                throw new SepaRuleException("Currency has to be a valid 3 character code in ISO format.");
            }
            CreditorAccountCurrency = creditorAccountCurrencyCode.ToUpper();

            var lines = System.IO.File.ReadAllLines(N19File, System.Text.Encoding.Default);
            var nif = lines[0].Substring(4, 9);
            var bid = lines[0].Substring(13, 3);
            var name = lines[0].Substring(28, 40).Trim();
            var fechapresentacion = DateTime.ParseExact(lines[1].Substring(22, 6), "ddMMyy", CultureInfo.InvariantCulture);
            var ccc = lines[1].Substring(68, 20);
            var iban = Common.Utils.generateIban(ccc);
            var bic = Common.Utils.GetBicFromBanKCode(ccc.Substring(0, 4));
            var sepacif = Common.Utils.SEPACodeCIF(nif, bid);

            Creditor = new SepaIbanData() { Name = name, Iban = iban, Bic = bic };
            MessageIdentification = "";
            InitiatingPartyId = sepacif;
            PersonId = sepacif;
            InitiatingPartyName = name;
            RequestedExecutionDate = DateTime.Now.AddDays(1);

            int index = 2;
            string NextLineCode = lines[index].Substring(0, 4);
            while (NextLineCode == "5680")
            {



                string client_ccc = lines[index].Substring(68, 20);
                decimal client_total = int.Parse(lines[index].Substring(88, 10)) / 100m;
                string client_iban = Common.Utils.generateIban(client_ccc);
                string client_swift = Common.Utils.GetBicFromBanKCode(client_ccc.Substring(0, 4));
                string client_name = lines[index].Substring(28, 40).Trim();
                string client_nif = lines[index].Substring(16, 9).ToUpper();
                string client_fact = lines[index].Substring(114, 40);
                if (client_total > 0)
                {
                    var entrada = new SepaDebitTransferTransaction()
                    {
                        Amount = client_total,
                        DateOfSignature = DateTime.Now,
                        Debtor = new SepaIbanData() { Name = client_name, Iban = client_iban, Bic = client_swift },
                        EndToEndId = client_nif,
                        MandateIdentification = client_fact,
                        RemittanceInformation = client_fact
                    };
                    AddDebitTransfer(entrada);
                }
                index += 4;
                NextLineCode = lines[index].Substring(0, 4);
            }




        }
        public SepaDebitTransfer(string creditorAccountCurrencyCode)
        {
            if (string.IsNullOrWhiteSpace(creditorAccountCurrencyCode) || creditorAccountCurrencyCode.Length != 3)
            {
                throw new SepaRuleException("Currency has to be a valid 3 character code in ISO format.");
            }
            CreditorAccountCurrency = creditorAccountCurrencyCode.ToUpper();
            LocalInstrumentCode = "CORE";
            CreationDate = DateTime.Now;
            schema = SepaSchema.Pain00800102;
        }



        public SepaDebitTransferTransaction GetTransaction(string Iban)
        {
            return transactions.SingleOrDefault(s => s.Debtor.Iban == Iban);
        }

        public IEnumerable<SepaDebitTransferTransaction> GetTransactions()
        {
            return transactions;
        }

        public static SepaPaymentNormalization operator -(SepaDebitTransfer completeSepa, SepaDebitTransfer partialSepa)
        {
            SepaPaymentNormalization ResultSepa = new SepaPaymentNormalization(completeSepa, partialSepa);
            return ResultSepa;
        }
        /// <summary>
        ///     Creditor IBAN data
        /// </summary>
        /// <exception cref="SepaRuleException">If creditor to set is not valid.</exception>
        public SepaIbanData Creditor
        {
            get { return SepaIban; }
            set
            {
                if (!value.IsValid || value.UnknownBic)
                    throw new SepaRuleException("Creditor IBAN data are invalid.");
                SepaIban = value;
            }
        }

        /// <summary>
        ///     Is Mandatory data are set ? In other case a SepaRuleException will be thrown
        /// </summary>
        /// <exception cref="SepaRuleException">If mandatory data is missing.</exception>
        protected override void CheckMandatoryData()
        {
            base.CheckMandatoryData();

            if (Creditor == null)
            {
                throw new SepaRuleException("The creditor is mandatory.");
            }
        }

        /// <summary>
        ///     Add an existing transfer transaction
        /// </summary>
        /// <param name="transfer"></param>
        /// <exception cref="ArgumentNullException">If transfert is null.</exception>
        public void AddDebitTransfer(SepaDebitTransferTransaction transfer)
        {
            if (AllowDuplicated)
                AddTransfer(transfer);
            else
            {
                if (transactions.Any(t => t.Debtor.Iban == transfer.Debtor.Iban))
                    transactions.Single(t => t.Debtor.Iban == transfer.Debtor.Iban).Amount += transfer.Amount;
                else
                    AddTransfer(transfer);
            }
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
            el.NewElement("CstmrDrctDbtInitn");

            // Part 1: Group Header
            var grpHdr = XmlUtils.GetFirstElement(xml, "CstmrDrctDbtInitn").NewElement("GrpHdr");
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
            this.LocalInstrumentCode = "CORE";
            // Part 2: Payment Information for each Sequence Type.
            foreach (SepaSequenceType seqTp in Enum.GetValues(typeof(SepaSequenceType)))
            {
                var seqTransactions = transactions.FindAll(d => d.SequenceType == seqTp);
                var pmtInf = GeneratePaymentInformation(xml, seqTp, seqTransactions);
                // If a payment information has been created
                if (pmtInf != null)
                {
                    // Part 3: Debit Transfer Transaction Information
                    foreach (var transfer in seqTransactions)
                    {
                        GenerateTransaction(pmtInf, transfer);
                    }
                }
            }

            return xml;
        }

        /// <summary>
        /// Generate a Payment Information node for a Sequence Type.
        /// </summary>
        /// <param name="xml">The XML object to write</param>
        /// <param name="sqType">The Sequence Type</param>
        /// <param name="seqTransactions">The transactions of the specified type</param>
        private XmlElement GeneratePaymentInformation(XmlDocument xml, SepaSequenceType sqType, IEnumerable<SepaDebitTransferTransaction> seqTransactions)
        {
            int controlNumber = 0;
            decimal controlSum = 0;

            // We check the number of transaction to write and the sum due to the Sequence Type.
            foreach (var transfer in seqTransactions)
            {
                controlNumber += 1;
                controlSum += transfer.Amount;
            }

            // If there is no transaction, we end the method here.
            if (controlNumber == 0)
                return null;

            var pmtInf = XmlUtils.GetFirstElement(xml, "CstmrDrctDbtInitn").NewElement("PmtInf");
            pmtInf.NewElement("PmtInfId", PaymentInfoId ?? MessageIdentification);
            if (CategoryPurposeCode != null)
                pmtInf.NewElement("CtgyPurp").NewElement("Cd", CategoryPurposeCode);

            pmtInf.NewElement("PmtMtd", Constant.DebitTransfertPaymentMethod);
            pmtInf.NewElement("NbOfTxs", controlNumber);
            pmtInf.NewElement("CtrlSum", StringUtils.FormatAmount(controlSum));

            var pmtTpInf = pmtInf.NewElement("PmtTpInf");
            pmtTpInf.NewElement("SvcLvl").NewElement("Cd", "SEPA");
            pmtTpInf.NewElement("LclInstrm").NewElement("Cd", LocalInstrumentCode);
            pmtTpInf.NewElement("SeqTp", SepaSequenceTypeUtils.SepaSequenceTypeToString(sqType));

            pmtInf.NewElement("ReqdColltnDt", StringUtils.FormatDate(RequestedExecutionDate));
            pmtInf.NewElement("Cdtr").NewElement("Nm", Creditor.Name);

            var dbtrAcct = pmtInf.NewElement("CdtrAcct");
            dbtrAcct.NewElement("Id").NewElement("IBAN", Creditor.Iban);
            dbtrAcct.NewElement("Ccy", CreditorAccountCurrency);

            pmtInf.NewElement("CdtrAgt").NewElement("FinInstnId").NewElement("BIC", Creditor.Bic);
            pmtInf.NewElement("ChrgBr", "SLEV");

            var othr = pmtInf.NewElement("CdtrSchmeId").NewElement("Id")
                    .NewElement("PrvtId")
                        .NewElement("Othr");
            othr.NewElement("Id", PersonId);
            othr.NewElement("SchmeNm").NewElement("Prtry", "SEPA");

            return pmtInf;
        }

        /// <summary>
        /// Generate the Transaction XML part
        /// </summary>
        /// <param name="pmtInf">The root nodes for a transaction</param>
        /// <param name="transfer">The transaction to generate</param>
        private static void GenerateTransaction(XmlElement pmtInf, SepaDebitTransferTransaction transfer)
        {
            var cdtTrfTxInf = pmtInf.NewElement("DrctDbtTxInf");
            var pmtId = cdtTrfTxInf.NewElement("PmtId");
            if (transfer.Id != null)
                pmtId.NewElement("InstrId", transfer.Id);
            pmtId.NewElement("EndToEndId", transfer.EndToEndId);
            cdtTrfTxInf.NewElement("InstdAmt", StringUtils.FormatAmount(transfer.Amount)).SetAttribute("Ccy", transfer.Currency.ToUpper());

            var mndtRltdInf = cdtTrfTxInf.NewElement("DrctDbtTx").NewElement("MndtRltdInf");
            mndtRltdInf.NewElement("MndtId", transfer.MandateIdentification);
            mndtRltdInf.NewElement("DtOfSgntr", StringUtils.FormatDate(transfer.DateOfSignature));

            XmlUtils.CreateBic(cdtTrfTxInf.NewElement("DbtrAgt"), transfer.Debtor);
            cdtTrfTxInf.NewElement("Dbtr").NewElement("Nm", transfer.Debtor.Name);
            cdtTrfTxInf.NewElement("DbtrAcct").NewElement("Id").NewElement("IBAN", transfer.Debtor.Iban);

            if (!string.IsNullOrEmpty(transfer.RemittanceInformation))
                cdtTrfTxInf.NewElement("RmtInf").NewElement("Ustrd", transfer.RemittanceInformation);
        }

        protected override bool CheckSchema(SepaSchema aSchema)
        {
            return aSchema == SepaSchema.Pain00800102 || aSchema == SepaSchema.Pain00800103;
        }
    }
}
