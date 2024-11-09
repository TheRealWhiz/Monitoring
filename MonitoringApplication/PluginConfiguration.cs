using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Whiz.Monitoring.Application.Common;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Configuration;

namespace Whiz.Monitoring.Application
{
	/// <summary>
	/// Plugin configuration form
	/// </summary>
	public partial class PluginConfiguration : PluginBaseForm
	{
		/// <summary>
		/// Plugin configuration form contructor
		/// </summary>
		public PluginConfiguration()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Loads the configuration
		/// </summary>
		private void LoadConfiguration()
		{
			XDocument pXD = new XDocument();
			pXD = XDocument.Load(Program.PluginConfig);
			foreach (XElement pX in pXD.XPathSelectElements("//assembly").ToList())
			{
				Assembly pAssembly = Assembly.LoadFrom(pX.Attribute("ref").Value);
				String pConfiguration = pX.Element("configuration") == null ? "" : pX.Element("configuration").Value;
				foreach (XElement pEP in pX.XPathSelectElements("entrypoint").ToList())
				{
					ListViewItem pI = new ListViewItem();
					pI.Text = pX.Attribute("ref").Value;
					pI.SubItems.Add(pEP.Attribute("class").Value);
					pI.SubItems.Add(pEP.Attribute("description").Value);
					pI.SubItems.Add(pEP.Attribute("auto").Value == "true" ? "Yes" : "No");
					pI.SubItems.Add(pConfiguration);
					lsvPlugins.Items.Add(pI);
				}
			}
		}
		/// <summary>
		/// Load event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginConfiguration_Load(object sender, EventArgs e)
		{
			LoadConfiguration();
		}
		/// <summary>
		/// ListView selected index event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lsvPlugins_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lsvPlugins.SelectedItems.Count > 0)
			{
				EnableGroup(true);
				btnRemovePlugin.Enabled = true;
				txtPlugin.Text = lsvPlugins.SelectedItems[0].SubItems[0].Text;
				LoadClassesCombo(lsvPlugins.SelectedItems[0].SubItems[0].Text);
				cmbClasses.SelectedIndex = cmbClasses.Items.IndexOf(lsvPlugins.SelectedItems[0].SubItems[1].Text);
				txtDescription.Text = lsvPlugins.SelectedItems[0].SubItems[2].Text;
				txtConfiguration.Text = lsvPlugins.SelectedItems[0].SubItems[4].Text;
				if (lsvPlugins.SelectedItems[0].SubItems[3].Text == "Yes")
				{
					chkAuto.Checked = true;
				}
			}
			else
			{
				EnableGroup(false);
				btnRemovePlugin.Enabled = false;
			}
		}
		/// <summary>
		/// Enable/Disable for the details interface
		/// </summary>
		/// <param name="_Enabled"></param>
		private void EnableGroup(Boolean _Enabled)
		{
			txtDescription.Text = "";
			txtPlugin.Text = "";
			cmbClasses.Items.Clear();
			cmbClasses.Text = "";
			chkAuto.Checked = false;
			grbPluginConfiguration.Enabled = _Enabled;
		}
		/// <summary>
		/// Loads the combobox from assembly
		/// </summary>
		/// <param name="_Assembly"></param>
		private void LoadClassesCombo(String _Assembly)
		{
			Assembly pAssembly = Assembly.LoadFrom(_Assembly);
			foreach (Type pT in pAssembly.GetTypes())
			{
				if (pT.BaseType == typeof(PluginBaseForm))
				{
					cmbClasses.Items.Add(pT.FullName);
				}
			}
		}
		/// <summary>
		/// Botton click event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddPlugin_Click(object sender, EventArgs e)
		{
			EnableGroup(true);
			btnRemovePlugin.Enabled = false;
			lsvPlugins.SelectedItems.Clear();
		}
		/// <summary>
		/// Botton click event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRemovePlugin_Click(object sender, EventArgs e)
		{
			if (lsvPlugins.SelectedItems.Count > 0)
			{
				lsvPlugins.Items.Remove(lsvPlugins.SelectedItems[0]);
				EnableGroup(false);
			}
		}
		/// <summary>
		/// Botton click event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnChooseAssembly_Click(object sender, EventArgs e)
		{
			String pFile = ChooseFile();
			if (pFile != String.Empty)
			{
				txtPlugin.Text = pFile;
				LoadClassesCombo(pFile);
			}
		}
		/// <summary>
		/// Choose file common method with filedialog window
		/// </summary>
		/// <returns></returns>
		private String ChooseFile()
		{
			OpenFileDialog pDialog = new OpenFileDialog();
			if (pDialog.ShowDialog() == DialogResult.OK)
			{
				return pDialog.FileName;
			}
			else
			{
				return String.Empty;
			}
		}
		/// <summary>
		/// Botton event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (lsvPlugins.SelectedItems.Count > 0)
			{
				lsvPlugins.SelectedItems[0].SubItems[0].Text = txtPlugin.Text;
				lsvPlugins.SelectedItems[0].SubItems[1].Text = cmbClasses.Text;
				lsvPlugins.SelectedItems[0].SubItems[2].Text = txtDescription.Text;
				if (chkAuto.Checked)
				{
					lsvPlugins.SelectedItems[0].SubItems[3].Text = "Yes";
				}
				else
				{
					lsvPlugins.SelectedItems[0].SubItems[3].Text = "No";
				}
				lsvPlugins.SelectedItems[0].SubItems[4].Text = txtConfiguration.Text;
				EnableGroup(false);
			}
			else
			{
				ListViewItem pI = new ListViewItem();
				pI.Text = txtPlugin.Text;
				pI.SubItems.Add(cmbClasses.Text);
				pI.SubItems.Add(txtDescription.Text);
				if (chkAuto.Checked)
				{
					pI.SubItems.Add("Yes");
				}
				else
				{
					pI.SubItems.Add("No");
				}
				pI.SubItems.Add(txtConfiguration.Text);
				lsvPlugins.Items.Add(pI);
				EnableGroup(false);
			}
		}
		/// <summary>
		/// Botton event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReset_Click(object sender, EventArgs e)
		{
			EnableGroup(false);
		}
		/// <summary>
		/// Botton event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("Do you want to overwrite actual plugin configuration?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
				case System.Windows.Forms.DialogResult.Yes:
					StringBuilder pSB = new StringBuilder();
					pSB.Append("<plugins><plugin>");
					foreach (ListViewItem pI in lsvPlugins.Items)
					{
						pSB.Append("<assembly ref=\"" + pI.Text + "\">");
						pSB.Append("<configuration><![CDATA[" + pI.SubItems[4].Text + "]]></configuration>");
						pSB.Append("<entrypoint description=\"" + pI.SubItems[2].Text + "\" class=\"" + pI.SubItems[1].Text + "\" auto=\"" + (pI.SubItems[3].Text == "Yes" ? "true" : "false") + "\"/>");
						pSB.Append("</assembly>");
					}
					pSB.Append("</plugin></plugins>");
					XDocument.Parse(pSB.ToString()).Save(Program.PluginConfig);
					MessageBox.Show("Changes done needs a restart of the application in order to take place", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
					break;
				case System.Windows.Forms.DialogResult.No:
					this.Close();
					break;
				case System.Windows.Forms.DialogResult.Cancel:
					break;
			}
		}
	}
}
