using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Whiz.Monitoring.Application
{
	/// <summary>
	/// Information form
	/// </summary>
	public partial class Information : Form
	{
		/// <summary>
		/// Information form constructor
		/// </summary>
		public Information()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Information form load event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Informations_Load(object sender, EventArgs e)
		{
			foreach (Assembly pA in AppDomain.CurrentDomain.GetAssemblies())
			{
				if (!pA.GetName().Name.StartsWith("System") && !pA.GetName().Name.StartsWith("Microsoft") && !pA.GetName().Name.Contains("VisualStudio") && pA.GetName().Name != ("mscorlib") && pA.GetName().Name != ("vshost"))
				{
					ListViewItem pI = new ListViewItem();
					pI.Text = pA.GetName().Name;
					pI.SubItems.Add(pA.GetName().Version.ToString());
					lsvAssemblies.Items.Add(pI);
				}
			}
		}
	}
}
