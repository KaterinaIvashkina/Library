using System;
using System.Windows.Forms;

namespace Library
{
    public partial class FormAutho : Form
    {
        public FormAutho()
        {
            InitializeComponent();
            loginTextBox.AutoCompleteCustomSource = DBAction.getLoginUser();
        }

        private void OnlineButton_Click(object sender, EventArgs e)
        {
            FormSelect form = new FormSelect();
            Authorization autho = new Authorization();

            if (autho.checkingUser(loginTextBox.Text, passwordTextBox.Text))
            {
                form.Show();
                this.Hide();
            }
            else MessageBox.Show("Неверный логин или пароль!");
        }
    }
}
