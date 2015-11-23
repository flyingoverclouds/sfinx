using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SableFin.SfinX.SimplePersistance;

namespace Sablefin.SFINx.SimplePersistanceTest
{
	/// <summary>
	/// Description résumée de frmTestIdentity.
	/// </summary>
	public class frmTestIdentity : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtValeur;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butInsertIdentity;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblPKidentity;
		private System.Windows.Forms.Button cmdTestRead;
		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.Button butTestUpdate;
		private System.Windows.Forms.Button butTestDelete;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTestIdentity()
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
			this.txtValeur = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.butInsertIdentity = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lblPKidentity = new System.Windows.Forms.Label();
			this.cmdTestRead = new System.Windows.Forms.Button();
			this.txtId = new System.Windows.Forms.TextBox();
			this.butTestUpdate = new System.Windows.Forms.Button();
			this.butTestDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtValeur
			// 
			this.txtValeur.Location = new System.Drawing.Point(64, 24);
			this.txtValeur.Name = "txtValeur";
			this.txtValeur.Size = new System.Drawing.Size(208, 20);
			this.txtValeur.TabIndex = 0;
			this.txtValeur.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Valeur :";
			// 
			// butInsertIdentity
			// 
			this.butInsertIdentity.Location = new System.Drawing.Point(72, 72);
			this.butInsertIdentity.Name = "butInsertIdentity";
			this.butInsertIdentity.Size = new System.Drawing.Size(120, 23);
			this.butInsertIdentity.TabIndex = 2;
			this.butInsertIdentity.Text = "Insertion";
			this.butInsertIdentity.Click += new System.EventHandler(this.butInsertIdentity_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Clé primaire :";
			// 
			// lblPKidentity
			// 
			this.lblPKidentity.Location = new System.Drawing.Point(80, 120);
			this.lblPKidentity.Name = "lblPKidentity";
			this.lblPKidentity.Size = new System.Drawing.Size(200, 23);
			this.lblPKidentity.TabIndex = 4;
			this.lblPKidentity.Text = "000";
			// 
			// cmdTestRead
			// 
			this.cmdTestRead.Location = new System.Drawing.Point(136, 192);
			this.cmdTestRead.Name = "cmdTestRead";
			this.cmdTestRead.TabIndex = 5;
			this.cmdTestRead.Text = "test select";
			this.cmdTestRead.Click += new System.EventHandler(this.cmdTestRead_Click);
			// 
			// txtId
			// 
			this.txtId.Location = new System.Drawing.Point(32, 192);
			this.txtId.Name = "txtId";
			this.txtId.TabIndex = 6;
			this.txtId.Text = "1";
			// 
			// butTestUpdate
			// 
			this.butTestUpdate.Location = new System.Drawing.Point(136, 224);
			this.butTestUpdate.Name = "butTestUpdate";
			this.butTestUpdate.TabIndex = 7;
			this.butTestUpdate.Text = "test Update";
			this.butTestUpdate.Click += new System.EventHandler(this.butTestUpdate_Click);
			// 
			// butTestDelete
			// 
			this.butTestDelete.Location = new System.Drawing.Point(136, 256);
			this.butTestDelete.Name = "butTestDelete";
			this.butTestDelete.TabIndex = 8;
			this.butTestDelete.Text = "test Delete";
			this.butTestDelete.Click += new System.EventHandler(this.butTestDelete_Click);
			// 
			// frmTestIdentity
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 334);
			this.Controls.Add(this.butTestDelete);
			this.Controls.Add(this.butTestUpdate);
			this.Controls.Add(this.txtId);
			this.Controls.Add(this.cmdTestRead);
			this.Controls.Add(this.lblPKidentity);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.butInsertIdentity);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtValeur);
			this.Name = "frmTestIdentity";
			this.Text = "frmTestIdentity";
			this.ResumeLayout(false);

		}
		#endregion

		private void butInsertIdentity_Click(object sender, System.EventArgs e)
		{
			ObjWithIdentityPK t=new ObjWithIdentityPK();
			t.Nom=txtValeur.Text;
			SableFin.SfinX.SimplePersistance.PersistDAL.Insert(t);
			lblPKidentity.Text=t.Identity.ToString();
		
		}

		private void cmdTestRead_Click(object sender, System.EventArgs e)
		{
			ObjWithIdentityPK t=new ObjWithIdentityPK();
			t.Identity=short.Parse(txtId.Text);
			SableFin.SfinX.SimplePersistance.PersistDAL.Read(t);
			txtValeur.Text=t.Nom;
		}

		private void butTestUpdate_Click(object sender, System.EventArgs e)
		{
			ObjWithIdentityPK t=new ObjWithIdentityPK();
			t.Identity=short.Parse(txtId.Text);
			PersistDAL.Read(t);
			t.Nom=txtValeur.Text;
			PersistDAL.Update(t);
		
		}

		private void butTestDelete_Click(object sender, System.EventArgs e)
		{
			ObjWithIdentityPK t=new ObjWithIdentityPK();
			t.Identity=short.Parse(txtId.Text);
			PersistDAL.Delete(t);
		}
	}
}
