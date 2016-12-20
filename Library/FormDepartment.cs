using System;
using System.ComponentModel;
using System.Windows.Forms;
using Npgsql;

namespace Library
{
    public partial class FormDepartment : Form
    {
        ToolStripLabel dateLabel, timeLabel, infoLabel;
        Timer timer;

        public FormDepartment()
        {
            InitializeComponent();

            departmentBindingSource.DataSource = DBAction.libraryDS.Tables["department"];

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
        private static NpgsqlDataAdapter departmentDataAdapter;

        private static string table = "department";

        private NpgsqlCommand deleteCommand = new NpgsqlCommand(@"delete from department where id_department = @Id");
        private NpgsqlCommand insertCommand = new NpgsqlCommand(@"insert into department(address, phone, e_mail) values(@Address, @Phone, @Email) returning id_department;");
        private NpgsqlCommand updateCommand = new NpgsqlCommand(@"update department set address = @Address, phone = @Phone, e_mail = @Email where id_department = @Id;");

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            dataGridDepartment.Sort(dataGridDepartment.Columns[0], ListSortDirection.Ascending);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        public static void getTableDepartment()
        {
            DBAction.libraryDS.Tables[table].Clear();
            DBAction.getData(out departmentDataAdapter, table);
        }

        private void buttonSaveChange_Click(object sender, EventArgs e)
        {
            //departmentDataTable.AcceptChanges();
            //dataAdapter.Update((DataTable)bindingSourceDepartment.DataSource);

            //sqlQuery = "update department(address, phone, e_mail) set values (" + dataGridDepartment.CurrentCell.Value + ", " + dataGridDepartment.CurrentCell.Value + ", " + dataGridDepartment.CurrentCell.Value  + ") where " + dataGridDepartment.CurrentCell.RowIndex + " = id_department";
            //DBAction.updateDataTable(ref dataAdapterDepartment, sqlQuery);
            //dataAdapter.UpdateCommamd((DataTable)bindingSourceDepartment.DataSource);

            departmentDataAdapter = new NpgsqlDataAdapter();

            #region parameteters.add
            deleteCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_department";

            insertCommand.Parameters.Add("@Address", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "address";
            insertCommand.Parameters.Add("@Phone", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "phone";
            insertCommand.Parameters.Add("@Email", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "e_mail";

            updateCommand.Parameters.Add("@Address", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "address";
            updateCommand.Parameters.Add("@Phone", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "phone";
            updateCommand.Parameters.Add("@Email", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "e_mail";
            updateCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_department";
            #endregion

            departmentDataAdapter.UpdateCommand = updateCommand;
            departmentDataAdapter.DeleteCommand = deleteCommand;
            departmentDataAdapter.InsertCommand = insertCommand;


            DBAction.updateDataTable(departmentDataAdapter, table);

            getTableDepartment();

        }
        
        
    }
}
