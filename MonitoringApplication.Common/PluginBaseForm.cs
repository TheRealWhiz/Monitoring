using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

[assembly: InternalsVisibleToAttribute("MonitoringApplication")]

namespace Whiz.Monitoring.Application.Common
{
	/// <summary>
	/// The delegate for the OpenPluginFormRequest
	/// </summary>
	/// <param name="_Sender"></param>
	/// <param name="_E"></param>
	public delegate void OpenPluginFormRequestHandler(Object _Sender, OpenPluginFormEventArgs _E);
	/// <summary>
	/// The delegate for the PluginServiceRequestHandler
	/// </summary>
	/// <param name="_Sender"></param>
	/// <param name="_E"></param>
	public delegate void PluginServiceRequestHandler(Object _Sender, PluginServiceEventArgs _E);
	/// <summary>
	/// This is the base form class used by the Monitoring application to use plugins
	/// </summary>
	public partial class PluginBaseForm : Form
	{
		/// <summary>
		/// Dictionary holding all the custom configs from the plugins configuration
		/// </summary>
		internal static Dictionary<String, String> Config { get; set; }
		/// <summary>
		/// Form size (independent from maximize or minimize)
		/// </summary>
		public Size FormSize { get; set; }
		/// <summary>
		/// The assembly where the derived class came from
		/// </summary>
		private String pAssembly = "";
		/// <summary>
		/// Configuration
		/// </summary>
		public String Configuration
		{
			get
			{
				if (pAssembly == String.Empty)
				{
					pAssembly = Assembly.GetAssembly(this.GetType()).CodeBase;
				}
				return Config[pAssembly];
			}
		}
		/// <summary>
		/// Form position (independent from maximize or minimize)
		/// </summary>
		public Point FormLocation { get; set; }
		/// <summary>
		/// Event to tell to the Monitoring application to open and register the form to the services
		/// </summary>
		public event OpenPluginFormRequestHandler OpenPluginFormRequest;
		/// <summary>
		/// Event to require a service exposed by other plugins
		/// </summary>
		public event PluginServiceRequestHandler PluginServiceRequest;
		/// <summary>
		/// Constructor
		/// </summary>
		public PluginBaseForm()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Opens a plugin form
		/// </summary>
		/// <param name="_Form">The form to open</param>
		protected void OpenPluginForm(PluginBaseForm _Form)
		{
			if (OpenPluginFormRequest != null)
			{
				OpenPluginFormRequest.Invoke(this, new OpenPluginFormEventArgs(_Form));
			}
			else
			{
				_Form.MdiParent = this.MdiParent;
				_Form.Show();
			}
		}
		/// <summary>
		/// Try to invoke a service exposed by another plugin
		/// More than one plugin could expose such service
		/// </summary>
		/// <param name="_Identifier">The service identifier</param>
		/// <param name="_Parameter">The service parameter</param>
		/// <returns>Eventual results. Empty list when no one set a result, null when no one is listening</returns>
		protected List<Object> InvokeService(String _Identifier, Object _Parameter)
		{
			if (PluginServiceRequest != null)
			{
				PluginServiceEventArgs ea = new PluginServiceEventArgs(_Identifier, _Parameter);
				PluginServiceRequest.Invoke(this, ea);
				return ea.Results;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// The handler for the service requests
		/// </summary>
		/// <param name="_Identifier">Identifier of the service</param>
		/// <param name="_Parameter">Parameter for the service</param>
		/// <param name="_Result">Result of the request</param>
		public virtual void ServiceRequest(String _Identifier, Object _Parameter, ref Object _Result)
		{
		}
		/// <summary>
		/// When overriden this will handle the snapshot of a window when the application is closed
		/// </summary>
		/// <returns>Return null when snapshot should not be handled, a known object elsewhere</returns>
		public virtual Object Snapshot()
		{
			return null;
		}
		/// <summary>
		/// When overriden this will handle the restore of a form when the application will restart and a snapshot has done on closing
		/// </summary>
		/// <param name="_SnapshotInfo">Information for the restore</param>
		public virtual void Restore(Object _SnapshotInfo)
		{
		}
		/// <summary>
		/// This event handler checks if the forms was maximized o minimized. If not (a manual resize) then the size is updated
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginBaseForm_SizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				FormSize = this.Size;
				FormLocation = this.Location;
			}
		}
		/// <summary>
		/// Store the last known size and position before changes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginBaseForm_ResizeBegin(object sender, EventArgs e)
		{
			FormSize = this.Size;
			FormLocation = this.Location;
		}
		/// <summary>
		/// Store the last known size and position when moving the form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginBaseForm_Move(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				FormSize = this.Size;
				FormLocation = this.Location;
			}
		}
		/// <summary>
		/// Store the last known size and position when moving the form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginBaseForm_LocationChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				FormSize = this.Size;
				FormLocation = this.Location;
			}
		}
	}
	#region Event Args
	/// <summary>
	/// The OpenPluginForm event args
	/// </summary>
	public class OpenPluginFormEventArgs
	{
		/// <summary>
		/// The form to open
		/// </summary>
		public PluginBaseForm Form { get; private set; }
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_Form">The form to open</param>
		public OpenPluginFormEventArgs(PluginBaseForm _Form)
		{
			Form = _Form;
		}
	}
	/// <summary>
	/// The PluginServiceRequest event args
	/// </summary>
	public class PluginServiceEventArgs
	{
		/// <summary>
		/// The Service Identifier
		/// </summary>
		public String Identifier { get; private set; }
		/// <summary>
		/// The Parameter
		/// </summary>
		public Object Parameter { get; private set; }
		/// <summary>
		/// Eventual results of the service
		/// </summary>
		public List<Object> Results { get; set; }
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_Identifier">Service identifier</param>
		/// <param name="_Parameter">Parameter</param>
		public PluginServiceEventArgs(String _Identifier, Object _Parameter)
		{
			Identifier = _Identifier;
			Parameter = _Parameter;
			Results = new List<Object>();
		}
	}
	#endregion
}
