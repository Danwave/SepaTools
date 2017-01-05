using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialFileFormats.SEPA
{
    public class SepaPaymentNormalization
    {

        public SepaDebitTransfer SepaD { get; set; }
        public SepaCreditTransfer SepaP { get; set; }



        public SepaPaymentNormalization(SepaDebitTransfer completeSepa, SepaDebitTransfer partialSepa)
        {
            SepaD = new SepaDebitTransfer();
            //create SepaD and  SepaP from completeSepa
            SepaD.Creditor = completeSepa.Creditor;
            SepaD.MessageIdentification = completeSepa.MessageIdentification;
            SepaD.InitiatingPartyId = completeSepa.InitiatingPartyId;
            SepaD.PersonId = completeSepa.PersonId;
            SepaD.InitiatingPartyName = completeSepa.InitiatingPartyName;
            SepaD.RequestedExecutionDate = completeSepa.RequestedExecutionDate;

            SepaP = new SepaCreditTransfer();
            SepaP.Debtor = completeSepa.Creditor;
            SepaP.MessageIdentification = completeSepa.MessageIdentification;
            SepaP.PaymentInfoId = completeSepa.PersonId;
            SepaP.InitiatingPartyId = completeSepa.InitiatingPartyId;
            SepaP.InitiatingPartyName = completeSepa.InitiatingPartyName;
            SepaP.RequestedExecutionDate = completeSepa.RequestedExecutionDate;
            List<SepaDebitTransferTransaction> visited = new List<SepaDebitTransferTransaction>();
            foreach (var entry in completeSepa.GetTransactions())
            {
                var iban = entry.Debtor.Iban;
                var EquivalentEntry = partialSepa.GetTransaction(iban);
                if (EquivalentEntry != null)
                {
                    visited.Add(EquivalentEntry);
                    if (EquivalentEntry.Amount < entry.Amount)
                        SepaD.AddDebitTransfer(new SepaDebitTransferTransaction() { Amount = (entry.Amount - EquivalentEntry.Amount), Debtor = entry.Debtor, EndToEndId = entry.EndToEndId, MandateIdentification = entry.MandateIdentification });
                    else if (EquivalentEntry.Amount > entry.Amount)
                        SepaP.AddCreditTransfer(new SepaCreditTransferTransaction() { Amount = (EquivalentEntry.Amount - entry.Amount), Creditor = entry.Debtor, EndToEndId = entry.EndToEndId });
                }
            }
            foreach (var entry in partialSepa.GetTransactions())
            {
                if (!visited.Contains(entry))
                    SepaP.AddCreditTransfer(new SepaCreditTransferTransaction() { Amount = (entry.Amount), Creditor = entry.Debtor, EndToEndId = entry.EndToEndId });
            }
        }
        public SepaPaymentNormalization(SepaCreditTransfer completeSepa, SepaCreditTransfer partialSepa)
        {
            //create SepaD and  SepaP from completeSepa

        }
    }
}
