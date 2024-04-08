using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ToursProject.Tables
{
    public partial class Hotels : Form
    {
        int page;
        public Hotels()
        {
            InitializeComponent();
        }

        private void Hotels_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOURS_CHERNAEVADataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.tOURS_CHERNAEVADataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOURS_CHERNAEVADataSet.Hotels". При необходимости она может быть перемещена или удалена.
            this.hotelsTableAdapter.Fill(this.tOURS_CHERNAEVADataSet.Hotels);
            page = 0;
            Paging(page);
        }

        private void hotelsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0&&e.ColumnIndex == 4) {
                Hide();
                DataGridViewCellCollection r = hotelsDataGridView.Rows[e.RowIndex].Cells;
                Helpers.HotelsRedact.Redacting(r[r.Count - 1].Value.ToString(), r[0].Value.ToString(), (int)r[1].Value, r[2].Value.ToString());
                Show();
                hotelsTableAdapter.Fill(this.tOURS_CHERNAEVADataSet.Hotels);
                page = 0;
                Paging(page);
            }
        }
        void Paging(int page)
        {
            hotelsBindingSource.CurrencyManager.SuspendBinding();
            foreach (DataGridViewRow item in hotelsDataGridView.Rows)
            {
                item.Visible = false;
            }
            hotelsBindingSource.CurrencyManager.ResumeBinding();
            var con = countryTableAdapter.Connection;
            con.Open();
            var cmd = new SqlCommand("", con);
            for (int i = page * (int)numericUpDown1.Value; i < page * (int)numericUpDown1.Value + (int)numericUpDown1.Value && i < hotelsBindingSource.Count; i++)
            {
                hotelsDataGridView.Rows[i].Visible = true;
                cmd.CommandText = "select count([Hotels].Name) from [Hotels],Country,Tours where Tours.Country_Code = Country.Country_Code and CountryName = Country.Country_Code and Hotel_id = "+ hotelsDataGridView.Rows[i].Cells[hotelsDataGridView.Rows[i].Cells.Count-1].Value;
                var rdr = cmd.ExecuteReader();
                while (rdr.Read()) hotelsDataGridView.Rows[i].Cells[3].Value = rdr[0];
                rdr.Close();
            }
            con.Close();
            bindingNavigatorPositionItem.Text = (page + 1).ToString();
            bindingNavigatorCountItem.Text = "из " + ((hotelsBindingSource.Count-1) / (int)numericUpDown1.Value+1);
            numericUpDown1.Maximum = hotelsBindingSource.Count;
            label2.Text = "Кол-во записей всего: " + hotelsBindingSource.Count;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            page = 0;
            Paging(page);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            page = hotelsBindingSource.Count / (int)numericUpDown1.Value;
            Paging(page);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            page -= page>0?1:0;
            Paging(page);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            page += page < (hotelsBindingSource.Count-1) / (int)numericUpDown1.Value ? 1 : 0;
            Paging(page);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            page = 0;
            Paging(page);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Helpers.HotelsRedact.New();
            Show();
            this.hotelsTableAdapter.Fill(this.tOURS_CHERNAEVADataSet.Hotels);
            page = 0;
            Paging(page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hotelsDataGridView.SelectedCells.Count > 0)
            {
                var con = hotelsTableAdapter.Connection;
                con.Open();
                var cmd = new SqlCommand("select * " +
                    "from Hotels,Country,Tours " +
                    "where Tours.Country_Code = Country.Country_Code " +
                    "and CountryName = Country.Country_Code " +
                   $"and Hotels.Hotel_id = {hotelsDataGridView.Rows[hotelsDataGridView.SelectedCells[0].RowIndex].Cells[hotelsDataGridView.ColumnCount - 1].Value}" +
                   $"and Tours.IsActual = 1", con);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MessageBox.Show("Данный отель невозможно удалить, на его месте есть активный тур!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                    return;
                }
                rdr.Close();
                con.Close();
                if (MessageBox.Show("Вы уверены, что хотите удалить данный отель?",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                    ==
                    DialogResult.Yes)
                {
                    hotelsBindingSource.RemoveCurrent();
                    hotelsBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.tOURS_CHERNAEVADataSet);
                };
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
