using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace AirLine_Reservation
{
    public partial class Search_reservations : Form
    {
        public Search_reservations()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
            OracleDataAdapter adapter;
            DataSet ds = new DataSet();
            string command = @"select * 
                               from reservations 
                               where destination = :var";
            adapter = new OracleDataAdapter(command, ordb);
            adapter.SelectCommand.Parameters.Add("var", textBox1.Text);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
