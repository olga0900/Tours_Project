using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToursProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(135, 135, 135);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(255, 255, 255);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new Tables.ToursTable() { Tag = ((string)Tag).Split('/')[1] }.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new Tables.Hotels().ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            new Tables.OrdersTable().ShowDialog();
            Show();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            button4.Visible = new string[] { "4", "3" }.Contains(((string)Tag).Split('/')[0]);
        }
    }
}
