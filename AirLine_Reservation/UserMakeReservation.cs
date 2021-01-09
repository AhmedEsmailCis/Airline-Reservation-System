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
    public partial class UserMakeReservation : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection conn;
        string userName;
        string flightNumber;
        string AirPlaneCode;
        string To_;
        string From_;
        string Price;
        int maxId;
        public UserMakeReservation()
        {
            InitializeComponent();
        }
        public UserMakeReservation(string us ,string fn,string ac,string to,string from ,string pr)
        {
            InitializeComponent();
             userName=us;
             flightNumber=fn;
             AirPlaneCode=ac;
             To_=to;
             From_=from;
             Price=pr;
        }

        private void UserMakeReservation_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            textBox6.Text = userName;
            textBox9.Text = flightNumber;
            textBox16.Text = AirPlaneCode;
            textBox13.Text = To_;
            textBox12.Text = From_;
            textBox11.Text = Price;
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "GETRESID";
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("resId", OracleDbType.Int32, ParameterDirection.Output);
            cmd2.ExecuteNonQuery();
            maxId = Convert.ToInt32(cmd2.Parameters["resId"].Value.ToString());
            maxId++;
            string max = Convert.ToString(maxId);
            textBox14.Text = max;

            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select snumber from seats where airplanecode=:a and status= :s  ";
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("a", AirPlaneCode);
            cmd1.Parameters.Add("s", "n");
            OracleDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1[0]);
            }
            
            dr1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select age from passengers where ssn =:s ";
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("s", textBox1.Text);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            int counter = 0;
            while (dr1.Read())
            {
                counter++;
            }
            dr1.Close();
            if (counter == 0)
            {
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into passengers values (:fn ,:mn ,:ln ,:sn ,:ge ,: ag ,:em ,:us) ";
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add("fn", textBox2.Text);
                cmd2.Parameters.Add("mn", textBox3.Text);
                cmd2.Parameters.Add("ln", textBox4.Text);
                cmd2.Parameters.Add("sn", textBox1.Text);
                cmd2.Parameters.Add("ge", comboBox1.SelectedItem.ToString());
                cmd2.Parameters.Add("ag", Convert.ToInt16(textBox5.Text));
                cmd2.Parameters.Add("em", textBox7.Text);
                cmd2.Parameters.Add("us", userName);
                int r = cmd2.ExecuteNonQuery();

                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "insert into reservations values (:em ,:red ,:de ,:st ,:rd ,:pr ,:fn ,:sn ,:ai ,:ss) ";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("em", textBox10.Text);
                cmd3.Parameters.Add("red", maxId);
                cmd3.Parameters.Add("de", To_);
                cmd3.Parameters.Add("st", From_);
                cmd3.Parameters.Add("rd", Convert.ToDateTime(DateTime.Now.ToString()));
                cmd3.Parameters.Add("pr", Convert.ToInt16(Price));
                cmd3.Parameters.Add("fn", Convert.ToInt16(flightNumber));
                cmd3.Parameters.Add("sn", Convert.ToInt16(comboBox2.SelectedItem.ToString()));
                cmd3.Parameters.Add("ai", AirPlaneCode);
                cmd3.Parameters.Add("ss", textBox1.Text);
                 r = cmd3.ExecuteNonQuery();

                 OracleCommand cmd6 = new OracleCommand();
                 cmd6.Connection = conn;
                 cmd6.CommandText = "inser into contacts  values(:cc,:ss )";
                 cmd6.CommandType = CommandType.Text;
                 cmd6.Parameters.Add("cc", textBox8.Text);
                 cmd6.Parameters.Add("ss", textBox1.Text);
                 int m = cmd6.ExecuteNonQuery();

            }
            else
            {
                OracleCommand cmd4 = new OracleCommand();
                cmd4.Connection = conn;
                cmd4.CommandText = "insert into reservations values (:em ,:red ,:de ,:st ,:rd ,:pr ,:fn ,:sn ,:ai ,:ss) ";
                cmd4.CommandType = CommandType.Text;
                cmd4.Parameters.Add("em", textBox10.Text);
                cmd4.Parameters.Add("red", maxId);
                cmd4.Parameters.Add("de", To_);
                cmd4.Parameters.Add("st", From_);
                cmd4.Parameters.Add("rd", Convert.ToDateTime(DateTime.Now.ToString()));
                cmd4.Parameters.Add("pr", Convert.ToInt16(Price));
                cmd4.Parameters.Add("fn", Convert.ToInt16(flightNumber));
                cmd4.Parameters.Add("sn", Convert.ToInt16(comboBox2.SelectedItem.ToString()));
                cmd4.Parameters.Add("ai", AirPlaneCode);
                cmd4.Parameters.Add("ss", textBox1.Text);
                int r = cmd4.ExecuteNonQuery();
            }
            OracleCommand cmd5 = new OracleCommand();
            cmd5.Connection = conn;
            cmd5.CommandText = "update seats set status=:n where snumber=:s and airplanecode=:arp ";
            cmd5.CommandType = CommandType.Text;
            cmd5.Parameters.Add("n", "y");
            cmd5.Parameters.Add("s", Convert.ToInt16(comboBox2.SelectedItem.ToString()));
            cmd5.Parameters.Add("arp", AirPlaneCode);
            int s = cmd5.ExecuteNonQuery();
            MessageBox.Show("Graduation Insertion ....");
            this.Hide();
            main ma=new main();
            ma.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main m = new main();
            m.ShowDialog();
            this.Close();
        }

        private void UserMakeReservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
