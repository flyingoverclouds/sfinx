using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace SableFin.SfinX.DataValidation
{
	/// <summary>
	/// Description r�sum�e de DataValidationProperty.
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
		/// permet de v�rifier que le context est ok apres son initialisation
		/// </summary>
		/// <param name="newCtx">le context qui vient d'etre cr��</param>
		/// <returns>True : le contexte contient bien une propri�t� appel� "ValidationData". False sinon.</returns>
		public bool IsNewContextOK(Context newCtx)
		{
			DataValidationProperty prop=newCtx.GetProperty("DataValidation") as DataValidationProperty;
			if (prop!=null)	// on a une propri�t� appel� ValidationData dans le contexte ?
				return true;	// Oui -> on accepte le contexte

			return false;	// Non -> on refuse le contexte
		}


		public void Freeze(Context newContext)
		{
			// ne fait rien. Pour une utilisation avanc�e uniquement.
		}

		#endregion

		#region Membres de IContributeServerContextSink

		/// <summary>
		/// permet de cr�er une nouvelle sink si besoin
		/// </summary>
		/// <param name="nextSink">sink suivante � memorise</param>
		/// <returns>la nouvelle sink</returns>
		public System.Runtime.Remoting.Messaging.IMessageSink GetServerContextSink(System.Runtime.Remoting.Messaging.IMessageSink nextSink)
		{
			// on cr�er une nouvelle sink qui va se relier � sink suivante
			IMessageSink sink=new ValidateDataSink(nextSink);

			// on retourne la nouvelle sink afin de l'ins�rer la file des sink.
			return sink;
		}

		#endregion
	}
}
