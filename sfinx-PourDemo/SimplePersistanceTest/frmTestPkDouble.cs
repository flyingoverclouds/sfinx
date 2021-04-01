using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SableFin.SfinX.SimplePersistance;

namespace Sablefin.SFINx.SimplePersistanceTest
{
	/// <summary>
	/// Description résumée de frmTestPkDouble.
	/// </summary>
	public class frmTestPkDouble : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdInsert;
		private System.Windows.Forms.Button cmdSelect;
		private System.Windows.Forms.Button cmdUpdate;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.TextBox txtID1;
		private System.Windows.Forms.TextBox txtID2;
		private System.Windows.Forms.TextBox txtDonnee;
		private System.Windows.Forms.Button cmdResetScreen;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTestPkDouble()
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
			this.cmdInsert = new System.Windows.Forms.Button();
			this.cmdSelect = new System.Windows.Forms.Button();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.txtID1 = new System.Windows.Forms.TextBox();
			this.txtID2 = new System.Windows.Forms.TextBox();
			this.txtDonnee = new System.Windows.Forms.TextBox();
			this.cmdResetScreen = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmdInsert
			// 
			this.cmdInsert.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdInsert.Location = new System.Drawing.Point(40, 88);
			this.cmdInsert.Name = "cmdInsert";
			this.cmdInsert.TabIndex = 0;
			this.cmdInsert.Text = "Insert";
			this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
			// 
			// cmdSelect
			// 
			this.cmdSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdSelect.Location = new System.Drawing.Point(40, 120);
			this.cmdSelect.Name = "cmdSelect";
			this.cmdSelect.TabIndex = 1;
			this.cmdSelect.Text = "Select";
			this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdUpdate.Location = new System.Drawing.Point(40, 152);
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 2;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdDelete.Location = new System.Drawing.Point(40, 184);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 3;
			this.cmdDelete.Text = "Delete";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// txtID1
			// 
			this.txtID1.Location = new System.Drawing.Point(16, 16);
			this.txtID1.Name = "txtID1";
			this.txtID1.Size = new System.Drawing.Size(72, 20);
			this.txtID1.TabIndex = 4;
			this.txtID1.Text = "";
			// 
			// txtID2
			// 
			this.txtID2.Location = new System.Drawing.Point(104, 16);
			this.txtID2.Name = "txtID2";
			this.txtID2.Size = new System.Drawing.Size(72, 20);
			this.txtID2.TabIndex = 5;
			this.txtID2.Text = "";
			// 
			// txtDonnee
			// 
			this.txtDonnee.Location = new System.Drawing.Point(16, 48);
			this.txtDonnee.Name = "txtDonnee";
			this.txtDonnee.Size = new System.Drawing.Size(200, 20);
			this.txtDonnee.TabIndex = 6;
			this.txtDonnee.Text = "";
			// 
			// cmdResetScreen
			// 
			this.cmdResetScreen.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdResetScreen.Location = new System.Drawing.Point(160, 88);
			this.cmdResetScreen.Name = "cmdResetScreen";
			this.cmdResetScreen.Size = new System.Drawing.Size(104, 23);
			this.cmdResetScreen.TabIndex = 7;
			this.cmdResetScreen.Text = "reset Screen";
			this.cmdResetScreen.Click += new System.EventHandler(this.cmdResetScreen_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(168, 144);
			this.button1.Name = "button1";
			this.button1.TabIndex = 8;
			this.button1.Text = "lafuma";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmTestPkDouble
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cmdResetScreen);
			this.Controls.Add(this.txtDonnee);
			this.Controls.Add(this.txtID2);
			this.Controls.Add(this.txtID1);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdUpdate);
			this.Controls.Add(this.cmdSelect);
			this.Controls.Add(this.cmdInsert);
			this.Name = "frmTestPkDouble";
			this.Text = "frmTestPkDouble";
			this.ResumeLayout(false);

		}
		#endregion

		void FillObjectFromScreen(PKDouble pkd)
		{
			pkd.id1=int.Parse(txtID1.Text);
			pkd.id2=short.Parse(txtID2.Text);
			pkd.donnee=txtDonnee.Text;
		}

		void FillScreenFromObject(PKDouble pkd)
		{
			txtID1.Text=pkd.id1.ToString();
			txtID2.Text=pkd.id2.ToString();
			txtDonnee.Text=pkd.donnee;
		}

		private void cmdInsert_Click(object sender, System.EventArgs e)
		{
			PKDouble pkd=new PKDouble();
			FillObjectFromScreen(pkd);
			PersistDAL.Insert(pkd);
			FillScreenFromObject(pkd);
		}

		private void cmdSelect_Click(object sender, System.EventArgs e)
		{
			PKDouble pkd=new PKDouble();
			FillObjectFromScreen(pkd);
			PersistDAL.Read(pkd);
			FillScreenFromObject(pkd);
		}

		private void cmdUpdate_Click(object sender, System.EventArgs e)
		{
			PKDouble pkd=new PKDouble();
			FillObjectFromScreen(pkd);
			PersistDAL.Update(pkd);
			FillScreenFromObject(pkd);
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			PKDouble pkd=new PKDouble();
			FillObjectFromScreen(pkd);
			PersistDAL.Delete(pkd);
			txtID1.Text="";
			txtID2.Text="";
			txtDonnee.Text="";
		}

		private void cmdResetScreen_Click(object sender, System.EventArgs e)
		{
			txtID1.Text="";
			txtID2.Text="";
			txtDonnee.Text="";
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Adresse adr=new Adresse();
			adr.ADR_SITE_ID=1;
			adr.ADR_CLIE_ID=6;
			PersistDAL.Read(adr);
			MessageBox.Show(adr.ADR_NOM);
		}
	}
}
