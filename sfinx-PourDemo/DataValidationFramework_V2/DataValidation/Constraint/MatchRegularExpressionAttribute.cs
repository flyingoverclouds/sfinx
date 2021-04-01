using System;
using System.Text.RegularExpressions;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Description résumée de MatchRegularExpressionAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class MatchRegularExpressionAttribute : Attribute, IDataValidationConstraint
	{
		
		Regex _regex=null;

		public MatchRegularExpressionAttribute(string regex) : base()
		{
			_regex= new Regex(regex);
		}

		public bool DoCheck(object obj)
		{

			return( _regex.Match(obj.ToString()).Success);
		}

		public string GetValidationFailureMessage()
		{
			return "Does not match regular expression : " + _regex.ToString();
		}

		public string GetConstraintDetails()
		{
			return "match regex " + _regex.ToString();
		}

	}
}
