using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace dbassistant {
    public static class Extensions {

        public static void MorphBinaryColumns(this DataTable table) {
            var targetNames =
                table.Columns.Cast<DataColumn>()
                    .Where(col => col.DataType.Equals(typeof(byte[])))
                    .Select(col => col.ColumnName).ToList();

            foreach (string colName in targetNames) {
                // add new column and put it where the old column was
                var tmpName = "new";
                table.Columns.Add(new DataColumn(tmpName, typeof(string)));
                table.Columns[tmpName].SetOrdinal(table.Columns[colName].Ordinal);

                // fill in values in new column for every row
                foreach (DataRow row in table.Rows) {
                    row[tmpName] = "0x" + string.Join("", ((byte[])row[colName]).Select(b => b.ToString("X2")).ToArray());
                }

                // cleanup
                table.Columns.Remove(colName);
                table.Columns[tmpName].ColumnName = colName;
            }
        }

    }
}
