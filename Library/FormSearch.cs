using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string searchText = textBoxQuery.Text;
            DataTable searchDataBook = new DataTable();
            searchDataBook = FormBooks.booksDataTable.Clone();
            DataTable searchDataReader = new DataTable();
            searchDataReader = FormReaders.readersDataTable.Clone();

            for (int i = 0; i < FormBooks.booksDataTable.Rows.Count; i++)
            {
                for (int j = 0; j< FormBooks.booksDataTable.Columns.Count; j++)
                {
                    if (searchText == FormBooks.booksDataTable.Rows[i][j].ToString())
                    {
                        //searchDataBook.Merge(

                    }
                }
            }

            dataGridViewSearch.DataSource = searchDataBook;
        }
    }
}
