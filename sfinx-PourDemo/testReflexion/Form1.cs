using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using Sablefin.SFINx.SimplePersistance;

namespace testReflexion
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
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
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(224, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(8, 64);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(248, 511);
			this.listBox1.TabIndex = 1;
			// 
			// listBox2
			// 
			this.listBox2.Location = new System.Drawing.Point(264, 64);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(264, 511);
			this.listBox2.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 590);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void DEBUGListAttributeAndValue(object b)
		{
			string txt="";
			
			FieldInfo[] tabFields=b.GetType().GetFields();
			foreach(FieldInfo fi in tabFields) // on parcours chaque champ de la classe
			{
				txt+=(fi.Name)+"\r\n";
				object[] tabAttrsField=fi.GetCustomAttributes(true);	// pour le champ en cours, on recupere ses attributs 
				foreach(object obj in tabAttrsField)
				{
					txt+="    [" + obj.GetType().Name+"]"+"\r\n";
					if (obj is DBFieldAttribute)	// si le champ est un [PersistField]
					{
						txt+="        DBFieldName = " + (obj as DBFieldAttribute).DBFieldName+"\r\n"; 
						txt+="        DBFieldType = " + (obj as DBFieldAttribute).DBFieldType+"\r\n"; 
						if ((obj as DBFieldAttribute).PrimaryKey)
							txt+="        IsPrimaryKey"+"\r\n"; 
					}
				}
			}
			MessageBox.Show(txt);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			TESTCLASSE b1=new TESTCLASSE();
			DEBUGListAttributeAndValue(b1);
			TESTCLASSE b2=(TESTCLASSE)(Activator.CreateInstance(b1.GetType()));
			DEBUGListAttributeAndValue(b2);

		}
	}
}
