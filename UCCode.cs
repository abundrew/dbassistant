using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace dbassistant
{
    public partial class UCCode : UserControl
    {
        private UCCode()
        {
            InitializeComponent();
        }

        private string filename;
        private string code;

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, richCode.SelectedText);
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            richCode.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CheckPathExists = true;
            sfd.DefaultExt = "sql";
            sfd.Filter = "SQL Files (*.sql)|*.sql";
            sfd.FileName = filename;
            sfd.OverwritePrompt = true;
            if (sfd.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(sfd.FileName, richCode.Text);
        }

        #region -- SQL keywords --

        private static readonly string[] keywords = {
            "ADD",
            "EXISTS",
            "PRECISION",
            "ALL",
            "EXIT",
            "PRIMARY",
            "ALTER",
            "EXTERNAL",
            "PRINT",
            "AND",
            "FETCH",
            "PROC",
            "ANY",
            "FILE",
            "PROCEDURE",
            "AS",
            "FILLFACTOR",
            "PUBLIC",
            "ASC",
            "FOR",
            "RAISERROR",
            "AUTHORIZATION",
            "FOREIGN",
            "READ",
            "BACKUP",
            "FREETEXT",
            "READTEXT",
            "BEGIN",
            "FREETEXTTABLE",
            "RECONFIGURE",
            "BETWEEN",
            "FROM",
            "REFERENCES",
            "BREAK",
            "FULL",
            "REPLICATION",
            "BROWSE",
            "FUNCTION",
            "RESTORE",
            "BULK",
            "GOTO",
            "RESTRICT",
            "BY",
            "GRANT",
            "RETURN",
            "CASCADE",
            "GROUP",
            "REVERT",
            "CASE",
            "HAVING",
            "REVOKE",
            "CHECK",
            "HOLDLOCK",
            "RIGHT",
            "CHECKPOINT",
            "IDENTITY",
            "ROLLBACK",
            "CLOSE",
            "IDENTITY_INSERT",
            "ROWCOUNT",
            "CLUSTERED",
            "IDENTITYCOL",
            "ROWGUIDCOL",
            "COALESCE",
            "IF",
            "RULE",
            "COLLATE",
            "IN",
            "SAVE",
            "COLUMN",
            "INDEX",
            "SCHEMA",
            "COMMIT",
            "INNER",
            "SECURITYAUDIT",
            "COMPUTE",
            "INSERT",
            "SELECT",
            "CONSTRAINT",
            "INTERSECT",
            "SESSION_USER",
            "CONTAINS",
            "INTO",
            "SET",
            "CONTAINSTABLE",
            "IS",
            "SETUSER",
            "CONTINUE",
            "JOIN",
            "SHUTDOWN",
            "CONVERT",
            "KEY",
            "SOME",
            "CREATE",
            "KILL",
            "STATISTICS",
            "CROSS",
            "LEFT",
            "SYSTEM_USER",
            "CURRENT",
            "LIKE",
            "TABLE",
            "CURRENT_DATE",
            "LINENO",
            "TABLESAMPLE",
            "CURRENT_TIME",
            "LOAD",
            "TEXTSIZE",
            "CURRENT_TIMESTAMP",
            "MERGE",
            "THEN",
            "CURRENT_USER",
            "NATIONAL",
            "TO",
            "CURSOR",
            "NOCHECK",
            "TOP",
            "DATABASE",
            "NONCLUSTERED",
            "TRAN",
            "DBCC",
            "NOT",
            "TRANSACTION",
            "DEALLOCATE",
            "NULL",
            "TRIGGER",
            "DECLARE",
            "NULLIF",
            "TRUNCATE",
            "DEFAULT",
            "OF",
            "TSEQUAL",
            "DELETE",
            "OFF",
            "UNION",
            "DENY",
            "OFFSETS",
            "UNIQUE",
            "DESC",
            "ON",
            "UNPIVOT",
            "DISK",
            "OPEN",
            "UPDATE",
            "DISTINCT",
            "OPENDATASOURCE",
            "UPDATETEXT",
            "DISTRIBUTED",
            "OPENQUERY",
            "USE",
            "DOUBLE",
            "OPENROWSET",
            "USER",
            "DROP",
            "OPENXML",
            "VALUES",
            "DUMP",
            "OPTION",
            "VARYING",
            "ELSE",
            "OR",
            "VIEW",
            "END",
            "ORDER",
            "WAITFOR",
            "ERRLVL",
            "OUTER",
            "WHEN",
            "ESCAPE",
            "OVER",
            "WHERE",
            "EXCEPT",
            "PERCENT",
            "WHILE",
            "EXEC",
            "PIVOT",
            "WITH",
            "EXECUTE",
            "PLAN",
            "WRITETEXT"
        };

        #endregion

        public static UCCode Create(string description, string filename, string code)
        {
            UCCode uc = new UCCode();
            uc.code = code;
            uc.filename = filename;
            uc.lblDescription.Text = description;

            uc.richCode.SelectionTabs = new int[] {28, 56, 84, 112, 140, 168, 196, 224, 252, 280};
            uc.richCode.Text = code;

            uc.richCode.ContextMenuStrip = uc.ctxCode;

            Color color = uc.richCode.SelectionColor;

            Regex r = new Regex(@"(\w+)", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            Match m = r.Match(uc.richCode.Text);
            while (m.Success)
            {
                foreach (Capture c in m.Groups[1].Captures)
                {
                    if (keywords.Contains(c.Value.ToUpper()))
                    {
                        uc.richCode.Select(c.Index, c.Length);
                        uc.richCode.SelectionColor = Color.FromArgb(0, 0, 255);
                    }
                }
                m = m.NextMatch();
            }

            r = new Regex(@"(--.*)$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            m = r.Match(uc.richCode.Text);
            while (m.Success)
            {
                foreach (Capture c in m.Groups[1].Captures)
                {
                        uc.richCode.Select(c.Index, c.Length);
                        uc.richCode.SelectionColor = Color.FromArgb(0, 128, 0);
                }
                m = m.NextMatch();
            }

            r = new Regex(@"(/\*.*?\*/)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            m = r.Match(uc.richCode.Text);
            while (m.Success)
            {
                foreach (Capture c in m.Groups[1].Captures)
                {
                    uc.richCode.Select(c.Index, c.Length);
                    uc.richCode.SelectionColor = Color.FromArgb(0, 128, 0);
                }
                m = m.NextMatch();
            }

            uc.richCode.Select(0, 0);

            return uc;
        }

    }
}
