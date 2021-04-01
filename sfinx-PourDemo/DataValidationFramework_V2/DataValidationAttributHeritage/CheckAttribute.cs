using System;

namespace DataValidationAttributHeritage
{
	//public abstract class CheckAttribute : Attribute
	public  class CheckAttribute : Attribute
	{
		//public abstract bool DoCheck(object value);
		public virtual bool DoCheck(object value) 
		{ return false; }
	}
}
