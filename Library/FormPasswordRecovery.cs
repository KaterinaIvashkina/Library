using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Library
{
    public partial class FormPasswordRecovery : Form
    {
        public FormPasswordRecovery()
        {
            InitializeComponent();
        }
        private string confCode = "";
        private string login;

        private void FormPasswordRecovery_Load(object sender, EventArgs e)
        {
            label3.Hide();
            label4.Hide();
            textBoxCode.Hide();
            textBoxNewPassword.Hide();
            buttonRecovery.Hide();

        }

        private void buttonSendMail_Click(object sender, EventArgs e)
        {
            string e_mail = textBoxMail.Text;
            login = textBoxLogin.Text;

            if (Authorization.checkingUser(login, e_mail))
            {
                confCode = SendMail(e_mail);

                #region changeForm
                label1.Hide();
                label2.Hide();
                textBoxLogin.Hide();
                textBoxMail.Hide();
                buttonSendMail.Hide();


                label3.Show();
                label4.Show();
                textBoxCode.Show();
                textBoxNewPassword.Show();
                buttonRecovery.Show();
                #endregion
            }
            else MessageBox.Show("Не удается распознать логин или e-mail. Проверьте правильность введенных данных");
        }

        private void buttonRecovery_Click(object sender, EventArgs e)
        {
            //if (confCode == textBoxCode.Text)
            //{
                string digest = Authorization.SHAdigest(textBoxNewPassword.Text);

                if (DBAction.updatePassword(digest, login))
                {
                    MessageBox.Show("Пароль изменен! Теперь вы можете войти в систему");
                }
                else MessageBox.Show("Возникла ошибка");

            //}
            //else MessageBox.Show("Введен неверный код");
        }

        private string SendMail(string to)
        {
            //smtp сервер
            const string smtpHost = "smtp.mail.ru";
            //smtp порт - 25, 587 или 2525
            const int smtpPort = 25;

            const string login = "library.best@mail.ru";
            const string pass = "64Rqw.12";

            SmtpClient client = new SmtpClient(smtpHost, smtpPort);
            client.Credentials = new NetworkCredential(login, pass);
            client.EnableSsl = true;

            Random rand = new Random();
            string confCode = rand.Next(10000, 100000).ToString();

            string from = "library.best@mail.ru";
            string subject = "Восстановление пароля. Библиотека";
            string body = String.Format("Здравствуйте, {0}! \n\n\n Вы заполнили форму восстановления пароля \n\n\n Ваш код подтверждения: {1}", Authorization.nameUser, confCode);

            MailMessage mess = new MailMessage(from, to, subject, body);

            try
            {
                client.Send(mess);
                MessageBox.Show("На Вашу почту был отправлен код подтверждения");
                return confCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
