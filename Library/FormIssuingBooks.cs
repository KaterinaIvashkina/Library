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
    public partial class FormIssuingBooks : Form
    {
        ToolStripLabel dateLabel, timeLabel, infoLabel;
        Timer timer;

        public FormIssuingBooks()
        {
            InitializeComponent();

            issuingbooksBindingSource.DataSource = DBAction.libraryDS.Tables["issuing_books"];

            if (Authorization.admin)
            {
                bindingNavigator1.DeleteItem.Visible = false;
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
        public static NpgsqlDataAdapter issuingBooksDataAdapter;

        private static string table = "issuing_books";

        private NpgsqlCommand deleteCommand = new NpgsqlCommand(@"delete from issuing_books where id_issuing = @Id");
        private NpgsqlCommand insertCommand = new NpgsqlCommand(@"insert into issuing_books(id_library_kard, id_library_cipher, date_issuing, date_return, id_department) values(@LibraryCard, @LibraryCipher, @DateIssuing, @DateReturn, @Department);");
        private NpgsqlCommand updateCommand = new NpgsqlCommand(@"update issuing_books set date_return = @DateReturn where id_issuing = @Id;");

        void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void FormIssuingBooks_Load(object sender, EventArgs e)
        {
            dataGridIssuingBooks.Sort(dataGridIssuingBooks.Columns[0], ListSortDirection.Ascending);
        }

        public static void getTableIssuingBooks()
        {
            DBAction.libraryDS.Tables[table].Clear();
            DBAction.getData(out issuingBooksDataAdapter, table);
        }

        private void buttonCheckDebt_Click(object sender, EventArgs e)
        {
            bool debt = false;
            for (int i = 0; i < DBAction.libraryDS.Tables[table].Rows.Count; i++)
            {
                if (DateTime.Now > DateTime.Parse(DBAction.libraryDS.Tables[table].Rows[i][4].ToString()))
                {
                    debt = true;
                }
            }

            if (debt) { MessageBox.Show("Задолженности есть"); }
            else { MessageBox.Show("Задолженностей нет"); }
        }

        private void buttonSaveChange_Click(object sender, EventArgs e)
        {
            dataAdapterCommand();
        }

        private void buttonBooksDay_Click(object sender, EventArgs e)
        {

        }

        public void dataAdapterCommand()
        {
            #region parameteters.add
            deleteCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_issuing";

            insertCommand.Parameters.Add("@LibraryCard", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = DBAction.libraryDS.Tables[table].Columns[1].ToString();
            insertCommand.Parameters.Add("@LibraryCipher", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = DBAction.libraryDS.Tables[table].Columns[2].ToString();
            insertCommand.Parameters.Add("@DateIssuing", NpgsqlTypes.NpgsqlDbType.Date).SourceColumn = DBAction.libraryDS.Tables[table].Columns[3].ToString();
            insertCommand.Parameters.Add("@DateReturn", NpgsqlTypes.NpgsqlDbType.Date).SourceColumn = DBAction.libraryDS.Tables[table].Columns[4].ToString();
            insertCommand.Parameters.Add("@Department", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = DBAction.libraryDS.Tables[table].Columns[5].ToString();

            updateCommand.Parameters.Add("@DateReturn", NpgsqlTypes.NpgsqlDbType.Date).SourceColumn = "date_return";
            updateCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_issuing";
            #endregion

            issuingBooksDataAdapter.UpdateCommand = updateCommand;
            issuingBooksDataAdapter.DeleteCommand = deleteCommand;
            issuingBooksDataAdapter.InsertCommand = insertCommand;

            DBAction.updateDataTable(issuingBooksDataAdapter, table);

            getTableIssuingBooks();
        }
    }
}
