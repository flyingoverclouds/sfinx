using System;

namespace DatavalidationAttributInterface
{
	/// <summary>
	/// Description r�sum�e de Client.
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
