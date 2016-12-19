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
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string searchText = textBoxQuery.Text;

            string[] fieldBook = new string[]{"id_library_cipher", "author", "name_book", "year_book",
                "number_of_pages", "number_of_copies", "id_department"};
            string[] fieldReader = new string[]{"id_library_kard", "name_reader", "home_address", 
                "phone", "e_mail"};

            DataTable searchDataBook = new DataTable();
            searchDataBook = DBAction.libraryDS.Tables["book"].Clone(); 

            DataTable searchDataReader = new DataTable();
            searchDataReader = DBAction.libraryDS.Tables["reader"].Clone();

            if ((radioButtonBook.Checked) || (Authorization.user))
            {
                for (int i = 1; i < searchDataBook.Columns.Count; i++)
                {
                    string filterString = String.Format("[{0}] = '{1}'", searchDataBook.Columns[i], searchText);

                    foreach (DataRow row in DBAction.libraryDS.Tables["book"].Select(filterString))
                    {
                        searchDataBook.ImportRow(row);
                    }
                }

                dataGridViewSearch.DataSource = searchDataBook;
            }
            else if (radioButtonReader.Checked)
            {
                foreach (var readerColumn in fieldReader)
                {
                    string filterString = String.Format("[{0}] = '{1}'", readerColumn, searchText);

                    foreach (DataRow row in DBAction.libraryDS.Tables["reader"].Select(filterString))
                    {
                        searchDataReader.ImportRow(row);
                    }
                }
                dataGridViewSearch.DataSource = searchDataReader;
            }
            else MessageBox.Show("Кажется, где-то тут ошибка!");
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            if (Authorization.user)
            {
                radioButtonBook.Visible = false;
                radioButtonReader.Visible = false;

                label1.Text = "Воспользуйтесь кнопкой 'Поиск', чтобы найти интересующую вас книгу";
            }
            else if ((Authorization.admin) || (Authorization.employee))
            { label1.Visible = false; }
        }
    }
}
