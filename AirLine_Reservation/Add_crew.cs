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
    public partial class Add_crew : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection conn;
        public Add_crew()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Add_crew_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandType = CommandType.Text;
            c.CommandText = "select CODE  from  airplane ";
            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);

            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into CREWS values (:id,:name,:job,:code)";
            cmd.Parameters.Add("id", textBox3.Text);
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("job", textBox2.Text);
            cmd.Parameters.Add("code", comboBox2.SelectedItem.ToString());
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Done");
            }
        }

        private void Add_crew_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
