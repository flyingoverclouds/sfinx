using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SableFin.SfinX.SimplePersistance;
using System.Reflection;

namespace Sablefin.SFINx.SimplePersistanceTest
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form, IConnectionStringProvider
	{
		private System.Windows.Forms.Button cmdRead;
		private System.Windows.Forms.Button cmdUpdate;
		private System.Windows.Forms.Button cmdTestInsert;
		private System.Windows.Forms.Button cmdTestDelete;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTitleID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdNouveau;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtPubDate;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.TextBox txtYtdSales;
		private System.Windows.Forms.TextBox txtAdvance;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.TextBox txtPubID;
		private System.Windows.Forms.TextBox txtType;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtRoyalty;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button cmdTestTransaction;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtPubNom;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtPubVille;
		private System.Windows.Forms.TextBox txtPubEtat;
		private System.Windows.Forms.TextBox txtPubPays;
		private System.Windows.Forms.Button butTestIdentity;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button cmdPKDouble;
		private System.Windows.Forms.CheckBox chkTypeInfoCache;
		private System.Windows.Forms.Button butQuery;
		private System.Windows.Forms.Button cmdUpdateBench;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			this.cmdRead = new System.Windows.Forms.Button();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cmdTestInsert = new System.Windows.Forms.Button();
			this.cmdTestDelete = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtPubPays = new System.Windows.Forms.TextBox();
			this.txtPubEtat = new System.Windows.Forms.TextBox();
			this.txtPubVille = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtPubNom = new System.Windows.Forms.TextBox();
			this.txtPubDate = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtYtdSales = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtRoyalty = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAdvance = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPubID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtType = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTitleID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdNouveau = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.cmdTestTransaction = new System.Windows.Forms.Button();
			this.butTestIdentity = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.cmdPKDouble = new System.Windows.Forms.Button();
			this.chkTypeInfoCache = new System.Windows.Forms.CheckBox();
			this.butQuery = new System.Windows.Forms.Button();
			this.cmdUpdateBench = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdRead
			// 
			this.cmdRead.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdRead.Location = new System.Drawing.Point(120, 288);
			this.cmdRead.Name = "cmdRead";
			this.cmdRead.TabIndex = 2;
			this.cmdRead.Text = "Read";
			this.cmdRead.Click += new System.EventHandler(this.cmdRead_Click);
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdUpdate.Location = new System.Drawing.Point(208, 288);
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 8;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
			// 
			// cmdTestInsert
			// 
			this.cmdTestInsert.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdTestInsert.Location = new System.Drawing.Point(296, 288);
			this.cmdTestInsert.Name = "cmdTestInsert";
			this.cmdTestInsert.TabIndex = 9;
			this.cmdTestInsert.Text = "Insert";
			this.cmdTestInsert.Click += new System.EventHandler(this.cmdTestInsert_Click);
			// 
			// cmdTestDelete
			// 
			this.cmdTestDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdTestDelete.Location = new System.Drawing.Point(384, 288);
			this.cmdTestDelete.Name = "cmdTestDelete";
			this.cmdTestDelete.TabIndex = 10;
			this.cmdTestDelete.Text = "Delete";
			this.cmdTestDelete.Click += new System.EventHandler(this.cmdTestDelete_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.txtPubDate);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.txtNotes);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtYtdSales);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtRoyalty);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtAdvance);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtPrice);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtPubID);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtType);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtTitle);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtTitleID);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(576, 272);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Livre en cours";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.txtPubPays);
			this.groupBox2.Controls.Add(this.txtPubEtat);
			this.groupBox2.Controls.Add(this.txtPubVille);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.txtPubNom);
			this.groupBox2.Enabled = false;
			this.groupBox2.Location = new System.Drawing.Point(248, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(312, 104);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Publisher";
			// 
			// txtPubPays
			// 
			this.txtPubPays.Location = new System.Drawing.Point(184, 64);
			this.txtPubPays.Name = "txtPubPays";
			this.txtPubPays.Size = new System.Drawing.Size(120, 20);
			this.txtPubPays.TabIndex = 7;
			this.txtPubPays.Text = "";
			// 
			// txtPubEtat
			// 
			this.txtPubEtat.Location = new System.Drawing.Point(48, 64);
			this.txtPubEtat.Name = "txtPubEtat";
			this.txtPubEtat.TabIndex = 6;
			this.txtPubEtat.Text = "";
			// 
			// txtPubVille
			// 
			this.txtPubVille.Location = new System.Drawing.Point(48, 40);
			this.txtPubVille.Name = "txtPubVille";
			this.txtPubVille.Size = new System.Drawing.Size(256, 20);
			this.txtPubVille.TabIndex = 5;
			this.txtPubVille.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(152, 64);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(48, 16);
			this.label14.TabIndex = 4;
			this.label14.Text = "Pays :";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 64);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(40, 23);
			this.label13.TabIndex = 3;
			this.label13.Text = "Etat :";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(32, 23);
			this.label12.TabIndex = 2;
			this.label12.Text = "Ville :";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(40, 23);
			this.label11.TabIndex = 1;
			this.label11.Text = "Nom :";
			// 
			// txtPubNom
			// 
			this.txtPubNom.Location = new System.Drawing.Point(48, 16);
			this.txtPubNom.Name = "txtPubNom";
			this.txtPubNom.Size = new System.Drawing.Size(256, 20);
			this.txtPubNom.TabIndex = 0;
			this.txtPubNom.Text = "";
			// 
			// txtPubDate
			// 
			this.txtPubDate.Location = new System.Drawing.Point(72, 248);
			this.txtPubDate.Name = "txtPubDate";
			this.txtPubDate.Size = new System.Drawing.Size(176, 20);
			this.txtPubDate.TabIndex = 27;
			this.txtPubDate.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 248);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 16);
			this.label10.TabIndex = 26;
			this.label10.Text = "Pub. Date :";
			// 
			// txtNotes
			// 
			this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNotes.Location = new System.Drawing.Point(72, 224);
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(488, 20);
			this.txtNotes.TabIndex = 25;
			this.txtNotes.Text = "";
			this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 224);
			this.label9.Name = "label9";
			this.label9.TabIndex = 24;
			this.label9.Text = "Notes :";
			// 
			// txtYtdSales
			// 
			this.txtYtdSales.Location = new System.Drawing.Point(72, 200);
			this.txtYtdSales.Name = "txtYtdSales";
			this.txtYtdSales.Size = new System.Drawing.Size(128, 20);
			this.txtYtdSales.TabIndex = 23;
			this.txtYtdSales.Text = "";
			this.txtYtdSales.TextChanged += new System.EventHandler(this.txtYtdSales_TextChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 200);
			this.label8.Name = "label8";
			this.label8.TabIndex = 22;
			this.label8.Text = "Ytd Sales :";
			// 
			// txtRoyalty
			// 
			this.txtRoyalty.Location = new System.Drawing.Point(72, 176);
			this.txtRoyalty.Name = "txtRoyalty";
			this.txtRoyalty.Size = new System.Drawing.Size(128, 20);
			this.txtRoyalty.TabIndex = 21;
			this.txtRoyalty.Text = "";
			this.txtRoyalty.TextChanged += new System.EventHandler(this.txtRoyalty_TextChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 176);
			this.label7.Name = "label7";
			this.label7.TabIndex = 20;
			this.label7.Text = "Royalty :";
			// 
			// txtAdvance
			// 
			this.txtAdvance.Location = new System.Drawing.Point(72, 152);
			this.txtAdvance.Name = "txtAdvance";
			this.txtAdvance.Size = new System.Drawing.Size(128, 20);
			this.txtAdvance.TabIndex = 19;
			this.txtAdvance.Text = "";
			this.txtAdvance.TextChanged += new System.EventHandler(this.txtAdvance_TextChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 152);
			this.label6.Name = "label6";
			this.label6.TabIndex = 18;
			this.label6.Text = "Advance :";
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(72, 128);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(128, 20);
			this.txtPrice.TabIndex = 17;
			this.txtPrice.Text = "";
			this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 128);
			this.label5.Name = "label5";
			this.label5.TabIndex = 16;
			this.label5.Text = "Price :";
			// 
			// txtPubID
			// 
			this.txtPubID.Location = new System.Drawing.Point(72, 104);
			this.txtPubID.Name = "txtPubID";
			this.txtPubID.Size = new System.Drawing.Size(48, 20);
			this.txtPubID.TabIndex = 15;
			this.txtPubID.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.TabIndex = 14;
			this.label4.Text = "Pub ID :";
			// 
			// txtType
			// 
			this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtType.Location = new System.Drawing.Point(72, 80);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(488, 20);
			this.txtType.TabIndex = 13;
			this.txtType.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.TabIndex = 12;
			this.label3.Text = "Type :";
			// 
			// txtTitle
			// 
			this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTitle.Location = new System.Drawing.Point(72, 48);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(488, 20);
			this.txtTitle.TabIndex = 11;
			this.txtTitle.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "Titre du livre :";
			// 
			// txtTitleID
			// 
			this.txtTitleID.Location = new System.Drawing.Point(72, 24);
			this.txtTitleID.Name = "txtTitleID";
			this.txtTitleID.TabIndex = 8;
			this.txtTitleID.Text = "PC9999";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "ID du livre :";
			// 
			// cmdNouveau
			// 
			this.cmdNouveau.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdNouveau.Location = new System.Drawing.Point(32, 288);
			this.cmdNouveau.Name = "cmdNouveau";
			this.cmdNouveau.TabIndex = 12;
			this.cmdNouveau.Text = "Nouveau";
			this.cmdNouveau.Click += new System.EventHandler(this.cmdNouveau_Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(352, 328);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "test aggregate";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cmdTestTransaction
			// 
			this.cmdTestTransaction.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdTestTransaction.Location = new System.Drawing.Point(216, 328);
			this.cmdTestTransaction.Name = "cmdTestTransaction";
			this.cmdTestTransaction.Size = new System.Drawing.Size(104, 23);
			this.cmdTestTransaction.TabIndex = 14;
			this.cmdTestTransaction.Text = "testTransaction";
			this.cmdTestTransaction.Click += new System.EventHandler(this.cmdTestTransaction_Click);
			// 
			// butTestIdentity
			// 
			this.butTestIdentity.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.butTestIdentity.Location = new System.Drawing.Point(216, 360);
			this.butTestIdentity.Name = "butTestIdentity";
			this.butTestIdentity.Size = new System.Drawing.Size(104, 23);
			this.butTestIdentity.TabIndex = 16;
			this.butTestIdentity.Text = "test identity";
			this.butTestIdentity.Click += new System.EventHandler(this.butTestIdentity_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(352, 360);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 23);
			this.button2.TabIndex = 17;
			this.button2.Text = "test ReadMultiple";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// cmdPKDouble
			// 
			this.cmdPKDouble.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdPKDouble.Location = new System.Drawing.Point(472, 328);
			this.cmdPKDouble.Name = "cmdPKDouble";
			this.cmdPKDouble.Size = new System.Drawing.Size(96, 23);
			this.cmdPKDouble.TabIndex = 18;
			this.cmdPKDouble.Text = "test PKDouble";
			this.cmdPKDouble.Click += new System.EventHandler(this.cmdPKDouble_Click);
			// 
			// chkTypeInfoCache
			// 
			this.chkTypeInfoCache.Checked = true;
			this.chkTypeInfoCache.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTypeInfoCache.Location = new System.Drawing.Point(32, 328);
			this.chkTypeInfoCache.Name = "chkTypeInfoCache";
			this.chkTypeInfoCache.Size = new System.Drawing.Size(120, 24);
			this.chkTypeInfoCache.TabIndex = 19;
			this.chkTypeInfoCache.Text = "Use typeInfoCache";
			this.chkTypeInfoCache.CheckedChanged += new System.EventHandler(this.chkTypeInfoCache_CheckedChanged);
			// 
			// butQuery
			// 
			this.butQuery.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.butQuery.Location = new System.Drawing.Point(472, 360);
			this.butQuery.Name = "butQuery";
			this.butQuery.Size = new System.Drawing.Size(96, 23);
			this.butQuery.TabIndex = 20;
			this.butQuery.Text = "test Query";
			this.butQuery.Click += new System.EventHandler(this.butQuery_Click);
			// 
			// cmdUpdateBench
			// 
			this.cmdUpdateBench.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdUpdateBench.Location = new System.Drawing.Point(48, 360);
			this.cmdUpdateBench.Name = "cmdUpdateBench";
			this.cmdUpdateBench.Size = new System.Drawing.Size(144, 23);
			this.cmdUpdateBench.TabIndex = 21;
			this.cmdUpdateBench.Text = "Update Bench";
			this.cmdUpdateBench.Click += new System.EventHandler(this.cmdUpdateBench_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 398);
			this.Controls.Add(this.cmdUpdateBench);
			this.Controls.Add(this.butQuery);
			this.Controls.Add(this.chkTypeInfoCache);
			this.Controls.Add(this.cmdPKDouble);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.butTestIdentity);
			this.Controls.Add(this.cmdTestTransaction);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cmdNouveau);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdTestDelete);
			this.Controls.Add(this.cmdTestInsert);
			this.Controls.Add(this.cmdUpdate);
			this.Controls.Add(this.cmdRead);
			this.Name = "Form1";
			this.Text = "Test Sablefin.Persistance";
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
			Application.Run(new Form1());
		}

		private void cmdRead_Click(object sender, System.EventArgs e)
		{
			// Creation d'un object book
			titles objTestBook=new titles();

			objTestBook.title_id=txtTitleID.Text;	// j'initialise la 'clé primaire'

			// Persistance de l'obj
			PersistDAL.Read(objTestBook);			// j'utilise la méthode statis Read pour le lire dans la base 
			ResetDisplayedData(objTestBook);		// je reactulise l'affichage

		}

		private void cmdUpdate_Click(object sender, System.EventArgs e)
		{
			titles objTestBook=GetNewBookFromDisplayedData();	// je crée un objet a partir de l'affichage
			PersistDAL.Update(objTestBook);					// on persist l'objet dans la base de données via la méthode static update
		}

		private void cmdTestInsert_Click(object sender, System.EventArgs e)
		{
			titles objTestBook=GetNewBookFromDisplayedData();
			PersistDAL.Insert(objTestBook);
			ResetDisplayedData(objTestBook);	// au cas ou certain valeur serait généré automatiquement ( style compteur )
		}

		private void cmdTestDelete_Click(object sender, System.EventArgs e)
		{
			titles objTestBook = new titles();

			objTestBook.title_id=txtTitleID.Text;
			PersistDAL.Delete(objTestBook);
		}

		private void cmdNouveau_Click(object sender, System.EventArgs e)
		{
			titles b=new titles();		// reset l'affichage pour pouvoir créer un nouveau Book.
			b.pub_id="9999";
			b.pubdate=DateTime.Now;
			ResetDisplayedData(b);
		}

		
		private titles GetNewBookFromDisplayedData()
		{
			titles b=new titles();

			if (txtAdvance.BackColor==Color.Red) b.advanceISNULL=true; else b.advance=decimal.Parse(txtAdvance.Text);
			b.title_id=txtTitleID.Text;
			if (txtNotes.BackColor==Color.Red) b.notesISNULL=true; else b.notes=txtNotes.Text;
			if (txtPrice.BackColor==Color.Red) b.priceISNULL=true; else b.price=decimal.Parse(txtPrice.Text);
			b.pubdate=DateTime.Parse(txtPubDate.Text);
			if (txtPubID.BackColor==Color.Red) b.pub_idISNULL=true; else b.pub_id=txtPubID.Text;
			if (txtRoyalty.BackColor==Color.Red) b.royaltyISNULL=true; else b.royalty=int.Parse(txtRoyalty.Text);
			b.title=txtTitle.Text;
			b.type=txtType.Text;
			if (txtYtdSales.BackColor==Color.Red) b.ytd_salesISNULL=true; else b.ytd_sales=int.Parse(txtYtdSales.Text);

			
/*
			b.Editeur=new Publisher();
			b.Editeur.pub_id=b.pub_id;
			b.Editeur.pub_name=txtPubNom.Text;
			b.Editeur.city=txtPubVille.Text;
			b.Editeur.state=txtPubEtat.Text;
			b.Editeur.country=txtPubPays.Text;
*/
			return b;
		}

		private void ResetDisplayedData(titles b)
		{
			txtTitleID.Text=b.title_id;
			txtTitle.Text=b.title;
			txtAdvance.Text=b.advance.ToString();
			txtNotes.Text=b.notes;
			txtPrice.Text=b.price.ToString();
			txtPubDate.Text=b.pubdate.ToShortDateString();
			txtPubID.Text=b.pub_id;
			txtRoyalty.Text=b.royalty.ToString();
			txtType.Text=b.type;
			txtYtdSales.Text=b.ytd_sales.ToString();
			if (b.advanceISNULL) txtAdvance.BackColor=Color.Red; else txtAdvance.BackColor=Color.White;
			if (b.notesISNULL) txtNotes.BackColor=Color.Red; else txtNotes.BackColor=Color.White;;
			if (b.priceISNULL) txtPrice.BackColor=Color.Red; else txtPrice.BackColor=Color.White;;
			if (b.pub_idISNULL) txtPubID.BackColor=Color.Red; else txtPubID.BackColor=Color.White;;
			if (b.royaltyISNULL) txtRoyalty.BackColor=Color.Red; else txtRoyalty.BackColor=Color.White;;
			if (b.ytd_salesISNULL) txtYtdSales.BackColor=Color.Red; else txtYtdSales.BackColor=Color.White;;
			/*
			if (b.Editeur!=null)
			{
				txtPubNom.Text=b.Editeur.pub_name;
				txtPubVille.Text=b.Editeur.city;
				txtPubEtat.Text=b.Editeur.state;
				txtPubPays.Text=b.Editeur.country;
			}
*/
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			titles b=new titles();

			b.title_id="PC8888";
			PersistDAL.Read(b);
			//MessageBox.Show("<" + b.Editeur.pub_name +">",b.Editeur.pub_id);
		}

		private void cmdTestTransaction_Click(object sender, System.EventArgs e)
		{
			titles a=new titles();
			titles b=new titles();

			a.title_id="A";
			//PersistDAL.Read(a);

			b.title_id="B";
			//PersistDAL.Read(b);

			a.title="livre A - " + DateTime.Now.ToLongTimeString();
			b.title="libre B - " + DateTime.Now.ToLongTimeString();
/*			PersistDAL.Update(new object[] { a,b} );
			PersistDAL.Delete(new object[] { a,b } );

*/
			a.pubdate=DateTime.Now;
			b.pubdate=DateTime.Now;
			PersistDAL.Insert(new object[] { a,b });

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			PersistDAL.TypeInfoCacheEnable=chkTypeInfoCache.Checked;
			PersistDAL.ConnectionStringProvider=this;
		}

		

		private void butTestIdentity_Click(object sender, System.EventArgs e)
		{
			frmTestIdentity fti=new frmTestIdentity();
			fti.ShowDialog();
			fti.Dispose();
			fti=null;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			frmTestMultipleRead ftmr=new frmTestMultipleRead();
			ftmr.ShowDialog();
			ftmr.Dispose();
			ftmr=null;
		}

		private void cmdPKDouble_Click(object sender, System.EventArgs e)
		{
			frmTestPkDouble frm=new frmTestPkDouble();
			frm.ShowDialog();
			frm.Dispose();
			frm=null;
		}

		private void txtPrice_TextChanged(object sender, System.EventArgs e)
		{
			txtPrice.BackColor=Color.White;
		}

		private void txtAdvance_TextChanged(object sender, System.EventArgs e)
		{
			txtAdvance.BackColor=Color.White;
		}

		private void txtYtdSales_TextChanged(object sender, System.EventArgs e)
		{
			txtYtdSales.BackColor=Color.White;
		}

		private void txtNotes_TextChanged(object sender, System.EventArgs e)
		{
			txtNotes.BackColor=Color.White;
		}

		private void txtRoyalty_TextChanged(object sender, System.EventArgs e)
		{
			txtRoyalty.BackColor=Color.White;
		}

		private void chkTypeInfoCache_CheckedChanged(object sender, System.EventArgs e)
		{
			PersistDAL.TypeInfoCacheEnable=chkTypeInfoCache.Checked;
		}

		private void butQuery_Click(object sender, System.EventArgs e)
		{
			titles t=new titles();
			t.title="A";
			ArrayList alBooks=PersistDAL.Query(typeof(titles),new SQLLike(t.title));
		}
		#region Membres de IConnectionStringProvider

		public string GetConnectionString(string fullyTypeName)
		{
			MessageBox.Show("IconnectionStringProvider.GetconnectionString()");
			return @"user id=sfinxtest;password=sfinxtest;data source=nathanael\netsdk;initial catalog=pubs";
		}

		#endregion

		private void cmdUpdateBench_Click(object sender, System.EventArgs e)
		{
			int nb=50;
			int repeat=50;

			this.Cursor=Cursors.WaitCursor;
			titles[] at=new titles[nb];
			// initialisation des enreg 
			for(int n=0;n<nb;n++)
			{
				at[n]=new titles();
				at[n].pubdate=DateTime.Now;
				at[n].type="";
				at[n].title="BENCH "+n.ToString();

				at[n].title_id="B"+n.ToString();
				
				try { PersistDAL.Delete(at[n]); } 
				catch{}
			}

			DateTime timeStart=DateTime.Now;
			// insert initial
			for(int n=0;n<nb;n++)
			{
				PersistDAL.Insert(at[n]);
			}

			// sequence Read/Update sur les NB enreg, repété REPEAT fois
			for(int r=0;r<repeat;r++)
			{
				for(int n=0;n<nb;n++)
				{
					PersistDAL.Read(at[n]);
					PersistDAL.Update(at[n]);
				}
			}

			// delete final
			for(int n=0;n<nb;n++)
			{
				PersistDAL.Delete(at[n]);
			}
			DateTime timeStop=DateTime.Now;

			TimeSpan temps=timeStop-timeStart;

			this.Cursor=Cursors.Default;
			MessageBox.Show("Bench pour " + nb.ToString() + " enregistrements\r\nlu/updaté " + repeat.ToString() +" fois = \r\n\r\n" + temps.TotalMilliseconds.ToString() + " ms");

		}	

	}
}
