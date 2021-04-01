using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace AppliTestInterceptionContext
{
	/// <summary>
	/// Description résumée de InterceptionAppelProperty.
	/// </summary>
	public class InterceptionAppelProperty : IContextProperty, IContributeServerContextSink
	{
		public InterceptionAppelProperty()
		{
		}
		#region Membres de IContextProperty

		public string Name
		{
			get { return "InterceptionAppelProperty"; }
		}

		/// <summary>
		/// permet de vérifier que le context est ok apres son initialisation
		/// </summary>
		/// <param name="newCtx">le context qui vient d'etre créé</param>
		/// <returns>True : le contexte contien bien une propriété appelé "InterceptionAppel". False sinon.</returns>
		public bool IsNewContextOK(Context newCtx)
		{
			InterceptionAppelProperty prop=newCtx.GetProperty("InterceptionAppelProperty") as InterceptionAppelProperty;
			if (prop!=null)	// on a une propriété appelé InterceptionAppel dans le contexte ?
				return true;	// Oui -> on accepte le contexte

			return false;	// Non -> on refuse le contexte
		}


		public void Freeze(Context newContext)
		{
			// ne fait rien. Pour une utilisation avancée uniquement.
		}

		#endregion

		#region Membres de IContributeServerContextSink

		/// <summary>
		/// permet de créer une nouvelle sink si besoin
		/// </summary>
		/// <param name="nextSink"></param>
		/// <returns></returns>
		public System.Runtime.Remoting.Messaging.IMessageSink GetServerContextSink(System.Runtime.Remoting.Messaging.IMessageSink nextSink)
		{
			// on créer une nouvelle sink qui va se relier à sink suivante
			IMessageSink sink=new InterceptionAppelSink(nextSink);

			// on retourne la nouvelle sink afin de l'insérer la file des sink.
			return sink;
		}

		#endregion
	}
}
