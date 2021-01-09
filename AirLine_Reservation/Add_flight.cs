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
    public partial class Add_flight : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection conn;
        public Add_flight()
        {
            InitializeComponent();
        }

        private void Add_flight_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select AirplaneCode  from  Flights ";
            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["AirplaneCode"]);
            }
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "add_flight";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("num", Convert.ToInt32(textBox3.Text));
            cmd.Parameters.Add("dept", Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()));
            cmd.Parameters.Add("arrive", Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString()));
            cmd.Parameters.Add("f", textBox1.Text);
            cmd.Parameters.Add("t", textBox2.Text);
            cmd.Parameters.Add("pric", Convert.ToInt32(textBox4.Text));
            cmd.Parameters.Add("code", comboBox2.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            MessageBox.Show("the flight is added ");

        }

        private void Add_flight_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
