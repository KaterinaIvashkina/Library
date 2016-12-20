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

        private NpgsqlCommand deleteCommand = new NpgsqlCommand(@"delete from book where id_library_cipher = @Id");
        private NpgsqlCommand insertCommand = new NpgsqlCommand(@"insert into book(author, name_book, year_book, number_of_pages, number_of_copies, id_department) values(@Author, @Name, @Year, @Pages, @Copies, @Department) returning id_library_cipher;");
        private NpgsqlCommand updateCommand = new NpgsqlCommand(@"update book set author = @Author, name_book = @Name, year_book = @Year, number_of_pages = @Pages, number_of_copies = @Copies, id_department = @Department where id_library_cipher = @Id;");

        private void FormBooks_Load(object sender, EventArgs e)
        {
            dataGridBooks.Sort(dataGridBooks.Columns[0], ListSortDirection.Ascending);
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
            string book = dataGridBooks.CurrentRow.Cells[1].Value.ToString().Trim() + " '" +
                    dataGridBooks.CurrentRow.Cells[2].Value.ToString().Trim() + "'";
            string library_cipher = dataGridBooks.CurrentRow.Cells[0].Value.ToString();

            var f = new FormIssuingBookReader(book, library_cipher);
            f.ShowDialog();
        }

        private void buttonBooking_Click(object sender, EventArgs e)
        {
            bool readerHasNotBooking = true;
            for (int i = 0; i < DBAction.libraryDS.Tables["booking"].Rows.Count; i++)
            {
                if (DBAction.libraryDS.Tables["booking"].Rows[i][2].ToString() == Authorization.nameUser)
                { readerHasNotBooking = false; }
                else readerHasNotBooking = true;
            }
            if (!readerHasNotBooking) { MessageBox.Show("У вас уже есть забронированные книги"); }
            else if ((dataGridBooks.SelectedRows.Count == 1) && (readerHasNotBooking))
            {
                string book = dataGridBooks.CurrentRow.Cells[1].Value.ToString().Trim() + " '" +
                    dataGridBooks.CurrentRow.Cells[2].Value.ToString().Trim() + "'";
                string library_cipher = dataGridBooks.CurrentRow.Cells[0].Value.ToString();
                Reader_Booking f = new Reader_Booking(book, library_cipher);
                f.ShowDialog();
            }
            else MessageBox.Show("Забронировать можно только одну книгу");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataAdapterCommand();
        }

        public void dataAdapterCommand()
        {
            bookDataAdapter = new NpgsqlDataAdapter();

            #region parameteters.add
            deleteCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_library_cipher";

            insertCommand.Parameters.Add("@Author", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "author";
            insertCommand.Parameters.Add("@Name", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "name_book";
            insertCommand.Parameters.Add("@Year", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "year_book";
            insertCommand.Parameters.Add("@Pages", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "number_of_pages";
            insertCommand.Parameters.Add("@Copies", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "number_of_copies";
            insertCommand.Parameters.Add("@Department", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_department";

            updateCommand.Parameters.Add("@Author", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "author";
            updateCommand.Parameters.Add("@Name", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "name_book";
            updateCommand.Parameters.Add("@Year", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "year_book";
            updateCommand.Parameters.Add("@Pages", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "number_of_pages";
            updateCommand.Parameters.Add("@Copies", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "number_of_copies";
            updateCommand.Parameters.Add("@Department", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_department";
            updateCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_library_cipher";
            #endregion

            bookDataAdapter.UpdateCommand = updateCommand;
            bookDataAdapter.DeleteCommand = deleteCommand;
            bookDataAdapter.InsertCommand = insertCommand;


            DBAction.updateDataTable(bookDataAdapter, table);

            getTableBook();
        }

        public static void getTableBook()
        {
            DBAction.libraryDS.Tables[table].Clear();
            DBAction.getData(out bookDataAdapter, table);
        }

        private void dataGridBooks_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введены некорректные данные");
        }

        
    }
}
