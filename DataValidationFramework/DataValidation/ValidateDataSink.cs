using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts;
using System.Collections;
using System.Reflection;

namespace SableFin.SfinX.DataValidation
{
	/// <summary>
	/// Class "sink" permettant d'intercepter les appels pour les vérification de validité/format des données.
	/// Pour ce faire, elle implémente l'interface IMEssageSing
	/// </summary>
	public class ValidateDataSink : IMessageSink
	{
		private IMessageSink _nextSink;

		/// <summary>
		/// Initialise la sink courante.
		/// </summary>
		/// <param name="nextSink">Sink suivante dans la file</param>
		public ValidateDataSink(IMessageSink nextSink)
		{
			_nextSink = nextSink;	// on memorise la 'sink' suivante
		}

		#region Membres de IMessageSink

		public IMessage SyncProcessMessage(IMessage msg)
		{
			// traitement à effectuer AVANT l'appel
			TraitementPREappel(msg);

			// on propage l'appel en cours
			IMessage returnedMessage = _nextSink.SyncProcessMessage(msg); 

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
			if (msg is IMethodCallMessage)
			{
				#region Traitement d'un IMethodCallMessage

				object[] tabat=null;	// contiendra le tableau d'attribut
				IMethodCallMessage mcmsg=msg as IMethodCallMessage;

				if (mcmsg.MethodBase.IsSpecialName && mcmsg.MethodName.StartsWith("set_"))	// propriété ?
				{
					#region Appel d'une propriété
					// recupération du nom de lapropriété
					string pname=mcmsg.MethodName.Substring(4,mcmsg.MethodName.Length-4);
					
					// recupération des attributs posés sur cette propriété
					tabat=mcmsg.MethodBase.ReflectedType.GetProperty(pname).GetCustomAttributes(typeof(IDataValidationConstraint),false);
					foreach(IDataValidationConstraint chkatt in tabat)
					{
						if (!chkatt.DoCheck(mcmsg.GetArg(0))) // pour le setter d'une propriété : un seul param : value
						{
							string errMsg = "DataValidation failed on " + mcmsg.MethodBase.ReflectedType.Name + "." + pname + "\r\n";
							errMsg += "property value : " + chkatt.GetValidationFailureMessage();
							throw new DataValidationException(errMsg,pname,chkatt);
						}
					}
					#endregion
				}
				else
				{
					#region Appel d'une fonction
					ParameterInfo[] pi=mcmsg.MethodBase.GetParameters(); // on recupere la liste des parametres de la méthode
					for(int pin=0;pin<pi.Length;pin++)	// on vérifie les attributs posé sur chaque parametre
					{
						tabat=pi[pin].GetCustomAttributes(typeof(IDataValidationConstraint),false); // on recupère les attributs du paramètre
						foreach(IDataValidationConstraint chkatt in tabat)
						{
							if (!chkatt.DoCheck(mcmsg.GetArg(pin)))
							{
								string errMsg = "DataValidation failed on " + mcmsg.MethodBase.ReflectedType.Name + "." + mcmsg.MethodBase.Name + "\r\n";
								errMsg += "parameter " + pi[pin].Name + " : " + chkatt.GetValidationFailureMessage();
								throw new DataValidationException(errMsg,mcmsg.MethodBase.Name,pi[pin].Name,chkatt);
							}
						}
					}
					#endregion
				}
				#endregion
			} 
		}
	}
}
