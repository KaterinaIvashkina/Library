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
    public partial class FormBooking : Form
    {
        ToolStripLabel dateLabel, timeLabel, infoLabel;
        Timer timer;

        public FormBooking()
        {
            InitializeComponent();

            bookingBindingSource.DataSource = DBAction.libraryDS.Tables["booking"];

            if (Authorization.admin)
            {
                bindingNavigator1.DeleteItem.Visible = false;
            }

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

        private static NpgsqlDataAdapter bookingDataAdapter = new NpgsqlDataAdapter();
        private static string table = "booking";

        private NpgsqlCommand deleteCommand = new NpgsqlCommand(@"delete from booking where id_booking = @Id");
        private NpgsqlCommand insertCommand = new NpgsqlCommand(@"insert into booking(id_library_cipher, id_library_kard, date_booking, id_department) values(@LibraryCipher, @LibraryCard, @DateBooking, @Department);");
        private NpgsqlCommand updateCommand = new NpgsqlCommand(@"update booking set date_booking = @DateBooking, id_department = @Department where id_booking = @Id);");

        void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        public static void getTableBooking()
        {
            DBAction.libraryDS.Tables[table].Clear();
            DBAction.getData(out bookingDataAdapter, table);
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            dataGridBooking.Sort(dataGridBooking.Columns[0], ListSortDirection.Ascending);
        }

        private void buttonSaveChange_Click(object sender, EventArgs e)
        {
            dataAdapterCommand();
        }

        public void dataAdapterCommand()
        {
            #region parameteters.add
            deleteCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_booking";

            insertCommand.Parameters.Add("@LibraryCipher", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = DBAction.libraryDS.Tables[table].Columns[1].ToString();
            insertCommand.Parameters.Add("@LibraryCard", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = DBAction.libraryDS.Tables[table].Columns[2].ToString();
            insertCommand.Parameters.Add("@DateBooking", NpgsqlTypes.NpgsqlDbType.Date).SourceColumn = DBAction.libraryDS.Tables[table].Columns[3].ToString();
            insertCommand.Parameters.Add("@Department", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = DBAction.libraryDS.Tables[table].Columns[4].ToString();

            updateCommand.Parameters.Add("@DateBooking", NpgsqlTypes.NpgsqlDbType.Date).SourceColumn = "date_booking";
            updateCommand.Parameters.Add("@Department", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_department";
            updateCommand.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).SourceColumn = "id_booking";
            #endregion

            bookingDataAdapter.UpdateCommand = updateCommand;
            bookingDataAdapter.DeleteCommand = deleteCommand;
            bookingDataAdapter.InsertCommand = insertCommand;

            DBAction.updateDataTable(bookingDataAdapter, table);

            getTableBooking();
        }
    }
}
