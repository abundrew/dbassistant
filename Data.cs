using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using System.Configuration;

namespace dbassistant
{
    public class Data
    {
        const string sqlCatalogs = @"
            DECLARE @AllCatalogs table (catalog sysname) 
            INSERT INTO @AllCatalogs (catalog) 
            EXEC sp_msforeachdb 'SELECT DISTINCT TABLE_CATALOG FROM [?].information_schema.TABLES'
            SELECT '<All>' AS catalog
            UNION ALL
            SELECT DISTINCT catalog FROM @AllCatalogs
            WHERE NOT catalog IN ('master', 'model', 'msdb', 'tempdb')
            ORDER BY catalog";

        public DataTable GetCatalogs(string connectionString)
        {
            DataTable datatable = new DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();

                adapter.SelectCommand.CommandText = sqlCatalogs;
                adapter.SelectCommand.CommandType = CommandType.Text;

                connection.Open();
                connection.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandTimeout = 0;

                adapter.Fill(datatable);
            }
            return datatable;
        }

        const string sqlTables = @"
            DECLARE @AllTables table (catalog sysname, [schema] sysname, name sysname, type sysname, rownum int) 
            INSERT INTO @AllTables (catalog, [schema], name, type, rownum) 
            EXEC sp_msforeachdb 'SELECT T.TABLE_CATALOG, T.TABLE_SCHEMA, T.TABLE_NAME, T.TABLE_TYPE, I.rows AS ROW_NUM FROM [?].information_schema.TABLES T LEFT OUTER JOIN [?]..sysindexes I ON (I.id = OBJECT_ID(T.TABLE_CATALOG + ''.'' + T.TABLE_SCHEMA + ''.'' + T.TABLE_NAME) AND I.indid < 2)'
            SELECT catalog AS ""Database"", [schema] AS ""Schema"", name AS ""Table Name"", type AS ""Type"", rownum AS ""Row Count"" FROM @AllTables
            WHERE NOT catalog IN ('master', 'model', 'msdb', 'tempdb')
            ORDER BY catalog, [schema], name";

        const string sqlTablesNoRowNum = @"
            DECLARE @AllTables table (catalog sysname, [schema] sysname, name sysname, type sysname) 
            INSERT INTO @AllTables (catalog, [schema], name, type) 
            EXEC sp_msforeachdb 'SELECT T.TABLE_CATALOG, T.TABLE_SCHEMA, T.TABLE_NAME, T.TABLE_TYPE FROM [?].information_schema.TABLES T'
            SELECT catalog AS ""Database"", [schema] AS ""Schema"", name AS ""Table Name"", type AS ""Type"" FROM @AllTables
            WHERE NOT catalog IN ('master', 'model', 'msdb', 'tempdb')
            ORDER BY catalog, [schema], name";

