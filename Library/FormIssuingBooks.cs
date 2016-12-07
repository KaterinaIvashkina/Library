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
        public FormIssuingBooks()
        {
            InitializeComponent();
        }
        public static DataTable issuingBooksDataTable = new DataTable();
        public static NpgsqlDataAdapter dataAdapterIssuingBooks = new NpgsqlDataAdapter();

        private void FormIssuingBooks_Load(object sender, EventArgs e)
        {
            issuingBooksDataTable.Columns[0].AutoIncrement = true;
            dataGridIssuingBooks.DataSource = issuingBooksDataTable;
        }
    }
}
