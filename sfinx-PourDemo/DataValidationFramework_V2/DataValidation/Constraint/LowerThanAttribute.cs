using System;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Description résumée de LowerThanµ.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class LowerThanAttribute : Attribute, IDataValidationConstraint
	{
		double _higherValue=double.MinValue;

		public LowerThanAttribute(double higherValue) : base()
		{
			_higherValue= higherValue;
		}


		public bool DoCheck(object obj)
		{

			return( _higherValue>(double)obj);
		}

		public string GetValidationFailureMessage()
		{
			return "Must be lower than " + _higherValue.ToString();
		}

		public string GetConstraintDetails()
		{
			return "<"+_higherValue.ToString();
		}

	}
}
