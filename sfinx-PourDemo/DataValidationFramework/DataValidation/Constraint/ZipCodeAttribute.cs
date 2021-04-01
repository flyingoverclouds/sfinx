using System;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Attribut permettant de pr�ciser que la donn�es doit etre un code postal au format francais.
	/// 
	/// Cette attribut h�ritage de la classe MatchREgularExpression o� on force l'expression reguliere pour
	/// correspondre � un code postal francais.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter )]
	public class ZipCodeAttribute : MatchRegularExpressionAttribute
	{
		public ZipCodeAttribute() : base(@"^\d{5}$")
		{
		}

		public new string GetValidationFailureMessage()
		{
			return "Must be a french zipcode";
		}

		
	}
}
