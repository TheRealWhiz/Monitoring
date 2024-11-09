namespace Whiz.Monitoring.Application
{
	partial class Information
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
			this.lsvAssemblies = new System.Windows.Forms.ListView();
			this.colAssemblyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colAssemblyVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblLoadedDll = new System.Windows.Forms.Label();
			this.picLogo = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// lsvAssemblies
			// 
			this.lsvAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lsvAssemblies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssemblyName,
            this.colAssemblyVersion});
			this.lsvAssemblies.FullRowSelect = true;
			this.lsvAssemblies.GridLines = true;
			this.lsvAssemblies.HideSelection = false;
			this.lsvAssemblies.Location = new System.Drawing.Point(12, 215);
			this.lsvAssemblies.Name = "lsvAssemblies";
			this.lsvAssemblies.Size = new System.Drawing.Size(574, 222);
			this.lsvAssemblies.TabIndex = 0;
			this.lsvAssemblies.UseCompatibleStateImageBehavior = false;
			this.lsvAssemblies.View = System.Windows.Forms.View.Details;
			// 
			// colAssemblyName
			// 
			this.colAssemblyName.Text = "Assembly";
			this.colAssemblyName.Width = 444;
			// 
			// colAssemblyVersion
			// 
			this.colAssemblyVersion.Text = "Version";
			this.colAssemblyVersion.Width = 124;
			// 
			// lblLoadedDll
			// 
			this.lblLoadedDll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLoadedDll.AutoSize = true;
			this.lblLoadedDll.Location = new System.Drawing.Point(12, 199);
			this.lblLoadedDll.Name = "lblLoadedDll";
			this.lblLoadedDll.Size = new System.Drawing.Size(88, 13);
			this.lblLoadedDll.TabIndex = 1;
			this.lblLoadedDll.Text = "Loaded modules:";
			// 
			// picLogo
			// 
			this.picLogo.BackgroundImage = global::Whiz.Monitoring.Application.Properties.Resources.LogoSmall;
			this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.picLogo.Location = new System.Drawing.Point(12, 12);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(574, 184);
			this.picLogo.TabIndex = 2;
			this.picLogo.TabStop = false;
			// 
			// Informations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(598, 449);
			this.Controls.Add(this.picLogo);
			this.Controls.Add(this.lblLoadedDll);
			this.Controls.Add(this.lsvAssemblies);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Informations";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Informations";
			this.Load += new System.EventHandler(this.Informations_Load);
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lsvAssemblies;
		private System.Windows.Forms.Label lblLoadedDll;
		private System.Windows.Forms.ColumnHeader colAssemblyName;
		private System.Windows.Forms.ColumnHeader colAssemblyVersion;
		private System.Windows.Forms.PictureBox picLogo;
	}
}