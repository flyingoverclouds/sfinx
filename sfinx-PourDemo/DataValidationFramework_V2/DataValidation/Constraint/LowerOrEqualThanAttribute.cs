using System;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Description résumée de LowerOrEqualThanAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class LowerOrEqualThanAttribute : Attribute, IDataValidationConstraint
	{
		double _higherValue=double.MinValue;

		public LowerOrEqualThanAttribute(double higherValue) : base()
		{
			_higherValue= higherValue;
		}


		public bool DoCheck(object obj)
		{

			return( _higherValue>=(double)obj);
		}

		public string GetValidationFailureMessage()
		{
			return "Must be lower or equal than " + _higherValue.ToString();
		}

		public string GetConstraintDetails()
		{
			return "<=" + _higherValue.ToString();
		}

	}
}
