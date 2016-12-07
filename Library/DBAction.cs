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
        
        public static void getData(ref DataTable primaryDataTable, ref NpgsqlDataAdapter dataAdapter, string param)
        {
            primaryDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;

            string querySql = String.Format("select * from {0};", param);

            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);

            try
            {
                dataAdapter = new NpgsqlDataAdapter(querySql, npgSqlConnection);

                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

                npgSqlConnection.Open();
                dataAdapter.Fill(primaryDataTable);
            }
            catch { MessageBox.Show("Ошибка!"); }
            finally { npgSqlConnection.Close(); }



        }

        public static AutoCompleteStringCollection getLoginUser()
        {
            AutoCompleteStringCollection autoStringCollection = new AutoCompleteStringCollection();
            string querySql = "select id_library_kard from login;";
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

        

        public static void deleteFromDataTable(ref BindingSource bindSource, ref NpgsqlDataAdapter dataAdapter, string _table, string _columnID, int _valueID)
        {
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                string sqlQuery = String.Format("delete from {0} where {1} = {2}", _table, _columnID, _valueID);
                dataAdapter.DeleteCommand = new NpgsqlCommand(sqlQuery);
                dataAdapter.DeleteCommand.Connection = npgSqlConnection;
                if (npgSqlConnection.State != ConnectionState.Open)
                { npgSqlConnection.Open(); }
                //dataAdapter.Update((DataTable)bindSource.DataSource);
                dataAdapter.DeleteCommand.ExecuteNonQuery();
                dataAdapter.Update((DataTable)bindSource.DataSource);
            }
        }

        public static bool updatePassword(string passDigest, string login)
        {
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);

            try
            {
                string sqlQuery = String.Format("update login set password_user = '{0}' where id_library_kard = {1};", passDigest, login);

                var dataAdapter = new NpgsqlDataAdapter();
                dataAdapter.UpdateCommand = new NpgsqlCommand(sqlQuery, npgSqlConnection);
                npgSqlConnection.Open();
                return (dataAdapter.UpdateCommand.ExecuteNonQuery() == 1);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                npgSqlConnection.Close();
            }
        }

        public static void updateDataTable(ref BindingSource bindSource, ref NpgsqlDataAdapter dataAdapter, string sqlQuery)
        {
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                dataAdapter.UpdateCommand = new NpgsqlCommand(sqlQuery, npgSqlConnection);
                dataAdapter.Update((DataTable)bindSource.DataSource);
            }
        }
    }
}
