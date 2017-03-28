namespace dbassistant
{
    partial class UCTable
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
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
          this.tlpTable = new System.Windows.Forms.TableLayoutPanel();
          this.grpTable = new System.Windows.Forms.GroupBox();
          this.dgvTable = new System.Windows.Forms.DataGridView();
          this.panelSelect = new System.Windows.Forms.Panel();
          this.btnExportTable = new System.Windows.Forms.Button();
          this.txtFilter = new System.Windows.Forms.TextBox();
          this.lblFilter = new System.Windows.Forms.Label();
          this.toolTip = new System.Windows.Forms.ToolTip(this.components);
          this.picWait = new System.Windows.Forms.PictureBox();
          this.tlpTable.SuspendLayout();
          this.grpTable.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
          this.panelSelect.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
          this.SuspendLayout();
          // 
          // tlpTable
          // 
          this.tlpTable.ColumnCount = 2;
          this.tlpTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
          this.tlpTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tlpTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.tlpTable.Controls.Add(this.grpTable, 1, 0);
          this.tlpTable.Controls.Add(this.panelSelect, 0, 0);
          this.tlpTable.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpTable.Location = new System.Drawing.Point(0, 0);
          this.tlpTable.Name = "tlpTable";
          this.tlpTable.RowCount = 1;
          this.tlpTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tlpTable.Size = new System.Drawing.Size(600, 400);
          this.tlpTable.TabIndex = 1;
          // 
          // grpTable
          // 
          this.grpTable.Controls.Add(this.dgvTable);
          this.grpTable.Dock = System.Windows.Forms.DockStyle.Fill;
          this.grpTable.Location = new System.Drawing.Point(173, 3);
          this.grpTable.Name = "grpTable";
          this.grpTable.Size = new System.Drawing.Size(424, 394);
          this.grpTable.TabIndex = 1;
          this.grpTable.TabStop = false;
          this.grpTable.Text = "Table:";
          // 
          // dgvTable
          // 
          this.dgvTable.AllowUserToAddRows = false;
          this.dgvTable.AllowUserToDeleteRows = false;
          this.dgvTable.AllowUserToResizeRows = false;
          this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
          dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
          dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
          dataGridViewCellStyle1.NullValue = "NULL";
          dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
          dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
          dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
          this.dgvTable.DefaultCellStyle = dataGridViewCellStyle1;
          this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dgvTable.Location = new System.Drawing.Point(3, 16);
          this.dgvTable.MultiSelect = false;
          this.dgvTable.Name = "dgvTable";
          this.dgvTable.ReadOnly = true;
          this.dgvTable.RowHeadersVisible = false;
          this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
          this.dgvTable.Size = new System.Drawing.Size(418, 375);
          this.dgvTable.TabIndex = 0;
          // 
          // panelSelect
          // 
          this.panelSelect.Controls.Add(this.picWait);
          this.panelSelect.Controls.Add(this.btnExportTable);
          this.panelSelect.Controls.Add(this.txtFilter);
          this.panelSelect.Controls.Add(this.lblFilter);
          this.panelSelect.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panelSelect.Location = new System.Drawing.Point(3, 3);
          this.panelSelect.Name = "panelSelect";
          this.panelSelect.Size = new System.Drawing.Size(164, 394);
          this.panelSelect.TabIndex = 0;
          // 
          // btnExportTable
          // 
          this.btnExportTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnExportTable.Location = new System.Drawing.Point(70, 64);
          this.btnExportTable.Name = "btnExportTable";
          this.btnExportTable.Size = new System.Drawing.Size(25, 25);
          this.btnExportTable.TabIndex = 9;
          this.toolTip.SetToolTip(this.btnExportTable, "Export Table...");
          this.btnExportTable.UseVisualStyleBackColor = true;
          this.btnExportTable.Click += new System.EventHandler(this.btnExportTable_Click);
          // 
          // txtFilter
          // 
          this.txtFilter.Location = new System.Drawing.Point(12, 29);
          this.txtFilter.Name = "txtFilter";
          this.txtFilter.Size = new System.Drawing.Size(140, 20);
          this.txtFilter.TabIndex = 5;
          this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
          // 
          // lblFilter
          // 
          this.lblFilter.AutoSize = true;
          this.lblFilter.Location = new System.Drawing.Point(12, 12);
          this.lblFilter.Name = "lblFilter";
          this.lblFilter.Size = new System.Drawing.Size(32, 13);
          this.lblFilter.TabIndex = 4;
          this.lblFilter.Text = "Filter:";
          // 
          // picWait
          // 
          this.picWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
          this.picWait.Location = new System.Drawing.Point(50, 317);
          this.picWait.Name = "picWait";
          this.picWait.Size = new System.Drawing.Size(64, 64);
          this.picWait.TabIndex = 13;
          this.picWait.TabStop = false;
          // 
          // UCTable
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.AutoScroll = true;
          this.AutoSize = true;
          this.Controls.Add(this.tlpTable);
          this.Name = "UCTable";
          this.Size = new System.Drawing.Size(600, 400);
          this.tlpTable.ResumeLayout(false);
          this.grpTable.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
          this.panelSelect.ResumeLayout(false);
          this.panelSelect.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTable;
        private System.Windows.Forms.GroupBox grpTable;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Button btnExportTable;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox picWait;
    }
}
