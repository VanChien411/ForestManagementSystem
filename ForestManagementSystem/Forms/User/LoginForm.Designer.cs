namespace ForestManagementSystem.Forms.User
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            customButton1 = new ForestManagementSystem.Common.Button.CustomButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            label2 = new Label();
            tbPassword = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            tbUserName = new TextBox();
            pictureBox1 = new PictureBox();
            lbRegister = new Label();
            lbError = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(customButton1, 0, 4);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(lbRegister, 0, 3);
            tableLayoutPanel1.Controls.Add(lbError, 0, 0);
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
            tableLayoutPanel1.Size = new Size(507, 436);
            tableLayoutPanel1.TabIndex = 0;
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
            customButton1.Location = new Point(33, 358);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(441, 45);
            customButton1.TabIndex = 6;
            customButton1.Text = "Đăng nhập";
            customButton1.TextColor = Color.White;
            customButton1.Click += customButton1_Click_1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(33, 115);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(441, 187);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Controls.Add(tbPassword, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Top;
            tableLayoutPanel4.Location = new Point(3, 96);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(435, 73);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(429, 20);
            label2.TabIndex = 0;
            label2.Text = "Mật khẩu";
            // 
            // tbPassword
            // 
            tbPassword.Dock = DockStyle.Fill;
            tbPassword.Location = new Point(3, 39);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(429, 27);
            tbPassword.TabIndex = 1;
            tbPassword.Text = "admin";
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
            tableLayoutPanel3.Size = new Size(435, 73);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(429, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // tbUserName
            // 
            tbUserName.Dock = DockStyle.Fill;
            tbUserName.Location = new Point(3, 39);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(429, 27);
            tbUserName.TabIndex = 1;
            tbUserName.Text = "admin";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(441, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lbRegister
            // 
            lbRegister.Anchor = AnchorStyles.Left;
            lbRegister.AutoSize = true;
            lbRegister.ForeColor = Color.Lime;
            lbRegister.Location = new Point(33, 320);
            lbRegister.Name = "lbRegister";
            lbRegister.Size = new Size(99, 20);
            lbRegister.TabIndex = 3;
            lbRegister.Text = "Đăng ký ngay";
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
            lbError.Size = new Size(441, 20);
            lbError.TabIndex = 4;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 436);
            Controls.Add(tableLayoutPanel1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
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
        private Common.Button.CustomButton customButton1;
    }
}