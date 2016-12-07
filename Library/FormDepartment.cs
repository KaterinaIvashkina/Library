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
    public partial class FormDepartment : Form
    {
        public FormDepartment()
        {
            InitializeComponent();
        }
        public static DataTable departmentDataTable = new DataTable();
        public static NpgsqlDataAdapter dataAdapterDepartment = new NpgsqlDataAdapter();
        private string sqlQuery;

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            
            //DBAction.updateDataTable(ref dataAdapter);
            bindingSourceDepartment.DataSource = departmentDataTable;
            dataGridDepartment.DataSource = bindingSourceDepartment;
        }

        private void buttonSaveChange_Click(object sender, EventArgs e)
        {
            departmentDataTable.AcceptChanges();
            //dataAdapter.Update((DataTable)bindingSourceDepartment.DataSource);

            sqlQuery = "update department(address, phone, e_mail) set values (" + dataGridDepartment.CurrentCell.Value + ", " + dataGridDepartment.CurrentCell.Value + ", " + dataGridDepartment.CurrentCell.Value  + ") where " + dataGridDepartment.CurrentCell.RowIndex + " = id_department";
            //DBAction.updateDataTable(ref dataAdapterDepartment, sqlQuery);
            //dataAdapter.UpdateCommamd((DataTable)bindingSourceDepartment.DataSource);
        }

        
        
    }
}
