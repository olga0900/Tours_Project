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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToursProject.TOURS_CHERNAEVADataSetTableAdapters;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace ToursProject.Order
{
    public partial class OrderForm : Form
    {
        int currentTour;
        List<StaticOrder.ToursWithCount> Tours = StaticOrder.TourPanels;
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            if (((string)Tag).Length > 1)
                label1.Text += " формирует " + Tag;
            sumOrder();
            selectView(currentTour);
        }
        private void selectView(int index)
        {
            numericUpDown1.Maximum = decimal.MaxValue;
            tableLayoutPanel1.Controls.RemoveAt(tableLayoutPanel1.Controls.Count-1);
            tableLayoutPanel1.Controls.Add(Tours[index].tour);
            tableLayoutPanel1.SetColumn(Tours[index].tour, 1);
            tableLayoutPanel1.SetRow(Tours[index].tour, 1);
            Tours[index].tour.Anchor = AnchorStyles.None;
            numericUpDown1.Value = Tours[index].count;
            numericUpDown1.Maximum = Tours[index].tour.tourTickets;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTour += currentTour < Tours.Count-1 ? 1 : 0;
            selectView(currentTour);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentTour -= currentTour > 0 ? 1 : 0;
            selectView(currentTour);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string order = "";
            decimal sum = 0;

            foreach (StaticOrder.ToursWithCount tour in Tours)
                order += $"{tour.tour.id}:{tour.count};";
            foreach (StaticOrder.ToursWithCount tour in Tours)
                sum += tour.tour.tourPrice * tour.count;

            var con = new SqlConnection("Data Source=DESKTOP-ACVJ1AI;Initial Catalog=TOURS_CHERNAEVA;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            var cmd = new SqlCommand("INSERT INTO [TOURS_CHERNAEVA].[dbo].[orders] values(@a,@b,GETDATE(),DATEADD(DAY,3,GETDATE()),@e,@f,@g,@h,@i)", con);
            cmd.Parameters.Add("@a", SqlDbType.Text).Value = "новый";
            cmd.Parameters.Add("@b", SqlDbType.Int).Value = -1;
            cmd.Parameters.Add("@e", SqlDbType.Decimal).Value = $"{r.Next(0, 10)}{r.Next(0, 10)}{r.Next(0, 10)}";
            cmd.Parameters.Add("@f", SqlDbType.Text).Value = order;
            cmd.Parameters.Add("@g", SqlDbType.Money).Value = sum;
            cmd.Parameters.Add("@h", SqlDbType.Money).Value = 0;
            cmd.Parameters.Add("@i", SqlDbType.Text).Value = "GUEST";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ваш заказ сформирован, спасибо за заказ!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd.CommandText = "SELECT TOP(1) O_id, O_dateOrder, O_CODE FROM [TOURS_CHERNAEVA].[dbo].[orders] order by O_id DESC";
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
                generatePDF(rdr.GetInt32(0), rdr[1].ToString(), rdr[2].ToString());

            con.Close();
            Tours.Clear();
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
                if (MessageBox.Show("Вы действительно хотите убрать данный тур из заказа?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
                    ==
                    DialogResult.Yes)
                {
                    Tours.RemoveAt(currentTour);
                    currentTour = 0;
                    if (Tours.Count == 0)
                    {
                        MessageBox.Show("В вашем заказе закончились туры",
                            "Внимание!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        Close();
                        return;
                    }
                    selectView(currentTour);
                }
                else numericUpDown1.Value = 1;
            else
                Tours[currentTour].count = (int)numericUpDown1.Value;
            sumOrder();
        }
        void sumOrder()
        {
            decimal sum = 0;
            foreach (StaticOrder.ToursWithCount tour in Tours)
                sum += tour.tour.tourPrice*tour.count;
            label2.Text = $"Сумма заказа: {sum} Руб.";
        }
        void generatePDF(int id, string datetime, string CODE)
        {
            Document doc = new Document();
            doc.Pages.Add();
            Table table = new Table();
            table.Rows.Add();
            doc.Pages[1].Paragraphs.Add(new TextFragment("Заказ №" + id));
            table.Rows[0].Cells.Add("Дата заказа: " + datetime);
            decimal sum = 0;
            foreach (StaticOrder.ToursWithCount tour in Tours)
                sum += tour.tour.tourPrice * tour.count;
            table.Rows[0].Cells.Add("Сумма заказа: " + sum);
            table.Rows[0].Cells.Add("Сумма скидки: 0");
            table.Rows.Add();
            table.Rows[1].Cells.Add("Пункт получения заказа: <...>");
            table.Rows[1].Cells.Add();
            table.Rows[1].Cells.Add("Код для получения: " + CODE,new TextState { FontStyle = FontStyles.Bold,FontSize = 16});

            int i = 0;
            foreach (StaticOrder.ToursWithCount tour in Tours)
            {
                Row row = table.Rows.Add();
                row.Cells.Add($"{++i}. {tour.tour.tourName} — {tour.count} шт.");
                row.Cells[0].ColSpan = 3;
            }
            doc.Pages[1].Paragraphs.Add(table);

            doc.Save("Talon.pdf");
        }

    }
}
