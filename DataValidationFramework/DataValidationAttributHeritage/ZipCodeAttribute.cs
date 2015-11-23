using System;
using System.Text.RegularExpressions;

namespace DataValidationAttributHeritage
{
	/// <summary>
	/// Description résumée de ZipCodeAttribut.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class ZipCodeAttribute : CheckAttribute
	{
		public override bool DoCheck(object value)
		{
			Regex _regex=null;
			_regex= new Regex(@"^\d{5}$");
			return( _regex.Match(value.ToString()).Success);
		}
	}
}
