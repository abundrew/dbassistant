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
    public partial class UCTable : UserControl
    {
        public UCTable()
        {
            InitializeComponent();
        }

        private DataTable datatable { get; set; }

        private const string SMART_SEARCH_COLUMN_NAME = "smart_search_box_column";

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Text.StringBuilder sb = new StringBuilder();

                string fmt = string.Format("{0} LIKE '%{{0}}%'", SMART_SEARCH_COLUMN_NAME);
                foreach (string word in txtFilter.Text.Split(' '))
                {
                    if (!string.IsNullOrEmpty(word) && word.Replace("'", "") != "")
                    {
                        sb.AppendFormat(fmt, word.Replace("'", ""));
                        fmt = string.Format(" AND {0} LIKE '%{{0}}%'", SMART_SEARCH_COLUMN_NAME);
                    }
                }
                datatable.DefaultView.RowFilter = sb.ToString();

                int maxRecords = 100000;
                int rowCount = datatable.Rows.Count;
                if (maxRecords > 0 && rowCount >= maxRecords) {
                  grpTable.Text = string.Format("Table [{0} / max records = {1}]", datatable.DefaultView.Count, maxRecords); 
                }
                else {
                  grpTable.Text = string.Format("Table [{0}]", datatable.DefaultView.Count);
                }
            }
            catch {}
        }

        private void btnExportTable_Click(object sender, EventArgs e)
        {
            if (dgvTable.DataSource != null && dgvTable.DataSource is DataTable)
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Export Table Content to CSV";
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

        public static UCTable Create(string database, string schema, string tablename, string where)
        {
            UCTable uc = new UCTable();
            uc.btnExportTable.Image = Properties.Resources.ico_export_excel_16;

            uc.datatable = new dbassistant.Data().GetTableContent(FormMain.MainForm.ConnectionString, database, schema, tablename, where, true);

            uc.datatable.Columns.Add(SMART_SEARCH_COLUMN_NAME, typeof(string));
            foreach (DataRow dr in uc.datatable.Rows) {
              System.Text.StringBuilder sb = new StringBuilder();
              for (int i = 0; i < uc.datatable.Columns.Count - 2; i++) {
                if (!string.IsNullOrEmpty(uc.datatable.Columns[i].Caption))
                  sb.AppendFormat("{0} ", dr[i].ToString());
              }
              dr[SMART_SEARCH_COLUMN_NAME] = sb.ToString().Replace("'", "").Trim();
            }
            uc.dgvTable.DataSource = uc.datatable;
            uc.dgvTable.Columns[SMART_SEARCH_COLUMN_NAME].Visible = false;
            uc.txtFilter_TextChanged(null, null);

            uc.picWait.Image = Properties.Resources.ico_wait_64;
            uc.picWait.Visible = false;

            return uc;
        }

        public void Check1000(string database, string schema, string tablename, string where)
        {
            if (this.datatable.Rows.Count == 1000 && MessageBox.Show("First 1000 records have only been loaded. Do you want to load all records?", "Load All Records", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PopulateTable(database, schema, tablename, where);
            }
        }

        public void PopulateTable(string database, string schema, string tablename, string where) {
          this.Enabled = false;
          this.picWait.Visible = true;

          bw = new BackgroundWorker();
          bw.DoWork += new DoWorkEventHandler(bw_DoWork);
          bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
          bw.RunWorkerAsync(new BWArgument() { maxRecords = 100000, connectionString = FormMain.MainForm.ConnectionString, database = database, schema = schema, tablename = tablename, where = where });
        }

        #region - Background Worker -

        BackgroundWorker bw;

        struct BWArgument {
          public int maxRecords;
          public string connectionString;
          public string database;
          public string schema;
          public string tablename;
          public string where;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e) {
          try {
            this.datatable = null;
            this.datatable = new dbassistant.Data().GetTableContent(((BWArgument)e.Argument).maxRecords, ((BWArgument)e.Argument).connectionString, ((BWArgument)e.Argument).database, ((BWArgument)e.Argument).schema, ((BWArgument)e.Argument).tablename, ((BWArgument)e.Argument).where, false);
          }
          catch { }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
          try {
            this.datatable.Columns.Add(SMART_SEARCH_COLUMN_NAME, typeof(string));
            foreach (DataRow dr in this.datatable.Rows) {
              System.Text.StringBuilder sb = new StringBuilder();
              for (int i = 0; i < this.datatable.Columns.Count - 2; i++) {
                if (!string.IsNullOrEmpty(this.datatable.Columns[i].Caption))
                  sb.AppendFormat("{0} ", dr[i].ToString());
              }
              dr[SMART_SEARCH_COLUMN_NAME] = sb.ToString().Replace("'", "").Trim();
            }
            this.dgvTable.DataSource = this.datatable;
            this.dgvTable.Columns[SMART_SEARCH_COLUMN_NAME].Visible = false;
            this.txtFilter_TextChanged(null, null);
          }
          catch { }
          finally {
            this.picWait.Visible = false;
            this.Enabled = true;
          }
        }

        #endregion
    }
}
