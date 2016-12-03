using System;
using System.Windows.Forms;

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

            FormBooks.booksDataTable.Clear();
            FormDepartment.departmentDataTable.Clear();
            FormIssuingBooks.issuingBooksDataTable.Clear();
            FormReaders.readersDataTable.Clear();
            #endregion
            

            form.ShowDialog();
        }

        private void labelSearch_Click(object sender, EventArgs e)
        {
            var form = new FormSearch();
            form.ShowDialog();
        }       
    }
}