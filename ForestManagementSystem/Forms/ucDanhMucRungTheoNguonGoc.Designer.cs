namespace ForestManagementSystem.Forms
{
    partial class ucDanhMucRungTheoNguonGoc
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            gListCard = new GroupBox();
            tblLayoutListCard = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            lbHeader = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            tableLayoutPanel10 = new TableLayoutPanel();
            cbLapDia = new ComboBox();
            cbNguonGoc = new ComboBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            gListCard.SuspendLayout();
            tblLayoutListCard.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(gListCard, 0, 2);
            tableLayoutPanel1.Controls.Add(lbHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ForeColor = Color.Black;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(57, 20, 57, 20);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(968, 486);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // gListCard
            // 
            gListCard.BackColor = Color.White;
            gListCard.Controls.Add(tblLayoutListCard);
            gListCard.Dock = DockStyle.Fill;
            gListCard.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gListCard.ForeColor = SystemColors.ActiveCaption;
            gListCard.Location = new Point(60, 133);
            gListCard.Name = "gListCard";
            gListCard.Size = new Size(848, 310);
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
            tblLayoutListCard.Size = new Size(842, 273);
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
            tableLayoutPanel7.Size = new Size(796, 267);
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
            dataGridView1.Size = new Size(790, 261);
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
            lbHeader.Size = new Size(851, 51);
            lbHeader.TabIndex = 3;
            lbHeader.Text = "Sách";
            lbHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel10, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(60, 74);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(0, 0, 0, 5);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(848, 53);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Right;
            label2.Location = new Point(130, 0);
            label2.Name = "label2";
            label2.Size = new Size(121, 48);
            label2.TabIndex = 9;
            label2.Text = "Điều kiện lập địa";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 3;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel10.Controls.Add(cbLapDia, 0, 0);
            tableLayoutPanel10.Controls.Add(cbNguonGoc, 2, 0);
            tableLayoutPanel10.Controls.Add(label1, 1, 0);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(257, 10);
            tableLayoutPanel10.Margin = new Padding(3, 10, 3, 3);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel10.Size = new Size(588, 35);
            tableLayoutPanel10.TabIndex = 8;
            // 
            // cbLapDia
            // 
            cbLapDia.Dock = DockStyle.Fill;
            cbLapDia.FormattingEnabled = true;
            cbLapDia.Location = new Point(3, 3);
            cbLapDia.Name = "cbLapDia";
            cbLapDia.Size = new Size(190, 28);
            cbLapDia.TabIndex = 2;
            // 
            // cbNguonGoc
            // 
            cbNguonGoc.Dock = DockStyle.Fill;
            cbNguonGoc.FormattingEnabled = true;
            cbNguonGoc.Location = new Point(395, 3);
            cbNguonGoc.Name = "cbNguonGoc";
            cbNguonGoc.Size = new Size(190, 28);
            cbNguonGoc.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Location = new Point(306, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 35);
            label1.TabIndex = 1;
            label1.Text = "Nguồn gốc";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucDanhMucRungTheoNguonGoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ucDanhMucRungTheoNguonGoc";
            Size = new Size(968, 486);
            Load += ucDanhMucRungTheoNguonGoc_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            gListCard.ResumeLayout(false);
            tblLayoutListCard.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gListCard;
        private TableLayoutPanel tblLayoutListCard;
        private TableLayoutPanel tableLayoutPanel7;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn STT;
        private Label lbHeader;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel10;
        private ComboBox cbNguonGoc;
        private Label label1;
        private Label label2;
        private ComboBox cbLapDia;
    }
}
