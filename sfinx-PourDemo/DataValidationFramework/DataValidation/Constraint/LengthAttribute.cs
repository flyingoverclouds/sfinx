using System;

namespace SableFin.SfinX.DataValidation.Constraint
{
	/// <summary>
	/// Description résumée de LengthAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter,AllowMultiple=true)]
	public class LengthAttribute : Attribute, IDataValidationConstraint
	{
		private int _minLength;
		private int _maxLength;
		public LengthAttribute(int minLength,int maxLength) : base()
		{
			_minLength=minLength;
			_maxLength=maxLength;
		}

		public bool DoCheck(object obj)
		{
			return (_minLength<=obj.ToString().Length && obj.ToString().Length<=_maxLength);
		}

		public string GetValidationFailureMessage()
		{
			return "Length must be between " + _minLength.ToString() + " and " + _maxLength.ToString();
		}

		public string GetConstraintDetails()
		{
			return _minLength.ToString() + "<=Length<=" + _maxLength.ToString();
		}

	}
}
