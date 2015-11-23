using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SableFin.SfinX.DataValidation;

namespace SableFin.DataValidationTest
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class frmDemoInterceptionAppel : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNumCde;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCodeClient;
		private System.Windows.Forms.TextBox txtCodePostal;
		private System.Windows.Forms.TextBox txtTotalHT;
		private System.Windows.Forms.Button butCreerCommande;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox lstInformation;
		private System.Windows.Forms.Button butMajCommande;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtGuid;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtNbIteration;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butRunTestClassical;
		private System.Windows.Forms.Button butRunTestContextBound;
		private System.Windows.Forms.Label lblRuningTime;
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
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butMajCommande = new System.Windows.Forms.Button();
            this.butCreerCommande = new System.Windows.Forms.Button();
            this.txtTotalHT = new System.Windows.Forms.TextBox();
            this.txtCodePostal = new System.Windows.Forms.TextBox();
            this.txtCodeClient = new System.Windows.Forms.TextBox();
            this.txtNumCde = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstInformation = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRuningTime = new System.Windows.Forms.Label();
            this.butRunTestContextBound = new System.Windows.Forms.Button();
            this.butRunTestClassical = new System.Windows.Forms.Button();
            this.txtNbIteration = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGuid);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.butMajCommande);
            this.groupBox1.Controls.Add(this.butCreerCommande);
            this.groupBox1.Controls.Add(this.txtTotalHT);
            this.groupBox1.Controls.Add(this.txtCodePostal);
            this.groupBox1.Controls.Add(this.txtCodeClient);
            this.groupBox1.Controls.Add(this.txtNumCde);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commande";
            // 
            // txtGuid
            // 
            this.txtGuid.Location = new System.Drawing.Point(40, 120);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(192, 20);
            this.txtGuid.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Guid :";
            // 
            // butMajCommande
            // 
            this.butMajCommande.Location = new System.Drawing.Point(88, 160);
            this.butMajCommande.Name = "butMajCommande";
            this.butMajCommande.Size = new System.Drawing.Size(80, 40);
            this.butMajCommande.TabIndex = 9;
            this.butMajCommande.Text = "maj Commande";
            this.butMajCommande.Click += new System.EventHandler(this.butMajCommande_Click);
            // 
            // butCreerCommande
            // 
            this.butCreerCommande.Location = new System.Drawing.Point(8, 160);
            this.butCreerCommande.Name = "butCreerCommande";
            this.butCreerCommande.Size = new System.Drawing.Size(72, 40);
            this.butCreerCommande.TabIndex = 8;
            this.butCreerCommande.Text = "nouvelle commande";
            this.butCreerCommande.Click += new System.EventHandler(this.butCreerCommande_Click);
            // 
            // txtTotalHT
            // 
            this.txtTotalHT.Location = new System.Drawing.Point(64, 96);
            this.txtTotalHT.Name = "txtTotalHT";
            this.txtTotalHT.Size = new System.Drawing.Size(168, 20);
            this.txtTotalHT.TabIndex = 7;
            // 
            // txtCodePostal
            // 
            this.txtCodePostal.Location = new System.Drawing.Point(80, 72);
            this.txtCodePostal.Name = "txtCodePostal";
            this.txtCodePostal.Size = new System.Drawing.Size(152, 20);
            this.txtCodePostal.TabIndex = 6;
            // 
            // txtCodeClient
            // 
            this.txtCodeClient.Location = new System.Drawing.Point(72, 48);
            this.txtCodeClient.Name = "txtCodeClient";
            this.txtCodeClient.Size = new System.Drawing.Size(160, 20);
            this.txtCodeClient.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCodeClient, "format : PPIIIIII : P=code pays; IIIIII=num client");
            // 
            // txtNumCde
            // 
            this.txtNumCde.Location = new System.Drawing.Point(56, 24);
            this.txtNumCde.Name = "txtNumCde";
            this.txtNumCde.Size = new System.Drawing.Size(176, 20);
            this.txtNumCde.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtNumCde, "format : AAAAMMJJNNNNNC : AAAAMMJJ=date, NNNNN=numéro jour, C=code controle");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total HT :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Code Postal :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code Client :";
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
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox2.Controls.Add(this.lstInformation);
            this.groupBox2.Location = new System.Drawing.Point(296, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 384);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informations d\'interception";
            // 
            // lstInformation
            // 
            this.lstInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lstInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInformation.ForeColor = System.Drawing.Color.Blue;
            this.lstInformation.Location = new System.Drawing.Point(16, 24);
            this.lstInformation.Name = "lstInformation";
            this.lstInformation.Size = new System.Drawing.Size(700, 342);
            this.lstInformation.TabIndex = 0;
            this.lstInformation.DoubleClick += new System.EventHandler(this.lstInformation_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblRuningTime);
            this.groupBox3.Controls.Add(this.butRunTestContextBound);
            this.groupBox3.Controls.Add(this.butRunTestClassical);
            this.groupBox3.Controls.Add(this.txtNbIteration);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(8, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 160);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PerformanceTest";
            // 
            // lblRuningTime
            // 
            this.lblRuningTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuningTime.Location = new System.Drawing.Point(16, 96);
            this.lblRuningTime.Name = "lblRuningTime";
            this.lblRuningTime.Size = new System.Drawing.Size(256, 56);
            this.lblRuningTime.TabIndex = 4;
            this.lblRuningTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butRunTestContextBound
            // 
            this.butRunTestContextBound.Location = new System.Drawing.Point(120, 48);
            this.butRunTestContextBound.Name = "butRunTestContextBound";
            this.butRunTestContextBound.Size = new System.Drawing.Size(88, 40);
            this.butRunTestContextBound.TabIndex = 3;
            this.butRunTestContextBound.Text = "Run test ContextBound";
            this.butRunTestContextBound.Click += new System.EventHandler(this.butRunTestContextBound_Click);
            // 
            // butRunTestClassical
            // 
            this.butRunTestClassical.Location = new System.Drawing.Point(16, 48);
            this.butRunTestClassical.Name = "butRunTestClassical";
            this.butRunTestClassical.Size = new System.Drawing.Size(75, 40);
            this.butRunTestClassical.TabIndex = 2;
            this.butRunTestClassical.Text = "Run test classical";
            this.butRunTestClassical.Click += new System.EventHandler(this.butRunTestClassical_Click);
            // 
            // txtNbIteration
            // 
            this.txtNbIteration.Location = new System.Drawing.Point(64, 16);
            this.txtNbIteration.Name = "txtNbIteration";
            this.txtNbIteration.Size = new System.Drawing.Size(100, 20);
            this.txtNbIteration.TabIndex = 0;
            this.txtNbIteration.Text = "1000";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Iterations :";
            // 
            // frmDemoInterceptionAppel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1028, 398);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDemoInterceptionAppel";
            this.Text = "Démo Interception d\'appel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmDemoInterceptionAppel());
		}

		private Commande cde=null;

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
			cde=new Commande();
			txtCodeClient.Text="";
			txtCodePostal.Text="";
			txtNumCde.Text="";
			txtTotalHT.Text=decimal.Zero.ToString();
			txtGuid.Text=Guid.NewGuid().ToString();
		}

		private void butMajCommande_Click(object sender, System.EventArgs e)
		{
			
			if (cde==null)
			{
				MessageBox.Show("Vous devez d'abord créer une commande !");
				return;
			}
			try
			{
				cde.CodeClient=txtCodeClient.Text;
				cde.CodePostal=txtCodePostal.Text;
				cde.Numero=txtNumCde.Text;
				cde.TotalHT=double.Parse(txtTotalHT.Text);
				cde.PrintedId=new Guid(txtGuid.Text);
				cde.DoSomething(cde.CodeClient,cde.PrintedId);
			}
			catch(DataValidationException ex)
			{
				switch(ex.ThrownByType)
				{
					case ThrownByTypeEnum.Property:
						LogInfo("La propriété " + ex.PropertyName + " n'est pas conforme à la contrainte [" + ex.Constraint.GetConstraintDetails() + "]");
						break;
					case ThrownByTypeEnum.MethodParameter:
						LogInfo("Le parametre " + ex.ParameterName + " de la méthode " + ex.MethodName + " n'est pas conforme à la contrainte [" + ex.Constraint.GetConstraintDetails() + "]");
						break;
					default:
						LogInfo("ERREUR : ");
						LogInfo("     " + ex.Message);
						break;
				}
			}
		}

		private void lstInformation_DoubleClick(object sender, System.EventArgs e)
		{
			MessageBox.Show(lstInformation.SelectedItem.ToString(),"Détail");
		}

		private void butRunTestClassical_Click(object sender, System.EventArgs e)
		{
			long maxIter=long.Parse(txtNbIteration.Text);
			PerfObjectClassical poc=null;
			DateTime start=DateTime.Now;
			for(long n=0;n<maxIter;n++)
			{
				poc=new PerfObjectClassical();
				poc.v=n;
			}
			DateTime end=DateTime.Now;
			TimeSpan duree=end-start;
			lblRuningTime.ForeColor=Color.DarkBlue;
			lblRuningTime.Text=duree.ToString();
			Application.DoEvents();
		}

		private void butRunTestContextBound_Click(object sender, System.EventArgs e)
		{
			long maxIter=long.Parse(txtNbIteration.Text);
			PerfObjectContextBounded poc=null;
			DateTime start=DateTime.Now;
			for(long n=0;n<maxIter;n++)
			{
				poc=new PerfObjectContextBounded();
				for(int i=0;i<100;i++)
					poc.v=n+i;
			}
			DateTime end=DateTime.Now;
			TimeSpan duree=end-start;
			lblRuningTime.ForeColor=Color.Orange;
			lblRuningTime.Text=duree.ToString();
			Application.DoEvents();
		}
	}
}
