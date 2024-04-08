namespace ToursProject.Tables.Helpers
{
    partial class HotelsRedact
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label countryNameLabel;
            System.Windows.Forms.Label hotel_idLabel;
            System.Windows.Forms.Label countOfStarsLabel1;
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.countryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tOURS_CHERNAEVADataSet = new ToursProject.TOURS_CHERNAEVADataSet();
            this.hotel_idTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.countOfStarsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.countryNameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.countryTableAdapter = new ToursProject.TOURS_CHERNAEVADataSetTableAdapters.CountryTableAdapter();
            nameLabel = new System.Windows.Forms.Label();
            countryNameLabel = new System.Windows.Forms.Label();
            hotel_idLabel = new System.Windows.Forms.Label();
            countOfStarsLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOURS_CHERNAEVADataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countOfStarsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(32, 99);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(57, 26);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Название отеля:";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // countryNameLabel
            // 
            countryNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            countryNameLabel.AutoSize = true;
            countryNameLabel.Location = new System.Drawing.Point(43, 169);
            countryNameLabel.Name = "countryNameLabel";
            countryNameLabel.Size = new System.Drawing.Size(46, 13);
            countryNameLabel.TabIndex = 5;
            countryNameLabel.Text = "Страна:";
            countryNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hotel_idLabel
            // 
            hotel_idLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            hotel_idLabel.AutoSize = true;
            hotel_idLabel.Location = new System.Drawing.Point(15, 67);
            hotel_idLabel.Name = "hotel_idLabel";
            hotel_idLabel.Size = new System.Drawing.Size(74, 26);
            hotel_idLabel.TabIndex = 6;
            hotel_idLabel.Text = "Порядковый номер отеля:";
            hotel_idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // countOfStarsLabel1
            // 
            countOfStarsLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            countOfStarsLabel1.AutoSize = true;
            countOfStarsLabel1.Location = new System.Drawing.Point(23, 131);
            countOfStarsLabel1.Name = "countOfStarsLabel1";
            countOfStarsLabel1.Size = new System.Drawing.Size(66, 26);
            countOfStarsLabel1.TabIndex = 8;
            countOfStarsLabel1.Text = "Количество звёзд:";
            countOfStarsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameTextBox.Location = new System.Drawing.Point(95, 102);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(68, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // countryBindingSource
            // 
            this.countryBindingSource.DataMember = "Country";
            this.countryBindingSource.DataSource = this.tOURS_CHERNAEVADataSet;
            // 
            // tOURS_CHERNAEVADataSet
            // 
            this.tOURS_CHERNAEVADataSet.DataSetName = "TOURS_CHERNAEVADataSet";
            this.tOURS_CHERNAEVADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hotel_idTextBox
            // 
            this.hotel_idTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hotel_idTextBox.Location = new System.Drawing.Point(95, 70);
            this.hotel_idTextBox.Name = "hotel_idTextBox";
            this.hotel_idTextBox.ReadOnly = true;
            this.hotel_idTextBox.Size = new System.Drawing.Size(68, 20);
            this.hotel_idTextBox.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.countOfStarsNumericUpDown, 1, 4);
            this.tableLayoutPanel1.Controls.Add(countOfStarsLabel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(hotel_idLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.hotel_idTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(nameLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(countryNameLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.countryNameComboBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(184, 261);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // countOfStarsNumericUpDown
            // 
            this.countOfStarsNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.countOfStarsNumericUpDown.Location = new System.Drawing.Point(95, 134);
            this.countOfStarsNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.countOfStarsNumericUpDown.Name = "countOfStarsNumericUpDown";
            this.countOfStarsNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.countOfStarsNumericUpDown.TabIndex = 9;
            // 
            // countryNameComboBox
            // 
            this.countryNameComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.countryNameComboBox.DataSource = this.countryBindingSource;
            this.countryNameComboBox.DisplayMember = "Country_Name";
            this.countryNameComboBox.FormattingEnabled = true;
            this.countryNameComboBox.Location = new System.Drawing.Point(95, 165);
            this.countryNameComboBox.Name = "countryNameComboBox";
            this.countryNameComboBox.Size = new System.Drawing.Size(68, 21);
            this.countryNameComboBox.TabIndex = 6;
            this.countryNameComboBox.ValueMember = "Country_Code";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(72, 25);
            this.label1.Name = "label1";
            this.tableLayoutPanel1.SetRowSpan(this.label1, 2);
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "MODE";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(8, 215);
            this.button2.Name = "button2";
            this.tableLayoutPanel1.SetRowSpan(this.button2, 2);
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(100, 215);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // countryTableAdapter
            // 
            this.countryTableAdapter.ClearBeforeFill = true;
            // 
            // HotelsRedact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HotelsRedact";
            this.Text = "ToursRedact";
            this.Load += new System.EventHandler(this.ToursRedact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOURS_CHERNAEVADataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countOfStarsNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox hotel_idTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown countOfStarsNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private TOURS_CHERNAEVADataSet tOURS_CHERNAEVADataSet;
        private System.Windows.Forms.BindingSource countryBindingSource;
        private TOURS_CHERNAEVADataSetTableAdapters.CountryTableAdapter countryTableAdapter;
        private System.Windows.Forms.ComboBox countryNameComboBox;
    }
}