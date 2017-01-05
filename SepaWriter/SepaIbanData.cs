﻿using System;
using System.Text.RegularExpressions;
using FinancialFileFormats.SEPA.Utils;

namespace FinancialFileFormats.SEPA
{
	/// <summary>
	/// Get Creditor or Debtor data (Name and BIC + IBAN)
	/// </summary>
	public class SepaIbanData : ICloneable
	{
		private string bic;
		private string iban;
		private string name;
		private bool withoutBic;

		// Regex to find space
		private static readonly Regex SpaceRegex = new Regex("\\s+", RegexOptions.Compiled); 

		/// <summary>
		/// The Name of the owner
		/// </summary>
		public string Name
		{
			get { return name; }
			set
			{
				name = StringUtils.GetLimitedString(value, 70);
			}
		}

		/// <summary>
		/// Is the BIC code unknown?
		/// </summary>
		public bool UnknownBic
		{
			get { return withoutBic; }
			set { withoutBic = value; }
		}

		/// <summary>
		/// The BIC Code (has to be uppercase)
		/// </summary>
		/// <exception cref="SepaRuleException">If BIC hasn't 8 or 11 characters.</exception>
		/// <exception cref="SepaRuleException">Invalid BIC format.</exception>
		public string Bic
		{
			get { return bic; }
			set
			{
				if (value == null || (value.Length != 8 && value.Length != 11)) {
					throw new SepaRuleException(string.Format("Null or Invalid length of BIC/swift code \"{0}\", must be 8 or 11 chars.", value));
				}
				value = value.ToUpper();
				var regex = @"^[A-Z]{6,6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3,3}){0,1}$";
				var match = Regex.Match(value, regex, RegexOptions.IgnoreCase);

				if (!match.Success)
				{
					// does not match
					throw new SepaRuleException(string.Format("Invalid format of BIC/swift code \"{0}\".", value));
				}
				bic = value;
			}
		}

		/// <summary>
		/// The IBAN Number (has to be uppercase)
		/// </summary>
		/// <exception cref="SepaRuleException">If IBAN length is not between 14 and 34 characters.</exception>
		/// <exception cref="SepaRuleException">Invalid format of IBAN code.</exception>
		public string Iban
		{
			get { return iban; }
			set
			{
				if (value == null || value.Length < 14 || value.Length > 34)
					throw new SepaRuleException(string.Format("Null or Invalid length of IBAN code \"{0}\", must contain between 14 and 34 characters.", value));

				value = SpaceRegex.Replace(value.ToUpper(), string.Empty);
				var regex = @"^[A-Z]{2}[0-9]{2}[A-Z0-9]{4}[0-9]{7}([A-Z0-9]?){0,16}$";
				var match = Regex.Match(value, regex, RegexOptions.IgnoreCase);

				if (!match.Success)
				{
					// does not match
					throw new SepaRuleException(string.Format("Invalid format of IBAN code \"{0}\".", value));
				}
				if (!IbanValidationUtils.IsIbanChecksumValid(value))
				{
					throw new SepaRuleException(string.Format("Invalid IBAN checksum on \"{0}\".", value));

				}

				iban = value;
			}
		}

		/// <summary>
		/// Is data is well set to be used
		/// </summary>
		/// <returns></returns>
		public bool IsValid
		{
			get { return (!string.IsNullOrEmpty(bic) || withoutBic) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(iban); }
		}

		/// <summary>
		/// Return a copy of this object
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return MemberwiseClone();
		}
		public override string ToString()
		{
			return name;
			
		}
	}
}