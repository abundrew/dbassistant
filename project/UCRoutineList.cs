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
    public partial class UCRoutineList : UserControl
    {
      public UCRoutineList()
      {
        InitializeComponent();
      }

      private DataTable datatable { get; set; }

      private void cboDatabase_SelectedValueChanged(object sender, EventArgs e)
      {
        PopulateRoutines();
      }

      private void txtRoutine_TextChanged(object sender, EventArgs e)
      {
        PopulateRoutines();
      }

      private void txtRoutineCode_TextChanged(object sender, EventArgs e)
      {
        PopulateRoutines();
      }

      private void dgvRoutines_SelectionChanged(object sender, EventArgs e)
      {
        PopulateRoutineText();
      }

        private void btnRoutine_Click(object sender, EventArgs e)
        {
            FormMain.MainForm.ViewCode(
                dgvRoutines.SelectedRows[0].Cells["Routine Name"].Value.ToString(),
                dgvRoutines.SelectedRows[0].Cells["Routine Name"].Value.ToString(),
                "",
                new dbassistant.Data().GetRoutineCode(
                    FormMain.MainForm.ConnectionString,
                    dgvRoutines.SelectedRows[0].Cells["Database"].Value.ToString(),
                    dgvRoutines.SelectedRows[0].Cells["Schema"].Value.ToString(),
                    dgvRoutines.SelectedRows[0].Cells["Routine Name"].Value.ToString()
                )
            );
        }

        private void btnExportRoutineList_Click(object sender, EventArgs e)
        {
            if (dgvRoutines.DataSource != null && dgvRoutines.DataSource is DataTable)
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Export Routine List Content to CSV";
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

        private void dgvRoutines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRoutine_Click(null, null);
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
            datatable = new dbassistant.Data().GetRoutines(((BWArgument)e.Argument).connectionString);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
          dgvRoutines.DataSource = datatable;

          dgvRoutines.Columns["definition"].Visible = false;
          dgvRoutines.Columns["Created"].Visible = false;
          dgvRoutines.Columns["Altered"].Visible = true;

          cboDatabase.DataSource = new dbassistant.Data().GetCatalogs(FormMain.MainForm.ConnectionString);
          cboDatabase.DisplayMember = "catalog";
          cboDatabase.ValueMember = "catalog";
          cboDatabase.SelectedIndex = 0;

          PopulateRoutines();

          this.picWait.Visible = false;
          this.Enabled = true;
        }

        #endregion

        private void PopulateRoutines()
        {
            try
            {
                string filter = "";

                if (cboDatabase.SelectedIndex > -1 && cboDatabase.SelectedValue.ToString() != "<All>")
                {
                    filter = string.Format(@"[Database] = '{0}'", cboDatabase.SelectedValue);
                }

                if (!string.IsNullOrEmpty(txtRoutine.Text.Trim()))
                {
                    filter = string.Format(@"{0}[Routine Name] LIKE '%{1}%'", string.IsNullOrEmpty(filter) ? "" : string.Format("{0} AND ", filter), txtRoutine.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtRoutineCode.Text.Trim()))
                {
                    filter = string.Format(@"{0}[definition] LIKE '%{1}%'", string.IsNullOrEmpty(filter) ? "" : string.Format("{0} AND ", filter), txtRoutineCode.Text.Trim());
                }
                datatable.DefaultView.RowFilter = filter;
                grpRoutines.Text = string.Format("Routines [{0}]", datatable.DefaultView.Count);
            }
            catch { }
        }

        private void PopulateRoutineText()
        {
            try
            {
                txtRoutineText.Text = new dbassistant.Data().GetRoutineCode(FormMain.MainForm.ConnectionString, dgvRoutines.SelectedRows[0].Cells["Database"].Value.ToString(), dgvRoutines.SelectedRows[0].Cells["Schema"].Value.ToString(), dgvRoutines.SelectedRows[0].Cells["Routine Name"].Value.ToString());
                txtRoutineText.SelectionStart = 0;
                txtRoutineText.SelectionLength = 0;
            }
            catch
            {
                txtRoutineText.Text = "";
            }
        }

        public static UCRoutineList CreateRoutineList()
        {
            UCRoutineList uc = new UCRoutineList();

            uc.btnRoutine.Image = Properties.Resources.ico_source_code_16;
            uc.btnExportRoutineList.Image = Properties.Resources.ico_export_excel_16;

            uc.picWait.Image = Properties.Resources.ico_wait_64;
            uc.picWait.Visible = false;

            uc.PopulateDatabase();

            return uc;
        }

    }
}
