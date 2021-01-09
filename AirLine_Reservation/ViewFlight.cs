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
    public partial class ViewFlight : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection conn;
        string userName=" ";
        string flightNumber = " ";
        string AirPlaneCode = " ";
        string To_ = " ";
        string From_ = " ";
        string Price = " ";


        public ViewFlight(string us)
        {
            InitializeComponent();
            userName = us;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main m = new main();
            m.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserMakeReservation m = new UserMakeReservation(userName, flightNumber, AirPlaneCode, To_, From_, Price);
            m.ShowDialog();
           


        }

        private void ViewFlight_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd1 = new OracleCommand();
            OracleCommand cmd2 = new OracleCommand();
            cmd1.Connection = conn;
            cmd2.Connection = conn;
            cmd1.CommandText = "select DISTINCT stratVolitation  from Flights  ";
            cmd2.CommandText = "select DISTINCT Destination  from Flights  ";
            cmd1.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;
            OracleDataReader dr1 = cmd1.ExecuteReader();
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1[0]);
            }
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2[0]);
            }
            dr1.Close();
            dr2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Flights where stratVolitation =:st and Destination  = :ds and Dep_Date =:dd ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("st", comboBox1.SelectedItem.ToString());
            cmd.Parameters.Add("ds", comboBox2.SelectedItem.ToString());
            cmd.Parameters.Add("dd", Convert.ToDateTime(dateTimePicker1.Text));
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt =new DataTable();
            dt.Columns.Add("flight number");
            dt.Columns.Add("Dep_date");
            dt.Columns.Add("arrival date");
            dt.Columns.Add("from");
            dt.Columns.Add("to");
            dt.Columns.Add("price");
            dt.Columns.Add("Airplane Code");
            DataRow r;
            while (dr.Read())
            {
                r = dt.NewRow();
                r["flight number"]=dr[0];
                r["Dep_date"]=dr[1];
                r["arrival date"]=dr[2];
                r["from"]=dr[3];
                r["to"]=dr[4];
                r["price"]=dr[5];
                r["Airplane Code"] = dr[6];
                dt.Rows.Add(r);
            }
            dr.Close();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                flightNumber = row.Cells["flight number"].Value.ToString();
                AirPlaneCode = row.Cells["Airplane Code"].Value.ToString();
                To_ = row.Cells["to"].Value.ToString();
                From_ = row.Cells["from"].Value.ToString();
                Price = row.Cells["price"].Value.ToString();

            }
        }

        private void ViewFlight_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
