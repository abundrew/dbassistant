namespace dbassistant
{
    partial class UCRoutineList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnExportRoutineList = new System.Windows.Forms.Button();
            this.btnRoutine = new System.Windows.Forms.Button();
            this.tlpRoutineList = new System.Windows.Forms.TableLayoutPanel();
            this.grpRoutine = new System.Windows.Forms.GroupBox();
            this.txtRoutineText = new System.Windows.Forms.TextBox();
            this.grpRoutines = new System.Windows.Forms.GroupBox();
            this.dgvRoutines = new System.Windows.Forms.DataGridView();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.txtRoutineCode = new System.Windows.Forms.TextBox();
            this.lblRoutineCode = new System.Windows.Forms.Label();
            this.txtRoutine = new System.Windows.Forms.TextBox();
            this.lblRoutine = new System.Windows.Forms.Label();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.tlpRoutineList.SuspendLayout();
            this.grpRoutine.SuspendLayout();
            this.grpRoutines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutines)).BeginInit();
            this.panelSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportRoutineList
            // 
            this.btnExportRoutineList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportRoutineList.Location = new System.Drawing.Point(85, 152);
            this.btnExportRoutineList.Name = "btnExportRoutineList";
            this.btnExportRoutineList.Size = new System.Drawing.Size(25, 25);
            this.btnExportRoutineList.TabIndex = 9;
            this.toolTip.SetToolTip(this.btnExportRoutineList, "Export Routine List...");
            this.btnExportRoutineList.UseVisualStyleBackColor = true;
            this.btnExportRoutineList.Click += new System.EventHandler(this.btnExportRoutineList_Click);
            // 
            // btnRoutine
            // 
            this.btnRoutine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoutine.Location = new System.Drawing.Point(54, 152);
            this.btnRoutine.Name = "btnRoutine";
            this.btnRoutine.Size = new System.Drawing.Size(25, 25);
            this.btnRoutine.TabIndex = 8;
            this.toolTip.SetToolTip(this.btnRoutine, "Open Routine");
            this.btnRoutine.UseVisualStyleBackColor = true;
            this.btnRoutine.Click += new System.EventHandler(this.btnRoutine_Click);
            // 
            // tlpRoutineList
            // 
            this.tlpRoutineList.ColumnCount = 3;
            this.tlpRoutineList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpRoutineList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpRoutineList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpRoutineList.Controls.Add(this.grpRoutine, 2, 0);
            this.tlpRoutineList.Controls.Add(this.grpRoutines, 1, 0);
            this.tlpRoutineList.Controls.Add(this.panelSelect, 0, 0);
            this.tlpRoutineList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoutineList.Location = new System.Drawing.Point(0, 0);
            this.tlpRoutineList.Name = "tlpRoutineList";
            this.tlpRoutineList.RowCount = 1;
            this.tlpRoutineList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoutineList.Size = new System.Drawing.Size(600, 400);
            this.tlpRoutineList.TabIndex = 0;
            // 
            // grpRoutine
            // 
            this.grpRoutine.Controls.Add(this.txtRoutineText);
            this.grpRoutine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRoutine.Location = new System.Drawing.Point(452, 3);
            this.grpRoutine.Name = "grpRoutine";
            this.grpRoutine.Size = new System.Drawing.Size(145, 394);
            this.grpRoutine.TabIndex = 2;
            this.grpRoutine.TabStop = false;
            this.grpRoutine.Text = "Routine Code:";
            // 
            // txtRoutineText
            // 
            this.txtRoutineText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRoutineText.Location = new System.Drawing.Point(3, 16);
            this.txtRoutineText.Multiline = true;
            this.txtRoutineText.Name = "txtRoutineText";
            this.txtRoutineText.ReadOnly = true;
            this.txtRoutineText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRoutineText.Size = new System.Drawing.Size(139, 375);
            this.txtRoutineText.TabIndex = 0;
            // 
            // grpRoutines
            // 
            this.grpRoutines.Controls.Add(this.dgvRoutines);
            this.grpRoutines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRoutines.Location = new System.Drawing.Point(173, 3);
            this.grpRoutines.Name = "grpRoutines";
            this.grpRoutines.Size = new System.Drawing.Size(273, 394);
            this.grpRoutines.TabIndex = 1;
            this.grpRoutines.TabStop = false;
            this.grpRoutines.Text = "Routines:";
            // 
            // dgvRoutines
            // 
            this.dgvRoutines.AllowUserToAddRows = false;
            this.dgvRoutines.AllowUserToDeleteRows = false;
            this.dgvRoutines.AllowUserToResizeRows = false;
            this.dgvRoutines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoutines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoutines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoutines.Location = new System.Drawing.Point(3, 16);
            this.dgvRoutines.MultiSelect = false;
            this.dgvRoutines.Name = "dgvRoutines";
            this.dgvRoutines.ReadOnly = true;
            this.dgvRoutines.RowHeadersVisible = false;
            this.dgvRoutines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoutines.Size = new System.Drawing.Size(267, 375);
            this.dgvRoutines.TabIndex = 0;
            this.dgvRoutines.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoutines_CellDoubleClick);
            this.dgvRoutines.SelectionChanged += new System.EventHandler(this.dgvRoutines_SelectionChanged);
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.picWait);
            this.panelSelect.Controls.Add(this.txtRoutineCode);
            this.panelSelect.Controls.Add(this.lblRoutineCode);
            this.panelSelect.Controls.Add(this.btnExportRoutineList);
            this.panelSelect.Controls.Add(this.btnRoutine);
            this.panelSelect.Controls.Add(this.txtRoutine);
            this.panelSelect.Controls.Add(this.lblRoutine);
            this.panelSelect.Controls.Add(this.cboDatabase);
            this.panelSelect.Controls.Add(this.lblDatabase);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelect.Location = new System.Drawing.Point(3, 3);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(164, 394);
            this.panelSelect.TabIndex = 0;
            // 
            // picWait
            // 
            this.picWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picWait.Location = new System.Drawing.Point(50, 317);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(64, 64);
            this.picWait.TabIndex = 10;
            this.picWait.TabStop = false;
            // 
            // txtRoutineCode
            // 
            this.txtRoutineCode.Location = new System.Drawing.Point(12, 117);
            this.txtRoutineCode.Name = "txtRoutineCode";
            this.txtRoutineCode.Size = new System.Drawing.Size(140, 20);
            this.txtRoutineCode.TabIndex = 7;
            this.txtRoutineCode.TextChanged += new System.EventHandler(this.txtRoutineCode_TextChanged);
            // 
            // lblRoutineCode
            // 
            this.lblRoutineCode.AutoSize = true;
            this.lblRoutineCode.Location = new System.Drawing.Point(12, 100);
            this.lblRoutineCode.Name = "lblRoutineCode";
            this.lblRoutineCode.Size = new System.Drawing.Size(75, 13);
            this.lblRoutineCode.TabIndex = 6;
            this.lblRoutineCode.Text = "Routine Code:";
            // 
            // txtRoutine
            // 
            this.txtRoutine.Location = new System.Drawing.Point(12, 73);
            this.txtRoutine.Name = "txtRoutine";
            this.txtRoutine.Size = new System.Drawing.Size(140, 20);
            this.txtRoutine.TabIndex = 5;
            this.txtRoutine.TextChanged += new System.EventHandler(this.txtRoutine_TextChanged);
            // 
            // lblRoutine
            // 
            this.lblRoutine.AutoSize = true;
            this.lblRoutine.Location = new System.Drawing.Point(12, 56);
            this.lblRoutine.Name = "lblRoutine";
            this.lblRoutine.Size = new System.Drawing.Size(78, 13);
            this.lblRoutine.TabIndex = 4;
            this.lblRoutine.Text = "Routine Name:";
            // 
            // cboDatabase
            // 
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(12, 29);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(140, 21);
            this.cboDatabase.TabIndex = 3;
            this.cboDatabase.SelectedValueChanged += new System.EventHandler(this.cboDatabase_SelectedValueChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(12, 12);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database:";
            // 
            // UCRoutineList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.tlpRoutineList);
            this.Name = "UCRoutineList";
            this.Size = new System.Drawing.Size(600, 400);
            this.tlpRoutineList.ResumeLayout(false);
            this.grpRoutine.ResumeLayout(false);
            this.grpRoutine.PerformLayout();
            this.grpRoutines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutines)).EndInit();
            this.panelSelect.ResumeLayout(false);
            this.panelSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel tlpRoutineList;
        private System.Windows.Forms.GroupBox grpRoutine;
        private System.Windows.Forms.GroupBox grpRoutines;
        private System.Windows.Forms.DataGridView dgvRoutines;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Button btnExportRoutineList;
        private System.Windows.Forms.Button btnRoutine;
        private System.Windows.Forms.TextBox txtRoutine;
        private System.Windows.Forms.Label lblRoutine;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtRoutineText;
        private System.Windows.Forms.TextBox txtRoutineCode;
        private System.Windows.Forms.Label lblRoutineCode;
        private System.Windows.Forms.PictureBox picWait;
    }
}
