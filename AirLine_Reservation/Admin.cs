using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLine_Reservation
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Logout ?!", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                this.Hide();
                main m = new main();
                m.ShowDialog();
            }
            else
            {
                MessageBox.Show("Operation is Cancelled....");
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_flight a = new Add_flight();
            a.ShowDialog();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChangeAirplane a = new ChangeAirplane();
            a.ShowDialog();
        }

        private void showCrewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCrews a = new ShowCrews();
            a.ShowDialog();
        }

        private void reportToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Report_airplane a = new Report_airplane();
            a.ShowDialog();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Add_airline a = new Add_airline();
            a.ShowDialog();
        }

        private void updateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Update_airline a = new Update_airline();
            a.ShowDialog();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Delete_airline a = new Delete_airline();
            a.ShowDialog();
        }

        private void showAirportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_flight a = new Update_flight();
            a.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_flight a = new Delete_flight();
            a.ShowDialog();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowItsReservation a = new ShowItsReservation();
            a.ShowDialog();
        }

        private void reportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Report_flight a = new Report_flight();
            a.ShowDialog();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_crew a = new Add_crew();
            a.ShowDialog();
        }

        private void updateToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Update_crew a = new Update_crew();
            a.ShowDialog();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Delete_crew a = new Delete_crew();
            a.ShowDialog();
        }

        private void showAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search_reservations s = new Search_reservations();
            s.ShowDialog();
        }

        private void aLLAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllAvailableReservation a = new AllAvailableReservation();
            a.ShowDialog();
            
        }   
    }
}
