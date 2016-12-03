using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

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

            #region hashPass
            string pass = passwordTextBox.Text;
            byte[] bytes = new byte[pass.Length];
            int count = 0;

            foreach (var temp in pass)
            {
                bytes[count++] = Convert.ToByte(temp);
            }

            SHA1 sha = new SHA1CryptoServiceProvider();
            var result = sha.ComputeHash(sha.ComputeHash(bytes));

            StringBuilder hex = new StringBuilder(result.Length * 2);
            foreach (byte b in result)
            { hex.AppendFormat("{0:x2}", b); }
            #endregion

            if (autho.validation(loginTextBox.Text, hex.ToString()))
            {
                form.ShowDialog();
                this.Hide();
                Application.Exit();
            }
            else MessageBox.Show("Неверный логин или пароль!");
        }

        private void labelForgottenPassword_Click(object sender, EventArgs e)
        {
            FormPasswordRecovery form = new FormPasswordRecovery();
            form.ShowDialog();
        }
    }
}
