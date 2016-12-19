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
    public partial class FormReaders : Form
    {
        public FormReaders()
        {
            InitializeComponent();
        }
        private static Npgsql.NpgsqlDataAdapter readersDataAdapter;
        private static string table = "reader";

        public static void getTableReaders()
        {
            DBAction.getData(out readersDataAdapter, table);
        }

        private void FormReaders_Load(object sender, EventArgs e)
        {
            
            //bindingSourceReaders.DataSource = readersDataTable;
            //dataGridReaders.DataSource = bindingSourceReaders;
            
        }
    }
}
