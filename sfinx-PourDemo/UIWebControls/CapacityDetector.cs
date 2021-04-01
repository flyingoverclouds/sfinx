using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web;

// (c) Nicolas CLERC 2002 - Sablefin.NET

namespace Sablefin.SFINx.Web.UI.WebControls
{

	public delegate void DotNETSupportedEventHandler(string version);
	
	/// <summary>
	/// Summary description for CapacityDetector.
	/// </summary>
	[DefaultProperty("Enable your application to autodetect .NET enabled capacity of browser"),
		ToolboxData("<{0}:CapacityDetector runat=server></{0}:CapacityDetector>")]
	public class CapacityDetector : System.Web.UI.WebControls.WebControl
	{
		private string text;
		private bool p_dotNetEnabled=false;
		private string p_dotNetVersion="";


		public event DotNETSupportedEventHandler DotNETSupportedEvent;

		public bool IsDotNETenabled
		{
			get { return p_dotNetEnabled; }
		}

		public string DotNETversion
		{
			get { return p_dotNetVersion; }
		}


		[Bindable(true),
			Category("Appearance"),
			DefaultValue("")]
		public string Text
		{
			get { return text; }
			set	{ text = value;}
		}

		/// <summary>
		/// Génère le rendu HTML du controle.
		/// </summary>
		/// <param name="output"> Le write HTML a utiliser pour générer le rendu.</param>
		protected override void Render(HtmlTextWriter output)
		{
			output.Write(Text);
		}

		protected override void OnLoad(EventArgs e) 
		{
			EnsureChildControls();
			base.OnLoad(e);

			if (HttpContext.Current.Request.Headers["User-Agent"].IndexOfAny(((string)".NET CLR").ToCharArray())>=0)
			{
				if (DotNETSupportedEvent!=null)
				{
					p_dotNetEnabled=true;
					p_dotNetVersion="1.0";
					DotNETSupportedEvent(p_dotNetVersion);
				}
			}
		}
	}
}
