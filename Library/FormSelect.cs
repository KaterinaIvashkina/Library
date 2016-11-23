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
            form.Show();
        }

        private void buttonListDepart_Click(object sender, EventArgs e)
        {
            var form = new FormDepartment();
            form.Show();
        }

        private void buttonListOutBooks_Click(object sender, EventArgs e)
        {
            var form = new FormIssuingBooks();
            form.Show();
        }

        private void buttonListReaders_Click(object sender, EventArgs e)
        {
            var form = new FormReaders();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var form = new FormPersonalUser();
            form.Show();
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }       
    }
}