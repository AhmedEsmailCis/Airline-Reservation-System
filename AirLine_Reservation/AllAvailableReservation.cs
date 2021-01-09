using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
namespace AirLine_Reservation
{
    public partial class AllAvailableReservation : Form
    {
        public AllAvailableReservation()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AllAvailableReservation_Load(object sender, EventArgs e)
        {
            string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
            string command = "select * from reservations";
            OracleDataAdapter adapter = new OracleDataAdapter(command, ordb);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
