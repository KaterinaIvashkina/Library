using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Library
{
    public partial class FormReaders : Form
    {
        ToolStripLabel dateLabel, timeLabel, infoLabel;
        Timer timer;

        public FormReaders()
        {
            InitializeComponent();

            readerBindingSource.DataSource = DBAction.libraryDS.Tables["reader"];

            infoLabel = new ToolStripLabel("Текущие дата и время:");
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        private static NpgsqlDataAdapter readersDataAdapter;
        private static string table = "reader";

        private NpgsqlCommand deleteCommand = new NpgsqlCommand(@"delete from reader where id_library_kard = @Id");
        private NpgsqlCommand insertCommand = new NpgsqlCommand(@"insert into reader(name_reader, home_address, phone, e_mail) values(@NameReader, @Address, @Phone, @Email) returning id_library_kard;");
        private NpgsqlCommand updateCommand = new NpgsqlCommand(@"update reader set name_reader = @NameReader, home_address = @Address, phone = @Phone, e_mail = @Email where id_library_kard = @Id;");

        void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void FormReaders_Load(object sender, EventArgs e)
        {
            dataGridReaders.Sort(dataGridReaders.Columns[0], ListSortDirection.Ascending);
        }

        public static void getTableReaders()
        {
            DBAction.libraryDS.Tables[table].Clear();
            DBAction.getData(out readersDataAdapter, table);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //var f = new FormNewReader();
            //f.ShowDialog();
        }

        private void buttonSaveChange_Click(object sender, EventArgs e)
        {
            readersDataAdapter = new NpgsqlDataAdapter();

            #region parameteters.add
            deleteCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_library_kard";

            insertCommand.Parameters.Add("@NameReader", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "name_reader";
            insertCommand.Parameters.Add("@Address", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "home_address";
            insertCommand.Parameters.Add("@Phone", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "phone";
            insertCommand.Parameters.Add("@Email", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "e_mail";

            updateCommand.Parameters.Add("@NameReader", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "name_reader";
            updateCommand.Parameters.Add("@Address", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "home_address";
            updateCommand.Parameters.Add("@Phone", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "phone";
            updateCommand.Parameters.Add("@Email", NpgsqlTypes.NpgsqlDbType.Varchar).SourceColumn = "e_mail";
            updateCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_library_kard";
            #endregion

            readersDataAdapter.UpdateCommand = updateCommand;
            readersDataAdapter.DeleteCommand = deleteCommand;
            readersDataAdapter.InsertCommand = insertCommand;


            DBAction.updateDataTable(readersDataAdapter, table);

            getTableReaders();
        }

    }
}
