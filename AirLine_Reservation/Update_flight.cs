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
    public partial class Update_flight : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection con;
        public Update_flight()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cd = new OracleCommand();
            cd.Connection = con;

            cd.CommandText = "update_in_flights";
            cd.CommandType = CommandType.StoredProcedure;

            cd.Parameters.Add("fnum", comboBox1.SelectedItem.ToString());

            cd.Parameters.Add("dept", Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()));

            cd.Parameters.Add("arrive", Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString()));


            cd.Parameters.Add("f", textBox1.Text);

            cd.Parameters.Add("t", textBox2.Text);

            cd.Parameters.Add("pric", Convert.ToInt32(textBox4.Text));

            cd.Parameters.Add("code", Convert.ToString(comboBox2.SelectedItem.ToString()));

            cd.ExecuteNonQuery();
            MessageBox.Show("updated");

        }

        private void Update_flight_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = con;
            c.CommandText = "select FNumber ,AirplaneCode  from  Flights ";
            //c.CommandType = CommandType.Text;
            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
                comboBox2.Items.Add(dr[1]);

            }
            dr.Close();
        }

        private void Update_flight_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Dispose();
        }
    }
}
