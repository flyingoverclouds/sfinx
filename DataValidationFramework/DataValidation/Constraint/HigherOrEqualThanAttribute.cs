using System;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Description résumée de HigherOrEqualThanAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class HigherOrEqualThanAttribute : Attribute, IDataValidationConstraint
	{
		double _lowerValue=double.MinValue;

		public HigherOrEqualThanAttribute(double lowerValue) : base()
		{
			_lowerValue= lowerValue;
		}


		public bool DoCheck(object obj)
		{

			return( _lowerValue<=(double)obj);
		}

		public string GetValidationFailureMessage()
		{
			return "Must be higher or equal than " + _lowerValue.ToString();
		}

		public string GetConstraintDetails()
		{
			return ">=" + _lowerValue.ToString();
		}

	}
}
