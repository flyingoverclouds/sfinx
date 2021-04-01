using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace SableFin.SfinX.DataValidation
{
	/// <summary>
	/// Description résumée de DataValidationProperty.
	/// </summary>
	public class DataValidationProperty : IContextProperty, IContributeServerContextSink
	{
		public DataValidationProperty()
		{
		}
		#region Membres de IContextProperty

		public string Name
		{
			get { return "DataValidation"; }
		}

		/// <summary>
		/// permet de vérifier que le context est ok apres son initialisation
		/// </summary>
		/// <param name="newCtx">le context qui vient d'etre créé</param>
		/// <returns>True : le contexte contient bien une propriété appelé "ValidationData". False sinon.</returns>
		public bool IsNewContextOK(Context newCtx)
		{
			DataValidationProperty prop=newCtx.GetProperty("DataValidation") as DataValidationProperty;
			if (prop!=null)	// on a une propriété appelé ValidationData dans le contexte ?
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
		/// <param name="nextSink">sink suivante à memorise</param>
		/// <returns>la nouvelle sink</returns>
		public System.Runtime.Remoting.Messaging.IMessageSink GetServerContextSink(System.Runtime.Remoting.Messaging.IMessageSink nextSink)
		{
			// on créer une nouvelle sink qui va se relier à sink suivante
			IMessageSink sink=new ValidateDataSink(nextSink);

			// on retourne la nouvelle sink afin de l'insérer la file des sink.
			return sink;
		}

		#endregion
	}
}
