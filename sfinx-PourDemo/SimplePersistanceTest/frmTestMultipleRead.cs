using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SableFin.SfinX.SimplePersistance;

namespace Sablefin.SFINx.SimplePersistanceTest
{
	/// <summary>
	/// Description résumée de frmTestMultipleRead.
	/// </summary>
	public class frmTestMultipleRead : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdTest;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTestMultipleRead()
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
			this.cmdTest = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdTest
			// 
			this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdTest.Location = new System.Drawing.Point(0, 0);
			this.cmdTest.Name = "cmdTest";
			this.cmdTest.Size = new System.Drawing.Size(80, 23);
			this.cmdTest.TabIndex = 0;
			this.cmdTest.Text = "Charger";
			this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(88, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Mettre a jour";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 32);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(472, 240);
			this.dataGrid1.TabIndex = 2;
			// 
			// frmTestMultipleRead
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 270);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cmdTest);
			this.Name = "frmTestMultipleRead";
			this.Text = "test du MultipleRead()";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdTest_Click(object sender, System.EventArgs e)
		{
			titles b=new titles();
			b.pub_id="1000";

			ArrayList alBook=PersistDAL.ReadMultiple(b,null,"[pub_id]<1000",null,null);
			dataGrid1.DataSource=alBook;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			PersistDAL.Update(dataGrid1.DataSource);
		}

	
	}







}
