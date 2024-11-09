namespace Whiz.Monitoring.Application
{
	partial class PluginControlBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lsbPlugins = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lsbPlugins
			// 
			this.lsbPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lsbPlugins.FormattingEnabled = true;
			this.lsbPlugins.Location = new System.Drawing.Point(12, 12);
			this.lsbPlugins.Name = "lsbPlugins";
			this.lsbPlugins.Size = new System.Drawing.Size(226, 173);
			this.lsbPlugins.TabIndex = 0;
			this.lsbPlugins.DoubleClick += new System.EventHandler(this.lsbPlugins_DoubleClick);
			// 
			// PluginControlBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(250, 199);
			this.ControlBox = false;
			this.Controls.Add(this.lsbPlugins);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.MaximizeBox = false;
			this.Name = "PluginControlBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Plugin Control Box";
			this.Load += new System.EventHandler(this.PluginControlBox_Load);
			this.Shown += new System.EventHandler(this.PluginControlBox_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lsbPlugins;


	}
}