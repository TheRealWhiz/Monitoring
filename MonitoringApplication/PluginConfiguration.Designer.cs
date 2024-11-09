namespace Whiz.Monitoring.Application
{
	partial class PluginConfiguration
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginConfiguration));
			this.lsvPlugins = new System.Windows.Forms.ListView();
			this.colAssembly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colAuto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colConfig = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnRemovePlugin = new System.Windows.Forms.Button();
			this.btnAddPlugin = new System.Windows.Forms.Button();
			this.grbPluginConfiguration = new System.Windows.Forms.GroupBox();
			this.lblConfiguration = new System.Windows.Forms.Label();
			this.txtConfiguration = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.chkAuto = new System.Windows.Forms.CheckBox();
			this.cmbClasses = new System.Windows.Forms.ComboBox();
			this.btnChooseAssembly = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.lblObject = new System.Windows.Forms.Label();
			this.lblFile = new System.Windows.Forms.Label();
			this.txtPlugin = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.grbPluginConfiguration.SuspendLayout();
			this.SuspendLayout();
			// 
			// lsvPlugins
			// 
			this.lsvPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssembly,
            this.colClass,
            this.colDescription,
            this.colAuto,
            this.colConfig});
			this.lsvPlugins.FullRowSelect = true;
			this.lsvPlugins.GridLines = true;
			this.lsvPlugins.Location = new System.Drawing.Point(12, 9);
			this.lsvPlugins.MultiSelect = false;
			this.lsvPlugins.Name = "lsvPlugins";
			this.lsvPlugins.Size = new System.Drawing.Size(508, 313);
			this.lsvPlugins.TabIndex = 0;
			this.lsvPlugins.UseCompatibleStateImageBehavior = false;
			this.lsvPlugins.View = System.Windows.Forms.View.Details;
			this.lsvPlugins.SelectedIndexChanged += new System.EventHandler(this.lsvPlugins_SelectedIndexChanged);
			// 
			// colAssembly
			// 
			this.colAssembly.Text = "Assembly";
			this.colAssembly.Width = 160;
			// 
			// colClass
			// 
			this.colClass.Text = "Class";
			this.colClass.Width = 160;
			// 
			// colDescription
			// 
			this.colDescription.Text = "Description";
			this.colDescription.Width = 120;
			// 
			// colAuto
			// 
			this.colAuto.Text = "Auto";
			this.colAuto.Width = 40;
			// 
			// colConfig
			// 
			this.colConfig.Text = "Configuration";
			this.colConfig.Width = 200;
			// 
			// btnRemovePlugin
			// 
			this.btnRemovePlugin.Enabled = false;
			this.btnRemovePlugin.Location = new System.Drawing.Point(526, 299);
			this.btnRemovePlugin.Name = "btnRemovePlugin";
			this.btnRemovePlugin.Size = new System.Drawing.Size(26, 23);
			this.btnRemovePlugin.TabIndex = 49;
			this.btnRemovePlugin.Text = "-";
			this.btnRemovePlugin.UseVisualStyleBackColor = true;
			this.btnRemovePlugin.Click += new System.EventHandler(this.btnRemovePlugin_Click);
			// 
			// btnAddPlugin
			// 
			this.btnAddPlugin.Location = new System.Drawing.Point(526, 270);
			this.btnAddPlugin.Name = "btnAddPlugin";
			this.btnAddPlugin.Size = new System.Drawing.Size(26, 23);
			this.btnAddPlugin.TabIndex = 48;
			this.btnAddPlugin.Text = "+";
			this.btnAddPlugin.UseVisualStyleBackColor = true;
			this.btnAddPlugin.Click += new System.EventHandler(this.btnAddPlugin_Click);
			// 
			// grbPluginConfiguration
			// 
			this.grbPluginConfiguration.Controls.Add(this.lblConfiguration);
			this.grbPluginConfiguration.Controls.Add(this.txtConfiguration);
			this.grbPluginConfiguration.Controls.Add(this.label1);
			this.grbPluginConfiguration.Controls.Add(this.txtDescription);
			this.grbPluginConfiguration.Controls.Add(this.chkAuto);
			this.grbPluginConfiguration.Controls.Add(this.cmbClasses);
			this.grbPluginConfiguration.Controls.Add(this.btnChooseAssembly);
			this.grbPluginConfiguration.Controls.Add(this.btnReset);
			this.grbPluginConfiguration.Controls.Add(this.btnConfirm);
			this.grbPluginConfiguration.Controls.Add(this.lblObject);
			this.grbPluginConfiguration.Controls.Add(this.lblFile);
			this.grbPluginConfiguration.Controls.Add(this.txtPlugin);
			this.grbPluginConfiguration.Enabled = false;
			this.grbPluginConfiguration.Location = new System.Drawing.Point(12, 328);
			this.grbPluginConfiguration.Name = "grbPluginConfiguration";
			this.grbPluginConfiguration.Size = new System.Drawing.Size(538, 158);
			this.grbPluginConfiguration.TabIndex = 50;
			this.grbPluginConfiguration.TabStop = false;
			this.grbPluginConfiguration.Text = "Plugin Configuration";
			// 
			// lblConfiguration
			// 
			this.lblConfiguration.AutoSize = true;
			this.lblConfiguration.Location = new System.Drawing.Point(6, 48);
			this.lblConfiguration.Name = "lblConfiguration";
			this.lblConfiguration.Size = new System.Drawing.Size(69, 13);
			this.lblConfiguration.TabIndex = 50;
			this.lblConfiguration.Text = "Configuration";
			// 
			// txtConfiguration
			// 
			this.txtConfiguration.Location = new System.Drawing.Point(116, 45);
			this.txtConfiguration.Name = "txtConfiguration";
			this.txtConfiguration.Size = new System.Drawing.Size(416, 20);
			this.txtConfiguration.TabIndex = 49;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 48;
			this.label1.Text = "Description";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(116, 99);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(416, 20);
			this.txtDescription.TabIndex = 47;
			// 
			// chkAuto
			// 
			this.chkAuto.AutoSize = true;
			this.chkAuto.Location = new System.Drawing.Point(116, 129);
			this.chkAuto.Name = "chkAuto";
			this.chkAuto.Size = new System.Drawing.Size(48, 17);
			this.chkAuto.TabIndex = 46;
			this.chkAuto.Text = "Auto";
			this.chkAuto.UseVisualStyleBackColor = true;
			// 
			// cmbClasses
			// 
			this.cmbClasses.FormattingEnabled = true;
			this.cmbClasses.Location = new System.Drawing.Point(116, 72);
			this.cmbClasses.Name = "cmbClasses";
			this.cmbClasses.Size = new System.Drawing.Size(416, 21);
			this.cmbClasses.TabIndex = 45;
			// 
			// btnChooseAssembly
			// 
			this.btnChooseAssembly.Location = new System.Drawing.Point(506, 17);
			this.btnChooseAssembly.Name = "btnChooseAssembly";
			this.btnChooseAssembly.Size = new System.Drawing.Size(26, 23);
			this.btnChooseAssembly.TabIndex = 44;
			this.btnChooseAssembly.Text = "...";
			this.btnChooseAssembly.UseVisualStyleBackColor = true;
			this.btnChooseAssembly.Click += new System.EventHandler(this.btnChooseAssembly_Click);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(457, 125);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 41;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnConfirm
			// 
			this.btnConfirm.Location = new System.Drawing.Point(376, 125);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(75, 23);
			this.btnConfirm.TabIndex = 40;
			this.btnConfirm.Text = "Confirm";
			this.btnConfirm.UseVisualStyleBackColor = true;
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// lblObject
			// 
			this.lblObject.AutoSize = true;
			this.lblObject.Location = new System.Drawing.Point(6, 75);
			this.lblObject.Name = "lblObject";
			this.lblObject.Size = new System.Drawing.Size(32, 13);
			this.lblObject.TabIndex = 11;
			this.lblObject.Text = "Class";
			// 
			// lblFile
			// 
			this.lblFile.AutoSize = true;
			this.lblFile.Location = new System.Drawing.Point(6, 22);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(51, 13);
			this.lblFile.TabIndex = 8;
			this.lblFile.Text = "Assembly";
			// 
			// txtPlugin
			// 
			this.txtPlugin.Location = new System.Drawing.Point(116, 19);
			this.txtPlugin.Name = "txtPlugin";
			this.txtPlugin.Size = new System.Drawing.Size(384, 20);
			this.txtPlugin.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(475, 492);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 51;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// PluginConfiguration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(562, 523);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.grbPluginConfiguration);
			this.Controls.Add(this.btnRemovePlugin);
			this.Controls.Add(this.btnAddPlugin);
			this.Controls.Add(this.lsvPlugins);
			this.FormLocation = new System.Drawing.Point(15, 15);
			this.FormSize = new System.Drawing.Size(578, 562);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = true;
			this.Name = "PluginConfiguration";
			this.Text = "Configure Plugins";
			this.Load += new System.EventHandler(this.PluginConfiguration_Load);
			this.grbPluginConfiguration.ResumeLayout(false);
			this.grbPluginConfiguration.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lsvPlugins;
		private System.Windows.Forms.ColumnHeader colAssembly;
		private System.Windows.Forms.ColumnHeader colClass;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.Button btnRemovePlugin;
		private System.Windows.Forms.Button btnAddPlugin;
		private System.Windows.Forms.GroupBox grbPluginConfiguration;
		private System.Windows.Forms.Button btnChooseAssembly;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.Label lblObject;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.TextBox txtPlugin;
		private System.Windows.Forms.ComboBox cmbClasses;
		private System.Windows.Forms.CheckBox chkAuto;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.ColumnHeader colAuto;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblConfiguration;
		private System.Windows.Forms.TextBox txtConfiguration;
		private System.Windows.Forms.ColumnHeader colConfig;
	}
}