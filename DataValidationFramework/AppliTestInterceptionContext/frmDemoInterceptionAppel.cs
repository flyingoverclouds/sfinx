using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AppliTestInterceptionContext
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class frmDemoInterceptionAppel : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNumCde;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butCreerCommande;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox lstInformation;
		private System.Windows.Forms.Button butMajCommande;
		private System.Windows.Forms.Button butAppelMethode;
		private System.ComponentModel.IContainer components;

		public frmDemoInterceptionAppel()
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
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.butAppelMethode = new System.Windows.Forms.Button();
			this.butMajCommande = new System.Windows.Forms.Button();
			this.butCreerCommande = new System.Windows.Forms.Button();
			this.txtNumCde = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstInformation = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.butAppelMethode);
			this.groupBox1.Controls.Add(this.butMajCommande);
			this.groupBox1.Controls.Add(this.butCreerCommande);
			this.groupBox1.Controls.Add(this.txtNumCde);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 104);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ObjetDemo";
			// 
			// butAppelMethode
			// 
			this.butAppelMethode.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.butAppelMethode.Location = new System.Drawing.Point(152, 56);
			this.butAppelMethode.Name = "butAppelMethode";
			this.butAppelMethode.Size = new System.Drawing.Size(75, 40);
			this.butAppelMethode.TabIndex = 10;
			this.butAppelMethode.Text = "appel DoSomething2";
			this.butAppelMethode.Click += new System.EventHandler(this.butAppelMethode_Click);
			// 
			// butMajCommande
			// 
			this.butMajCommande.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.butMajCommande.Location = new System.Drawing.Point(80, 56);
			this.butMajCommande.Name = "butMajCommande";
			this.butMajCommande.Size = new System.Drawing.Size(72, 40);
			this.butMajCommande.TabIndex = 9;
			this.butMajCommande.Text = "maj prop";
			this.butMajCommande.Click += new System.EventHandler(this.butMajCommande_Click);
			// 
			// butCreerCommande
			// 
			this.butCreerCommande.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.butCreerCommande.Location = new System.Drawing.Point(8, 56);
			this.butCreerCommande.Name = "butCreerCommande";
			this.butCreerCommande.Size = new System.Drawing.Size(72, 40);
			this.butCreerCommande.TabIndex = 8;
			this.butCreerCommande.Text = "nouveaux";
			this.butCreerCommande.Click += new System.EventHandler(this.butCreerCommande_Click);
			// 
			// txtNumCde
			// 
			this.txtNumCde.Location = new System.Drawing.Point(56, 24);
			this.txtNumCde.Name = "txtNumCde";
			this.txtNumCde.Size = new System.Drawing.Size(176, 20);
			this.txtNumCde.TabIndex = 0;
			this.txtNumCde.Text = "";
			this.toolTip1.SetToolTip(this.txtNumCde, "format : AAAAMMJJNNNNNC : AAAAMMJJ=date, NNNNN=numéro jour, C=code controle");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Numéro :";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox2.Controls.Add(this.lstInformation);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(296, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(376, 352);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Informations d\'interception";
			// 
			// lstInformation
			// 
			this.lstInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lstInformation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.lstInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lstInformation.ForeColor = System.Drawing.Color.Blue;
			this.lstInformation.Location = new System.Drawing.Point(16, 24);
			this.lstInformation.Name = "lstInformation";
			this.lstInformation.Size = new System.Drawing.Size(352, 316);
			this.lstInformation.TabIndex = 0;
			this.lstInformation.DoubleClick += new System.EventHandler(this.lstInformation_DoubleClick);
			this.lstInformation.SelectedIndexChanged += new System.EventHandler(this.lstInformation_SelectedIndexChanged);
			// 
			// frmDemoInterceptionAppel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 366);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmDemoInterceptionAppel";
			this.Text = "Démo Interception d\'appel";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new frmDemoInterceptionAppel());
		}

		private ObjetDemo objdemo=null;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			lst=lstInformation;
		}

		private static ListBox lst=null;

		public static void LogInfo(string msg)
		{
			if (lst==null) return;
			lst.Items.Add(msg);
		}

		private void butCreerCommande_Click(object sender, System.EventArgs e)
		{
			objdemo=new ObjetDemo();
			txtNumCde.Text="";
		}

		private void butMajCommande_Click(object sender, System.EventArgs e)
		{
			if (objdemo==null)
			{
				MessageBox.Show("Vous devez d'abord créer un objet !");
				return;
			}
			objdemo.Numero=txtNumCde.Text;
			objdemo.DoSomething("12345");
		}

		private void lstInformation_DoubleClick(object sender, System.EventArgs e)
		{
			if (lstInformation.SelectedItem==null) return;
			MessageBox.Show(lstInformation.SelectedItem.ToString(),"Détail");
		}

		private void butAppelMethode_Click(object sender, System.EventArgs e)
		{
			if (objdemo==null)
			{
				MessageBox.Show("Vous devez d'abord créer un objet !");
				return;
			}
			objdemo.Numero=txtNumCde.Text;
			LogInfo("");
			ObjetDemo dem=objdemo.DoSomething2();
			LogInfo("Numero=" + dem.Numero.ToString());;
		}

		private void lstInformation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