        public DataTable GetTables(string connectionString, bool rownum)
        {
            DataTable datatable = new DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();

                adapter.SelectCommand.CommandText = rownum ? sqlTables : sqlTablesNoRowNum;
                adapter.SelectCommand.CommandType = CommandType.Text;

                connection.Open();
                connection.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandTimeout = 0;

                adapter.Fill(datatable);
            }
            return datatable;
        }

        const string sqlColumns = @"
            USE [{0}]
            SELECT
            	c.name AS [Column Name],
	            [SQL Type] = CASE
		            WHEN t.name = 'binary' THEN 'binary(' + LTRIM(RTRIM(STR(c.max_length))) + ')'
		            WHEN t.name = 'char' THEN 'char(' + LTRIM(RTRIM(STR(c.max_length))) + ')'
		            WHEN t.name = 'decimal' THEN 'decimal(' + LTRIM(RTRIM(STR(c.precision))) + ', ' + LTRIM(RTRIM(STR(c.scale))) + ')'
		            WHEN t.name = 'float' THEN CASE WHEN c.max_length = 4 THEN 'float(24)' ELSE 'float(53)' END
		            WHEN t.name = 'nchar' THEN 'nchar(' + LTRIM(RTRIM(STR(c.max_length / 2))) + ')'
		            WHEN t.name = 'numeric' THEN 'numeric(' + LTRIM(RTRIM(STR(c.precision))) + ', ' + LTRIM(RTRIM(STR(c.scale))) + ')'
		            WHEN t.name = 'nvarchar' THEN CASE WHEN c.max_length = -1 THEN 'nvarchar(max)' ELSE 'nvarchar(' + LTRIM(RTRIM(STR(c.max_length / 2))) + ')' END
		            WHEN t.name = 'varbinary' THEN CASE WHEN c.max_length = -1 THEN 'varbinary(max)' ELSE 'varbinary(' + LTRIM(RTRIM(STR(c.max_length))) + ')' END
		            WHEN t.name = 'varchar' THEN CASE WHEN c.max_length = -1 THEN 'varchar(max)' ELSE 'varchar(' + LTRIM(RTRIM(STR(c.max_length))) + ')' END
		            ELSE t.name
	            END,
	            c.is_nullable AS [Null],
                c.is_identity AS [Identity]
            FROM
	            sys.columns c
	            LEFT OUTER JOIN sys.types t ON (t.user_type_id = c.user_type_id) 
            WHERE OBJECT_NAME(object_id) = '{1}' ORDER BY c.column_id";

        public DataTable GetColumns(string connectionString, string database, string table)
        {
            DataTable datatable = new DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();

                adapter.SelectCommand.CommandText = string.Format(sqlColumns, database, table);
                adapter.SelectCommand.CommandType = CommandType.Text;

                connection.Open();
                connection.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandTimeout = 0;

                adapter.Fill(datatable);
            }
            return datatable;
        }

        const string sqlRoutines = @"
            DECLARE @AllRoutines table (catalog sysname, [schema] sysname, name sysname, type sysname, definition text, datatype varchar(100), created datetime, altered datetime) 
            INSERT INTO @AllRoutines (catalog, [schema], name, type, definition, datatype, created, altered) 
            EXEC sp_msforeachdb 'SELECT ROUTINE_CATALOG, ROUTINE_SCHEMA, ROUTINE_NAME, ROUTINE_TYPE, ROUTINE_DEFINITION, DATA_TYPE = CASE WHEN DATA_TYPE LIKE ''%char%'' THEN DATA_TYPE + ''('' + LTRIM(RTRIM(STR(CHARACTER_MAXIMUM_LENGTH))) + '')'' WHEN DATA_TYPE IN (''decimal'', ''numeric'') THEN DATA_TYPE + ''('' + LTRIM(RTRIM(STR(NUMERIC_PRECISION))) + '','' + LTRIM(RTRIM(STR(NUMERIC_SCALE))) + '')'' ELSE DATA_TYPE END, CREATED, LAST_ALTERED FROM [?].information_schema.ROUTINES'
            SELECT catalog AS ""Database"", [schema] AS ""Schema"", name AS ""Routine Name"", type AS ""Type"", definition, datatype AS ""Data Type"", created AS ""Created"", altered AS ""Altered"" FROM @AllRoutines
            WHERE NOT catalog IN ('master', 'model', 'msdb', 'tempdb')
            ORDER BY catalog, [schema], name";

        public DataTable GetRoutines(string connectionString)
        {
            DataTable datatable = new DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();

                adapter.SelectCommand.CommandText = sqlRoutines;
                adapter.SelectCommand.CommandType = CommandType.Text;

                connection.Open();
                connection.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandTimeout = 0;

                adapter.Fill(datatable);
            }
            return datatable;
        }

        public string GetRoutineCode(string connectionString, string database, string schema, string routine)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                    StringBuilder sb = new StringBuilder();

                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "sp_helptext";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@objname", string.Format("{0}.{1}", schema, routine)));

                    connection.Open();
                    if (!string.IsNullOrEmpty(database)) connection.ChangeDatabase(database);
                    connection.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                    System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                      while (reader.Read()) {
                        sb.Append(reader.GetString(0));
                      }

                    reader.Close();
                    return sb.ToString();
                }
            }
            catch { }

            return "";
        }

        const string sqlSelectTable = @"SELECT * FROM [{0}].[{1}].[{2}]{3}";
        const string sqlSelectTableMaxRecords = @"SELECT TOP {0} * FROM [{1}].[{2}].[{3}]{4}";
        const string sqlSelectTable1000 = @"SELECT TOP 1000 * FROM [{0}].[{1}].[{2}]{3}";

        public DataTable GetTableContent(string connectionString, string database, string schema, string tablename, string where, bool top1000) {
            return GetTableContent(0, connectionString, database, schema, tablename, where, top1000);
        }

        public DataTable GetTableContent(int maxrecords, string connectionString, string database, string schema, string tablename, string where, bool top1000)
        {
            DataTable datatable = new DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
                if (top1000) {
                  adapter.SelectCommand.CommandText = string.Format(sqlSelectTable1000, database, schema, tablename, string.IsNullOrEmpty(where) ? "" : string.Format(" WHERE {0}", where));
                }
                else if (maxrecords > 0) {
                  adapter.SelectCommand.CommandText = string.Format(sqlSelectTableMaxRecords, maxrecords, database, schema, tablename, string.IsNullOrEmpty(where) ? "" : string.Format(" WHERE {0}", where));
                }
                else {
                  adapter.SelectCommand.CommandText = string.Format(sqlSelectTable, database, schema, tablename, string.IsNullOrEmpty(where) ? "" : string.Format(" WHERE {0}", where));
                }
                adapter.SelectCommand.CommandType = CommandType.Text;

                connection.Open();
                connection.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandTimeout = 0;

                if (maxrecords > 0) {
                  adapter.Fill(0, maxrecords, datatable);
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
