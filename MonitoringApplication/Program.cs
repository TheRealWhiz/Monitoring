using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Whiz.Monitoring.Application
{
	static class Program
	{
		public static string PluginConfig
		{
			get;
			set;
		}
		public static string SnapshotConfig
		{
			get;
			set;
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(String[] args)
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			if (args.Length > 0)
			{
				Program.PluginConfig = args[0];
				Program.SnapshotConfig = args[1];
			}
			else
			{
				Program.PluginConfig = ConfigurationManager.AppSettings.Get("plugins_config");
				Program.SnapshotConfig = ConfigurationManager.AppSettings.Get("snapshots");
			}
			try
			{
				System.Windows.Forms.Application.Run(new Main());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
