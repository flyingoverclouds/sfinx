using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace Sablefin.SFINx.StoredProcCreator
{
	/// <summary>
	/// Description résumée de AboutForm.
	/// </summary>
	public class AboutForm : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TextBox txtAbout;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AboutForm()
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
			this.txtAbout = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtAbout
			// 
			this.txtAbout.Location = new System.Drawing.Point(8, 8);
			this.txtAbout.Multiline = true;
			this.txtAbout.Name = "txtAbout";
			this.txtAbout.Size = new System.Drawing.Size(360, 240);
			this.txtAbout.TabIndex = 0;
			this.txtAbout.Text = "txtInfo";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(272, 248);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "&Ok";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 278);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtAbout);
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AboutForm";
			this.Load += new System.EventHandler(this.AboutForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void AboutForm_Load(object sender, System.EventArgs e)
		{
			Assembly exe = Assembly.GetEntryAssembly();

			txtAbout.Text+=exe.ToString() + "\r\n";
			txtAbout.Text+="running on CLR " +  exe.ImageRuntimeVersion + "\r\n";
			foreach(Attribute attr in exe.GetCustomAttributes(false))
			{
				if (attr is AssemblyTitleAttribute)
					txtAbout.Text+=((AssemblyTitleAttribute)attr).Title+ "\r\n";
				else if (attr is AssemblyVersionAttribute)
					txtAbout.Text+=((AssemblyVersionAttribute)attr).Version+ "\r\n";
				else if (attr is AssemblyCompanyAttribute)
					txtAbout.Text+= ((AssemblyCompanyAttribute)attr).Company+ "\r\n";
				else if (attr is AssemblyCopyrightAttribute)
					txtAbout.Text+= ((AssemblyCopyrightAttribute)attr).Copyright+ "\r\n";
				else if (attr is AssemblyTrademarkAttribute)
					txtAbout.Text+= ((AssemblyTrademarkAttribute)attr).Trademark+ "\r\n";
				else if (attr is AssemblyProductAttribute)
					txtAbout.Text+= ((AssemblyProductAttribute)attr).Product+ "\r\n";

			}		
		}

		


	}
}
