using System;
using System.Data;
using System.Linq;
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
            string filterString = "";
            
            DataTable searchDataBook = new DataTable();
            searchDataBook = DBAction.libraryDS.Tables["book"].Clone();

            #region SearchDataBook.Columns - Headers
            searchDataBook.Columns[0].Caption = "Библиотечный шифр";
            searchDataBook.Columns[1].Caption = "Автор";
            searchDataBook.Columns[2].Caption = "Заглавие";
            searchDataBook.Columns[3].Caption = "Год";
            searchDataBook.Columns[4].Caption = "Количество страниц";
            searchDataBook.Columns[5].Caption = "Количество экземпляров";
            searchDataBook.Columns[6].Caption = "Номер отдела";
            #endregion

            DataTable searchDataReader = new DataTable();
            searchDataReader = DBAction.libraryDS.Tables["reader"].Clone();

            #region SearchDataReader.Columns - Headers
            searchDataReader.Columns[0].Caption = "Номер читательского билета";
            searchDataReader.Columns[1].Caption = "Имя читателя";
            searchDataReader.Columns[2].Caption = "Домашний адрес";
            searchDataReader.Columns[3].Caption = "Телефон";
            searchDataReader.Columns[4].Caption = "E-mail";
            #endregion

            int searchDigits;
            bool isInt = Int32.TryParse(searchText, out searchDigits);

            if ((radioButtonBook.Checked) || (Authorization.user))
            {
                if (isInt)
                {
                    filterString = String.Format("[id_library_cipher] = '{0}' OR [year_book] = '{0}' OR [number_of_copies] = '{0}' OR [number_of_pages] = '{0}' OR [id_department] = '{0}'", searchDigits);                   
                }
                else if (!isInt)
                {
                    filterString = String.Format("[author] LIKE '%{0}%' OR [name_book] LIKE '%{0}%'", searchText);
                }
                DataRow[] selectedRows = DBAction.libraryDS.Tables["book"].Select(filterString);

                if (selectedRows.Count() == 0) { MessageBox.Show("Ничего не найдено"); }
                else
                {
                    foreach (DataRow row in selectedRows)
                    {
                        searchDataBook.ImportRow(row);
                    }

                    dataGridViewSearch.DataSource = searchDataBook;
                }
            }
            else if (radioButtonReader.Checked)
            {
                if (isInt)
                {
                    filterString = String.Format("[id_library_kard] = '{0}'", searchDigits);
                }
                else if (!isInt)
                {
                    filterString = String.Format("[name_reader] LIKE '%{0}%' OR [home_address] LIKE '%{0}%' OR [phone] LIKE '%{0}%' OR [e_mail] LIKE '%{0}%'", searchText);
                }
                DataRow[] selectedRows = DBAction.libraryDS.Tables["reader"].Select(filterString);

                if (selectedRows.Count() == 0) { MessageBox.Show("Ничего не найдено"); }
                else
                {
                    foreach (DataRow row in selectedRows)
                    {
                        searchDataReader.ImportRow(row);
                    }

                    dataGridViewSearch.DataSource = searchDataReader;
                }
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