using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security.Principal;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.IO;


namespace dbassistant
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public static FormMain MainForm { get; private set; }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MainForm = this;
            Text = FormAbout.AssemblyProduct;
            Icon = Icon.FromHandle(Properties.Resources.ico_table_multiple_32.GetHicon());
            
            mnuFileOpen.Image = Properties.Resources.ico_folder_16;
            mnuObjectTables.Image = Properties.Resources.ico_table_multiple_16;
            mnuObjectRoutines.Image = Properties.Resources.ico_list_16;
            mnuWindowClose.Image = Properties.Resources.ico_cancel_16;
            mnuHelpAbout.Text = string.Format("About {0}", FormAbout.AssemblyProduct);
            
            tsbOpen.Image = Properties.Resources.ico_folder_16;
            tsbTables.Image = Properties.Resources.ico_table_multiple_16;
            tsbRoutines.Image = Properties.Resources.ico_list_16;
            tsbClose.Image = Properties.Resources.ico_cancel_16;

            staMain.Items["staUser"].Text = "-";
            staMain.Items["staServer"].Text = "-";
        }

        private string connectionString = "";
        public string ConnectionString {
            get {
                return connectionString;
            }
            private set {
                connectionString = value;

                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = connectionString;

                if (!builder.IntegratedSecurity)
                {
                    if (string.IsNullOrEmpty(builder.DataSource) || string.IsNullOrEmpty(builder.UserID) || string.IsNullOrEmpty(builder.Password))
                    {
                        string dataSource = builder.DataSource;
                        string userID = builder.UserID;
                        string password = builder.Password;

                        if (FormConnect.Connect(ref dataSource, ref userID, ref password)) {
                            if (string.IsNullOrEmpty(builder.DataSource)) builder.DataSource = dataSource;
                            if (string.IsNullOrEmpty(builder.UserID)) builder.UserID = userID;
                            if (string.IsNullOrEmpty(builder.Password)) builder.Password = password;

                            connectionString = builder.ConnectionString;
                        } else connectionString = "";
                    }
                }
                staMain.Items["staUser"].Text = string.IsNullOrEmpty(builder.UserID) ? "-" : builder.UserID;
                staMain.Items["staServer"].Text = string.IsNullOrEmpty(builder.DataSource) ? "-" : builder.DataSource;
            }
        }

        private QuerySet.GroupItem[] queryGroups = new QuerySet.GroupItem[] { };
        private List<ToolStripMenuItem> qroupmenuitems = new List<ToolStripMenuItem>();
        private List<ToolStripDropDownButton> qrouptoolbuttons = new List<ToolStripDropDownButton>();

        private void OpenFile() {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                mnuWindowCloseAll_Click(null, null);

                string cs = "";
                queryGroups = QuerySet.GetQueries(openFileDialog.FileName, out cs);
                ConnectionString = cs;

                foreach (ToolStripMenuItem menuitem in qroupmenuitems) mnuQuery.DropDownItems.Remove(menuitem);
                foreach (ToolStripDropDownButton toolbutton in qrouptoolbuttons) tsMain.Items.Remove(toolbutton);

                for (int i = 0; i < queryGroups.Length; i++) {
                    ToolStripMenuItem menuitem = new ToolStripMenuItem(queryGroups[i].Name, Properties.Resources.ico_sql_join_left_16);
                    ToolStripDropDownButton toolbutton = new ToolStripDropDownButton(Properties.Resources.ico_sql_join_left_16);
                    toolbutton.ToolTipText = queryGroups[i].Name;
                    for (int j = 0; j < queryGroups[i].Items.Length; j++) {
                        menuitem.DropDownItems.Add(queryGroups[i].Items[j].Name, Properties.Resources.ico_sql_join_left_16, mnuQueriesDropDownItems_Click).Tag = i + j * 16;
                        toolbutton.DropDownItems.Add(queryGroups[i].Items[j].Name, Properties.Resources.ico_sql_join_left_16, mnuQueriesDropDownItems_Click).Tag = i + j * 16;
                    }
                    mnuQuery.DropDownItems.Add(menuitem);
                    tsMain.Items.Add(toolbutton);

                    qroupmenuitems.Add(menuitem);
                    qrouptoolbuttons.Add(toolbutton);
                }
            }
        }

        private void SaveFile() {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "dbassistant.settings_template.xml";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                    using (StreamReader reader = new StreamReader(stream)) {
                        System.IO.File.WriteAllText(saveFileDialog.FileName, reader.ReadToEnd());
                    }
                }
            }
        }

        #region - Menu -

        private void mnuFileOpen_Click(object sender, EventArgs e) {
            OpenFile();
        }

        private void mnuObjectTables_Click(object sender, EventArgs e) {
            SuspendLayout();
            try {
                TabPage page = new TabPage("Tables");
                UCTableList uc = UCTableList.CreateTableList();
                uc.Dock = DockStyle.Fill;
                page.Controls.Add(uc);
                tcMain.TabPages.Add(page);
                page.ImageKey = "ico_table_multiple_16.png";
                tcMain.SelectedTab = page;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "TABLES ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                ResumeLayout();
            }
        }

        private void mnuObjectRoutines_Click(object sender, EventArgs e) {
            SuspendLayout();
            try {
                TabPage page = new TabPage("Routines");
                UCRoutineList uc = UCRoutineList.CreateRoutineList();
                uc.Dock = DockStyle.Fill;
                page.Controls.Add(uc);
                tcMain.TabPages.Add(page);
                page.ImageKey = "ico_list_16.png";
                tcMain.SelectedTab = page;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "ROUTINES ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                ResumeLayout();
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuQueriesDropDownItems_Click(object sender, EventArgs e)
        {
            int i = (int)(sender as ToolStripMenuItem).Tag % 16;
            int j = (int)(sender as ToolStripMenuItem).Tag / 16;
            ViewQuery(queryGroups[i].Items[j].Name, queryGroups[i].Items[j].SqlText);
        }

        private void mnuWindowClose_Click(object sender, EventArgs e)
        {
            if (tcMain.TabPages.Count > 0)
            {
                int selectedindex = tcMain.SelectedIndex;
                tcMain.TabPages.RemoveAt(selectedindex);
                if (selectedindex > 0) tcMain.SelectedIndex = selectedindex - 1;
            }
        }

        private void mnuWindowCloseAll_Click(object sender, EventArgs e)
        {
            while (tcMain.TabPages.Count > 0) mnuWindowClose_Click(null, null);
        }

        private void mnuHelpSettingsTemplate_Click(object sender, EventArgs e) {
            SaveFile();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e) {
          FormAbout.About();
        }

        #endregion

        #region - Toolbar -

        private void tsbOpen_Click(object sender, EventArgs e) {
            mnuFileOpen_Click(null, null);
        }

        private void tsbTables_Click(object sender, EventArgs e)
        {
            mnuObjectTables_Click(null, null);
        }

        private void tsbRoutines_Click(object sender, EventArgs e)
        {
            mnuObjectRoutines_Click(null, null);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            mnuWindowClose_Click(null, null);
        }

        #endregion

        public void ViewQuery(string title, string sql)
        {
            SuspendLayout();
            try
            {
                TabPage page = new TabPage(string.Format("{0}", title));
                UCQuery uc = UCQuery.Create(new Query(ConnectionString, sql));
                uc.Dock = DockStyle.Fill;
                page.Controls.Add(uc);
                tcMain.TabPages.Add(page);
                page.ImageKey = "ico_sql_join_left_16.png";
                tcMain.SelectedTab = page;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "QUERY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ResumeLayout();
            }
        }

        public void ViewCode(string title, string description, string filename, string code)
        {
            SuspendLayout();
            try
            {
                TabPage page = new TabPage(string.Format("{0}", title));
                UCCode uc = UCCode.Create(description, filename, code);
                uc.Dock = DockStyle.Fill;
                page.Controls.Add(uc);
                tcMain.TabPages.Add(page);
                page.ImageKey = "ico_source_code_16.png";
                tcMain.SelectedTab = page;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CODE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ResumeLayout();
            }
        }

        public void ViewTable(string database, string schema, string tablename, string where)
        {
            SuspendLayout();
            try
            {
                TabPage page = new TabPage(string.Format("{0}", tablename));
                UCTable uc = UCTable.Create(database, schema, tablename, where);
                uc.Dock = DockStyle.Fill;
                page.Controls.Add(uc);
                tcMain.TabPages.Add(page);
                page.ImageKey = "ico_table_16.png";
                tcMain.SelectedTab = page;
                Application.DoEvents();
                uc.Check1000(database, schema, tablename, where);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TABLE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ResumeLayout();
            }
        }

    }
}
