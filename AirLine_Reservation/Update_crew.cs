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
    public partial class Update_crew : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection conn;
        public Update_crew()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Update_crew_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandType = CommandType.Text;
            c.CommandText = "select  crid ,airplanecode  from  crews ";
            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
                comboBox1.Items.Add(dr[1]);
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandType = CommandType.Text;
            c.CommandText = "update CREWS set CRNAME=:name,CRJOB=:job,AIRPLANECODE=:code where CRID=:id";
            c.Parameters.Add("name", textBox3.Text);
            c.Parameters.Add("job", textBox1.Text);
            c.Parameters.Add("code", comboBox1.SelectedItem.ToString());
            c.Parameters.Add("id", comboBox2.SelectedItem.ToString());
            int r = c.ExecuteNonQuery();
            if (r != -1)
            {
                textBox1.Clear();
                textBox3.Clear();
                MessageBox.Show("Done");
            }
        }

        private void Update_crew_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
