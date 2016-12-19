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
        public static NpgsqlDataAdapter issuingBooksDataAdapter;

        private static string table = "issuing_books";

        public static void getTableIssuingBooks()
        {
            DBAction.getData(out issuingBooksDataAdapter, table);
        }

        private void FormIssuingBooks_Load(object sender, EventArgs e)
        {
            //issuingBooksDataTable.Columns[0].AutoIncrement = true;
            //dataGridIssuingBooks.DataSource = issuingBooksDataTable;
        }
    }
}
