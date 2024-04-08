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

namespace ToursProject.Tables.Helpers
{
    public partial class HotelsRedact : Form
    {
        string cmdText;
        string val = string.Empty;
        string nameH = string.Empty;
        public HotelsRedact()
        {
            InitializeComponent();
        }
        static public void Redacting(string id, string name, int countOfStars, string country)
        {
            var x = new HotelsRedact();
            x.hotel_idTextBox.Text = id;
            x.nameTextBox.Text = name;
            x.nameH = name;
            x.countOfStarsNumericUpDown.Value = countOfStars;
            x.val = country;
            x.cmdText = "update [Hotels] set Name = @a, CountOfStars= @b, CountryName = @c where Hotel_id = " + x.hotel_idTextBox.Text;
            x.ShowDialog();
        }
        static public void New()
        {
            var x = new HotelsRedact();
            x.cmdText = "INSERT INTO [TOURS_CHERNAEVA].[dbo].[Hotels] (Name, CountOfStars, CountryName) VALUES(@a,@b,@c)";
            x.ShowDialog();
        }


        private void ToursRedact_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOURS_CHERNAEVADataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.tOURS_CHERNAEVADataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOURS_CHERNAEVADataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.tOURS_CHERNAEVADataSet.Country);
            if (val != string.Empty)
                countryNameComboBox.SelectedValue = val;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length < 1)
            {
                MessageBox.Show("Заполните все поля!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var con = countryTableAdapter.Connection;
            con.Open();
            var cmd = new SqlCommand("SELECT [Name] FROM [TOURS_CHERNAEVA].[dbo].[Hotels]", con);
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (nameH != string.Empty && nameTextBox.Text.ToLower() != nameH.ToLower())
                if (rdr.GetString(0).ToLower() == nameTextBox.Text.ToLower())
                {
                    MessageBox.Show("Такое название отеля уже существует в базе!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                    return;
                }
            }
            rdr.Close();
            cmd.CommandText = cmdText;
            cmd.Parameters.Add("@a", SqlDbType.Text).Value = nameTextBox.Text;
            cmd.Parameters.Add("@b", SqlDbType.Int).Value = countOfStarsNumericUpDown.Value;
            cmd.Parameters.Add("@c", SqlDbType.Text).Value = countryNameComboBox.SelectedValue;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Действие прошло успешно!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Ваши введённые данные не сохранятся! Продолжить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            Close();
        }
    }
}
