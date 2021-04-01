using System;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Attribut permettant de préciser que la données doit etre un code postal au format francais.
	/// 
	/// Cette attribut héritage de la classe MatchREgularExpression où on force l'expression reguliere pour
	/// correspondre à un code postal francais.
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
