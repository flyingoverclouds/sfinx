using System;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Description résumée de HigherThanAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class HigherThanAttribute : Attribute, IDataValidationConstraint
	{
		double _lowerValue=double.MinValue;

		public HigherThanAttribute(double lowerValue) : base()
		{
			_lowerValue= lowerValue;
		}


		public bool DoCheck(object obj)
		{

			return( _lowerValue<(double)obj);
		}

		public string GetValidationFailureMessage()
		{
			return "Must be higher than " + _lowerValue.ToString();
		}

		public string GetConstraintDetails()
		{
			return ">" + _lowerValue.ToString();
		}


	}
}
