using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Windows.Forms;
using Npgsql;

namespace Library
{
    class DBAction
    {
        private const String connectionString = "Server=127.0.0.1; Port=5432; User=postgres; Password=0000;Database=mylibrary;";
        //NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
        private static string querySql;
        //public static NpgsqlDataAdapter dataAdapter;
        
        //public static DataTable primaryDataTable = new DataTable();

        public static void getData(ref DataTable primaryDataTable, ref NpgsqlDataAdapter dataAdapter, string param)
        {
            primaryDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            querySql = String.Format("select * from {0};", param);
            //primaryDataTable.Clear();
            //primaryDataTable.Rows.Clear();
            //primaryDataTable.Columns.Clear();
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            //using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            try
            {
                dataAdapter = new NpgsqlDataAdapter(querySql, npgSqlConnection);
                //NpgsqlCommand commNpsql = new NpgsqlCommand(querySql, npgSqlConnection);
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(dataAdapter);
                npgSqlConnection.Open();
                dataAdapter.Fill(primaryDataTable);
                //dataAdapter.FillSchema(primaryDataTable, SchemaType.Mapped);
                //NpgsqlDataReader reader = commNpsql.ExecuteReader();
                //while (reader.HasRows)
                //{
                //    try
                //    {
                //        primaryDataTable.Load(reader);
                //    }
                //    catch { }

                //}
                npgSqlConnection.Close();
            }
            catch { }
            finally { npgSqlConnection.Close(); }



        }

        //public static void updateTable

        public static AutoCompleteStringCollection getLoginUser()
        {
            AutoCompleteStringCollection autoStringCollection = new AutoCompleteStringCollection();
            querySql = "select id_library_kard from login;";
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand commNpsql = new NpgsqlCommand(querySql, npgSqlConnection);
                npgSqlConnection.Open();
                NpgsqlDataReader reader = commNpsql.ExecuteReader();
                var list = new List<string>();
                while (reader.Read())
                {
                    try
                    {
                        autoStringCollection.Add(Convert.ToString(reader.GetInt32(0)));
                    }
                    catch { }

                }
            }

            return autoStringCollection;

        }


        
        
    }
}
