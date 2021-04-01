using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web;

namespace Sablefin.SFINx.Web.UI.WebControls
{
	/// <summary>
	/// Description résumée de eStatCounter.
	/// </summary>

	[DefaultProperty("Add an eStat Counter to your page"),
	ToolboxData("<{0}:eStatCounter runat=server></{0}:eStateCounter>")]
	public class eStatCounter : System.Web.UI.WebControls.WebControl
	{
		private string p_eStatID;
		private string p_title;	// title de page
		private string p_category;	// category of the page
		public eStatCounter()
		{
			//
			// TODO : ajoutez ici la logique du constructeur
			//
		}


		[Bindable(true),
		Category("Appearance"),
		DefaultValue("243043170641")]
		public string eStatID
		{
			get { return p_eStatID; }
			set	{ p_eStatID = value;}
		}

		[Bindable(true),
		Category("Appearance"),
		DefaultValue("Page_D_Accueil")]
		public string PageTitle
		{
			get { return p_title; }
			set	{ p_title = value;}
		}

		[Bindable(true),
		Category("Appearance"),
		DefaultValue("Accueil")]
		public string PageCategory
		{
			get { return p_category; }
			set	{ p_category = value;}
		}

		/// <summary>
		/// Génère le rendu HTML du controle.
		/// </summary>
		/// <param name="output"> Le write HTML a utiliser pour générer le rendu.</param>
		protected override void Render(HtmlTextWriter output)
		{
//			output.Write("<!-- eStat by Sfinx-->\n");
//			output.Write("<SCRIPT TYPE='text/javascript'>\n");
//			output.Write("<!--\n");
//			output.Write("var _UJS=0;\n");
//			output.Write("//-->\n");
//			output.Write("</SCRIPT>\n");
//			output.Write("<SCRIPT TYPE='text/javascript' SRC='http://perso.estat.com/js/m.js'></SCRIPT>\n");
//			output.Write("<SCRIPT TYPE='text/javascript'>\n");
//			output.Write("<!--\n");
//			output.Write("if(_UJS) _estat('" + p_eStatID + "','" + p_title + "','" + p_category + "');\n");
//			output.Write("//-->\n");
//			output.Write("</SCRIPT>\n");
//			output.Write("<!-- /eStat -->\n");
		}


	}
}
