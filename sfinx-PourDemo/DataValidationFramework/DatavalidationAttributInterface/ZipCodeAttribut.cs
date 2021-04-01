using System;
using System.Text.RegularExpressions;

namespace DatavalidationAttributInterface
{
	/// <summary>
	/// Description résumée de ZipCode.
	/// </summary>
	public class ZipCodeAttribute : Attribute, IDataValidationConstraint
	{
		public bool DoCheck(object obj)
		{
			Regex _regex=null;
			_regex= new Regex(@"^\d{5}$");
			return( _regex.Match(obj.ToString()).Success);
		}

	}
}
