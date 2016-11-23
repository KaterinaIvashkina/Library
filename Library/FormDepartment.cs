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
        private NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            DBAction.getData(ref departmentDataTable, ref dataAdapter, "department");
            bindingSourceDepartment.DataSource = departmentDataTable;
            dataGridDepartment.DataSource = bindingSourceDepartment;
        }

        private void buttonSaveChange_Click(object sender, EventArgs e)
        {
            departmentDataTable.AcceptChanges();
            dataAdapter.Update((DataTable)bindingSourceDepartment.DataSource);
        }

        public void UpdateDataTable()
        {

            //if (!dataGridDepartment.HasChanges(DataRowState.Added | DataRowState.Modified))
            //{
            //    MessageBox.Show("Hasn't been changed:" + DataRowState.Added + "  " + DataRowState.Modified);
            //    return;
            //}
            //DataSet xDataSet;
            //xDataSet = ds.GetChanges(DataRowState.Added | DataRowState.Modified);    // Changes for modified rows only.            
            //if (xDataSet.HasErrors)             // Check the DataSet for errors.
            //    MessageBox.Show("Has Errors"); // Resolve errors.

            //da.Update(xDataSet, tbl);             // After fixing errors, update the data source with da            
        }
        
    }
}
