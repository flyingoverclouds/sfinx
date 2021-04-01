using System;

namespace SableFin.SfinX.DataValidation
{
	public enum ThrownByTypeEnum
	{
		Unknow,
		Property,
		MethodParameter,
		Method
	}


	/// <summary>
	/// Description résumée de DataValidationException.
	/// </summary>
	public class DataValidationException : ApplicationException
	{
		
		private string _propertyName=string.Empty;
		private ThrownByTypeEnum _thrownByType=ThrownByTypeEnum.Unknow;
		private IDataValidationConstraint _constraint=null;
		private string _methodName=string.Empty;
		private string _parameterName=string.Empty;

		public DataValidationException(string message,string propertyName,IDataValidationConstraint constraint) : base (message)
		{
			_propertyName=propertyName;
			_constraint=constraint;
			_thrownByType=ThrownByTypeEnum.Property;
		}

		public DataValidationException(string message,string methodName,string parameterName,IDataValidationConstraint constraint) : base (message)
		{
			_methodName=methodName;
			_parameterName=parameterName;
			_constraint=constraint;
			_thrownByType=ThrownByTypeEnum.MethodParameter;
		}


		public string PropertyName
		{
			get { return _propertyName; }
		}

		public IDataValidationConstraint Constraint
		{
			get { return _constraint; }
		}

		public string MethodName
		{
			get { return _methodName; }
		}

		public string ParameterName
		{
			get { return _parameterName; }
		}

		public ThrownByTypeEnum ThrownByType
		{
			get { return _thrownByType; }
		}
	
	}
}
