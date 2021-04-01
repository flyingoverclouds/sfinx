using System;
using System.Runtime.Remoting.Contexts;	
using System.Runtime.Remoting.Activation;

namespace SableFin.SfinX.DataValidation
{
	/// <summary>
	/// On cr�e un attribut de context indiquant que la classe doit s'executer 
	/// dans un contexte supportant la validation des donn�es
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class DataValidationAttribute : ContextAttribute
	{
		public DataValidationAttribute() : base("DataValidationAttribute")
		{
			
		}


		// Permet d'ajouter des propri�t�s dans un nouveau contexte
		// ( Une propri�t� est un peu l'�quivalent des shared properties utilisable avec COM+ dans ComponentServices )
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
		{
			DataValidationProperty validProp = new DataValidationProperty();
			ctor.ContextProperties.Add(validProp);
		}


		//Le runtime .NET interroge pour savoir si le contexte courant est valide.
		//Si cette fonction false, le runtime cr�� un nouveau contexte et appelle GetPropertiesForNewContext()
		// pour v�rifier si le context est valid, on v�rifie la pr�sence (et la validit� si besoin) d'un propri�t�
		public override bool IsContextOK(Context ctx,IConstructionCallMessage ctorMsg) 
		{ 
			//return false;	// Seulement si vous souhaitez un contexte par instance !
			DataValidationProperty prop=ctx.GetProperty("DataValidation") as DataValidationProperty;
			if (prop!=null)	// on a une propri�t� appel� ValidationData dans le contexte ?
				return true;	// Oui -> on accepte le contexte

			return false;	// Non -> on refuse le contexte
		}

	}
}
