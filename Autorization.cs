using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToursProject
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=TOURS_CHERNAEVA;Integrated Security=True");
            con.Open();
            var cmd = new SqlCommand("Select [U_name],[U_login],[U_password],[U_OU_id] FROM [TOURS_CHERNAEVA].[dbo].[Users] ", con);
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr[1].ToString() == textBox1.Text&& rdr[2].ToString() == textBox2.Text)
                {
                    MessageBox.Show("Вход успешен!","Успех!",MessageBoxButtons.OK);
                    Hide();
                    new MainForm() { Tag = rdr[3].ToString()+'/'+rdr[0] }.ShowDialog();
                    Show();
                }
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new MainForm() { Tag = "/" }.ShowDialog();
            Show();
        }
    }
}
