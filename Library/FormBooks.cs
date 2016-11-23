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
        public FormBooks()
        {
            InitializeComponent();
        }
        public static DataTable booksDataTable = new DataTable();
        private NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();

        private void FormBooks_Load(object sender, EventArgs e)
        {
            DBAction.getData(ref booksDataTable, ref dataAdapter, "book");
            bindingSourceBooks.DataSource = booksDataTable;
            dataGridBooks.DataSource = bindingSourceBooks;
        }
    }
}
