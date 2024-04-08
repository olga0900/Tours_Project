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
using System.Xml.Linq;
using ToursProject.TOURS_CHERNAEVADataSetTableAdapters;

namespace ToursProject.Tables
{
    public partial class OrdersTable : Form
    {
        public OrdersTable()
        {
            InitializeComponent();
        }

        private void ordersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ordersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tOURS_CHERNAEVADataSet);

        }

        private void OrdersTable_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOURS_CHERNAEVADataSet.orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.tOURS_CHERNAEVADataSet.orders);
            DGVAddions();
            comboBox1.SelectedIndex = -1;
        }

        private void DGVAddions()
        {
            var con = ordersTableAdapter.Connection;
            con.Open();
            var cmd = new SqlCommand("", con);
            foreach (DataGridViewRow row in ordersDataGridView.Rows)
            {
                var splittedOrder = row.Cells[1].Value.ToString().Split(';').ToList();
                splittedOrder.RemoveAt(splittedOrder.Count - 1);
                foreach (string x in splittedOrder)
                {
                    cmd.CommandText = "select Tour_Name from Tours where Tours_id = " + x.Split(':')[0];
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        row.Cells[2].Value += $"{rdr[0]} - {x.Split(':')[1]} шт; ";
                    }
                    rdr.Close();
                }
                if (row.Cells[row.Cells.Count - 2].Value.ToString() != "GUEST")
                    row.Cells[row.Cells.Count - 1].Value = row.Cells[row.Cells.Count - 2].Value;
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(button1.Text)
            {
                case "Не отсортировано":
                    button1.Text = "По возрастанию";
                    ordersBindingSource.Sort = "O_sum ASC";
                    break;
                case "По возрастанию":
                    button1.Text = "По убыванию";
                    ordersBindingSource.Sort = "O_sum DESC";
                    break;
                case "По убыванию":
                    button1.Text = "Не отсортировано";
                    ordersBindingSource.Sort = "";
                    break;
            }
            DGVAddions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
              comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = comboBox1.Text.Split('-', '%').Length;
            ordersBindingSource.Filter = $"O_sale >= {(n!=1?comboBox1.Text.Split('-', '%')[0]:"0")} " +
                $"and O_sale <= {(n>2?comboBox1.Text.Split('-', '%')[2]:"100")}";
            DGVAddions();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
