using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace dbassistant.windows
{
    public class CsvWriter
    {
        public static string WriteToString(DataTable table, bool header, bool quoteall, string[] hiddencolumns, string[] textcolumns)
        {
            StringWriter writer = new StringWriter();
            WriteToStream(writer, table, header, quoteall, hiddencolumns, textcolumns);
            return writer.ToString();
        }

        public static string WriteToString(DataTable table, bool header, bool quoteall)
        {
            return WriteToString(table, header, quoteall, null, null);
        }

        public static void WriteToStream(TextWriter stream, DataTable table, bool header, bool quoteall, string[] hiddencolumns, string[] textcolumns)
        {
            if (header)
            {
                bool notfirst = false;

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (hiddencolumns != null && hiddencolumns.Contains(table.Columns[i].ColumnName)) continue;
                    if (notfirst) stream.Write(',');
                    WriteItem(stream, table.Columns[i].Caption, quoteall);
                    notfirst = true;
                }
                stream.Write('\n');
            }
            foreach (DataRow row in table.Rows)
            {
                bool notfirst = false;

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (hiddencolumns != null && hiddencolumns.Contains(table.Columns[i].ColumnName)) continue;
                    if (notfirst) stream.Write(',');

                    bool quoteanyway = (textcolumns != null) && textcolumns.Contains(table.Columns[i].ColumnName);
                    WriteItem(stream, row[i], quoteall, quoteanyway);
                    notfirst = true;
                }
                stream.Write('\n');
            }
        }

        public static void WriteToStream(TextWriter stream, DataTable table, bool header, bool quoteall, string[] textcolumns)
        {
            WriteToStream(stream, table, header, quoteall, null, null);
        }

        private static void WriteItem(TextWriter stream, object item, bool quoteall, bool quoteanyway)
        {
            if (item == null)
                return;
            string s = item.ToString();
            if (quoteanyway || quoteall || s.IndexOfAny("\",\x0A\x0D".ToCharArray()) > -1)
                stream.Write("\"" + s.Replace("\"", "\"\"") + "\"");
            else
                stream.Write(s);
        }

        private static void WriteItem(TextWriter stream, object item, bool quoteall)
        {
            WriteItem(stream, item, quoteall, false);
        }
    }
}
