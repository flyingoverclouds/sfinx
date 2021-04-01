using System;
using System.Reflection;

namespace DataValidationAttributHeritage
{
	/// <summary>
	/// Description résumée de AttributeValidationHelper.
	/// </summary>
	public sealed class AttributeValidationHelper
	{
		public static void CheckValidationConstraint(object instance,string nomProperty,object valeurAverifier)
		{
			PropertyInfo pi=instance.GetType().GetProperty(nomProperty);
			
			object[] tabAttr=pi.GetCustomAttributes(typeof(CheckAttribute),false);

			foreach(CheckAttribute att in tabAttr)
			{
				if (att.DoCheck(valeurAverifier)==false)
					throw new ApplicationException("La contrainte " + att.GetType().Name + 
						" echoue sur " + nomProperty + " pour la valeur " + valeurAverifier);
			}
		}
	}
}
