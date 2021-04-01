using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace SfinxPersistanceTestPPC
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MainMenu mainMenu1;

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
			base.Dispose( disposing );
		}
		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			this.mainMenu1.MenuItems.Add(this.menuItem2);
			// 
			// menuItem1
			// 
			this.menuItem1.Text = "&Quitter";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.MenuItems.Add(this.menuItem3);
			this.menuItem2.MenuItems.Add(this.menuItem4);
			this.menuItem2.MenuItems.Add(this.menuItem5);
			this.menuItem2.Text = "DataBase";
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "Create";
			// 
			// menuItem4
			// 
			this.menuItem4.Text = "Delete";
			// 
			// menuItem5
			// 
			this.menuItem5.Text = "Populate";
			// 
			// Form1
			// 
			this.Menu = this.mainMenu1;
			this.Text = "SinfX Test";

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
	}
}
