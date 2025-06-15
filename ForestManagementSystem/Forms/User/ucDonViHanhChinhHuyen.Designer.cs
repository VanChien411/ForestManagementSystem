namespace ForestManagementSystem.Forms.User
{
    partial class ucDonViHanhChinhHuyen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDonViHanhChinhHuyen));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tbSearch = new ForestManagementSystem.Common.Text.TextBoxControl();
            ptSearch = new PictureBox();
            gListCard = new GroupBox();
            tblLayoutListCard = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            lbHeader = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptSearch).BeginInit();
            gListCard.SuspendLayout();
            tblLayoutListCard.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel1.Controls.Add(gListCard, 0, 2);
            tableLayoutPanel1.Controls.Add(lbHeader, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ForeColor = Color.Black;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(57, 20, 57, 20);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(979, 683);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.74683F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.2531643F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Controls.Add(tbSearch, 0, 0);
            tableLayoutPanel5.Controls.Add(ptSearch, 1, 0);
            tableLayoutPanel5.Location = new Point(57, 87);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(316, 35);
            tableLayoutPanel5.TabIndex = 30;
            // 
            // tbSearch
            // 
            tbSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbSearch.BorderColor = Color.FromArgb(128, 128, 128);
            tbSearch.BorderThickness = 1;
            tbSearch.FocusBorderColor = Color.FromArgb(0, 120, 215);
            tbSearch.Location = new Point(3, 3);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(246, 29);
            tbSearch.TabIndex = 1;
            // 
            // ptSearch
            // 
            ptSearch.BorderStyle = BorderStyle.FixedSingle;
            ptSearch.Cursor = Cursors.Hand;
            ptSearch.Dock = DockStyle.Fill;
            ptSearch.ErrorImage = (Image)resources.GetObject("ptSearch.ErrorImage");
            ptSearch.Image = (Image)resources.GetObject("ptSearch.Image");
            ptSearch.Location = new Point(255, 3);
            ptSearch.Name = "ptSearch";
            ptSearch.Size = new Size(58, 29);
            ptSearch.SizeMode = PictureBoxSizeMode.Zoom;
            ptSearch.TabIndex = 2;
            ptSearch.TabStop = false;
            // 
            // gListCard
            // 
            gListCard.BackColor = Color.White;
            gListCard.Controls.Add(tblLayoutListCard);
            gListCard.Dock = DockStyle.Fill;
            gListCard.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gListCard.ForeColor = SystemColors.ActiveCaption;
            gListCard.Location = new Point(60, 125);
            gListCard.Name = "gListCard";
            gListCard.Size = new Size(859, 515);
            gListCard.TabIndex = 4;
            gListCard.TabStop = false;
            gListCard.Text = "Danh Sách";
            // 
            // tblLayoutListCard
            // 
            tblLayoutListCard.ColumnCount = 1;
            tblLayoutListCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLayoutListCard.Controls.Add(tableLayoutPanel7, 0, 0);
            tblLayoutListCard.Dock = DockStyle.Fill;
            tblLayoutListCard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tblLayoutListCard.Location = new Point(3, 34);
            tblLayoutListCard.Name = "tblLayoutListCard";
            tblLayoutListCard.Padding = new Padding(20, 0, 20, 0);
            tblLayoutListCard.RowCount = 1;
            tblLayoutListCard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayoutListCard.Size = new Size(853, 478);
            tblLayoutListCard.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(23, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(807, 472);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { STT });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = SystemColors.ActiveCaption;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 55;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(801, 466);
            dataGridView1.TabIndex = 1;
            // 
            // STT
            // 
            STT.FillWeight = 35F;
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Dock = DockStyle.Fill;
            lbHeader.Font = new Font("Arial", 25F, FontStyle.Bold);
            lbHeader.ForeColor = Color.Blue;
            lbHeader.Location = new Point(57, 20);
            lbHeader.Margin = new Padding(0, 0, 3, 0);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(862, 51);
            lbHeader.TabIndex = 3;
            lbHeader.Text = "Sách";
            lbHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucDonViHanhChinhHuyen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ucDonViHanhChinhHuyen";
            Size = new Size(979, 683);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptSearch).EndInit();
            gListCard.ResumeLayout(false);
            tblLayoutListCard.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel5;
        private Common.Text.TextBoxControl tbSearch;
        public PictureBox ptSearch;
        private GroupBox gListCard;
        private TableLayoutPanel tblLayoutListCard;
        private TableLayoutPanel tableLayoutPanel7;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn STT;
        private Label lbHeader;
    }
}
