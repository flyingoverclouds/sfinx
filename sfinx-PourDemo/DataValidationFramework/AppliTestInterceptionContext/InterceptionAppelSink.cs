using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts;

namespace AppliTestInterceptionContext
{
	/// <summary>
	/// Class "sink" permettant d'intercepter les appels de m�thodes.
	/// Pour ce faire, elle impl�mente l'interface IMessageSink
	/// </summary>
	public class InterceptionAppelSink : IMessageSink
	{
		private IMessageSink _nextSink;

		/// <summary>
		/// Initialise la sink courante.
		/// </summary>
		/// <param name="nextSink">Sink suivante dans la file</param>
		public InterceptionAppelSink(IMessageSink nextSink)
		{
			_nextSink = nextSink;	// on memorise la 'sink' suivante
		}

		#region Membres de IMessageSink

		public IMessage SyncProcessMessage(IMessage msg)
		{
			
			// traitement � effectuer AVANT l'appel de la m�thode
			TraitementPREappel(msg);

			// on propage l'appel en cours
			IMessage returnedMessage = _nextSink.SyncProcessMessage(msg); 
      
			// traitement � effectuer APRES l'appel de la m�thode
			TraitementPOSTappel(returnedMessage);

			return returnedMessage;

		}

		public IMessageSink NextSink
		{
			get
			{
				return _nextSink;
			}
		}

		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{			
			return _nextSink.AsyncProcessMessage(msg,replySink);
		}


		#endregion

		private void TraitementPREappel(IMessage msg)
		{
			if (msg is IMethodCallMessage) frmDemoInterceptionAppel.LogInfo(" is IMethodCallMessage");
			if (msg is IMethodMessage) frmDemoInterceptionAppel.LogInfo(" is IMethodMessage");

			if (msg is IMethodCallMessage)
			{
				IMethodCallMessage mcmsg=msg as IMethodCallMessage;
				string logtxt="Appel de " + mcmsg.MethodName;
				frmDemoInterceptionAppel.LogInfo(logtxt);
			}
			else frmDemoInterceptionAppel.LogInfo("PRE :" + msg.ToString());
		}

		private void TraitementPOSTappel(IMessage msg)
		{
			frmDemoInterceptionAppel.LogInfo("  " + msg.GetType().Name);
		}
	}
}
