using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class FormPersonalUser : Form
    {
        public FormPersonalUser()
        {
            InitializeComponent();
        }
        private Dictionary<int, string> books = new Dictionary<int, string>();
        private bool debtBooks = false;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormPersonalUser_Load(object sender, EventArgs e)
        {
            labelNameUser.Text = String.Format("Добро пожаловать в личный кабинет, {0}", Authorization.nameUser);

            int library_card = Convert.ToInt32(Authorization.loginUser);
            string filter = String.Format("[id_library_kard] = {0}", library_card);

            DataTable issuing = DBAction.libraryDS.Tables["issuing_books"].Clone();
            DataTable booking = DBAction.libraryDS.Tables["booking"].Clone();
            DataTable book = DBAction.libraryDS.Tables["book"].Clone();

            DataRow[] selectedIssuing = DBAction.libraryDS.Tables["issuing_books"].Select(filter);
            DataRow[] selectedBooking = DBAction.libraryDS.Tables["booking"].Select(filter);
            DataRow[] selectedBook;

            foreach (DataRow row in selectedIssuing)
            {
                issuing.ImportRow(row);
            }

            foreach (DataRow row in selectedBooking)
            {
                booking.ImportRow(row);
            }

            //selectedBook = selectedIssuing.Select(String.Format("[id_library_cipher] = {0}", 

            if (issuing.Rows.Count == 0) 
            { 
                listViewIssuing.Items.Add("Нет выданных книг");
                listViewIssuing.CheckBoxes = false;
            }
            else
            {
                listViewIssuing.CheckBoxes = true;
                for (int i = 0; i < issuing.Rows.Count; i++)
                {
                    int libraryCipher = Convert.ToInt32(issuing.Rows[i][2].ToString().Trim());

                    selectedBook = DBAction.libraryDS.Tables["book"].Select(String.Format("[id_library_cipher] = {0}", libraryCipher));

                    foreach (DataRow row in selectedBook)
                    {
                        //string bookRow = 

                        string issuingBook = String.Format("Книга - {0}, дата выдачи - {1}, \nдата возврата - {2}, отдел - {3}",
                            row[1].ToString().Trim() + " '" + row[2].ToString().Trim() + "'",
                            issuing.Rows[i][3].ToString().Trim(), issuing.Rows[i][4].ToString().Trim(),
                            issuing.Rows[i][5].ToString().Trim());
                        listViewIssuing.Items.Add(issuingBook);
                        books.Add(Convert.ToInt32(issuing.Rows[i][0].ToString().Trim()), issuingBook);
                    }

                    if (DateTime.Now > DateTime.Parse(issuing.Rows[i][4].ToString()))
                    { debtBooks = true; }
                }
            }

            if (booking.Rows.Count == 0) 
            { 
                listViewBooking.Items.Add("Нет забронированных книг"); 
                listViewBooking.CheckBoxes = false; 
            }
            else
            {
                listViewBooking.CheckBoxes = true; 
                for (int i = 0; i < booking.Rows.Count; i++)
                {
                    int libraryCipher = Convert.ToInt32(booking.Rows[i][1].ToString().Trim());

                    selectedBook = DBAction.libraryDS.Tables["book"].Select(String.Format("[id_library_cipher] = {0}", libraryCipher));

                    foreach (DataRow row in selectedBook)
                    {
                        string bookingBook = String.Format("Книга - {0}, дата конца бронирования - {1}, отдел - {2}",
                            row[1].ToString().Trim() + " '" + row[2].ToString().Trim() + "'",
                            booking.Rows[i][3].ToString().Trim(), booking.Rows[i][4].ToString().Trim());
                        listViewBooking.Items.Add(bookingBook);
                        books.Add(Convert.ToInt32(booking.Rows[i][0].ToString().Trim()), bookingBook);
                    }
                }
            }
            //this.ShowInTaskbar = false;
            //notifyIcon1.Click += notifyIcon1_Click;

            if (debtBooks)
            {
                // задаем иконку всплывающей подсказки
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                // задаем текст подсказки
                notifyIcon1.BalloonTipText = "У вас есть задолженности";
                // устанавливаем зголовк
                notifyIcon1.BalloonTipTitle = "Внимание";
                // отображаем подсказку 12 секунд
                notifyIcon1.ShowBalloonTip(12);
            }
            
        }

        //void notifyIcon1_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Normal;
        //}

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
