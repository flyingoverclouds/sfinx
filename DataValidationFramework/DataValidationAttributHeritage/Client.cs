using System;

namespace DataValidationAttributHeritage
{
	/// <summary>
	/// Description résumée de Client.
	/// </summary>
	public class Client
	{
		private string _codePostal;

		[ZipCode]
		public string CodePostal
		{
			get { return _codePostal; }
			set
			{
				AttributeValidationHelper.CheckValidationConstraint(this,"CodePostal",value);
				_codePostal=value;
			}
		}
		
	}
}
