namespace dbassistant
{
    partial class UCTableList
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
            this.tlpTableList = new System.Windows.Forms.TableLayoutPanel();
            this.grpColumns = new System.Windows.Forms.GroupBox();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.grpTables = new System.Windows.Forms.GroupBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.lblWhere = new System.Windows.Forms.Label();
            this.btnExportColumnList = new System.Windows.Forms.Button();
            this.btnExportTableList = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnView = new System.Windows.Forms.Button();
            this.tlpTableList.SuspendLayout();
            this.grpColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.grpTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.panelSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpTableList
            // 
            this.tlpTableList.ColumnCount = 3;
            this.tlpTableList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpTableList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpTableList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpTableList.Controls.Add(this.grpColumns, 2, 0);
            this.tlpTableList.Controls.Add(this.grpTables, 1, 0);
            this.tlpTableList.Controls.Add(this.panelSelect, 0, 0);
            this.tlpTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTableList.Location = new System.Drawing.Point(0, 0);
            this.tlpTableList.Name = "tlpTableList";
            this.tlpTableList.RowCount = 1;
            this.tlpTableList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTableList.Size = new System.Drawing.Size(600, 400);
            this.tlpTableList.TabIndex = 0;
            // 
            // grpColumns
            // 
            this.grpColumns.Controls.Add(this.dgvColumns);
            this.grpColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColumns.Location = new System.Drawing.Point(452, 3);
            this.grpColumns.Name = "grpColumns";
            this.grpColumns.Size = new System.Drawing.Size(145, 394);
            this.grpColumns.TabIndex = 2;
            this.grpColumns.TabStop = false;
            this.grpColumns.Text = "Columns:";
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.AllowUserToResizeRows = false;
            this.dgvColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(3, 16);
            this.dgvColumns.MultiSelect = false;
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.ReadOnly = true;
            this.dgvColumns.RowHeadersVisible = false;
            this.dgvColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColumns.Size = new System.Drawing.Size(139, 375);
            this.dgvColumns.TabIndex = 0;
            this.dgvColumns.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvColumns_CellFormatting);
            // 
            // grpTables
            // 
            this.grpTables.Controls.Add(this.dgvTables);
            this.grpTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTables.Location = new System.Drawing.Point(173, 3);
            this.grpTables.Name = "grpTables";
            this.grpTables.Size = new System.Drawing.Size(273, 394);
            this.grpTables.TabIndex = 1;
            this.grpTables.TabStop = false;
            this.grpTables.Text = "Tables:";
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AllowUserToResizeRows = false;
            this.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.Location = new System.Drawing.Point(3, 16);
            this.dgvTables.MultiSelect = false;
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.RowHeadersVisible = false;
            this.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTables.Size = new System.Drawing.Size(267, 375);
            this.dgvTables.TabIndex = 0;
            this.dgvTables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTables_CellDoubleClick);
            this.dgvTables.SelectionChanged += new System.EventHandler(this.dgvTables_SelectionChanged);
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.btnView);
            this.panelSelect.Controls.Add(this.picWait);
            this.panelSelect.Controls.Add(this.txtWhere);
            this.panelSelect.Controls.Add(this.lblWhere);
            this.panelSelect.Controls.Add(this.btnExportColumnList);
            this.panelSelect.Controls.Add(this.btnExportTableList);
            this.panelSelect.Controls.Add(this.btnTable);
            this.panelSelect.Controls.Add(this.txtTable);
            this.panelSelect.Controls.Add(this.lblTable);
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
            this.picWait.TabIndex = 12;
            this.picWait.TabStop = false;
            // 
            // txtWhere
            // 
            this.txtWhere.Location = new System.Drawing.Point(12, 161);
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.Size = new System.Drawing.Size(140, 20);
            this.txtWhere.TabIndex = 9;
            // 
            // lblWhere
            // 
            this.lblWhere.AutoSize = true;
            this.lblWhere.Location = new System.Drawing.Point(12, 144);
            this.lblWhere.Name = "lblWhere";
            this.lblWhere.Size = new System.Drawing.Size(42, 13);
            this.lblWhere.TabIndex = 8;
            this.lblWhere.Text = "Where:";
            // 
            // btnExportColumnList
            // 
            this.btnExportColumnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportColumnList.Location = new System.Drawing.Point(85, 108);
            this.btnExportColumnList.Name = "btnExportColumnList";
            this.btnExportColumnList.Size = new System.Drawing.Size(25, 25);
            this.btnExportColumnList.TabIndex = 7;
            this.toolTip.SetToolTip(this.btnExportColumnList, "Export Column List...");
            this.btnExportColumnList.UseVisualStyleBackColor = true;
            this.btnExportColumnList.Click += new System.EventHandler(this.btnExportColumnList_Click);
            // 
            // btnExportTableList
            // 
            this.btnExportTableList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportTableList.Location = new System.Drawing.Point(54, 108);
            this.btnExportTableList.Name = "btnExportTableList";
            this.btnExportTableList.Size = new System.Drawing.Size(25, 25);
            this.btnExportTableList.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnExportTableList, "Export Table List...");
            this.btnExportTableList.UseVisualStyleBackColor = true;
            this.btnExportTableList.Click += new System.EventHandler(this.btnExportTableList_Click);
            // 
            // btnTable
            // 
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Location = new System.Drawing.Point(70, 196);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(25, 25);
            this.btnTable.TabIndex = 10;
            this.toolTip.SetToolTip(this.btnTable, "Open Table");
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(12, 73);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(140, 20);
            this.txtTable.TabIndex = 5;
            this.txtTable.TextChanged += new System.EventHandler(this.txtTable_TextChanged);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(12, 56);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(68, 13);
            this.lblTable.TabIndex = 4;
            this.lblTable.Text = "Table Name:";
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
            // btnView
            // 
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Location = new System.Drawing.Point(70, 227);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(25, 25);
            this.btnView.TabIndex = 13;
            this.toolTip.SetToolTip(this.btnView, "View Definition");
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // UCTableList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.tlpTableList);
            this.Name = "UCTableList";
            this.Size = new System.Drawing.Size(600, 400);
            this.tlpTableList.ResumeLayout(false);
            this.grpColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.grpTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.panelSelect.ResumeLayout(false);
            this.panelSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTableList;
        private System.Windows.Forms.GroupBox grpTables;
        private System.Windows.Forms.GroupBox grpColumns;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Button btnExportColumnList;
        private System.Windows.Forms.Button btnExportTableList;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox txtWhere;
        private System.Windows.Forms.Label lblWhere;
        private System.Windows.Forms.PictureBox picWait;
        private System.Windows.Forms.Button btnView;
    }
}
