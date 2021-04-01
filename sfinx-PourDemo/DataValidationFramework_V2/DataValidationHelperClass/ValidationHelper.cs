using System;
using System.Text.RegularExpressions;

namespace DataValidation
{
	public sealed class ValidationHelper
	{
		public static bool MatchRegex(string expressionReguliere,string valeur)
		{
			Regex _regex=null;
			_regex= new Regex(expressionReguliere);
			return( _regex.Match(valeur).Success);
		}

		public static bool IsCodePostal(string valeur)
		{
			return MatchRegex(@"^\d{5}$",valeur);
		}

	}
}
