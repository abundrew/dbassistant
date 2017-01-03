using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dbassistant {
    public partial class FormConnect : Form {
        public FormConnect() {
            InitializeComponent();

            btnOK.Enabled = false;
            txtDataSource.TextChanged += txt_TextChanged;
            txtUserID.TextChanged += txt_TextChanged;
            txtPassword.TextChanged += txt_TextChanged;

            this.Load += FormConnect_Load;
        }

        void FormConnect_Load(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtDataSource.Text)) {
                this.ActiveControl = txtDataSource;
            } else if (string.IsNullOrEmpty(txtUserID.Text)) {
                this.ActiveControl = txtUserID;
            } else if (string.IsNullOrEmpty(txtPassword.Text)) {
                this.ActiveControl = txtPassword;
            } else this.ActiveControl = btnOK;
        }

        void txt_TextChanged(object sender, EventArgs e) {
            btnOK.Enabled = !string.IsNullOrEmpty(txtDataSource.Text) && !string.IsNullOrEmpty(txtUserID.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }

        public static bool Connect(ref string dataSource, ref string userID, ref string password)
        {
            FormConnect frm = new FormConnect();
            if (!string.IsNullOrEmpty(dataSource)) {
                frm.txtDataSource.ReadOnly = true;
                frm.txtDataSource.Text = dataSource;
            }
            if (!string.IsNullOrEmpty(userID)) {
                frm.txtUserID.ReadOnly = true;
                frm.txtUserID.Text = userID;
            }
            if (!string.IsNullOrEmpty(password)) {
                frm.txtPassword.ReadOnly = true;
                frm.txtPassword.Text = password;
            }
            if (frm.ShowDialog() == DialogResult.OK) {
                dataSource = frm.txtDataSource.Text;
                userID = frm.txtUserID.Text;
                password = frm.txtPassword.Text;
                return true;
            }
            return false;
        }
    }
}
