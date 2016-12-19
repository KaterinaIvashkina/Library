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
    public partial class FormBooking : Form
    {
        public FormBooking()
        {
            InitializeComponent();
        }

        private static Npgsql.NpgsqlDataAdapter bookingDataAdapter;
        private static string table = "booking";

        public static void getTableBooking()
        {
            DBAction.getData(out bookingDataAdapter, table);
        }
    }
}
