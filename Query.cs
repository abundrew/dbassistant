using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace dbassistant
{
    public class Query
    {
        public enum DataType
        {
            dtInt = 0,
            dtString = 1,
            dtBool = 2,
            dtDate = 3
        }

        public struct QueryDef
        {
            public string Description;
            public string Database;
            public ParamDef[] Parameters;
            public string SQL;
        }

        public struct ParamDef
        {
            public string ParamName;
            public string Designation;
            public DataType Type;
            public bool Nullable;
        }

        private string connectionString = "";
        private QueryDef query;

        private static QueryDef GetQueryDefResource(string sql)
        {
            QueryDef q = new QueryDef();

            Regex regex = new Regex(@"\[\*]\s*Description\s*=\s*(?<description>.*)\s*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match m = regex.Match(sql);
            if (m.Success) q.Description = m.Groups["description"].Value.Trim();

            regex = new Regex(@"\[\*]\s*Database\s*=\s*(?<database>.*)\s*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            m = regex.Match(sql);
            if (m.Success) q.Database = m.Groups["database"].Value.Trim();

            q.SQL = sql;

            List<ParamDef> pp = new List<ParamDef>();
            regex = new Regex(@"\[\*]\s*Parameter\s*(?<designation>.*)\s*=\s*(?<paramname>@\w+)\s*(?<type>bool|date|int|string|)\s*(?<nullable>NULL|NOT NULL|)\s*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            m = regex.Match(sql);
            while (m.Success)
            {
                ParamDef p = new ParamDef();
                p.ParamName = m.Groups["paramname"].Value;
                p.Designation = m.Groups["designation"].Value;
                switch (m.Groups["type"].Value)
                {
                    case "bool":
                        p.Type = DataType.dtBool;
                        break;
                    case "date":
                        p.Type = DataType.dtDate;
                        break;
                    case "int":
                        p.Type = DataType.dtInt;
                        break;
                    case "string":
                        p.Type = DataType.dtString;
                        break;
                    default:
                        p.Type = DataType.dtString;
                        break;
                }
                p.Nullable = m.Groups["nullable"].Value != "NOT NULL";
                pp.Add(p);

                m = m.NextMatch();
            }
            q.Parameters = pp.ToArray();
            return q;
        }

        public Query(string connectionString, QueryDef query)
        {
            this.connectionString = connectionString;
            this.query = query;
        }

        public Query(string connectionString, string sql) : this(connectionString, GetQueryDefResource(sql))
        {
        }

        public string Description()
        {
            return query.Description;
        }

        public string Database()
        {
            return query.Database;
        }

        public int ParamCount()
        {
            return query.Parameters.Length;
        }

        public string ParamDesignation(int i)
        {
            return query.Parameters[i].Designation;
        }

        public string SQL()
        {
            return query.SQL;
        }

        public DataTable Run(params string[] list) {
          return Run(0, list);
        }

        public DataTable Run(int maxRecords, params string[] list)
        {
            DataTable datatable = new DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();

                adapter.SelectCommand.CommandText = SQL();
                adapter.SelectCommand.CommandType = CommandType.Text;

                for (int i = 0; i < list.Length; i++)
                  if (i < query.Parameters.Length) {
                    System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter();
                    param.ParameterName = query.Parameters[i].ParamName;
                    string value = list[i].Trim();

                    if (!string.IsNullOrEmpty(value) || query.Parameters[i].Nullable) {
                      switch (query.Parameters[i].Type) {
                        case DataType.dtInt:
                          param.SqlDbType = SqlDbType.Int;
                          if (!string.IsNullOrEmpty(value))
                            param.Value = int.Parse(value);
                          else
                            param.Value = DBNull.Value;
                          break;
                        case DataType.dtString:
                          param.SqlDbType = SqlDbType.VarChar;
                          if (!string.IsNullOrEmpty(value))
                            param.Value = value;
                          else
                            param.Value = DBNull.Value;
                          break;
                        case DataType.dtBool:
                          param.SqlDbType = SqlDbType.Bit;
                          if (!string.IsNullOrEmpty(value))
                            param.Value = bool.Parse(value);
                          else
                            param.Value = DBNull.Value;
                          break;
                        case DataType.dtDate:
                          param.SqlDbType = SqlDbType.Int;
                          if (!string.IsNullOrEmpty(value))
                            param.Value = DateTime.Parse(value);
                          else
                            param.Value = DBNull.Value;
                          break;
                        default:
                          param.SqlDbType = SqlDbType.VarChar;
                          if (!string.IsNullOrEmpty(value))
                            param.Value = value;
                          else
                            param.Value = DBNull.Value;
                          break;
                      }
                      adapter.SelectCommand.Parameters.Add(param);
                    }
                  }

                connection.Open();
                if (!string.IsNullOrEmpty(Database())) connection.ChangeDatabase(Database());
                connection.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                adapter.SelectCommand.Connection = connection;

                if (maxRecords > 0) {
                  adapter.Fill(0, maxRecords, datatable);
                }
                else {
                  adapter.Fill(datatable);
                }
            }
            if (datatable != null) datatable.MorphBinaryColumns();
            return datatable;
        }
    }
}
