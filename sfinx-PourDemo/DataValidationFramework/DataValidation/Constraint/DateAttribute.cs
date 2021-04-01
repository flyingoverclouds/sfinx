using System;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Description résumée de FormatAttribute.
	/// </summary>
	public class DateAttribute : Attribute,IDataValidationConstraint
	{
		public DateAttribute()
		{
		}

		public bool DoCheck(object obj)
		{
			try
			{
				DateTime.Parse(obj.ToString());
					return true;
			}
			catch
			{
				return false;
			}
		}

		public string GetValidationFailureMessage()
		{
			return "Must be a valid date";
		}

		public string GetConstraintDetails()
		{
			return "Date valide";
		}


	}
}
