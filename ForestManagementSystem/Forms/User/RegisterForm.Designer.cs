namespace ForestManagementSystem.Forms.User
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            label3 = new Label();
            tbRePassword = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            label2 = new Label();
            tbPassword = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            tbUserName = new TextBox();
            pictureBox1 = new PictureBox();
            lbRegister = new Label();
            lbError = new Label();
            customButton1 = new ForestManagementSystem.Common.Button.CustomButton();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(lbRegister, 0, 3);
            tableLayoutPanel1.Controls.Add(lbError, 0, 0);
            tableLayoutPanel1.Controls.Add(customButton1, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(30, 0, 30, 30);
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 29.78304F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70.2169647F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(492, 485);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(33, 129);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
            tableLayoutPanel2.Size = new Size(426, 222);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(label3, 0, 0);
            tableLayoutPanel5.Controls.Add(tbRePassword, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Top;
            tableLayoutPanel5.Location = new Point(3, 139);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(420, 73);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(414, 20);
            label3.TabIndex = 0;
            label3.Text = "Nhập lại mật khẩu";
            // 
            // tbRePassword
            // 
            tbRePassword.Dock = DockStyle.Fill;
            tbRePassword.Location = new Point(3, 39);
            tbRePassword.Name = "tbRePassword";
            tbRePassword.Size = new Size(414, 27);
            tbRePassword.TabIndex = 1;
            tbRePassword.UseSystemPasswordChar = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Controls.Add(tbPassword, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Top;
            tableLayoutPanel4.Location = new Point(3, 71);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(420, 62);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(414, 20);
            label2.TabIndex = 0;
            label2.Text = "Mật khẩu";
            // 
            // tbPassword
            // 
            tbPassword.Dock = DockStyle.Fill;
            tbPassword.Location = new Point(3, 34);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(414, 27);
            tbPassword.TabIndex = 1;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(tbUserName, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(420, 62);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(414, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // tbUserName
            // 
            tbUserName.Dock = DockStyle.Fill;
            tbUserName.Location = new Point(3, 34);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(414, 27);
            tbUserName.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(426, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lbRegister
            // 
            lbRegister.Anchor = AnchorStyles.Left;
            lbRegister.AutoSize = true;
            lbRegister.ForeColor = Color.Lime;
            lbRegister.Location = new Point(33, 369);
            lbRegister.Name = "lbRegister";
            lbRegister.Size = new Size(118, 20);
            lbRegister.TabIndex = 3;
            lbRegister.Text = "Đăng nhập ngay";
            lbRegister.TextAlign = ContentAlignment.MiddleCenter;
            lbRegister.Click += lbRegister_Click;
            // 
            // lbError
            // 
            lbError.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbError.AutoSize = true;
            lbError.ForeColor = Color.Red;
            lbError.Location = new Point(33, 5);
            lbError.Name = "lbError";
            lbError.Size = new Size(426, 20);
            lbError.TabIndex = 4;
            // 
            // customButton1
            // 
            customButton1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
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
            customButton1.Location = new Point(33, 407);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(426, 45);
            customButton1.TabIndex = 5;
            customButton1.Text = "Đăng ký ";
            customButton1.TextColor = Color.White;
            customButton1.Click += customButton1_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 485);
            Controls.Add(tableLayoutPanel1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label3;
        private TextBox tbRePassword;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private TextBox tbPassword;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private TextBox tbUserName;
        private PictureBox pictureBox1;
        private Common.Button.CustomButton btLogin;
        private Label lbRegister;
        private Label lbError;
        private Common.Button.CustomButton btRegister;
        private Common.Button.CustomButton customButton1;
    }
}