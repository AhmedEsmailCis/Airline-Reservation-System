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
    public partial class Update_airline : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection conn;
        public Update_airline()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandType = CommandType.Text;
            c.CommandText = "update airline set arlnname=:nam where code=:c";
            c.Parameters.Add("nam", textBox2.Text);
            c.Parameters.Add("c", comboBox1.SelectedItem.ToString());
            int r = c.ExecuteNonQuery();
            if (r != -1)
            {
                textBox2.Clear();
                MessageBox.Show("Done");
            }
        }

        private void Update_airline_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select  code  from  airline ";
            c.CommandType = CommandType.Text;
            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void Update_airline_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
