using System;
using System.Runtime.Remoting.Contexts;	
using System.Runtime.Remoting.Activation;

namespace AppliTestInterceptionContext
{
	/// <summary>
	/// On cr�e un attribu de context indiquant que la classe doit s'executer 
	/// dans un contexte supportant l'interception des appels.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class InterceptionAppelAttribute : ContextAttribute
	{
		public InterceptionAppelAttribute() : base("InterceptionAppelAttribute")
		{
			
		}


		// Permet d'ajouter des propri�t�s dans un nouveau contexte
		// ( Une propri�t� est un peu l'�quivalent des shared properties utilisable avec COM+ dans ComponentServices )
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
		{
			InterceptionAppelProperty intercepProp = new InterceptionAppelProperty();
			ctor.ContextProperties.Add(intercepProp);
		}


		//Le runtime .NET interroge l'attribut pour savoir si le contexte courant est valide.
		//Si cette fonction renvoi false, le runtime cr�� un nouveau contexte et appelle GetPropertiesForNewContext()
		// pour v�rifier si le context est valid, on v�rifie la pr�sence (et la validit� si besoin) d'une propri�t�
		public override bool IsContextOK(Context ctx,IConstructionCallMessage ctorMsg) 
		{ 
			//le return false permet de forcer syst�matiquement un nouveau contexte pour chaqueinstance
			// utilise si une instance d'un type cr�� des instance de ce meme type : vous pouvez intercepter
			// les appels entre instance d'un meme type ( car il y aura changement de contexte )
			//return false;	

			InterceptionAppelProperty prop=ctx.GetProperty("InterceptionAppelProperty") as InterceptionAppelProperty;
			if (prop!=null)	// on a une propri�t� appel� InterceptionAppelProperty dans le contexte ?
				return true;	// Oui -> on accepte le contexte

			return false;	// Non -> on refuse le contexte
		}

	}
}
