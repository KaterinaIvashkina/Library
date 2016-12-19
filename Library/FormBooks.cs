using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Library
{
    public partial class FormBooks : Form
    {
        ToolStripLabel dateLabel, timeLabel, infoLabel;
        Timer timer;

        public FormBooks()
        {
            InitializeComponent();

            bookBindingSource.DataSource = DBAction.libraryDS.Tables["book"];

            //DBAction.libraryDS.Tables["book"].RejectChanges();

            //dataGridBooks.Sort(dataGridBooks.Columns[0], ListSortDirection.Ascending);

            if (Authorization.user)
            {
                dataGridBooks.ReadOnly = true;

                buttonIssuing.Visible = false;
                buttonSave.Visible = false;

                bindingNavigatorDeleteItem.Visible = false;
                bindingNavigatorAddNewItem.Visible = false;
            }

            if (Authorization.admin)
            {
                dataGridBooks.ReadOnly = false;

                buttonIssuing.Visible = false;
                buttonBooking.Visible = false;

                bindingNavigatorDeleteItem.Visible = true;
                bindingNavigatorAddNewItem.Visible = true;
            }

            if (Authorization.employee)
            {
                dataGridBooks.ReadOnly = false;

                buttonBooking.Visible = false;

                bindingNavigatorDeleteItem.Visible = true;
                bindingNavigatorAddNewItem.Visible = true;
            }

            for (int i = 0; i < DBAction.libraryDS.Tables["department"].Rows.Count; i++)
            {
                checkedListBoxDB.Items.Insert(i, DBAction.libraryDS.Tables["department"].Rows[i][1]);
            }

            infoLabel = new ToolStripLabel("Текущие дата и время:");
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer1_Tick;
            timer.Start();
        }

        private static string table = "book";
        private static NpgsqlDataAdapter bookDataAdapter;

        //private NpgsqlCommand deleteCommand = new NpgsqlCommand(@"delete from book where id_library_cipher = @Id");
        //private NpgsqlCommand insertCommand = new NpgsqlCommand(@"insert into book (author, name_book, year_book, number_of_pages, number_of_copies, id_department) values (@Author, @Name, @Year, @Pages, @Copies, @Department);");
        //private NpgsqlCommand updateCommand = new NpgsqlCommand(@"update book set author = @Author, name_book = @Name, year_book = @Year, number_of_pages = @Pages, number_of_copies = @Copies, id_department = @Department where id_library_cipher = @Id;");


        private void FormBooks_Load(object sender, EventArgs e)
        {
            
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void checkedListBoxDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((checkedListBoxDB.CheckedIndices.Count > 0) && (checkedListBoxDB.CheckedIndices.Count < checkedListBoxDB.Items.Count))
            {
                DataTable selectedBooksFromDepartment = new DataTable();
                selectedBooksFromDepartment = DBAction.libraryDS.Tables["book"].Clone();

                foreach (var temp in checkedListBoxDB.CheckedIndices)
                {
                    string filterString = String.Format("[{0}] = '{1}'", DBAction.libraryDS.Tables["book"].Columns[6], Convert.ToInt32(temp) + 1);

                    foreach (DataRow row in DBAction.libraryDS.Tables["book"].Select(filterString))
                    {
                        selectedBooksFromDepartment.ImportRow(row);
                    }
                }

                bookBindingSource.DataSource = selectedBooksFromDepartment;
            }
            else bookBindingSource.DataSource = DBAction.libraryDS.Tables["book"];
        }

        private void buttonIssuing_Click(object sender, EventArgs e)
        {

        }

        private void buttonBooking_Click(object sender, EventArgs e)
        {
            if (dataGridBooks.SelectedRows.Count == 1)
            {
                string book = dataGridBooks.CurrentRow.Cells[1].Value.ToString().Trim() + " '" +
                    dataGridBooks.CurrentRow.Cells[2].Value.ToString().Trim() + "'";
                Reader_Booking f = new Reader_Booking(book);
                f.ShowDialog();
            }
            else MessageBox.Show("Забронировать можно только одну книгу");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
                //DataTable updateDT = new DataTable();
                //updateDT = booksDataTable.GetChanges();

                //for (int i = 0; i < updateDT.Rows.Count; i++)
                //{
                //    string sqlUpdate = String.Format("update book set author = '{0}', name_book = '{1}', year_book = '{2}', number_of_pages = '{3}', number_of_copies = '{4}', id_department = '{5}' where id_library_cipher = {6};",
                //        updateDT.Rows[i][1].ToString().Trim(), updateDT.Rows[i][2].ToString().Trim(),
                //        updateDT.Rows[i][3].ToString().Trim(), updateDT.Rows[i][4].ToString().Trim(),
                //        updateDT.Rows[i][5].ToString().Trim(), updateDT.Rows[i][6].ToString().Trim(),
                //        updateDT.Rows[i][0].ToString().Trim());
                //    //string sqlDelete = String.Format("delete from book where id_library_cipher = {2}", 
                //    //DBAction.updateDataTable(ref bindingSourceBooks, ref dataAdapterBooks, sqlUpdate, sqlDelete, sqlAdd);
                //    DBAction.updateDataTable(ref bindingSourceBooks, ref dataAdapterBooks, sqlUpdate);

                //}
                //booksDataTable.AcceptChanges();

                //deleteCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_library_cipher";

                //NpgsqlDataAdapter bookDataAdapter = new NpgsqlDataAdapter();

                //updateCommand.Parameters.Add("@Author", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "authorColumn";
                //updateCommand.Parameters.Add("@Name", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "namebookColumn";
                //updateCommand.Parameters.Add("@Year", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "yearbookColumn";
                //updateCommand.Parameters.Add("@Pages", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "numberofpagesColumn";
                //updateCommand.Parameters.Add("@Copies", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "numberofcopiesColumn";
                //updateCommand.Parameters.Add("@Department", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "iddepartmentColumn";
                //updateCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "idlibrarycipherColumn";

                ////int changeRows = dataGridBooks.Rows.


                DBAction.updateDataTable(bookDataAdapter, table);

                //bookDataAdapter.Update(DBAction.libraryDS, table);

                //DBAction.libraryDS.AcceptChanges();

                //DBAction.updateDataTable(ref bookDataAdapter, deleteCommand, updateCommand, insertCommand, "book");
                ////bookDataAdapter.Update(DBAction.libraryDS);
            
        }

        //private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        //{
            //if (MessageBox.Show("Вы уверены, что хотите удалить книгу?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    deleteCommand.Parameters.Add("@Id", dataGridBooks[0, dataGridBooks.CurrentRow.Index].Value.ToString());

            //}
        //}

//        using (SqlConnection conn = new SqlConnection(строка подключения к бд))
//                {
//                    SqlCommand comm = new SqlCommand(@"Delete from ClientStock where Id=@Id", conn);
//                    comm.Parameters.Add("@Id", SqlDbType.Int).SourceColumn = "Id";
//                    SqlDataAdapter ada = new SqlDataAdapter();
//                    ada.DeleteCommand = comm;
//                    comm = new SqlCommand(@"Update ClientStock Set Adress = @Adrr, Distance=@Dist where Id=@Id", conn);
//                    comm.Parameters.Add("@Id", SqlDbType.Int).SourceColumn = "Id";
//                    comm.Parameters.Add("@Adrr", SqlDbType.NVarChar).SourceColumn = "Adress";
//                    comm.Parameters.Add("@Dist", SqlDbType.Decimal).SourceColumn = "Distance";
//                    ada.UpdateCommand = comm;
 
//                    comm = new SqlCommand(@"Insert into ClientStock Values(@IdCl, @IdCity, @Adrr, @Dist); Select @@IDENTITY", conn);
//                    comm.Parameters.Add("@IdCl", SqlDbType.Int).SourceColumn = "IdCl";
//                    comm.Parameters.Add("@IdCity", SqlDbType.Int).SourceColumn = "IdCity";
//                    comm.Parameters.Add("@Adrr", SqlDbType.NVarChar).SourceColumn = "Adress";
//                    comm.Parameters.Add("@Dist", SqlDbType.Decimal).SourceColumn = "Distance";
//                    ada.InsertCommand = comm;
 
                    
//                    ada.Update(ClStock); //ClStock - DataTable, 
////ada.Update(ds, "ClStock"); - перегрузка метода, в качестве параметра объект DataSet, второй - имя таблицы в DataSet
//                }



//        this.table_1TableAdapter.Update(this.test5DataSet.Table_1);
//this.table_2TableAdapter.Update(this.test5DataSet.Table_2);

        public static void getTableBook()
        {
            DBAction.getData(out bookDataAdapter, table);
        }

        
    }
}
