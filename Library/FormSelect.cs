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
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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
            DBAction.getData(ref FormBooks.booksDataTable, ref FormBooks.dataAdapterBooks, "book");
            DBAction.getData(ref FormDepartment.departmentDataTable, ref FormDepartment.dataAdapterDepartment, "department");
            DBAction.getData(ref FormIssuingBooks.issuingBooksDataTable, ref FormIssuingBooks.dataAdapterIssuingBooks, "issuing_books");
            DBAction.getData(ref FormReaders.readersDataTable, ref FormReaders.dataAdapterReaders, "reader");
            DBAction.getData(ref FormBooking.bookingDataTable, ref FormBooking.dataAdapterBooking, "booking");
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

            FormBooks.booksDataTable.Clear();
            FormBooks.booksDataTable.Columns.Clear();

            FormDepartment.departmentDataTable.Clear();
            FormDepartment.departmentDataTable.Columns.Clear();

            FormIssuingBooks.issuingBooksDataTable.Clear();
            FormIssuingBooks.issuingBooksDataTable.Columns.Clear();

            FormReaders.readersDataTable.Clear();
            FormReaders.readersDataTable.Columns.Clear();
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
    }
}