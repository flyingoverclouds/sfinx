using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Sablefin.SFINx.WebNews
{
	/// <summary>
	/// Description résumée de WebCustomControl1.
	/// </summary>
	[DefaultProperty("Text"),
		ToolboxData("<{0}:WebCustomControl1 runat=server></{0}:WebCustomControl1>")]
	public class WebCustomControl1 : System.Web.UI.WebControls.WebControl
	{
		private string text;

		[Bindable(true),
			Category("Appearance"),
			DefaultValue("")]
		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		/// <summary>
		/// Génère ce contrôle dans le paramètre de sortie spécifié.
		/// </summary>
		/// <param name="output"> Le writer HTML vers lequel écrire </param>
		protected override void Render(HtmlTextWriter output)
		{
			output.Write(Text);
		}
	}
}
