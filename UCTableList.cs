using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dbassistant
{
    public partial class UCTableList : UserControl
    {
        public UCTableList()
        {
            InitializeComponent();
        }

        private DataTable datatable { get; set; }

        private void cboDatabase_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateTables();
        }

        private void txtTable_TextChanged(object sender, EventArgs e)
        {
            PopulateTables();
        }

        private void dgvTables_SelectionChanged(object sender, EventArgs e)
        {
            PopulateColumns();
            btnView.Enabled = dgvTables.SelectedRows.Count > 0 && dgvTables.SelectedRows[0].Cells["Type"].Value.ToString() == "VIEW";
        }

        private void dgvColumns_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((bool)dgvColumns.Rows[e.RowIndex].Cells["Identity"].Value)
            {
                e.CellStyle.Font = new Font(dgvColumns.DefaultCellStyle.Font, FontStyle.Underline);
            }
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            FormMain.MainForm.ViewTable(dgvTables.SelectedRows[0].Cells["Database"].Value.ToString(), dgvTables.SelectedRows[0].Cells["Schema"].Value.ToString(), dgvTables.SelectedRows[0].Cells["Table Name"].Value.ToString(), txtWhere.Text.Trim());
        }

        private void btnView_Click(object sender, EventArgs e) {
            if (dgvTables.SelectedRows[0].Cells["Type"].Value.ToString() == "VIEW") {
                FormMain.MainForm.ViewCode(
                    dgvTables.SelectedRows[0].Cells["Table Name"].Value.ToString(),
                    dgvTables.SelectedRows[0].Cells["Table Name"].Value.ToString(),
                    "",
                    new dbassistant.Data().GetRoutineCode(
                        FormMain.MainForm.ConnectionString,
                        dgvTables.SelectedRows[0].Cells["Database"].Value.ToString(),
                        dgvTables.SelectedRows[0].Cells["Schema"].Value.ToString(),
                        dgvTables.SelectedRows[0].Cells["Table Name"].Value.ToString()
                    )
                );
            }
        }

        private void btnExportTableList_Click(object sender, EventArgs e)
        {
            if (dgvTables.DataSource != null && dgvTables.DataSource is DataTable)
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Export Table List Content to CSV";
                    sfd.DefaultExt = "csv";
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(sfd.FileName, windows.CsvWriter.WriteToString(datatable.DefaultView.ToTable(), true, false,
                            null,
                            null
                        ));
                    };
                }
        }

        private void btnExportColumnList_Click(object sender, EventArgs e)
        {
            if (dgvColumns.DataSource != null && dgvColumns.DataSource is DataTable)
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Export Column List Content to CSV";
                    sfd.DefaultExt = "csv";
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(sfd.FileName, windows.CsvWriter.WriteToString(dgvColumns.DataSource as DataTable, true, false,
                            null,
                            null
                        ));
                    };
                }
        }

        private void dgvTables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnTable_Click(null, null);
        }

        private void PopulateDatabase()
        {
            this.Enabled = false;
            this.picWait.Visible = true;
            
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync(new BWArgument() { connectionString = FormMain.MainForm.ConnectionString });
        }

        #region - Background Worker -

        BackgroundWorker bw;

        struct BWArgument {
          public string connectionString;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e) {
            datatable = new dbassistant.Data().GetTables(((BWArgument)e.Argument).connectionString, true);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
          dgvTables.DataSource = datatable;

          cboDatabase.DataSource = new dbassistant.Data().GetCatalogs(FormMain.MainForm.ConnectionString);
          cboDatabase.DisplayMember = "catalog";
          cboDatabase.ValueMember = "catalog";
          cboDatabase.SelectedIndex = 0;

          PopulateTables();

          this.picWait.Visible = false;
          this.Enabled = true;
        }

        #endregion
      
      private void PopulateTables()
        {
            try
            {
                string filter = "";

                if (cboDatabase.SelectedIndex > -1 && cboDatabase.SelectedValue.ToString() != "<All>")
                {
                    filter = string.Format(@"[Database] = '{0}'", cboDatabase.SelectedValue);
                }

                if (!string.IsNullOrEmpty(txtTable.Text.Trim()))
                {
                    filter = string.Format(@"{0}[TABLE NAME] LIKE '%{1}%'", string.IsNullOrEmpty(filter) ? "" : string.Format("{0} AND ", filter), txtTable.Text.Trim());
                }
                datatable.DefaultView.RowFilter = filter;
                grpTables.Text = string.Format("Tables [{0}]", datatable.DefaultView.Count);
            }
            catch { }
        }

        private void PopulateColumns()
        {
            try
            {
              dgvColumns.DataSource = new dbassistant.Data().GetColumns(FormMain.MainForm.ConnectionString, dgvTables.SelectedRows[0].Cells["Database"].Value.ToString(), dgvTables.SelectedRows[0].Cells["Table Name"].Value.ToString());
                dgvColumns.Columns["Identity"].Visible = false;
                foreach (DataGridViewColumn column in dgvColumns.Columns) 
                { 
                    column.SortMode = DataGridViewColumnSortMode.NotSortable; 
                }
                grpColumns.Text = string.Format("Columns [{0}]:", dgvColumns.Rows.Count);
            }
            catch
            {
                dgvColumns.DataSource = null;
                grpColumns.Text = "Columns:";
            }
        }

        public static UCTableList CreateTableList()
        {
            UCTableList uc = new UCTableList();

            uc.btnTable.Image = Properties.Resources.ico_table_16;
            uc.btnView.Image = Properties.Resources.ico_source_code_16;
            uc.btnExportTableList.Image = Properties.Resources.ico_export_excel_16;
            uc.btnExportColumnList.Image = Properties.Resources.ico_export_excel_16;

            uc.picWait.Image = Properties.Resources.ico_wait_64;
            uc.picWait.Visible = false;

            uc.PopulateDatabase();

            return uc;
        }

    }
}
