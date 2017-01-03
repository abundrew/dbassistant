using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace dbassistant
{
    public class QuerySet
    {
        public struct QueryItem
        {
            public string Name;
            public string SqlText;
        }

        public struct GroupItem
        {
            public string Name;
            public QueryItem[] Items;
        }

        public static GroupItem[] GetQueries(string fileName, out string connectionString)
        {
            connectionString = "";
            List<GroupItem> groups = new List<GroupItem>();
            try {
                XElement xdoc = XElement.Load(fileName);
                connectionString = xdoc.Element("ConnectionString").Value;
                foreach (XElement groupitem in xdoc.Element("GroupItems").Elements("GroupItem")) {
                    List<QueryItem> queries = new List<QueryItem>();
                    foreach (XElement queryitem in groupitem.Elements("QueryItems").Elements("QueryItem")) {
                        queries.Add(new QueryItem() { Name = queryitem.Element("QueryItemName").Value.Trim(), SqlText = queryitem.Element("QueryItemText").Value.Trim() });
                    }
                    groups.Add(new GroupItem() { Name = groupitem.Element("GroupItemName").Value.Trim(), Items = queries.ToArray() });
                }
            } catch (Exception e) {
                MessageBox.Show(e.Message, "FILE READ ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return groups.ToArray();

            /*

            List<GroupItem> groups = new List<GroupItem>();
            try
            {
                string cfgfile = AppSettings.QueryConfigFile;
                string path = Path.GetDirectoryName(cfgfile);

                foreach (string grpline in File.ReadAllLines(cfgfile))
                {
                    if (Regex.Match(grpline, @"^ *#").Success) continue;

                    string grpfile = grpline.Split('=')[1].Trim();
                    if (string.IsNullOrEmpty(Path.GetDirectoryName(grpfile))) grpfile = Path.Combine(path, grpfile);

                    List<QueryItem> queries = new List<QueryItem>();
                    foreach (string qryline in File.ReadAllLines(grpfile))
                    {
                        if (Regex.Match(qryline, @"^ *#").Success) continue;

                        string qryfile = qryline.Split('=')[1].Trim();
                        if (string.IsNullOrEmpty(Path.GetDirectoryName(qryfile))) qryfile = Path.Combine(path, qryfile);

                        queries.Add(new QueryItem() { Name = qryline.Split('=')[0].Trim(), SqlText = qryfile });
                    }
                    groups.Add(new GroupItem() { Name = grpline.Split('=')[0].Trim(), Items = queries.ToArray() });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "FILE READ ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return groups.ToArray();
            */
        }

    }
}
