using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLine_Reservation
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
           
            Thread t = new Thread(new ThreadStart(strartForm));
            t.Start();
            Thread.Sleep(3200);
            t.Abort();
            InitializeComponent();
        }
        public void strartForm()
        {
            Application.Run(new loading());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            main m = new main();
            m.ShowDialog();
            this.Close();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
