﻿namespace FinancialFileFormats.SEPA
{
    /// <summary>
    ///     Define a SEPA Credit Transfer Transaction
    /// </summary>
    public class SepaCreditTransferTransaction : SepaTransferTransaction
    {
        /// <summary>
        ///     Creditor IBAN data
        /// </summary>
        /// <exception cref="SepaRuleException">If creditor to set is not valid.</exception>
        public SepaIbanData Creditor
        {
            get { return SepaIban; }
            set
            {
                if (!value.IsValid)
                    throw new SepaRuleException("Creditor IBAN data are invalid.");
                SepaIban = value;
            }
        }
    }
}