using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sablefin.SFINx.Forms
{
	public class OpacityEffectForm : Sablefin.SFINx.Forms.EffectForms
	{
		private System.ComponentModel.IContainer components = null;

		public OpacityEffectForm()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO�: ajoutez les initialisations apr�s l'appel � InitializeComponent
		}

		/// <summary>
		/// Nettoyage des ressources utilis�es.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code g�n�r� par le concepteur
		/// <summary>
		/// M�thode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette m�thode avec l'�diteur de code.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// OpacityEffectForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 136);
			this.EffectTime = 800;
			this.Name = "OpacityEffectForm";
			this.Text = "Opacity Effect";

		}
		#endregion
	}
}

