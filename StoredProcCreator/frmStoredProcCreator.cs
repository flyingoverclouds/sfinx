using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Sablefin.SFINx.StoredProcCreator
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class frmStoredProcCreator : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdConnect;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSqlUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSqlPassword;
		private System.Windows.Forms.TreeView trvSqlServerSchema;
		private System.Windows.Forms.Button cmdAbout;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cmdCreateSelect;
		private System.Windows.Forms.Button cmdCreateUpdate;
		private System.Windows.Forms.Button cmdCreateInsert;
		private System.Windows.Forms.Button cmdCreateDelete;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblHelp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabStoredProc;
		private System.Windows.Forms.TabPage tabPersistClasses;
		private System.Windows.Forms.TextBox txtSQL;
		private System.Windows.Forms.Label labelHelp5;
		private System.Windows.Forms.CheckBox ckbNTAuth;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cboLanguage;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtClass;
		private System.Windows.Forms.TextBox txtBase;
		private System.Windows.Forms.Label lblBase;
		private System.Windows.Forms.CheckBox chkMakeFile;
		private System.Windows.Forms.TextBox txtDirCls;
		private System.Windows.Forms.Button btnParcourir;
		private System.Windows.Forms.TreeView trvTableColumns;
		private System.Windows.Forms.TextBox txtPrefix;
		private System.Windows.Forms.CheckBox ckbUsePrefix;
		private System.Windows.Forms.CheckBox chkTestMode;
		private System.Windows.Forms.ToolTip ttipStoredProcCreator;
		private System.Windows.Forms.ComboBox cboPDSA;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cboCnxStrIn;
		private System.ComponentModel.IContainer components;

		public frmStoredProcCreator()
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdConnect = new System.Windows.Forms.Button();
			this.trvSqlServerSchema = new System.Windows.Forms.TreeView();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSqlUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSqlPassword = new System.Windows.Forms.TextBox();
			this.cmdAbout = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkTestMode = new System.Windows.Forms.CheckBox();
			this.txtPrefix = new System.Windows.Forms.TextBox();
			this.ckbUsePrefix = new System.Windows.Forms.CheckBox();
			this.cmdCreateDelete = new System.Windows.Forms.Button();
			this.cmdCreateInsert = new System.Windows.Forms.Button();
			this.cmdCreateUpdate = new System.Windows.Forms.Button();
			this.cmdCreateSelect = new System.Windows.Forms.Button();
			this.txtSQL = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblHelp = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.labelHelp5 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabStoredProc = new System.Windows.Forms.TabPage();
			this.tabPersistClasses = new System.Windows.Forms.TabPage();
			this.cboCnxStrIn = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cboPDSA = new System.Windows.Forms.ComboBox();
			this.btnParcourir = new System.Windows.Forms.Button();
			this.txtDirCls = new System.Windows.Forms.TextBox();
			this.chkMakeFile = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtClass = new System.Windows.Forms.TextBox();
			this.cboLanguage = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ckbNTAuth = new System.Windows.Forms.CheckBox();
			this.txtBase = new System.Windows.Forms.TextBox();
			this.lblBase = new System.Windows.Forms.Label();
			this.trvTableColumns = new System.Windows.Forms.TreeView();
			this.ttipStoredProcCreator = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabStoredProc.SuspendLayout();
			this.tabPersistClasses.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtServerName
			// 
			this.txtServerName.Location = new System.Drawing.Point(104, 8);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.Size = new System.Drawing.Size(184, 20);
			this.txtServerName.TabIndex = 1;
			this.txtServerName.Text = ((string)(configurationAppSettings.GetValue("SQLServeurName.Text", typeof(string))));
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "SQLServer Name :";
			// 
			// cmdConnect
			// 
			this.cmdConnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdConnect.Location = new System.Drawing.Point(296, 8);
			this.cmdConnect.Name = "cmdConnect";
			this.cmdConnect.Size = new System.Drawing.Size(75, 32);
			this.cmdConnect.TabIndex = 3;
			this.cmdConnect.Text = "Connect to SQLServer";
			this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
			// 
			// trvSqlServerSchema
			// 
			this.trvSqlServerSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.trvSqlServerSchema.FullRowSelect = true;
			this.trvSqlServerSchema.HotTracking = true;
			this.trvSqlServerSchema.ImageIndex = -1;
			this.trvSqlServerSchema.Location = new System.Drawing.Point(8, 136);
			this.trvSqlServerSchema.Name = "trvSqlServerSchema";
			this.trvSqlServerSchema.SelectedImageIndex = -1;
			this.trvSqlServerSchema.Size = new System.Drawing.Size(200, 464);
			this.trvSqlServerSchema.TabIndex = 4;
			this.trvSqlServerSchema.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvSqlServerSchema_AfterSelect);
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.TabIndex = 5;
			this.label2.Text = "SQL User :";
			// 
			// txtSqlUser
			// 
			this.txtSqlUser.Enabled = false;
			this.txtSqlUser.Location = new System.Drawing.Point(104, 32);
			this.txtSqlUser.Name = "txtSqlUser";
			this.txtSqlUser.Size = new System.Drawing.Size(184, 20);
			this.txtSqlUser.TabIndex = 6;
			this.txtSqlUser.Text = ((string)(configurationAppSettings.GetValue("SQLUser.Text", typeof(string))));
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(8, 56);
			this.label3.Name = "label3";
			this.label3.TabIndex = 7;
			this.label3.Text = "SQL Password";
			// 
			// txtSqlPassword
			// 
			this.txtSqlPassword.Enabled = false;
			this.txtSqlPassword.Location = new System.Drawing.Point(104, 56);
			this.txtSqlPassword.Name = "txtSqlPassword";
			this.txtSqlPassword.PasswordChar = '*';
			this.txtSqlPassword.Size = new System.Drawing.Size(184, 20);
			this.txtSqlPassword.TabIndex = 8;
			this.txtSqlPassword.Text = ((string)(configurationAppSettings.GetValue("SQLPassword.Text", typeof(string))));
			// 
			// cmdAbout
			// 
			this.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdAbout.Location = new System.Drawing.Point(296, 48);
			this.cmdAbout.Name = "cmdAbout";
			this.cmdAbout.Size = new System.Drawing.Size(72, 32);
			this.cmdAbout.TabIndex = 10;
			this.cmdAbout.Text = "About";
			this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkTestMode);
			this.groupBox1.Controls.Add(this.txtPrefix);
			this.groupBox1.Controls.Add(this.ckbUsePrefix);
			this.groupBox1.Controls.Add(this.cmdCreateDelete);
			this.groupBox1.Controls.Add(this.cmdCreateInsert);
			this.groupBox1.Controls.Add(this.cmdCreateUpdate);
			this.groupBox1.Controls.Add(this.cmdCreateSelect);
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 232);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "create Stored Proc";
			// 
			// chkTestMode
			// 
			this.chkTestMode.Checked = true;
			this.chkTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTestMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkTestMode.Location = new System.Drawing.Point(8, 72);
			this.chkTestMode.Name = "chkTestMode";
			this.chkTestMode.Size = new System.Drawing.Size(120, 24);
			this.chkTestMode.TabIndex = 6;
			this.chkTestMode.Text = "TEST Mode";
			this.ttipStoredProcCreator.SetToolTip(this.chkTestMode, "Database are never updated when TEST mode is activated. Uncheck it for updating d" +
				"atabase.");
			// 
			// txtPrefix
			// 
			this.txtPrefix.Enabled = false;
			this.txtPrefix.Location = new System.Drawing.Point(24, 40);
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Size = new System.Drawing.Size(104, 20);
			this.txtPrefix.TabIndex = 5;
			this.txtPrefix.Text = "dbo";
			// 
			// ckbUsePrefix
			// 
			this.ckbUsePrefix.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ckbUsePrefix.Location = new System.Drawing.Point(8, 16);
			this.ckbUsePrefix.Name = "ckbUsePrefix";
			this.ckbUsePrefix.Size = new System.Drawing.Size(120, 24);
			this.ckbUsePrefix.TabIndex = 4;
			this.ckbUsePrefix.Text = "Use prefix";
			this.ttipStoredProcCreator.SetToolTip(this.ckbUsePrefix, "If checked, stored proc are generated using the defined prefix.");
			this.ckbUsePrefix.CheckedChanged += new System.EventHandler(this.ckbUsePrefix_CheckedChanged);
			// 
			// cmdCreateDelete
			// 
			this.cmdCreateDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCreateDelete.Location = new System.Drawing.Point(8, 200);
			this.cmdCreateDelete.Name = "cmdCreateDelete";
			this.cmdCreateDelete.Size = new System.Drawing.Size(128, 23);
			this.cmdCreateDelete.TabIndex = 3;
			this.cmdCreateDelete.Text = "Delete";
			this.ttipStoredProcCreator.SetToolTip(this.cmdCreateDelete, "Click here to create the DELETE stored procedure.");
			this.cmdCreateDelete.Click += new System.EventHandler(this.cmdCreateDelete_Click);
			// 
			// cmdCreateInsert
			// 
			this.cmdCreateInsert.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCreateInsert.Location = new System.Drawing.Point(8, 168);
			this.cmdCreateInsert.Name = "cmdCreateInsert";
			this.cmdCreateInsert.Size = new System.Drawing.Size(128, 23);
			this.cmdCreateInsert.TabIndex = 2;
			this.cmdCreateInsert.Text = "Insert";
			this.ttipStoredProcCreator.SetToolTip(this.cmdCreateInsert, "Click here to create the INSERT stored procedure.");
			this.cmdCreateInsert.Click += new System.EventHandler(this.cmdCreateInsert_Click);
			// 
			// cmdCreateUpdate
			// 
			this.cmdCreateUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCreateUpdate.Location = new System.Drawing.Point(8, 136);
			this.cmdCreateUpdate.Name = "cmdCreateUpdate";
			this.cmdCreateUpdate.Size = new System.Drawing.Size(128, 24);
			this.cmdCreateUpdate.TabIndex = 1;
			this.cmdCreateUpdate.Text = "Update";
			this.ttipStoredProcCreator.SetToolTip(this.cmdCreateUpdate, "Click here to create the UPDATE stored procedure.");
			this.cmdCreateUpdate.Click += new System.EventHandler(this.cmdCreateUpdate_Click);
			// 
			// cmdCreateSelect
			// 
			this.cmdCreateSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCreateSelect.Location = new System.Drawing.Point(8, 104);
			this.cmdCreateSelect.Name = "cmdCreateSelect";
			this.cmdCreateSelect.Size = new System.Drawing.Size(128, 23);
			this.cmdCreateSelect.TabIndex = 0;
			this.cmdCreateSelect.Text = "Select";
			this.ttipStoredProcCreator.SetToolTip(this.cmdCreateSelect, "Click here to create the SELECT stored procedure.");
			this.cmdCreateSelect.Click += new System.EventHandler(this.cmdCreateSelect_Click);
			// 
			// txtSQL
			// 
			this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSQL.Location = new System.Drawing.Point(160, 16);
			this.txtSQL.Multiline = true;
			this.txtSQL.Name = "txtSQL";
			this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSQL.Size = new System.Drawing.Size(504, 544);
			this.txtSQL.TabIndex = 12;
			this.txtSQL.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblHelp);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.labelHelp5);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(8, 256);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 304);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Help ? Read this !";
			// 
			// lblHelp
			// 
			this.lblHelp.ForeColor = System.Drawing.Color.Blue;
			this.lblHelp.Location = new System.Drawing.Point(8, 16);
			this.lblHelp.Name = "lblHelp";
			this.lblHelp.Size = new System.Drawing.Size(128, 32);
			this.lblHelp.TabIndex = 0;
			this.lblHelp.Text = "1) type SQL server connection informations.";
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Blue;
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 40);
			this.label4.TabIndex = 0;
			this.label4.Text = "2) Press \"Connect\". The treeview wil be refrehed with user\'s databases list.";
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.Blue;
			this.label5.Location = new System.Drawing.Point(8, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 56);
			this.label5.TabIndex = 0;
			this.label5.Text = "3) open the desired database node. This will list the user table of the selected " +
				"database.";
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.Color.Blue;
			this.label6.Location = new System.Drawing.Point(8, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 40);
			this.label6.TabIndex = 0;
			this.label6.Text = "4) Select a table. The list of field and type field is listed.";
			// 
			// labelHelp5
			// 
			this.labelHelp5.ForeColor = System.Drawing.Color.Blue;
			this.labelHelp5.Location = new System.Drawing.Point(8, 216);
			this.labelHelp5.Name = "labelHelp5";
			this.labelHelp5.Size = new System.Drawing.Size(128, 56);
			this.labelHelp5.TabIndex = 0;
			this.labelHelp5.Text = "5) Press the one of the \"Create Stored Proc Button\" to create the Stored proc.";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabStoredProc);
			this.tabControl1.Controls.Add(this.tabPersistClasses);
			this.tabControl1.Location = new System.Drawing.Point(392, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(680, 592);
			this.tabControl1.TabIndex = 14;
			// 
			// tabStoredProc
			// 
			this.tabStoredProc.Controls.Add(this.groupBox1);
			this.tabStoredProc.Controls.Add(this.groupBox2);
			this.tabStoredProc.Controls.Add(this.txtSQL);
			this.tabStoredProc.Location = new System.Drawing.Point(4, 22);
			this.tabStoredProc.Name = "tabStoredProc";
			this.tabStoredProc.Size = new System.Drawing.Size(672, 566);
			this.tabStoredProc.TabIndex = 0;
			this.tabStoredProc.Text = "Stored Procedure";
			// 
			// tabPersistClasses
			// 
			this.tabPersistClasses.Controls.Add(this.cboCnxStrIn);
			this.tabPersistClasses.Controls.Add(this.label9);
			this.tabPersistClasses.Controls.Add(this.label8);
			this.tabPersistClasses.Controls.Add(this.cboPDSA);
			this.tabPersistClasses.Controls.Add(this.btnParcourir);
			this.tabPersistClasses.Controls.Add(this.txtDirCls);
			this.tabPersistClasses.Controls.Add(this.chkMakeFile);
			this.tabPersistClasses.Controls.Add(this.button1);
			this.tabPersistClasses.Controls.Add(this.txtClass);
			this.tabPersistClasses.Controls.Add(this.cboLanguage);
			this.tabPersistClasses.Controls.Add(this.label7);
			this.tabPersistClasses.Location = new System.Drawing.Point(4, 22);
			this.tabPersistClasses.Name = "tabPersistClasses";
			this.tabPersistClasses.Size = new System.Drawing.Size(672, 566);
			this.tabPersistClasses.TabIndex = 1;
			this.tabPersistClasses.Text = "Persistable classes";
			this.tabPersistClasses.Click += new System.EventHandler(this.tabPersistClasses_Click);
			// 
			// cboCnxStrIn
			// 
			this.cboCnxStrIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCnxStrIn.Location = new System.Drawing.Point(536, 8);
			this.cboCnxStrIn.Name = "cboCnxStrIn";
			this.cboCnxStrIn.Size = new System.Drawing.Size(120, 21);
			this.cboCnxStrIn.TabIndex = 10;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(480, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 24);
			this.label9.TabIndex = 9;
			this.label9.Text = "CnxStr in";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(232, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "Select req type :";
			// 
			// cboPDSA
			// 
			this.cboPDSA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPDSA.Location = new System.Drawing.Point(320, 8);
			this.cboPDSA.Name = "cboPDSA";
			this.cboPDSA.Size = new System.Drawing.Size(120, 21);
			this.cboPDSA.TabIndex = 7;
			// 
			// btnParcourir
			// 
			this.btnParcourir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnParcourir.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnParcourir.Location = new System.Drawing.Point(416, 40);
			this.btnParcourir.Name = "btnParcourir";
			this.btnParcourir.Size = new System.Drawing.Size(24, 16);
			this.btnParcourir.TabIndex = 6;
			this.btnParcourir.Text = "...";
			this.btnParcourir.Click += new System.EventHandler(this.btnParcourir_Click);
			// 
			// txtDirCls
			// 
			this.txtDirCls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDirCls.Enabled = false;
			this.txtDirCls.Location = new System.Drawing.Point(144, 40);
			this.txtDirCls.Name = "txtDirCls";
			this.txtDirCls.Size = new System.Drawing.Size(264, 20);
			this.txtDirCls.TabIndex = 5;
			this.txtDirCls.Text = "";
			// 
			// chkMakeFile
			// 
			this.chkMakeFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkMakeFile.Location = new System.Drawing.Point(8, 40);
			this.chkMakeFile.Name = "chkMakeFile";
			this.chkMakeFile.Size = new System.Drawing.Size(148, 16);
			this.chkMakeFile.TabIndex = 4;
			this.chkMakeFile.Text = "Générer un fichier dans";
			this.chkMakeFile.CheckedChanged += new System.EventHandler(this.chkMakeFile_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(464, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(192, 24);
			this.button1.TabIndex = 3;
			this.button1.Text = "Generate Persistable Classes";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtClass
			// 
			this.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtClass.Location = new System.Drawing.Point(8, 72);
			this.txtClass.Multiline = true;
			this.txtClass.Name = "txtClass";
			this.txtClass.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtClass.Size = new System.Drawing.Size(656, 488);
			this.txtClass.TabIndex = 2;
			this.txtClass.Text = "ATTENTION : non finalisé : ne génere que des type string !";
			// 
			// cboLanguage
			// 
			this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLanguage.Items.AddRange(new object[] {
															 "C#",
															 "Visual Basic .NET"});
			this.cboLanguage.Location = new System.Drawing.Point(104, 8);
			this.cboLanguage.Name = "cboLanguage";
			this.cboLanguage.Size = new System.Drawing.Size(104, 21);
			this.cboLanguage.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.Location = new System.Drawing.Point(8, 8);
			this.label7.Name = "label7";
			this.label7.TabIndex = 0;
			this.label7.Text = "Select Language :";
			// 
			// ckbNTAuth
			// 
			this.ckbNTAuth.Checked = ((bool)(configurationAppSettings.GetValue("UseNTAuthentication.Checked", typeof(bool))));
			this.ckbNTAuth.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbNTAuth.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ckbNTAuth.Location = new System.Drawing.Point(8, 80);
			this.ckbNTAuth.Name = "ckbNTAuth";
			this.ckbNTAuth.Size = new System.Drawing.Size(152, 24);
			this.ckbNTAuth.TabIndex = 15;
			this.ckbNTAuth.Text = "Use NT Authentification";
			this.ckbNTAuth.CheckedChanged += new System.EventHandler(this.ckbNTAuth_CheckedChanged);
			// 
			// txtBase
			// 
			this.txtBase.Location = new System.Drawing.Point(104, 104);
			this.txtBase.Name = "txtBase";
			this.txtBase.Size = new System.Drawing.Size(184, 20);
			this.txtBase.TabIndex = 16;
			this.txtBase.Text = ((string)(configurationAppSettings.GetValue("SQLDatabase.Text", typeof(string))));
			// 
			// lblBase
			// 
			this.lblBase.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblBase.Location = new System.Drawing.Point(8, 106);
			this.lblBase.Name = "lblBase";
			this.lblBase.Size = new System.Drawing.Size(80, 16);
			this.lblBase.TabIndex = 17;
			this.lblBase.Text = "Base :";
			// 
			// trvTableColumns
			// 
			this.trvTableColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.trvTableColumns.CheckBoxes = true;
			this.trvTableColumns.ImageIndex = -1;
			this.trvTableColumns.Location = new System.Drawing.Point(216, 136);
			this.trvTableColumns.Name = "trvTableColumns";
			this.trvTableColumns.SelectedImageIndex = -1;
			this.trvTableColumns.Size = new System.Drawing.Size(168, 464);
			this.trvTableColumns.TabIndex = 18;
			// 
			// frmStoredProcCreator
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1080, 606);
			this.Controls.Add(this.trvTableColumns);
			this.Controls.Add(this.lblBase);
			this.Controls.Add(this.txtBase);
			this.Controls.Add(this.txtSqlPassword);
			this.Controls.Add(this.txtSqlUser);
			this.Controls.Add(this.txtServerName);
			this.Controls.Add(this.ckbNTAuth);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.cmdAbout);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.trvSqlServerSchema);
			this.Controls.Add(this.cmdConnect);
			this.Controls.Add(this.label1);
			this.Name = "frmStoredProcCreator";
			this.Text = "StoredProcCreator ¤ Nicolas CLERC 2003";
			this.Load += new System.EventHandler(this.frmStoredProcCreator_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabStoredProc.ResumeLayout(false);
			this.tabPersistClasses.ResumeLayout(false);
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
			Application.Run(new frmStoredProcCreator());
		}

		SQLDMO.SQLServerClass srv;

		private void cmdConnect_Click(object sender, System.EventArgs e)
		{
			if (srv!=null) srv.DisConnect();
			srv=new SQLDMO.SQLServerClass();
			if (ckbNTAuth.Checked)
				srv.LoginSecure=true;
			else
				srv.LoginSecure=false;
			srv.Connect(txtServerName.Text,txtSqlUser.Text,txtSqlPassword.Text);
			trvSqlServerSchema.Nodes.Clear();
			for(int n=1;n<=srv.Databases.Count;n++)
			{
				SQLDMO._Database db=srv.Databases.Item(n,null);
				if (!db.SystemObject)
				{
					if (("" == txtBase.Text) || (txtBase.Text.Trim().ToLower() == db.Name.Trim().ToLower()))
					{
						TreeNode dbNode=trvSqlServerSchema.Nodes.Add(db.Name);
						dbNode.Tag=db;
						for(int i=1;i<=db.Tables.Count;i++)
						{
							SQLDMO._Table tab=db.Tables.Item(i,null);
							if (!tab.SystemObject)
							{
								TreeNode tabNode=dbNode.Nodes.Add(tab.Name);
								tabNode.Tag=tab;
							}
						}
					}
				}
			}
		}


		private void trvSqlServerSchema_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//lstTableSchema.Items.Clear();
			trvTableColumns.Nodes.Clear();
			if (e.Node.Tag is SQLDMO._Table)
			{
				SQLDMO._Table tab=e.Node.Tag as SQLDMO._Table;
				//lstTableSchema.Items.Add("-- Schema of table : " + tab.Name + " --");
				//lstTableSchema.Items.Add("");

				for(int n=1;n<=tab.Columns.Count;n++)
				{
					SQLDMO._Column col=tab.Columns.Item(n);
					string pk="";
					if (col.InPrimaryKey) pk="PK";
					//lstTableSchema.Items.Add("@" + col.Name + "  [" + col.Datatype + "](" + col.Length.ToString() + ")   " + pk);

					TreeNode trvCol=trvTableColumns.Nodes.Add("@" + col.Name + "  [" + col.Datatype + "](" + col.Length.ToString() + ")   " + pk);
					trvCol.Tag=col;
				}
				

			}
		
		}

		private void cmdAbout_Click(object sender, System.EventArgs e)
		{
			AboutForm af=new AboutForm();
			af.ShowDialog();
			af.Dispose();
			af=null;
		}

		private bool IsFixedSizedType(string dataTypeName)
		{
			switch(dataTypeName)
			{
				case "nchar":
				case "char":
				case "varchar":
				case "nvarchar":
					return false;
			}
			return true;
		}

		private bool IsDecimalType(string dataTypeName)
		{
			switch(dataTypeName)
			{
				case "decimal":
				case "numeric":
					return true;
			}
			return false;
		}

		private void cmdCreateSelect_Click(object sender, System.EventArgs e)
		{
			string spParams="";
			string spCols="";
			string spName="";
			string spWhere="";
			string reqSql="";
			string prefix="";
			if (ckbUsePrefix.Checked)
				prefix=txtPrefix.Text+".";


			if (trvSqlServerSchema.SelectedNode==null)
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}

			if (!(trvSqlServerSchema.SelectedNode.Tag is SQLDMO._Table))
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			SQLDMO._Table tab=trvSqlServerSchema.SelectedNode.Tag as SQLDMO._Table;
			spName=prefix+"spS_" + tab.Name;

			for(int n=1;n<=tab.Columns.Count;n++)
			{
				SQLDMO._Column col=tab.Columns.Item(n);
				if (spCols!="")
					spCols+=",\r\n";
				spCols+="        [" + col.Name + "]";

				if (col.InPrimaryKey)
				{
					// on ajoute le champ dans les params a passer a la SP
					if (spParams!="")
						spParams+=",\r\n";
					spParams+="    @" + col.Name + " [" + col.Datatype +"]";
					if (!IsFixedSizedType(col.PhysicalDatatype) && col.PhysicalDatatype==col.Datatype)
						spParams+="(" + col.Length.ToString() + ")";
					else if (IsDecimalType(col.Datatype))
						spParams+="(" + col.NumericPrecision.ToString() + "," + col.NumericScale.ToString() + ")";

					if (spWhere!="")
						spWhere+=" AND \r\n";
					spWhere+="        " + col.Name + " = " + "@" + col.Name;
				}
			}

			SQLDMO._Database db=(SQLDMO._Database)trvSqlServerSchema.SelectedNode.Parent.Tag;
			try
			{
				if (!chkTestMode.Checked)
					db.ExecuteImmediate("DROP PROCEDURE " + spName,SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError,reqSql.Length);
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);	
			}

			reqSql="";
			reqSql+="CREATE PROCEDURE " + spName + "\r\n";
			reqSql+="   -- auto Generated by StoredProcCreator - (c) N. CLERC 2003"+ "\r\n";
			reqSql+="   -- " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
			reqSql+="   -- StoredProcCreator is a part of the SFINx Framework - Sablefin.Net"+ "\r\n";
			reqSql+="( " + "\r\n";
			reqSql+=spParams + "\r\n";
			reqSql+=") "+ "\r\n";
			reqSql+="AS" + "\r\n";
			reqSql+="    SELECT" + "\r\n";
			reqSql+=spCols + "\r\n";
			reqSql+="    FROM " + tab.Name + "\r\n";
			reqSql+="    WHERE "+ "\r\n";
			reqSql+=spWhere + "\r\n";
			reqSql+= "\r\n";
			reqSql+="    Return(@@RowCount)"+ "\r\n";
			reqSql+=""+ "\r\n";
			reqSql+=" ------------------------------------------------------- end of " + spName + "\r\n";

			reqSql+="GO\r\n";
			txtSQL.Text=reqSql;

			if (!chkTestMode.Checked)
				db.ExecuteImmediate(reqSql,SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError,reqSql.Length);
			db=null;


		}

		private void cmdCreateDelete_Click(object sender, System.EventArgs e)
		{
			string spParams="";
			string spName="";
			string spWhere="";
			string reqSql="";
			string prefix="";
			if (ckbUsePrefix.Checked)
				prefix=txtPrefix.Text+".";

			if (trvSqlServerSchema.SelectedNode==null)
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}

			if (!(trvSqlServerSchema.SelectedNode.Tag is SQLDMO._Table))
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			SQLDMO._Table tab=trvSqlServerSchema.SelectedNode.Tag as SQLDMO._Table;
			spName=prefix+"spD_" + tab.Name;

			for(int n=1;n<=tab.Columns.Count;n++)
			{
				SQLDMO._Column col=tab.Columns.Item(n);
				if (col.InPrimaryKey)
				{
					// on ajoute le champ dans les params a passer a la SP
					if (spParams!="")
						spParams+=",\r\n";
					spParams+="    @" + col.Name + " [" + col.Datatype +"]";
					if (!IsFixedSizedType(col.Datatype))
						spParams+="(" + col.Length.ToString() + ")";
					else if (IsDecimalType(col.Datatype))
						spParams+="(" + col.NumericPrecision.ToString() + "," + col.NumericScale.ToString() + ")";

					if (spWhere!="")
						spWhere+=" AND \r\n";
					spWhere+="        " + col.Name + " = " + "@" + col.Name;
				}
			}


			SQLDMO._Database db=(SQLDMO._Database)trvSqlServerSchema.SelectedNode.Parent.Tag;
			try
			{
				if (!chkTestMode.Checked)
					db.ExecuteImmediate("DROP PROCEDURE " + spName,SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError,reqSql.Length);
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
			

			reqSql="CREATE PROCEDURE " + spName + "\r\n";
			reqSql+="   -- auto Generated by StoredProcCreator - (c) N. CLERC 2003"+ "\r\n";
			reqSql+="   -- " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
			reqSql+="   -- StoredProcCreator is a part of the SFINx Framework - Sablefin.Net"+ "\r\n";
			reqSql+="( " + "\r\n";
			reqSql+=spParams + "\r\n";
			reqSql+=") "+ "\r\n";
			reqSql+="AS" + "\r\n";
			reqSql+="    DELETE FROM " + tab.Name + "\r\n";
			reqSql+="    WHERE "+ "\r\n";
			reqSql+=spWhere + "\r\n";
			reqSql+= "\r\n";
			reqSql+="    Return(@@RowCount)"+ "\r\n";
			reqSql+=""+ "\r\n";
			reqSql+=" ------------------------------------------------------- end of " + spName + "\r\n";

			reqSql+="GO\r\n";
			txtSQL.Text=reqSql;

			if (!chkTestMode.Checked)
				db.ExecuteImmediate(reqSql,SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError,reqSql.Length);
			db=null;

		}

		private void cmdCreateUpdate_Click(object sender, System.EventArgs e)
		{
			string spParams="";
			string spCols="";
			string spName="";
			string spSet="";
			string spWhere="";
			string reqSql="";
			string prefix="";
			if (ckbUsePrefix.Checked)
				prefix=txtPrefix.Text+".";

			if (trvSqlServerSchema.SelectedNode==null)
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			if (!(trvSqlServerSchema.SelectedNode.Tag is SQLDMO._Table))
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			SQLDMO._Table tab=trvSqlServerSchema.SelectedNode.Tag as SQLDMO._Table;
			spName=prefix+"spU_" + tab.Name;
			for(int n=1;n<=tab.Columns.Count;n++)
			{
				SQLDMO._Column col=tab.Columns.Item(n);
				if (spCols!="")
					spCols+=",\r\n";
				spCols+="        [" + col.Name + "]";

				if (spParams!="")
					spParams+=",\r\n";
				spParams+="    @" + col.Name + " [" + col.Datatype +"]";
				if (!IsFixedSizedType(col.Datatype))
					spParams+="(" + col.Length.ToString() + ")";
				else if (IsDecimalType(col.Datatype))
					spParams+="(" + col.NumericPrecision.ToString() + "," + col.NumericScale.ToString() + ")";

				
				if(!col.Identity)	// si c'est un identity => on ne peut pas le mettre a jour
				{
					if (spSet!="")
						spSet+=" ,\r\n";
					spSet+="        [" + col.Name + "] = " + "@" + col.Name;
				}

				if (col.InPrimaryKey)
				{
					if (spWhere!="")
						spWhere+=" AND\r\n";
					spWhere+="        [" + col.Name + "] = @" + col.Name;
				}
			}

			SQLDMO._Database db=(SQLDMO._Database)trvSqlServerSchema.SelectedNode.Parent.Tag;
			try
			{
				if (!chkTestMode.Checked)
					db.ExecuteImmediate("DROP PROCEDURE " + spName,SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError,reqSql.Length);
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}

			reqSql="CREATE PROCEDURE " + spName + "\r\n";
			reqSql+="   -- auto Generated by StoredProcCreator - (c) N. CLERC 2003"+ "\r\n";
			reqSql+="   -- " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
			reqSql+="   -- StoredProcCreator is a part of the SFINx Framework - Sablefin.Net"+ "\r\n";
			reqSql+="( " + "\r\n";
			reqSql+=spParams + "\r\n";
			reqSql+=") "+ "\r\n";
			reqSql+="AS" + "\r\n";
			reqSql+="    UPDATE " + tab.Name + " \r\n";
			reqSql+="    SET\r\n";
			reqSql+=spSet + "\r\n";
			reqSql+="    WHERE\r\n";
			reqSql+=spWhere +"\r\n";
			reqSql+= "\r\n";
			reqSql+="    Return(@@RowCount)"+ "\r\n";
			reqSql+=""+ "\r\n";
			reqSql+=" ------------------------------------------------------- end of " + spName + "\r\n";

			reqSql+="GO\r\n";
			txtSQL.Text=reqSql;

			if (!chkTestMode.Checked)
				db.ExecuteImmediate(reqSql,SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError,reqSql.Length);
			db=null;

		
		}

		private void cmdCreateInsert_Click(object sender, System.EventArgs e)
		{
			string spParams="";
			string spCols="";
			string spName="";
			string spValues="";
			string reqSql="";
			string prefix="";
			string identityParam=null;

			if (ckbUsePrefix.Checked)
				prefix=txtPrefix.Text+".";

			if (trvSqlServerSchema.SelectedNode==null)
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			if (!(trvSqlServerSchema.SelectedNode.Tag is SQLDMO._Table))
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			SQLDMO._Table tab=trvSqlServerSchema.SelectedNode.Tag as SQLDMO._Table;
			spName=prefix+"spI_" + tab.Name;
			for(int n=1;n<=tab.Columns.Count;n++)
			{
				SQLDMO._Column col=tab.Columns.Item(n);
				

				if (!col.Identity)
				{
					if (spCols!="")
					 spCols+=",\r\n";
					spCols+="        [" + col.Name + "]";
				}
				if (spParams!="")
					spParams+=",\r\n";
				spParams+="    @" + col.Name + " [" + col.Datatype +"]";
				if (!IsFixedSizedType(col.Datatype))
					spParams+="(" + col.Length.ToString() + ")";
				else if (IsDecimalType(col.Datatype))
					spParams+="(" + col.NumericPrecision.ToString() + "," + col.NumericScale.ToString() + ")";
				if (col.Identity)
				{
					spParams+=" OUTPUT ";
					identityParam=col.Name;
				}
				else
				{
					if (spValues!="")
						spValues+=" ,\r\n";
					spValues+="        @" + col.Name;
				}
			}


			SQLDMO._Database db=(SQLDMO._Database)trvSqlServerSchema.SelectedNode.Parent.Tag;
			try
			{
				if (!chkTestMode.Checked)
					db.ExecuteImmediate("DROP PROCEDURE " + spName,SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError,reqSql.Length);
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}

			reqSql="CREATE PROCEDURE " + spName + "\r\n";
			reqSql+="   -- auto Generated by StoredProcCreator - (c) N. CLERC 2003"+ "\r\n";
			reqSql+="   -- " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n";
			reqSql+="   -- StoredProcCreator is a part of the SFINx Framework - Sablefin.Net"+ "\r\n";
			reqSql+="( " + "\r\n";
			reqSql+=spParams + "\r\n";
			reqSql+=") "+ "\r\n";
			reqSql+="AS" + "\r\n";
			reqSql+="    INSERT INTO " + tab.Name + " \r\n";
			reqSql+="    (\r\n";
			reqSql+=spCols + "\r\n";
			reqSql+="    )\r\n";
			reqSql+="    VALUES\r\n";
			reqSql+="    (\r\n";
			reqSql+=spValues+"\r\n";
			reqSql+="    )\r\n";
			reqSql+= "\r\n";
			if (identityParam!=null)
			{
				reqSql+="    SELECT @"  + identityParam + " = @@IDENTITY\r\n";
			}
			reqSql+="    Return(@@RowCount)"+ "\r\n";
			reqSql+=""+ "\r\n";
			reqSql+=" ------------------------------------------------------- end of " + spName + "\r\n";

			reqSql+="GO\r\n";
			txtSQL.Text=reqSql;
			if (!chkTestMode.Checked)
				db.ExecuteImmediate(reqSql,SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError,reqSql.Length);
			db=null;


		}

		private void ckbNTAuth_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckbNTAuth.Checked)
			{
				txtSqlPassword.Enabled=false;
				txtSqlUser.Enabled=false;
			}
			else
			{
				txtSqlPassword.Enabled=true;
				txtSqlUser.Enabled=true;
			}
		}

		private void frmStoredProcCreator_Load(object sender, System.EventArgs e)
		{
			cboLanguage.SelectedIndex=0;
			
			cboPDSA.Items.Clear();
			cboPDSA.Items.Add(DatasourceType.DynamicSQL);
			cboPDSA.Items.Add(DatasourceType.SQLServerStoredProc);
			cboPDSA.SelectedItem=DatasourceType.SQLServerStoredProc;

			cboCnxStrIn.Items.Clear();
			cboCnxStrIn.Items.Add(ConnectionStringIn.ApplicationSettings);
			cboCnxStrIn.Items.Add(ConnectionStringIn.Session);
			cboCnxStrIn.SelectedItem=ConnectionStringIn.ApplicationSettings;
		}
	

		private enum Langage 
		{
			VB,
			CS,
			JS,
			JScript,
			CPP,
			COBOL
		}


		private Type GetDotNetType(string sqltype)
		{
			string dotnettypename=System.Configuration.ConfigurationSettings.AppSettings["SQL_"+sqltype];
			if (dotnettypename==null) return typeof(System.String);
			return Type.GetType(dotnettypename);
		}

		private object GetDefaultValueForNull(string sqlType)
		{
			object nullValue;

			// TODO : gérér la valeur du NULL
			nullValue=sqlType;
			switch(sqlType)
			{
				case "smallint":
					nullValue=Int16.MinValue;	break;
				case "int":
					nullValue="int.MinValue";	break;
				case "money":
					nullValue=decimal.MinValue; break;
				case "numeric":
					nullValue=0; break;
				case "datetime":
					nullValue=DateTime.MinValue; break;
			}

			return nullValue;
		}

		private string CreationClassePersistable(ICodeGenerator codeGenerator, Langage langageChoice) 
		{

			// namespace DB + nom de la base de données
			CodeNamespace monNamespace = new CodeNamespace("DB_" + (trvSqlServerSchema.SelectedNode.Parent.Tag as SQLDMO._Database).Name);

			// ajout des imports de namespace
			monNamespace.Imports.Add(new CodeNamespaceImport("System"));
			monNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
			monNamespace.Imports.Add(new CodeNamespaceImport("SableFin.SfinX.SimplePersistance"));

			// creation de la classe
			SQLDMO._Table tab=trvSqlServerSchema.SelectedNode.Tag as SQLDMO._Table;
			
			CodeTypeDeclaration maClasse = new CodeTypeDeclaration(tab.Name);
			//maClasse.BaseTypes.Add(tab.Name);
			maClasse.Attributes = MemberAttributes.Public;
			maClasse.IsClass = true;
			maClasse.Comments.Add(new CodeCommentStatement("Persistable classes for the " + tab.Name + " table.", false));

			// creation de l'attribut [PersistConnectionString]
			CodeAttributeDeclaration attr=new CodeAttributeDeclaration();
			attr.Name="PersistConnectionString";
			maClasse.CustomAttributes.Add(attr);
			if ((ConnectionStringIn)cboCnxStrIn.SelectedItem==ConnectionStringIn.ApplicationSettings)
				attr.Arguments.Add(new CodeAttributeArgument("AppSettingsName",new CodePrimitiveExpression("cnxstr")));
			else attr.Arguments.Add(new CodeAttributeArgument("SessionVariable",new CodePrimitiveExpression("cnxstr")));
			
			if ((DatasourceType)cboPDSA.SelectedItem==DatasourceType.SQLServerStoredProc)
			{
				// creation de l'attribut [PersistStoredProc]
				attr=new CodeAttributeDeclaration();
				attr.Name="PersistStoredProc";
				attr.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression("spS_" + tab.Name)));
				attr.Arguments.Add(new CodeAttributeArgument("INSERTStoredProc",new CodePrimitiveExpression("spI_" + tab.Name)));
				attr.Arguments.Add(new CodeAttributeArgument("DELETEStoredProc",new CodePrimitiveExpression("spD_" + tab.Name)));
				attr.Arguments.Add(new CodeAttributeArgument("UPDATEStoredProc",new CodePrimitiveExpression("spU_" + tab.Name)));
				attr.Arguments.Add(new CodeAttributeArgument("TableName",new CodePrimitiveExpression(tab.Name)));
			} 
			else if ((DatasourceType)cboPDSA.SelectedItem==DatasourceType.DynamicSQL)
			{
				// creation de l'attribut [PersistDynamicSQL]
				attr=new CodeAttributeDeclaration();
				attr.Name="PersistDynamicSQL";
				attr.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(tab.Name)));
				
			}
			maClasse.CustomAttributes.Add(attr);
			monNamespace.Types.Add(maClasse); // ajout de la classe dans le namespace


			for(int n=1;n<=tab.Columns.Count;n++)
			{
				SQLDMO._Column col=tab.Columns.Item(n);

				Type dotNetType=GetDotNetType(col.PhysicalDatatype);

				// private string 
				CodeMemberField priv_var = new CodeMemberField(dotNetType, "p_" + col.Name);
				maClasse.Members.Add(priv_var );

				// private bool si Nullable col
				CodeMemberField null_var=null;
				if (col.AllowNulls)
				{
					null_var=new CodeMemberField(typeof(bool),col.Name + "ISNULL");
					null_var.Attributes=MemberAttributes.Public | MemberAttributes.Final;
					null_var.InitExpression=new CodePrimitiveExpression(true);
					maClasse.Members.Add(null_var);
				}

				// definition d'une reference a une variable
				CodeFieldReferenceExpression ref_var = null;
				ref_var = new CodeFieldReferenceExpression();
				ref_var.TargetObject = new CodeThisReferenceExpression();
				ref_var.FieldName = priv_var.Name;

				CodeFieldReferenceExpression ref_null_var=null;
				if (col.AllowNulls)
				{
					ref_null_var = new CodeFieldReferenceExpression();
					ref_null_var.TargetObject = new CodeThisReferenceExpression();
					ref_null_var.FieldName = null_var.Name;
				}

				CodeMemberProperty champDB = new CodeMemberProperty();
				champDB.Attributes = MemberAttributes.Public | MemberAttributes.Final;
				champDB.Type = new CodeTypeReference(dotNetType);
				champDB.Name = col.Name;
				champDB.HasGet = true;
				champDB.HasSet = true;
				CodeMethodReturnStatement returnRefThis = new CodeMethodReturnStatement(ref_var);
				champDB.GetStatements.Add(returnRefThis);

				CodeAssignStatement setField=new CodeAssignStatement(ref_var,new CodePropertySetValueReferenceExpression());
				champDB.SetStatements.Add(setField);
				if (col.AllowNulls)
				{
					CodeAssignStatement setFieldIsNullToFalse=new CodeAssignStatement(ref_null_var,new CodePrimitiveExpression(false));
					champDB.SetStatements.Add(setFieldIsNullToFalse);
				}

				// création de l'attribut pour la propriété en cours
				attr=new CodeAttributeDeclaration();
				attr.Name="DBField";
				attr.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(col.Name)));
				if (col.InPrimaryKey)
				{
					attr.Arguments.Add(new CodeAttributeArgument("PrimaryKey", new CodePrimitiveExpression(true)));
				}
				if (col.Identity)
				{
					attr.Arguments.Add(new CodeAttributeArgument("Identity", new CodePrimitiveExpression(true)));
				}
				if (col.AllowNulls)
				{
					attr.Arguments.Add(new CodeAttributeArgument("IsNullable", new CodePrimitiveExpression(true)));
					//attr.Arguments.Add(new CodeAttributeArgument("NullValue", new CodePrimitiveExpression(GetDefaultValueForNull(col.PhysicalDatatype))));
				}



				champDB.CustomAttributes.Add(attr); // ajout de l'attribut sur la prop

				maClasse.Members.Add(champDB);	// ajout de la propriété dans la classe
			}

			// On génère finalement le code
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			TextWriter textWriter = new StringWriter(stringBuilder);

			try 
			{
				codeGenerator.GenerateCodeFromNamespace(monNamespace, textWriter, null);
			}
			catch (Exception exception)
			{
				return(exception.ToString());
			}
			finally 
			{
				textWriter.Close();
			}

			return(stringBuilder.ToString());
		}		
		
		private void button1_Click(object sender, System.EventArgs e)
		{
			if (trvSqlServerSchema.SelectedNode==null)
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			if (!(trvSqlServerSchema.SelectedNode.Tag is SQLDMO._Table))
			{
				MessageBox.Show("You need to select a table before creating SP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}

			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			ICodeGenerator codeGenerator = null;

			string classFileName="";
			switch(cboLanguage.SelectedIndex)
			{
				case 0: // C#
					codeGenerator = new Microsoft.CSharp.CSharpCodeProvider().CreateGenerator();
					txtClass.Text = CreationClassePersistable(codeGenerator, Langage.CS);
					classFileName=(trvSqlServerSchema.SelectedNode.Tag as SQLDMO._Table).Name + ".cs";
					break;

				case 1: // VB.NET
					codeGenerator = new Microsoft.VisualBasic.VBCodeProvider().CreateGenerator();
					txtClass.Text = CreationClassePersistable(codeGenerator, Langage.VB);
					classFileName=(trvSqlServerSchema.SelectedNode.Tag as SQLDMO._Table).Name + ".vb";
					break;
			}

			// Générer le fichier
			if ((chkMakeFile.Checked) && ("" != txtClass.Text))
			{
				string sFileName = txtDirCls.Text + "\\" + classFileName;
						
				if (File.Exists(sFileName)) 
				{
					MessageBox.Show(sFileName + " existe déjà.");
				}
				else
				{
					StreamWriter sr = File.CreateText(sFileName);
					sr.Write(txtClass.Text);
					sr.Close();
				}
			}
			this.Cursor = Cursors.Default;
		}

		private void chkMakeFile_CheckedChanged(object sender, System.EventArgs e)
		{
			txtDirCls.Enabled = chkMakeFile.Checked;
		}

		private void btnParcourir_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog  fdlg = new FolderBrowserDialog();
			if (fdlg.ShowDialog() == DialogResult.OK) 
			{
				txtDirCls.Text = fdlg.SelectedPath;
			}
		
		}


		private void ClearCheckedCol()
		{
			foreach(TreeNode nod in trvTableColumns.Nodes)
				nod.Checked=false;
		}

		
		private void ckbUsePrefix_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckbUsePrefix.Checked)
				txtPrefix.Enabled=true;
			else txtPrefix.Enabled=false;
		}

		private void tabPersistClasses_Click(object sender, System.EventArgs e)
		{
		
		}

		
		
	}
}
