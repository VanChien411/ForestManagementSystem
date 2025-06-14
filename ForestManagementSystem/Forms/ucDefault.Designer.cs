namespace ForestManagementSystem.Forms
{
    partial class ucDefault
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDefault));
            vehicleType = new DataGridViewTextBoxColumn();
            hasCard = new DataGridViewTextBoxColumn();
            LostCard = new DataGridViewButtonColumn();
            lbHeader = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            tableLayoutPanel10 = new TableLayoutPanel();
            customButton1 = new ForestManagementSystem.Common.Button.CustomButton();
            textBoxControl2 = new ForestManagementSystem.Common.Text.TextBoxControl();
            role = new DataGridViewTextBoxColumn();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            label4 = new Label();
            lbEligibleCards = new Label();
            lbUserNeedCard = new Label();
            lbCardType = new Label();
            cardType = new DataGridViewTextBoxColumn();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            gListCard = new GroupBox();
            tblLayoutListCard = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            lbIsLoading = new Label();
            lbShow = new Label();
            tableLayoutPanel9 = new TableLayoutPanel();
            label5 = new Label();
            cbRowNumber = new ComboBox();
            tableLayoutPanel11 = new TableLayoutPanel();
            lblTotalPages = new Label();
            cbPages = new ComboBox();
            label6 = new Label();
            label8 = new Label();
            dataGridView1 = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            UserId = new DataGridViewTextBoxColumn();
            UserName = new DataGridViewTextBoxColumn();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gListCard.SuspendLayout();
            tblLayoutListCard.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // vehicleType
            // 
            vehicleType.HeaderText = "Loại xe";
            vehicleType.MinimumWidth = 6;
            vehicleType.Name = "vehicleType";
            // 
            // hasCard
            // 
            hasCard.FillWeight = 70F;
            hasCard.HeaderText = "Số thẻ sở hữu";
            hasCard.MinimumWidth = 6;
            hasCard.Name = "hasCard";
            // 
            // LostCard
            // 
            LostCard.HeaderText = "Cấp thẻ mất";
            LostCard.MinimumWidth = 6;
            LostCard.Name = "LostCard";
            LostCard.Resizable = DataGridViewTriState.True;
            LostCard.SortMode = DataGridViewColumnSortMode.Automatic;
            LostCard.Text = "[Cấp thẻ]";
            LostCard.ToolTipText = "[Cấp thẻ]";
            LostCard.UseColumnTextForButtonValue = true;
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
            lbHeader.Size = new Size(947, 51);
            lbHeader.TabIndex = 3;
            lbHeader.Text = "Danh Sách Sử Dụng Thẻ";
            lbHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel10, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(60, 74);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(0, 0, 0, 5);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(944, 84);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel8);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(174, 192, 220);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(277, 73);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tạo từ ngày -> Đến ngày";
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(dtpEndDate, 1, 0);
            tableLayoutPanel8.Controls.Add(dtpStartDate, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 21);
            tableLayoutPanel8.Margin = new Padding(0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(271, 49);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpEndDate.CalendarFont = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(138, 3);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(130, 38);
            dtpEndDate.TabIndex = 10;
            dtpEndDate.Value = new DateTime(2024, 12, 20, 0, 0, 0, 0);
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpStartDate.CalendarFont = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(3, 3);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(129, 38);
            dtpStartDate.TabIndex = 11;
            dtpStartDate.Value = new DateTime(2024, 12, 20, 0, 0, 0, 0);
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 3;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel10.Controls.Add(customButton1, 2, 0);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(286, 10);
            tableLayoutPanel10.Margin = new Padding(3, 10, 3, 3);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel10.Size = new Size(655, 66);
            tableLayoutPanel10.TabIndex = 8;
            // 
            // customButton1
            // 
            customButton1.BackColor = Color.Transparent;
            customButton1.BorderColor = Color.Blue;
            customButton1.BorderRadius = 5;
            customButton1.BorderSize = 0;
            customButton1.ButtonColor = Color.Blue;
            customButton1.ButtonIcon = null;
            customButton1.ButtonType = Common.Button.ButtonType.Primary;
            customButton1.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton1.ForeColor = Color.White;
            customButton1.IconSize = 20;
            customButton1.IconSpacing = 5;
            customButton1.Location = new Point(439, 3);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(188, 52);
            customButton1.TabIndex = 0;
            customButton1.Text = "Button1";
            customButton1.TextColor = Color.White;
            // 
            // textBoxControl2
            // 
            textBoxControl2.BorderColor = Color.FromArgb(128, 128, 128);
            textBoxControl2.BorderThickness = 1;
            textBoxControl2.Dock = DockStyle.Fill;
            textBoxControl2.FocusBorderColor = Color.FromArgb(0, 120, 215);
            textBoxControl2.Location = new Point(3, 3);
            textBoxControl2.Name = "textBoxControl2";
            textBoxControl2.Size = new Size(246, 63);
            textBoxControl2.TabIndex = 1;
            // 
            // role
            // 
            role.FillWeight = 120F;
            role.HeaderText = "Vai trò";
            role.MinimumWidth = 6;
            role.Name = "role";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.74683F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.2531643F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Controls.Add(textBoxControl2, 0, 0);
            tableLayoutPanel5.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel5.Location = new Point(301, 5);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(316, 69);
            tableLayoutPanel5.TabIndex = 29;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 4;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 292F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 403F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 66F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(label4, 0, 0);
            tableLayoutPanel4.Controls.Add(lbEligibleCards, 0, 0);
            tableLayoutPanel4.Controls.Add(lbUserNeedCard, 1, 0);
            tableLayoutPanel4.Controls.Add(lbCardType, 0, 0);
            tableLayoutPanel4.Location = new Point(60, 249);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(890, 56);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Arial", 12.8F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(381, 0);
            label4.Name = "label4";
            label4.Size = new Size(397, 56);
            label4.TabIndex = 9;
            label4.Text = "Số Lượng Khách Hàng Cần Cấp Thẻ:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbEligibleCards
            // 
            lbEligibleCards.AutoSize = true;
            lbEligibleCards.Dock = DockStyle.Fill;
            lbEligibleCards.Font = new Font("Arial", 12.8F, FontStyle.Bold);
            lbEligibleCards.ForeColor = Color.Black;
            lbEligibleCards.Location = new Point(295, 0);
            lbEligibleCards.Name = "lbEligibleCards";
            lbEligibleCards.Size = new Size(80, 56);
            lbEligibleCards.TabIndex = 8;
            lbEligibleCards.Text = "0";
            lbEligibleCards.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbUserNeedCard
            // 
            lbUserNeedCard.AutoSize = true;
            lbUserNeedCard.Dock = DockStyle.Fill;
            lbUserNeedCard.Font = new Font("Arial", 12.8F, FontStyle.Bold);
            lbUserNeedCard.ForeColor = Color.Black;
            lbUserNeedCard.Location = new Point(784, 0);
            lbUserNeedCard.Name = "lbUserNeedCard";
            lbUserNeedCard.Size = new Size(103, 56);
            lbUserNeedCard.TabIndex = 7;
            lbUserNeedCard.Text = "0";
            lbUserNeedCard.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbCardType
            // 
            lbCardType.AutoSize = true;
            lbCardType.Dock = DockStyle.Fill;
            lbCardType.Font = new Font("Arial", 12.8F, FontStyle.Bold);
            lbCardType.ForeColor = Color.Black;
            lbCardType.Location = new Point(3, 0);
            lbCardType.Name = "lbCardType";
            lbCardType.Size = new Size(286, 56);
            lbCardType.TabIndex = 6;
            lbCardType.Text = "Số lượng thẻ có thể dùng:";
            lbCardType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardType
            // 
            cardType.HeaderText = "Loại thẻ";
            cardType.MinimumWidth = 6;
            cardType.Name = "cardType";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 346F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 643F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(60, 164);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(0, 5, 0, 5);
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(944, 79);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(gListCard, 0, 4);
            tableLayoutPanel1.Controls.Add(lbHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ForeColor = Color.Black;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(57, 20, 57, 20);
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1064, 691);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // gListCard
            // 
            gListCard.BackColor = Color.White;
            gListCard.Controls.Add(tblLayoutListCard);
            gListCard.Dock = DockStyle.Fill;
            gListCard.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gListCard.ForeColor = SystemColors.ActiveCaption;
            gListCard.Location = new Point(60, 311);
            gListCard.Name = "gListCard";
            gListCard.Size = new Size(944, 337);
            gListCard.TabIndex = 4;
            gListCard.TabStop = false;
            gListCard.Text = "Danh Sách Người Dùng Mất Thẻ Cần Cấp Lại";
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
            tblLayoutListCard.Size = new Size(938, 300);
            tblLayoutListCard.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(tableLayoutPanel6, 0, 1);
            tableLayoutPanel7.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(23, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tableLayoutPanel7.Size = new Size(892, 294);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel6.ColumnCount = 4;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 103F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(lbIsLoading, 2, 0);
            tableLayoutPanel6.Controls.Add(lbShow, 1, 0);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel9, 0, 0);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel11, 3, 0);
            tableLayoutPanel6.Location = new Point(3, 225);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(886, 66);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // lbIsLoading
            // 
            lbIsLoading.Anchor = AnchorStyles.Left;
            lbIsLoading.AutoSize = true;
            lbIsLoading.Font = new Font("Arial", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbIsLoading.ForeColor = Color.Black;
            lbIsLoading.Location = new Point(305, 23);
            lbIsLoading.Name = "lbIsLoading";
            lbIsLoading.Size = new Size(72, 19);
            lbIsLoading.TabIndex = 11;
            lbIsLoading.Text = "Đang tải";
            lbIsLoading.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbShow
            // 
            lbShow.Anchor = AnchorStyles.Left;
            lbShow.AutoSize = true;
            lbShow.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbShow.ForeColor = Color.Black;
            lbShow.Location = new Point(183, 20);
            lbShow.Name = "lbShow";
            lbShow.Size = new Size(88, 25);
            lbShow.TabIndex = 7;
            lbShow.Text = "0 - 0 of 0";
            lbShow.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.7391319F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.2608681F));
            tableLayoutPanel9.Controls.Add(label5, 0, 0);
            tableLayoutPanel9.Controls.Add(cbRowNumber, 1, 0);
            tableLayoutPanel9.Location = new Point(3, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(174, 60);
            tableLayoutPanel9.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(75, 60);
            label5.TabIndex = 8;
            label5.Text = "Hiển thị:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbRowNumber
            // 
            cbRowNumber.Anchor = AnchorStyles.Left;
            cbRowNumber.FormattingEnabled = true;
            cbRowNumber.Location = new Point(84, 16);
            cbRowNumber.Name = "cbRowNumber";
            cbRowNumber.Size = new Size(79, 36);
            cbRowNumber.TabIndex = 9;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.Anchor = AnchorStyles.Right;
            tableLayoutPanel11.ColumnCount = 6;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.5903625F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.4096375F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 19F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel11.Controls.Add(lblTotalPages, 0, 0);
            tableLayoutPanel11.Controls.Add(cbPages, 0, 0);
            tableLayoutPanel11.Controls.Add(label6, 0, 0);
            tableLayoutPanel11.Controls.Add(label8, 4, 0);
            tableLayoutPanel11.Location = new Point(408, 3);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 1;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel11.Size = new Size(475, 60);
            tableLayoutPanel11.TabIndex = 10;
            // 
            // lblTotalPages
            // 
            lblTotalPages.AutoSize = true;
            lblTotalPages.Dock = DockStyle.Fill;
            lblTotalPages.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPages.ForeColor = Color.Black;
            lblTotalPages.Location = new Point(73, 0);
            lblTotalPages.Name = "lblTotalPages";
            lblTotalPages.Size = new Size(79, 60);
            lblTotalPages.TabIndex = 11;
            lblTotalPages.Text = "/0 ]";
            lblTotalPages.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbPages
            // 
            cbPages.Anchor = AnchorStyles.Left;
            cbPages.FormattingEnabled = true;
            cbPages.Location = new Point(36, 16);
            cbPages.Name = "cbPages";
            cbPages.Size = new Size(31, 36);
            cbPages.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(27, 60);
            label6.TabIndex = 9;
            label6.Text = "[ Trang:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(308, 0);
            label8.Name = "label8";
            label8.Size = new Size(13, 60);
            label8.TabIndex = 33;
            label8.Text = "|";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { STT, UserId, UserName, cardType, vehicleType, role, hasCard, LostCard });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = SystemColors.ActiveCaption;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = Color.White;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 55;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(886, 216);
            dataGridView1.TabIndex = 1;
            // 
            // STT
            // 
            STT.FillWeight = 35F;
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            // 
            // UserId
            // 
            UserId.HeaderText = "ID người dùng";
            UserId.MinimumWidth = 6;
            UserId.Name = "UserId";
            // 
            // UserName
            // 
            UserName.HeaderText = "Tên";
            UserName.MinimumWidth = 6;
            UserName.Name = "UserName";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(294, 233);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(255, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // ucDefault
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Name = "ucDefault";
            Size = new Size(1064, 691);
            Load += ucDefault_Load;
            tableLayoutPanel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            gListCard.ResumeLayout(false);
            tblLayoutListCard.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewTextBoxColumn vehicleType;
        private DataGridViewTextBoxColumn hasCard;
        private DataGridViewButtonColumn LostCard;
        private Label lbHeader;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel8;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private TableLayoutPanel tableLayoutPanel10;
        private DataGridViewTextBoxColumn role;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel4;
        public Label label4;
        public Label lbEligibleCards;
        public Label lbUserNeedCard;
        public Label lbCardType;
        private DataGridViewTextBoxColumn cardType;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gListCard;
        private TableLayoutPanel tblLayoutListCard;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel6;
        private Label lbIsLoading;
        private Label lbShow;
        private TableLayoutPanel tableLayoutPanel9;
        private Label label5;
        private ComboBox cbRowNumber;
        private TableLayoutPanel tableLayoutPanel11;
        private Label lblTotalPages;
        private ComboBox cbPages;
        private Label label6;
        private Label label8;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn UserId;
        private DataGridViewTextBoxColumn UserName;
        private Label label1;
        private Common.Text.TextBoxControl textBoxControl1;
        private Common.Text.TextBoxControl textBoxControl2;
        public PictureBox pictureBox1;
        public Common.Button.CustomButton customButton1;
    }
}
