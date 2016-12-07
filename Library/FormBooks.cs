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
        public static DataTable booksDataTable = new DataTable();
        public static NpgsqlDataAdapter dataAdapterBooks = new NpgsqlDataAdapter();
        

        private void FormBooks_Load(object sender, EventArgs e)
        {
            bindingSourceBooks.DataSource = booksDataTable;
            dataGridBooks.DataSource = bindingSourceBooks;

            dataGridBooks.Sort(dataGridBooks.Columns[0], ListSortDirection.Ascending);

            //dataAdapterBooks.InsertCommand = new NpgsqlCommand();
            //dataAdapterBooks.UpdateCommand = new NpgsqlCommand();
            //dataAdapterBooks.DeleteCommand = new NpgsqlCommand();

            #region nameColumns
            booksDataTable.Columns[0].ColumnName = "Библиотечный шифр";
            booksDataTable.Columns[1].ColumnName = "Автор";
            booksDataTable.Columns[2].ColumnName = "Название";
            booksDataTable.Columns[3].ColumnName = "Год";
            booksDataTable.Columns[4].ColumnName = "Количество страниц";
            booksDataTable.Columns[5].ColumnName = "Количество экземпляров";
            booksDataTable.Columns[6].ColumnName = "Номер отдела";
            #endregion

            if (Authorization.user)
            {
                for (int i = 0; i < booksDataTable.Columns.Count; i++)
                {
                    booksDataTable.Columns[i].ReadOnly = true;
                }

                buttonIssuing.Visible = false;
                buttonSave.Visible = false;
                buttonDelete.Visible = false;
                buttonAdd.Visible = false;
            }

            if (Authorization.admin)
            {
                buttonIssuing.Visible = false;
                buttonBooking.Visible = false;
            }

            if (Authorization.employee)
            {
                buttonBooking.Visible = false;
            }
            
            for (int i = 0; i < FormDepartment.departmentDataTable.Rows.Count; i++)
            {
                checkedListBoxDB.Items.Insert(i, FormDepartment.departmentDataTable.Rows[i][1]);
                
            }
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
                selectedBooksFromDepartment = booksDataTable.Clone();
                
                foreach (var temp in checkedListBoxDB.CheckedIndices)
                {
                    string filterString = String.Format("[{0}] = '{1}'", booksDataTable.Columns[6], Convert.ToInt32(temp) + 1);

                    foreach (DataRow row in booksDataTable.Select(filterString))
                    {
                        selectedBooksFromDepartment.ImportRow(row);
                    }
                }

                bindingSourceBooks.DataSource = selectedBooksFromDepartment;
            }
            else bindingSourceBooks.DataSource = booksDataTable;
        }

        private void buttonIssuing_Click(object sender, EventArgs e)
        {

        }

        private void buttonBooking_Click(object sender, EventArgs e)
        {
            if (dataGridBooks.SelectedRows.Count == 1)
            {

                //FormIssuingBooks.issuingBooksDataTable.Rows.Add();
            }
            else MessageBox.Show("Забронировать можно только одну книгу");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable updateDT = new DataTable();
                updateDT = booksDataTable.GetChanges();

                for (int i = 0; i < updateDT.Rows.Count; i++)
                {
                    string sql = String.Format("update book set author = '{0}', name_book = '{1}', year_book = '{2}', number_of_pages = '{3}', number_of_copies = '{4}' where id_library_cipher = {5};",
                        updateDT.Rows[i][1].ToString().Trim(), updateDT.Rows[i][2].ToString().Trim(),
                        updateDT.Rows[i][3].ToString().Trim(), updateDT.Rows[i][4].ToString().Trim(),
                        updateDT.Rows[i][5].ToString().Trim(), updateDT.Rows[i][0].ToString().Trim());
                    DBAction.updateDataTable(ref bindingSourceBooks, ref dataAdapterBooks, sql);
                }
                booksDataTable.AcceptChanges();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Кажется, вы забыли хоть что-нибудь поменять");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //DataTable updateDT = new DataTable();
            //updateDT = booksDataTable.;

            for (int i = 0; i < dataGridBooks.SelectedRows.Count; i++)
            {
                int id = Convert.ToInt32(dataGridBooks[0, dataGridBooks.SelectedRows[i].Index].Value);
                DBAction.deleteFromDataTable(ref bindingSourceBooks, ref dataAdapterBooks, "book", "id_library_cipher", id);
                //booksDataTable.Rows[id].Delete();
            }
            
        }

        private void checkedListBoxDB_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }




        //private void buttonSaveChange_Click(object sender, EventArgs e)
        //{
        //    booksDataTable.AcceptChanges();
        //    dataAdapter.Update((DataTable)bindingSourceBooks.DataSource);
        //}


    }
}
