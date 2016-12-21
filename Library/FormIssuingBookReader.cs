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
    public partial class FormIssuingBookReader : Form
    {
        private string selectBook, cipherBook;
        private const double daysIssuing = 14;

        public FormIssuingBookReader(string book, string cipherBook)
        {
            InitializeComponent();

            this.selectBook = book;
            this.cipherBook = cipherBook;
        }

        

        private void FormIssuingBookReader_Load(object sender, EventArgs e)
        {
            comboBoxReaders.ValueMember = DBAction.libraryDS.Tables["reader"].Columns[1].ToString();
            for (int i = 0; i < DBAction.libraryDS.Tables["reader"].Rows.Count; i++)
            {
                comboBoxReaders.Items.Add(DBAction.libraryDS.Tables["reader"].Rows[i][0].ToString().Trim());
            }

            comboBoxDepartment.ValueMember = DBAction.libraryDS.Tables["department"].Columns[0].ToString();
            for (int i = 0; i < DBAction.libraryDS.Tables["department"].Rows.Count; i++)
            {
                comboBoxDepartment.Items.Add(DBAction.libraryDS.Tables["department"].Rows[i][1].ToString().Trim());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string info = String.Format("Книга - {0} \nОтдел - {1} \nЧитатель - {2} \nСрок выдачи - 14 дней \nНеобходимо вернуть книгу до {3}",
                selectBook, comboBoxDepartment.SelectedItem, comboBoxReaders.SelectedItem.ToString(), DateTime.Now.AddDays(daysIssuing).ToLongDateString());
            DialogResult result = MessageBox.Show(info, "Подтверждение", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.OK)
            {
                int count = DBAction.libraryDS.Tables["issuing_books"].Rows.Count + 1;
                DBAction.libraryDS.Tables["issuing_books"].Rows.Add(count, Convert.ToInt32(comboBoxReaders.SelectedItem), Convert.ToInt32(cipherBook), DateTime.Now.ToLongDateString(), DateTime.Now.AddDays(daysIssuing).ToLongDateString(), comboBoxDepartment.SelectedIndex + 1);
                var f = new FormIssuingBooks();
                f.dataAdapterCommand();
                //f.setInsertCommand(cipherBook, Authorization.nameUser, DateTime.Now.ToLongDateString(), (comboBoxDepartment.SelectedIndex + 1).ToString());
                this.Close();
                FormBooks f1 = new FormBooks();
                f1.Show();
            }

        }
    }
}
