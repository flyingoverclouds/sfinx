using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sablefin.SFINx.Forms
{
	/// <summary>
	/// Implémente une fors avec des effet d'apparition/disparition
	/// </summary>
	public class EffectForms : System.Windows.Forms.Form
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EffectForms()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// EffectForms
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Red;
			this.ClientSize = new System.Drawing.Size(354, 136);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EffectForms";
			this.ShowInTaskbar = false;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.EffectForms_Closing);
			this.Load += new System.EventHandler(this.EffectForms_Load);

		}
		#endregion


#region Effect Code
		protected int p_showSlice=50; // en ms entre chaque étape de l'apparition
		public int ShowSlice
		{
			get { return p_showSlice; }
			set { p_showSlice=value; }
		}

		protected int p_hideSlice=50; // en ms entre chaque étape de la disparition
		public int HideSlice
		{
			get { return p_hideSlice; }
			set { p_hideSlice=value; }
		}

		protected int p_effectTime=1000;	// temps en ms que dure l'effet apparition/disparition
		public int EffectTime
		{
			get { return p_effectTime; }
			set { p_effectTime=value; }
		}

		System.Threading.Thread trdEffect=null;


		private Size finalSize;
		private Point finalLocation;
				
		/// <summary>
		/// initialise la mécanique des effets d'apparition/disparition
		/// </summary>
		protected void InitEffect()
		{
			HideSlice=50;	
			ShowSlice=50;
			EffectTime=800;	
			finalSize=this.Size;
			finalLocation=this.Location;
			//Size=new Size(finalSize.Width,0);
			Opacity=0;
		}

		/// <summary>
		/// declenche le début de l'appartion de la fenetre
		/// </summary>
		public void StartShowing()
		{
			trdEffect=new System.Threading.Thread(new System.Threading.ThreadStart(DoShowing));
			trdEffect.IsBackground=true;
			trdEffect.Start();

		}

		/// <summary>
		/// function qui gere l'apparition de la fenetre
		/// </summary>
		protected void DoShowing()
		{
			int nb=EffectTime/ShowSlice;
			for(int n=0;n<nb;n++)
			{
				// pour un deroulement du bas de la fenetre
				//this.Size=new Size(finalSize.Width,finalSize.Height*n/nb); 
				//this.Refresh();

				// pour un deroulement style MSN msgr
				//this.Size=new Size(finalSize.Width,finalSize.Height*n/nb); 
				//this.Location=new Point(finalLocation.X,finalLocation.Y+finalSize.Height-(finalSize.Height*n/nb));
				//this.Refresh();

				// pour l'opacité
				this.Opacity=(n*1.0)/(1.0*nb);

				System.Threading.Thread.Sleep(ShowSlice);	// on fait la pause
			}
			//this.Size=finalSize;
			//this.Location=finalLocation;
			this.Opacity=1;
			
		}

		/// <summary>
		/// declenche le debut de la disparition de la fenetre
		/// </summary>
		public void StartHiding()
		{
			DoHiding();
		}

		/// <summary>
		/// fonction qui gere la disparition de la fenetre.
		/// </summary>
		protected void DoHiding()
		{
			int nb=EffectTime/ShowSlice;
			for(int n=nb;n>0;n--)
			{
				// pour un deroulement du bas de la fenetre
				//this.Size=new Size(finalSize.Width,finalSize.Height*n/nb); 

				// pour un deroulement style MSN msgr
				//this.Size=new Size(finalSize.Width,finalSize.Height*n/nb); 
				//this.Location=new Point(finalLocation.X,finalLocation.Y+finalSize.Height-(finalSize.Height*n/nb));

				// pour une transparence
				this.Opacity=(1.0*n)/(1.0*nb);

				System.Threading.Thread.Sleep(ShowSlice);	// on fait la pause
			}
		}

#endregion

		private void EffectForms_Load(object sender, System.EventArgs e)
		{
			InitEffect();
			StartShowing();
		}

		private void EffectForms_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{


			StartHiding();
		}
	}
}
