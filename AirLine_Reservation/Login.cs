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
    public partial class Login : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;"; 
        OracleConnection conn;
        string stat;
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main m = new main();
            this.Hide();
            m.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select status from Users where UserName =:us and Pword = :ps ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("us",textBox1.Text );
            cmd.Parameters.Add("ps",textBox2.Text );
            OracleDataReader dr = cmd.ExecuteReader();
            int counter=0;
            while (dr.Read())
            {
                counter++;
               stat=dr[0].ToString();
            }
            dr.Close();
            if(counter==1 && stat=="u" )
            {
                this.Hide();
                ViewFlight v = new ViewFlight(textBox1.Text);
                v.ShowDialog();
                
            }
            else if(counter==1 && stat=="a")
            {
                this.Hide();
                Admin a = new Admin();
                a.ShowDialog();
                
            }
            else if (counter == 0)
            {
                MessageBox.Show("wrong username or password");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
        }
    }
}
