namespace dbassistant
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileDiv1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuObject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuObjectTables = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuObjectRoutines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.staMain = new System.Windows.Forms.StatusStrip();
            this.staUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.staServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTables = new System.Windows.Forms.ToolStripButton();
            this.tsbRoutines = new System.Windows.Forms.ToolStripButton();
            this.tsbSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.lstImage = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mnuHelpDiv1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpSettingsTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mnuMain.SuspendLayout();
            this.staMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuObject,
            this.mnuQuery,
            this.mnuWindow,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(784, 24);
            this.mnuMain.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileDiv1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(152, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileDiv1
            // 
            this.mnuFileDiv1.Name = "mnuFileDiv1";
            this.mnuFileDiv1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(152, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuObject
            // 
            this.mnuObject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuObjectTables,
            this.mnuObjectRoutines});
            this.mnuObject.Name = "mnuObject";
            this.mnuObject.Size = new System.Drawing.Size(54, 20);
            this.mnuObject.Text = "&Object";
            // 
            // mnuObjectTables
            // 
            this.mnuObjectTables.Name = "mnuObjectTables";
            this.mnuObjectTables.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mnuObjectTables.Size = new System.Drawing.Size(157, 22);
            this.mnuObjectTables.Text = "&Tables";
            this.mnuObjectTables.Click += new System.EventHandler(this.mnuObjectTables_Click);
            // 
            // mnuObjectRoutines
            // 
            this.mnuObjectRoutines.Name = "mnuObjectRoutines";
            this.mnuObjectRoutines.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.mnuObjectRoutines.Size = new System.Drawing.Size(157, 22);
            this.mnuObjectRoutines.Text = "&Routines";
            this.mnuObjectRoutines.Click += new System.EventHandler(this.mnuObjectRoutines_Click);
            // 
            // mnuQuery
            // 
            this.mnuQuery.Name = "mnuQuery";
            this.mnuQuery.Size = new System.Drawing.Size(51, 20);
            this.mnuQuery.Text = "&Query";
            // 
            // mnuWindow
            // 
            this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowClose,
            this.mnuWindowCloseAll});
            this.mnuWindow.Name = "mnuWindow";
            this.mnuWindow.Size = new System.Drawing.Size(63, 20);
            this.mnuWindow.Text = "&Window";
            // 
            // mnuWindowClose
            // 
            this.mnuWindowClose.Name = "mnuWindowClose";
            this.mnuWindowClose.Size = new System.Drawing.Size(152, 22);
            this.mnuWindowClose.Text = "&Close";
            this.mnuWindowClose.Click += new System.EventHandler(this.mnuWindowClose_Click);
            // 
            // mnuWindowCloseAll
            // 
            this.mnuWindowCloseAll.Name = "mnuWindowCloseAll";
            this.mnuWindowCloseAll.Size = new System.Drawing.Size(152, 22);
            this.mnuWindowCloseAll.Text = "Close &All";
            this.mnuWindowCloseAll.Click += new System.EventHandler(this.mnuWindowCloseAll_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpSettingsTemplate,
            this.mnuHelpDiv1,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(175, 22);
            this.mnuHelpAbout.Text = "&About DB Assistant";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // staMain
            // 
            this.staMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staUser,
            this.staServer});
            this.staMain.Location = new System.Drawing.Point(0, 540);
            this.staMain.Name = "staMain";
            this.staMain.ShowItemToolTips = true;
            this.staMain.Size = new System.Drawing.Size(784, 22);
            this.staMain.TabIndex = 3;
            // 
            // staUser
            // 
            this.staUser.Image = global::dbassistant.Properties.Resources.ico_user_16;
            this.staUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.staUser.Name = "staUser";
            this.staUser.Size = new System.Drawing.Size(53, 17);
            this.staUser.Text = "(user)";
            this.staUser.ToolTipText = "User";
            // 
            // staServer
            // 
            this.staServer.Image = global::dbassistant.Properties.Resources.ico_server_database_16;
            this.staServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.staServer.Name = "staServer";
            this.staServer.Size = new System.Drawing.Size(62, 17);
            this.staServer.Text = "(server)";
            this.staServer.ToolTipText = "Server";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tsbOpen,
            this.tsbSep1,
            this.tsbTables,
            this.tsbRoutines,
            this.tsbSep2});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(784, 25);
            this.tsMain.TabIndex = 1;
            // 
            // tsbClose
            // 
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 22);
            this.tsbClose.Text = "Close Window";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSep1
            // 
            this.tsbSep1.Name = "tsbSep1";
            this.tsbSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbTables
            // 
            this.tsbTables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTables.Image = ((System.Drawing.Image)(resources.GetObject("tsbTables.Image")));
            this.tsbTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTables.Name = "tsbTables";
            this.tsbTables.Size = new System.Drawing.Size(23, 22);
            this.tsbTables.Text = "Tables";
            this.tsbTables.Click += new System.EventHandler(this.tsbTables_Click);
            // 
            // tsbRoutines
            // 
            this.tsbRoutines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRoutines.Image = ((System.Drawing.Image)(resources.GetObject("tsbRoutines.Image")));
            this.tsbRoutines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRoutines.Name = "tsbRoutines";
            this.tsbRoutines.Size = new System.Drawing.Size(23, 22);
            this.tsbRoutines.Text = "Routines";
            this.tsbRoutines.Click += new System.EventHandler(this.tsbRoutines_Click);
            // 
            // tsbSep2
            // 
            this.tsbSep2.Name = "tsbSep2";
            this.tsbSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.ImageList = this.lstImage;
            this.tcMain.ItemSize = new System.Drawing.Size(0, 24);
            this.tcMain.Location = new System.Drawing.Point(0, 49);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.ShowToolTips = true;
            this.tcMain.Size = new System.Drawing.Size(784, 491);
            this.tcMain.TabIndex = 2;
            // 
            // lstImage
            // 
            this.lstImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lstImage.ImageStream")));
            this.lstImage.TransparentColor = System.Drawing.Color.Transparent;
            this.lstImage.Images.SetKeyName(0, "ico_table_16.png");
            this.lstImage.Images.SetKeyName(1, "ico_sql_join_left_16.png");
            this.lstImage.Images.SetKeyName(2, "ico_source_code_16.png");
            this.lstImage.Images.SetKeyName(3, "ico_list_16.png");
            this.lstImage.Images.SetKeyName(4, "ico_table_multiple_16.png");
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.Filter = "XML files|*.xml|All files|*.*";
            this.openFileDialog.Title = "Open File";
            // 
            // mnuHelpDiv1
            // 
            this.mnuHelpDiv1.Name = "mnuHelpDiv1";
            this.mnuHelpDiv1.Size = new System.Drawing.Size(172, 6);
            // 
            // mnuHelpSettingsTemplate
            // 
            this.mnuHelpSettingsTemplate.Name = "mnuHelpSettingsTemplate";
            this.mnuHelpSettingsTemplate.Size = new System.Drawing.Size(175, 22);
            this.mnuHelpSettingsTemplate.Text = "Settings &Template";
            this.mnuHelpSettingsTemplate.Click += new System.EventHandler(this.mnuHelpSettingsTemplate_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "XML files|*.xml|All files|*.*";
            this.saveFileDialog.Title = "Save File";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Assistant";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.staMain.ResumeLayout(false);
            this.staMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.StatusStrip staMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripSeparator mnuFileDiv1;
        private System.Windows.Forms.ToolStripStatusLabel staUser;
        private System.Windows.Forms.ImageList lstImage;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripStatusLabel staServer;
        private System.Windows.Forms.ToolStripMenuItem mnuQuery;
        private System.Windows.Forms.ToolStripMenuItem mnuWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowClose;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowCloseAll;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripSeparator tsbSep1;
        private System.Windows.Forms.ToolStripButton tsbTables;
        private System.Windows.Forms.ToolStripButton tsbRoutines;
        private System.Windows.Forms.ToolStripSeparator tsbSep2;
        private System.Windows.Forms.ToolStripMenuItem mnuObject;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuObjectTables;
        private System.Windows.Forms.ToolStripMenuItem mnuObjectRoutines;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpSettingsTemplate;
        private System.Windows.Forms.ToolStripSeparator mnuHelpDiv1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

