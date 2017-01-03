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
    public partial class UCQuery : UserControl
    {
        private UCQuery()
        {
            InitializeComponent();
        }

        private Query query;

        public string Database()
        {
            return query.Database();
        }

        public string Description()
        {
            return query.Description();
        }

        public string SQL()
        {
            return query.SQL();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
          this.Enabled = false;
          this.picWait.Visible = true;

          bw = new BackgroundWorker();
          bw.DoWork += new DoWorkEventHandler(bw_DoWork);
          bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
          bw.RunWorkerAsync(new BWArgument() { maxRecords = 100000, param1 = txtParam1.Text, param2 = txtParam2.Text, param3 = txtParam3.Text, param4 = txtParam4.Text, param5 = txtParam5.Text });

          // Recoded with BackgroundWorker
          //
          //dgvQuery.DataSource = query.Run(txtParam1.Text, txtParam2.Text, txtParam3.Text, txtParam4.Text, txtParam5.Text);
          //lblCount.Text = string.Format("Count: {0}", (dgvQuery.DataSource as DataTable).Rows.Count);
        }

        #region - Background Worker -

        BackgroundWorker bw;
        DataTable datatable = null;

        struct BWArgument {
          public int maxRecords;
          public string param1;
          public string param2;
          public string param3;
          public string param4;
          public string param5;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e) {
          try {
            datatable = null;
            datatable = query.Run(((BWArgument)e.Argument).maxRecords, ((BWArgument)e.Argument).param1, ((BWArgument)e.Argument).param2, ((BWArgument)e.Argument).param3, ((BWArgument)e.Argument).param4, ((BWArgument)e.Argument).param5);
          }
          catch { }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
          try {
            lblCount.Text = "";
            dgvQuery.DataSource = datatable;
            int maxRecords = 100000;
            int rowCount = (dgvQuery.DataSource as DataTable).Rows.Count;
            if (maxRecords > 0 && rowCount >= maxRecords) {
              lblCount.Text = string.Format("Count: {0} / max records = {1}", rowCount, maxRecords);
            }
            else {
              lblCount.Text = string.Format("Count: {0}", rowCount);
            }
          }
          catch { }
          finally {
            this.picWait.Visible = false;
            this.Enabled = true;
          }
        }

        #endregion

        private void btnCopySQL_Click(object sender, EventArgs e)
        {
            FormMain.MainForm.ViewCode("SQL", query.Description(), "", SQL());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvQuery.DataSource != null && dgvQuery.DataSource is DataTable)
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Export Data Table Content to CSV";
                sfd.DefaultExt = "csv";
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, windows.CsvWriter.WriteToString(dgvQuery.DataSource as DataTable, true, false,
                        null,
                        null
                    ));
                };
            }
        }

        public static UCQuery Create(Query qry)
        {
            UCQuery uc = new UCQuery();
            uc.query = qry;

            uc.lblDescription.Text = uc.query.Description();
            uc.lblCount.Text = "Count: -";
            for (int i = 0; i < uc.query.ParamCount(); i++)
            {
                (windows.ReflectionInfo.GetControlByName(string.Format("lblParam{0}", i + 1), uc) as Label).Text = string.Format("{0}:", windows.Text.Omit(uc.query.ParamDesignation(i), 15));
                uc.toolTip.SetToolTip(windows.ReflectionInfo.GetControlByName(string.Format("lblParam{0}", i + 1), uc), string.Format("{0}:", uc.query.ParamDesignation(i)));
                uc.toolTip.SetToolTip(windows.ReflectionInfo.GetControlByName(string.Format("txtParam{0}", i + 1), uc), string.Format("{0}:", uc.query.ParamDesignation(i)));
            }
            for (int i = uc.query.ParamCount(); i < 5; i++)
            {
                (windows.ReflectionInfo.GetControlByName(string.Format("lblParam{0}", i + 1), uc) as Label).Visible = false;
                (windows.ReflectionInfo.GetControlByName(string.Format("txtParam{0}", i + 1), uc) as TextBox).Visible = false;
            }

            uc.btnExecute.Top -= (5 - uc.query.ParamCount()) * 44;
            uc.btnCopySQL.Top = uc.btnExecute.Top;
            uc.btnExport.Top = uc.btnExecute.Top;

            uc.picWait.Image = Properties.Resources.ico_wait_64;
            uc.picWait.Visible = false;

            return uc;
        }
    }
}
