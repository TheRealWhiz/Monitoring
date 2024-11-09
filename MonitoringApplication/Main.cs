using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using Whiz.Monitoring.Application.Common;
using System.Reflection;
using System.Collections.Concurrent;

namespace Whiz.Monitoring.Application
{
	public partial class Main : Form
	{
		PluginControlBox mPCB;
		/// <summary>
		/// Configurations for the assemblies
		/// </summary>
		internal static Dictionary<String, String> Config { get; set; }
		/// <summary>
		/// Constructor
		/// </summary>
		public Main()
		{
			InitializeComponent();
			Config = new Dictionary<String, String>();
			PluginBaseForm.Config = Config;
			this.Text += " Version : " + System.Windows.Forms.Application.ProductVersion;
			foreach (Control pC in this.Controls)
			{
				try
				{
					if (pC.GetType() == typeof(MdiClient))
					{
						MdiClient pControl = (MdiClient)pC;
						pControl.BackColor = this.BackColor;
					}
				}
				catch (InvalidCastException)
				{
					// nothing to do in this case
				}
			}
		}
		/// <summary>
		/// Load event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Main_Load(Object sender, EventArgs e)
		{
			mPCB = new PluginControlBox();
			mPCB.MdiParent = this;
			mPCB.StartPosition = FormStartPosition.Manual;
			mPCB.Show();
			RestoreOpenForms();
		}
		/// <summary>
		/// Events dispose of the form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void PluginForm_Disposed(Object sender, EventArgs e)
		{
			// TODO: checks for necessity
		}
		/// <summary>
		/// Event for opening a new plugin form
		/// </summary>
		/// <param name="_Sender"></param>
		/// <param name="_E"></param>
		void PluginForm_OpenPluginFormRequest(Object _Sender, OpenPluginFormEventArgs _E)
		{
			RegisterPluginForm(_E.Form);
			_E.Form.MdiParent = this;
			_E.Form.Show();
		}
		/// <summary>
		/// Events for a service request
		/// </summary>
		/// <param name="_Sender"></param>
		/// <param name="_E"></param>
		void PluginForm_PluginServiceRequest(Object _Sender, PluginServiceEventArgs _E)
		{
			ConcurrentDictionary<Guid, Object> t = new ConcurrentDictionary<Guid, Object>();
			Parallel.ForEach(this.MdiChildren, f =>
			{
				try
				{
					if (f.GetType().BaseType == typeof(PluginBaseForm))
					{
						Object result = null;
						((PluginBaseForm)f).ServiceRequest(_E.Identifier, _E.Parameter, ref result);
						if (result != null)
						{
							t.TryAdd(Guid.NewGuid(), result);
						}
					}
				}
				catch
				{
				}
			});
			_E.Results = t.Values.ToList();
		}
		/// <summary>
		/// Registers a plugin form in the system
		/// </summary>
		/// <param name="_Form"></param>
		internal void RegisterPluginForm(PluginBaseForm _Form)
		{
			_Form.OpenPluginFormRequest += new OpenPluginFormRequestHandler(PluginForm_OpenPluginFormRequest);
			_Form.PluginServiceRequest += new PluginServiceRequestHandler(PluginForm_PluginServiceRequest);
			_Form.Disposed += new EventHandler(PluginForm_Disposed);
		}
		#region Menu File Handling
		private void mnuExit_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.Application.Exit();
		}
		private void mnuInformation_Click(object sender, EventArgs e)
		{
			Information pI = new Information();
			pI.ShowDialog();
		}
		#endregion
		#region Menu Plugins Handling
		/// <summary>
		/// Adds a menu in the plugins menu
		/// </summary>
		/// <param name="_Description"></param>
		internal void AddPluginsMenuItem(String _Description)
		{
			ToolStripMenuItem pItem = new ToolStripMenuItem();
			pItem.Text = _Description;
			pItem.Click += new EventHandler(PluginsMenu_Click);
			mnuPlugins.DropDownItems.Add(pItem);
		}
		/// <summary>
		/// Clicks on a plugin menu voice
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginsMenu_Click(object sender, EventArgs e)
		{
			mPCB.OpenPlugin(((ToolStripMenuItem)sender).Text);
		}
		/// <summary>
		/// Configuration of the plugins
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuPluginsConfigure_Click(object sender, EventArgs e)
		{
			PluginConfiguration pPC = new PluginConfiguration();
			pPC.MdiParent = this;
			pPC.Show();
		}
		#endregion
		private void Main_Resize(object sender, EventArgs e)
		{
			this.Refresh();
		}
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			SnapshotOpenForms();
		}
		/// <summary>
		/// This function will snapshot open forms
		/// It will store this in a json serialized of at List of Tuple and will automatically care about state, sizing and position
		/// </summary>
		private void SnapshotOpenForms()
		{
			List<Tuple<String, Object, Point, Size, FormWindowState>> pSettings = new List<Tuple<String, Object, Point, Size, FormWindowState>>();
			foreach (Form pF in this.MdiChildren)
			{
				if (pF.GetType().BaseType == typeof(PluginBaseForm))
				{
					Object pT = ((PluginBaseForm)pF).Snapshot();
					if (pT != null)
					{
						pSettings.Add(new Tuple<String, Object, Point, Size, FormWindowState>(pF.GetType() + ", " + pF.GetType().Assembly.FullName, pT, ((PluginBaseForm)pF).FormLocation, ((PluginBaseForm)pF).FormSize, pF.WindowState));
					}
				}
			}
			if (pSettings.Count > 0)
			{
				System.IO.File.WriteAllText(Program.SnapshotConfig, Newtonsoft.Json.JsonConvert.SerializeObject(pSettings));
			}
		}
		/// <summary>
		/// This function will restore snapshots of open forms wh5en the app was closed
		/// </summary>
		private void RestoreOpenForms()
		{
			try
			{
				String pSnapshots = System.IO.File.ReadAllText(Program.SnapshotConfig);

				if (!String.IsNullOrEmpty(pSnapshots))
				{
					Assembly[] pAss = AppDomain.CurrentDomain.GetAssemblies();

					List<Tuple<String, Object, Point, Size, FormWindowState>> pSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tuple<String, Object, Point, Size, FormWindowState>>>(pSnapshots);
					if (pSettings != null)
					{
						foreach (Tuple<String, Object, Point, Size, FormWindowState> pInfos in pSettings)
						{
							try
							{
								PluginBaseForm pF;
								if (pAss.Where(p => p.FullName.Contains(pInfos.Item1.Split(',')[1].Trim())).Count() == 0)
								{
									pF = (PluginBaseForm)Activator.CreateInstance(Type.GetType(pInfos.Item1));
								}
								else
								{
									Assembly pAssembly = pAss.Where(p => p.FullName.Contains(pInfos.Item1.Split(',')[1].Trim())).Single();
									pF = (PluginBaseForm)pAssembly.CreateInstance(pInfos.Item1.Split(',')[0]);
								}
								RegisterPluginForm(pF);
								pF.MdiParent = this;
								pF.Restore(pInfos.Item2);
								pF.StartPosition = FormStartPosition.Manual;
								if (!(pF.FormBorderStyle == System.Windows.Forms.FormBorderStyle.FixedSingle))
								{
									pF.Size = pInfos.Item4;
								}
								pF.Location = pInfos.Item3;
								pF.WindowState = pInfos.Item5;
								pF.Show();
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

	}
}
