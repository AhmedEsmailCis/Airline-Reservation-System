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
    public partial class UserSignIn : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection conn;
        public UserSignIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main m = new main();
            m.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
               
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into Users values (:us , :ps , :st) ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("us", textBox1.Text);
                cmd.Parameters.Add("ps", textBox2.Text);
                cmd.Parameters.Add("st", "u");
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    this.Hide();
                    ViewFlight v = new ViewFlight(textBox1.Text);
                    v.ShowDialog();
                    
                }
            }
            else 
            {
                MessageBox.Show("invalid password ");
                textBox2.Clear();
                textBox3.Clear();

            }
        }

        private void UserSignIn_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void UserSignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

    }
}
