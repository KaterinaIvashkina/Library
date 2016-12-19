using System;
using System.Windows.Forms;
using System.Data;
using Npgsql;

namespace Library
{
    public partial class FormSelect : Form
    {
        public FormSelect()
        {
            InitializeComponent();

            getAllTables();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DBAction.libraryDS.RejectChanges();

            if (Authorization.user)
            {
                buttonListOutBooks.Visible = false;
                buttonListReaders.Visible = false;
                buttonBooking.Visible = false;
            }
            if ((Authorization.employee) || (Authorization.admin))
            {
                labelPersonal.Visible = false;
            }
        }

        private void buttonListBooks_Click(object sender, EventArgs e)
        {
            var form = new FormBooks();
            form.ShowDialog();
        }

        private void buttonListDepart_Click(object sender, EventArgs e)
        {
            var form = new FormDepartment();
            form.ShowDialog();
        }

        private void buttonListOutBooks_Click(object sender, EventArgs e)
        {
            var form = new FormIssuingBooks();
            form.ShowDialog();
        }

        private void buttonListReaders_Click(object sender, EventArgs e)
        {
            var form = new FormReaders();
            form.ShowDialog();
        }

        private void labelPersonal_Click(object sender, EventArgs e)
        {
            var form = new FormPersonalUser();
            form.ShowDialog();
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            var form = new FormAutho();
            this.Hide();
            #region Set default params
            Authorization.employee = false;
            Authorization.user = false;
            Authorization.admin = false;
            Authorization.nameUser = "";
            #endregion
            
            form.ShowDialog();
        }

        private void labelSearch_Click(object sender, EventArgs e)
        {
            var form = new FormSearch();
            form.ShowDialog();
        }

        private void buttonBooking_Click(object sender, EventArgs e)
        {
            var form = new FormBooking();
            form.ShowDialog();
        }

        public static void getAllTables()
        {
            FormBooking.getTableBooking();
            FormBooks.getTableBook();
            FormDepartment.getTableDepartmnet();
            FormIssuingBooks.getTableIssuingBooks();
            FormReaders.getTableReaders();

        }
    }
}