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

            departmentBindingSource.DataSource = DBAction.libraryDS.Tables["department"];
        }
        //public static DataTable departmentDataTable = new DataTable();
        public static NpgsqlDataAdapter departmentDataAdapter;

        private static string table = "department";

        public static void getTableDepartmnet()
        {
            DBAction.getData(out departmentDataAdapter, table);
        }

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = DBAction.libraryDS.Tables["department"];

            dataGridDepartment.Sort(dataGridDepartment.Columns[0], ListSortDirection.Ascending);
            //DBAction.updateDataTable(ref dataAdapter);
            //bindingSourceDepartment.DataSource = departmentDataTable;
            //dataGridDepartment.DataSource = bindingSourceDepartment;

            if (Authorization.user)
            {
                dataGridDepartment.ReadOnly = true;

                buttonSaveChange.Visible = false;

                bindingNavigatorDeleteItem.Visible = false;
                bindingNavigatorAddNewItem.Visible = false;
            }

            if (Authorization.admin || Authorization.employee)
            {
                dataGridDepartment.ReadOnly = false;

                buttonSaveChange.Visible = true;

                bindingNavigatorDeleteItem.Visible = true;
                bindingNavigatorAddNewItem.Visible = true;
            }
        }

        private void buttonSaveChange_Click(object sender, EventArgs e)
        {
            //departmentDataTable.AcceptChanges();
            //dataAdapter.Update((DataTable)bindingSourceDepartment.DataSource);

            //sqlQuery = "update department(address, phone, e_mail) set values (" + dataGridDepartment.CurrentCell.Value + ", " + dataGridDepartment.CurrentCell.Value + ", " + dataGridDepartment.CurrentCell.Value  + ") where " + dataGridDepartment.CurrentCell.RowIndex + " = id_department";
            //DBAction.updateDataTable(ref dataAdapterDepartment, sqlQuery);
            //dataAdapter.UpdateCommamd((DataTable)bindingSourceDepartment.DataSource);
            DBAction.updateDataTable(departmentDataAdapter, "department");
        }

        
        
    }
}
