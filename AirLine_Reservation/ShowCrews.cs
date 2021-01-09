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
    public partial class ShowCrews : Form
    {
        string ordb = "Data source=orcl;User Id=hr ; Password=hr;";
        OracleConnection conn;
        public ShowCrews()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ShowCrews_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select code  from airplane  ";
            cmd1.CommandType = CommandType.Text;
            OracleDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1[0]);
            }
            dr1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SHOW_CREWS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("airplaneCode", comboBox2.SelectedItem.ToString());
            cmd.Parameters.Add("data", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt =new DataTable();
            dt.Columns.Add("Seat number");
            dt.Columns.Add("Airplane Code");
            dt.Columns.Add("Status");
            dt.Columns.Add("Class");
            DataRow r;
            while (dr.Read())
            {
                r = dt.NewRow();
                r["Seat number"]=dr[0];
                r["Airplane Code"]=dr[3];
                r["Status"]=dr[1];
                r["Class"]=dr[2];
                dt.Rows.Add(r);
            }
            dr.Close();
            dataGridView1.DataSource = dt;
        }

        private void ShowCrews_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
        
    }
}
