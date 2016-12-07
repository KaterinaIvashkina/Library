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
        public static DataTable readersDataTable = new DataTable();
        public static NpgsqlDataAdapter dataAdapterReaders = new NpgsqlDataAdapter();

        private void FormReaders_Load(object sender, EventArgs e)
        {
            
            bindingSourceReaders.DataSource = readersDataTable;
            dataGridReaders.DataSource = bindingSourceReaders;
            
        }
    }
}
