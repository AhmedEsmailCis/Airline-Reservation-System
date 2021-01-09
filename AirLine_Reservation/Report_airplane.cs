using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;


namespace AirLine_Reservation
{
    public partial class Report_airplane : Form
    {
        airplane_report1 r;
        public Report_airplane()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = r;
        }

        private void Report_airplane_Load(object sender, EventArgs e)
        {
             r = new airplane_report1();
             foreach (ParameterDiscreteValue v in r.ParameterFields[0].DefaultValues)
                 comboBox1.Items.Add(v.Value);
        }
    }
}
