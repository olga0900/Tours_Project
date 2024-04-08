using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ToursProject.Properties;

namespace ToursProject
{
    public partial class TourPanel : UserControl
    {
        public string tourName = "XXX";
        public decimal tourPrice = 0;
        public bool isActual = false;
        public int tourTickets = 0;
        public int id = -1;
        public TourPanel()
        {
            InitializeComponent();
        }
        public void Init(string tourName, decimal price, bool act, int tickets, int id)
        {
            this.tourName = tourName;
            tourPrice = Math.Round(price, 2);
            isActual = act;
            tourTickets = tickets;
            this.id = id;

            label1.Text = tourName;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Resources));
            pictureBox1.BackgroundImage = resources.GetObject(tourName.Replace(' ', '_'))!=null?
                (Image)resources.GetObject(tourName.Replace(' ', '_')):
                (Image)resources.GetObject("NoPic");
            label2.Text = Math.Round(price,2).ToString();
            label3.Text = act ? "Актуален" : "Не актуален";
            label3.ForeColor = act ? Color.Green : Color.Red;
            label5.Text = label5.Text.Replace("XXXX", tickets.ToString());
        }
        public TourPanel Copy()
        {
            var a = new TourPanel();
            a.Init(tourName, tourPrice, isActual, tourTickets, id);
            return a;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var x = Order.StaticOrder.TourPanels;
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i].tour.tourName == tourName)
                {
                    x[i].count++;
                    ((Tables.ToursTable)Tag).checkOrder();
                    return;
                }
            }
            x.Add(new Order.StaticOrder.ToursWithCount { tour = Copy(), count = 1 });
            ((Tables.ToursTable)Tag).checkOrder();
        }
    }
}
