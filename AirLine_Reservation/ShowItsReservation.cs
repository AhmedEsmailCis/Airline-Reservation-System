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
    public partial class ShowItsReservation : Form
    {
        public ShowItsReservation()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ShowItsReservation_Load(object sender, EventArgs e)
        {
            string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
            DataSet ds = new DataSet();
            OracleDataAdapter ad1 = new OracleDataAdapter("select * from FLIGHTS", ordb);
            ad1.Fill(ds, "aa");
            OracleDataAdapter ad2 = new OracleDataAdapter("select * from reservations", ordb);
            ad2.Fill(ds, "ss");

            DataRelation relation = new DataRelation("f", ds.Tables[0].Columns["FNUMBER"], ds.Tables[1].Columns["FNUMBER"]);
            ds.Relations.Add(relation);
            BindingSource master = new BindingSource(ds, "aa");
            BindingSource details = new BindingSource(master, "f");
            dataGridView1.DataSource = master;
            dataGridView2.DataSource = details;
        }
    }
}
