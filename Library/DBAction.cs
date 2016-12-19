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
        public static DataSet libraryDS = new mylibraryDataSet();
        private const String connectionString = "Server=127.0.0.1; Port=5432; User=postgres; Password=0000;Database=mylibrary;";
        
        public static void getData(out NpgsqlDataAdapter dataAdapter, string table)
        {
            //string[] tables = new string[] { "book", "booking", "department", "login", "reader", "issuing_books" };
            
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
               
                connection.Open();

                string sql = String.Format("select * from {0};", table);

                dataAdapter = new NpgsqlDataAdapter(sql, connection);

                //libraryDS.Tables.Add(table);
                NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = builder.GetInsertCommand();
                dataAdapter.DeleteCommand = builder.GetDeleteCommand();
                dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                
                dataAdapter.Fill(libraryDS, table);

                


                

                //foreach (var table in tables) 
                //{                    
                //    string sql = String.Format("select * from {0};", table);
                //    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
                //    adapter.Fill(libraryDS, table);
                //}
            }
        }

       

        

        public static void deleteFromDataTable(ref NpgsqlDataAdapter dataAdapter, string sqlQuery)
        {
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                //string sqlQuery = String.Format("delete from {0} where {1} = {2}", _table, _columnID, _valueID);
                //dataAdapter.DeleteCommand = new NpgsqlCommand(sqlQuery);
                //dataAdapter.DeleteCommand.Connection = npgSqlConnection;
                //if (npgSqlConnection.State != ConnectionState.Open)
                //{ npgSqlConnection.Open(); }
                ////dataAdapter.Update((DataTable)bindSource.DataSource);
                //dataAdapter.DeleteCommand.ExecuteNonQuery();
                //dataAdapter.Update((DataTable)bindSource.DataSource);


                //npgSqlConnection.Open();
                //dataAdapter.DeleteCommand.CommandText = sqlQuery;
                //dataAdapter.DeleteCommand.Connection = npgSqlConnection;
                //dataAdapter.Update(libraryDS);

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

        public static void updateDataTable(NpgsqlDataAdapter dataAdapter, string table)//NpgsqlCommand deleteComm, NpgsqlCommand updateComm, NpgsqlCommand insertComm, string table)
        {
            //using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            //{
            //    dataAdapter.UpdateCommand = new NpgsqlCommand(sqlQuery, npgSqlConnection);
            //    dataAdapter.Update((DataTable)bindSource.DataSource);
            //}
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))


                connection.Open();
                //libraryDS.RejectChanges();


                ////dataAdapter.DeleteCommand = deleteComm;
                dataAdapter.DeleteCommand.Connection = connection;

                ////dataAdapter.UpdateCommand = updateComm;
                dataAdapter.UpdateCommand.Connection = connection;
                ////dataAdapter.UpdateCommand.ExecuteNonQuery();

                ////dataAdapter.InsertCommand = insertComm;
                dataAdapter.InsertCommand.Connection = connection;

                //string sql = String.Format("select * from {0};", table);

                //dataAdapter = new NpgsqlDataAdapter(sql, connection);
                //NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(dataAdapter);

                //dataAdapter.InsertCommand = builder.GetInsertCommand();
                //dataAdapter.DeleteCommand = builder.GetDeleteCommand();
                //dataAdapter.UpdateCommand = builder.GetUpdateCommand();



                dataAdapter.Update(libraryDS, table);

                libraryDS.AcceptChanges();

                //getData();

            }
        }


        public static void addDataTable(ref BindingSource bindSource, ref NpgsqlDataAdapter dataAdapter, string sqlQuery)
        {
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                dataAdapter.InsertCommand = new NpgsqlCommand(sqlQuery, npgSqlConnection);
                dataAdapter.Update((DataTable)bindSource.DataSource);
            }
        }
    }
}
