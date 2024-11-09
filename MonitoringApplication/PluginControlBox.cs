using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Configuration;
using System.Reflection;
using Whiz.Monitoring.Application.Common;

namespace Whiz.Monitoring.Application
{
	/// <summary>
	/// Plugin control box form
	/// </summary>
	public partial class PluginControlBox : Form
	{
		/// <summary>
		/// Dictionary of loaded plugins
		/// </summary>
		Dictionary<String, Tuple<String, Assembly, String>> pPlugins;
		/// <summary>
		/// Form for plugins entry point controls
		/// </summary>
		public PluginControlBox()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Load event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginControlBox_Load(object sender, EventArgs e)
		{
			try
			{
				pPlugins = new Dictionary<String, Tuple<String, Assembly, String>>();
				XDocument pXD = new XDocument();
				pXD = XDocument.Load(Program.PluginConfig);
				foreach (XElement pX in pXD.XPathSelectElements("//assembly").ToList()) //pXD.Element("plugins").Element("plugin").Elements("assembly").ToList())
				{
					Assembly pAssembly = Assembly.LoadFrom(pX.Attribute("ref").Value);
					String pConfiguration = pX.Element("configuration") == null ? "" : pX.Element("configuration").Value;
					Main.Config[pAssembly.CodeBase] = pConfiguration;
					foreach (XElement pEP in pX.Elements("entrypoint").ToList())
					{
						lsbPlugins.Items.Add(pEP.Attribute("description").Value);
						((Main)this.MdiParent).AddPluginsMenuItem(pEP.Attribute("description").Value);
						pPlugins.Add(pEP.Attribute("description").Value, new Tuple<String, Assembly, String>(pEP.Attribute("class").Value, pAssembly, pConfiguration));
						if (pEP.Attribute("auto").Value == "true")
						{
							PluginBaseForm pF = (PluginBaseForm)pPlugins[pEP.Attribute("description").Value].Item2.CreateInstance(pPlugins[pEP.Attribute("description").Value].Item1);
							//pF.Configuration = pConfiguration;
							pF.MdiParent = this.MdiParent;
							((Main)this.MdiParent).RegisterPluginForm(pF);
							pF.Show();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// Shown event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginControlBox_Shown(object sender, EventArgs e)
		{
			if (pPlugins.Count == 0)
			{
				this.Dispose();
			}
		}
		/// <summary>
		/// Listbox double click event handler (opens the plugin entry point)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lsbPlugins_DoubleClick(object sender, EventArgs e)
		{
			if (lsbPlugins.SelectedIndex != -1)
			{
				PluginBaseForm pF = (PluginBaseForm)pPlugins[lsbPlugins.SelectedItem.ToString()].Item2.CreateInstance(pPlugins[lsbPlugins.SelectedItem.ToString()].Item1);
				pF.MdiParent = this.MdiParent;
				((Main)this.MdiParent).RegisterPluginForm(pF);
				pF.Show();
			}
		}
		/// <summary>
		/// Open plugin common function
		/// </summary>
		/// <param name="_Plugin"></param>
		public void OpenPlugin(String _Plugin)
		{
			PluginBaseForm pF = (PluginBaseForm)pPlugins[_Plugin].Item2.CreateInstance(pPlugins[_Plugin].Item1);
			pF.MdiParent = this.MdiParent;
			((Main)this.MdiParent).RegisterPluginForm(pF);
			pF.Show();
		}

	}
}
