using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ToursProject.Tables
{
    public partial class ToursTable : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=TOURS_CHERNAEVA;Integrated Security=True");
        List <TourPanel> tourList = new List<TourPanel>();
        int page = 0;
        public ToursTable()
        {
            InitializeComponent();
        }
        public void checkOrder()
        {
            toolStripSplitButton1.Visible = Order.StaticOrder.TourPanels.Count > 0;
        }
        
        private void ToursTable_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex=0;
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT [TourType_Name] FROM [TOURS_CHERNAEVA].[dbo].[TourType]",connection);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            reader.Close();
            connection.Close();
            DataLoad();
            checkOrder();
        }
        void DataLoad()
        {
            tableLayoutPanel1.Controls.Clear();
            connection.Open();
            string commandText = "Select [Tour_Name],[Price],[IsActual],[Count_Of_Tickets],[Tours_id] from Tours";
            if (comboBox1.SelectedIndex != 0) commandText += $",ToursWithTourTypes where Tour_Name_id = Tours_id and Tour_Type_id = {comboBox1.SelectedIndex}";
            if (SortBut.Text == "По убыванию") commandText += " order by [Price] desc";
            if (SortBut.Text == "По возрастанию") commandText += " order by [Price] asc";
            SqlCommand command = new SqlCommand(commandText, connection);
            tourList.ForEach(tour => { tour.Dispose(); });
            tourList.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tourList.Add(new TourPanel());
                tourList.Last().Init(reader.GetString(0), reader.GetDecimal(1), reader.GetBoolean(2), reader.GetInt32(3), reader.GetInt32(4)) ;
                if(!reader.GetBoolean(2)) tourList.Last().contextMenuStrip1.Dispose();
                tourList.Last().Tag = this;
            }
            for (int i = 0; i < tourList.Count; i++)
            {
                if (!tourList[i].label1.Text.ToLower().Contains(textBox1.Text.ToLower())||
                    (checkBox1.Checked&&tourList[i].label3.Text=="Не актуален"))
                {
                    tourList[i].Dispose();
                    tourList.RemoveAt(i);
                    i--;
                }
            }
            reader.Close();
            connection.Close();
            button1.Enabled = button2.Enabled = tourList.Count != 0;
            if (tourList.Count == 0)
            {
                tableLayoutPanel1.Controls.Clear();
                toolStripStatusLabel1.Text = $"Данных нет";
                MessageBox.Show("Данный запрос не привёл результатов","Ошибка поиска",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            decimal price = 0;
            tourList.ForEach(tour => { price += tour.tourPrice*tour.tourTickets; });
            label3.Text = "Общая сумма туров: "+ price.ToString();
            page = 0;
            DataView(page);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void SortBut_Click(object sender, EventArgs e)
        {
            switch (SortBut.Text)
            {
                case "Не сортировано":
                    SortBut.Text = "По убыванию";
                    break;
                case "По убыванию":
                    SortBut.Text = "По возрастанию";
                    break;
                case "По возрастанию":
                    SortBut.Text = "Не сортировано";
                    break;
            }
            DataLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            page++;
            if (page == (tourList.Count - 1) / 6 + 1)
                page = 0;
            DataView(page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page--;
            if (page == -1)
                page = (tourList.Count-1) / 6;
            DataView(page);

        }
        void DataView(int page)
        {
            tableLayoutPanel1.Controls.Clear();
            for (int i = page * 6; i < page * 6 + 6; i++)
            {
                tableLayoutPanel1.Controls.Add(tourList[i]);
                if (tourList.Count - 1 == i) break;
            }
            toolStripStatusLabel1.Text = $"Страница: {page + 1} из {(tourList.Count - 1) / 6 + 1}";
        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {
            Hide();
            new Order.OrderForm() {Tag = Tag}.ShowDialog();
            checkOrder();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
