using System;
using DataValidation;

namespace DataValidationHelperClass
{
	/// <summary>
	/// Description résumée de Client.
	/// </summary>
	public class Client
	{
		private string _codePostal;

		public string CodePostal
		{
			get { return _codePostal; }
			set
			{
				if (!ValidationHelper.IsCodePostal(value))
					throw new ApplicationException(value + " n'est pas un code postal francais");
				_codePostal=value;
			}
		}
		
	}
}
