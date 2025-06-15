namespace ForestManagementSystem.Forms
{
    partial class MainForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabControl3 = new TabControl();
            tabPage8 = new TabPage();
            customButton10 = new ForestManagementSystem.Common.Button.CustomButton();
            customButton11 = new ForestManagementSystem.Common.Button.CustomButton();
            tabPage9 = new TabPage();
            tabPage2 = new TabPage();
            tabControl2 = new TabControl();
            tabPage3 = new TabPage();
            customButton6 = new ForestManagementSystem.Common.Button.CustomButton();
            tabPage4 = new TabPage();
            customButton1 = new ForestManagementSystem.Common.Button.CustomButton();
            customButton2 = new ForestManagementSystem.Common.Button.CustomButton();
            customButton3 = new ForestManagementSystem.Common.Button.CustomButton();
            customButton4 = new ForestManagementSystem.Common.Button.CustomButton();
            customButton5 = new ForestManagementSystem.Common.Button.CustomButton();
            tabPage5 = new TabPage();
            customButton7 = new ForestManagementSystem.Common.Button.CustomButton();
            tabPage6 = new TabPage();
            customButton8 = new ForestManagementSystem.Common.Button.CustomButton();
            tabPage7 = new TabPage();
            customButton9 = new ForestManagementSystem.Common.Button.CustomButton();
            customButton12 = new ForestManagementSystem.Common.Button.CustomButton();
            customButton13 = new ForestManagementSystem.Common.Button.CustomButton();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl3.SuspendLayout();
            tabPage8.SuspendLayout();
            tabPage9.SuspendLayout();
            tabPage2.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            tabPage7.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1495, 854);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1489, 848);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tabControl3);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1481, 815);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quản lý hệ thống";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(tabPage8);
            tabControl3.Controls.Add(tabPage9);
            tabControl3.Dock = DockStyle.Fill;
            tabControl3.Location = new Point(3, 3);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(1475, 809);
            tabControl3.TabIndex = 0;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(customButton10);
            tabPage8.Controls.Add(customButton11);
            tabPage8.Location = new Point(4, 29);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(1467, 776);
            tabPage8.TabIndex = 0;
            tabPage8.Text = "Quản lý đơn vị hành chính";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // customButton10
            // 
            customButton10.BackColor = Color.Transparent;
            customButton10.BorderColor = Color.Blue;
            customButton10.BorderRadius = 5;
            customButton10.BorderSize = 0;
            customButton10.ButtonColor = Color.Blue;
            customButton10.ButtonIcon = null;
            customButton10.ButtonType = Common.Button.ButtonType.Primary;
            customButton10.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton10.ForeColor = Color.White;
            customButton10.IconSize = 20;
            customButton10.IconSpacing = 5;
            customButton10.Location = new Point(465, 335);
            customButton10.Name = "customButton10";
            customButton10.Size = new Size(536, 50);
            customButton10.TabIndex = 7;
            customButton10.Text = "Quản lý và tìm kiếm cấp huyện";
            customButton10.TextColor = Color.White;
            customButton10.Click += customButton10_Click_1;
            // 
            // customButton11
            // 
            customButton11.BackColor = Color.Transparent;
            customButton11.BorderColor = Color.Blue;
            customButton11.BorderRadius = 5;
            customButton11.BorderSize = 0;
            customButton11.ButtonColor = Color.Blue;
            customButton11.ButtonIcon = null;
            customButton11.ButtonType = Common.Button.ButtonType.Primary;
            customButton11.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton11.ForeColor = Color.White;
            customButton11.IconSize = 20;
            customButton11.IconSpacing = 5;
            customButton11.Location = new Point(465, 391);
            customButton11.Name = "customButton11";
            customButton11.Size = new Size(536, 50);
            customButton11.TabIndex = 8;
            customButton11.Text = "Quản lý và tìm kiếm cấp xã";
            customButton11.TextColor = Color.White;
            customButton11.Click += customButton11_Click;
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(customButton12);
            tabPage9.Controls.Add(customButton13);
            tabPage9.Location = new Point(4, 29);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new Padding(3);
            tabPage9.Size = new Size(1467, 776);
            tabPage9.TabIndex = 1;
            tabPage9.Text = "Quản lý người dùng";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tabControl2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1481, 815);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quản lý rừng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Controls.Add(tabPage5);
            tabControl2.Controls.Add(tabPage6);
            tabControl2.Controls.Add(tabPage7);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1475, 809);
            tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(customButton6);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1467, 776);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Quy Hoạch Rừng";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // customButton6
            // 
            customButton6.BackColor = Color.Transparent;
            customButton6.BorderColor = Color.Blue;
            customButton6.BorderRadius = 5;
            customButton6.BorderSize = 0;
            customButton6.ButtonColor = Color.Blue;
            customButton6.ButtonIcon = null;
            customButton6.ButtonType = Common.Button.ButtonType.Primary;
            customButton6.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton6.ForeColor = Color.White;
            customButton6.IconSize = 20;
            customButton6.IconSpacing = 5;
            customButton6.Location = new Point(588, 327);
            customButton6.Name = "customButton6";
            customButton6.Size = new Size(446, 50);
            customButton6.TabIndex = 1;
            customButton6.Text = "Quy hoạch rừng";
            customButton6.TextColor = Color.White;
            customButton6.Click += customButton6_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(customButton1);
            tabPage4.Controls.Add(customButton2);
            tabPage4.Controls.Add(customButton3);
            tabPage4.Controls.Add(customButton4);
            tabPage4.Controls.Add(customButton5);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1467, 776);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Hiện trạng rừng";
            tabPage4.UseVisualStyleBackColor = true;
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
            customButton1.Location = new Point(425, 209);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(536, 50);
            customButton1.TabIndex = 5;
            customButton1.Text = "Quản lý loại rừng";
            customButton1.TextColor = Color.White;
            customButton1.Click += customButton1_Click_1;
            // 
            // customButton2
            // 
            customButton2.BackColor = Color.Transparent;
            customButton2.BorderColor = Color.Blue;
            customButton2.BorderRadius = 5;
            customButton2.BorderSize = 0;
            customButton2.ButtonColor = Color.Blue;
            customButton2.ButtonIcon = null;
            customButton2.ButtonType = Common.Button.ButtonType.Primary;
            customButton2.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton2.ForeColor = Color.White;
            customButton2.IconSize = 20;
            customButton2.IconSpacing = 5;
            customButton2.Location = new Point(425, 265);
            customButton2.Name = "customButton2";
            customButton2.Size = new Size(536, 50);
            customButton2.TabIndex = 6;
            customButton2.Text = "Danh mục rừng";
            customButton2.TextColor = Color.White;
            customButton2.Click += customButton2_Click;
            // 
            // customButton3
            // 
            customButton3.BackColor = Color.Transparent;
            customButton3.BorderColor = Color.Blue;
            customButton3.BorderRadius = 5;
            customButton3.BorderSize = 0;
            customButton3.ButtonColor = Color.Blue;
            customButton3.ButtonIcon = null;
            customButton3.ButtonType = Common.Button.ButtonType.Primary;
            customButton3.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton3.ForeColor = Color.White;
            customButton3.IconSize = 20;
            customButton3.IconSpacing = 5;
            customButton3.Location = new Point(425, 321);
            customButton3.Name = "customButton3";
            customButton3.Size = new Size(536, 50);
            customButton3.TabIndex = 7;
            customButton3.Text = "Nguồn gốc rừng ( TN, NT )";
            customButton3.TextColor = Color.White;
            customButton3.Click += customButton3_Click;
            // 
            // customButton4
            // 
            customButton4.BackColor = Color.Transparent;
            customButton4.BorderColor = Color.Blue;
            customButton4.BorderRadius = 5;
            customButton4.BorderSize = 0;
            customButton4.ButtonColor = Color.Blue;
            customButton4.ButtonIcon = null;
            customButton4.ButtonType = Common.Button.ButtonType.Primary;
            customButton4.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton4.ForeColor = Color.White;
            customButton4.IconSize = 20;
            customButton4.IconSpacing = 5;
            customButton4.Location = new Point(425, 377);
            customButton4.Name = "customButton4";
            customButton4.Size = new Size(536, 50);
            customButton4.TabIndex = 8;
            customButton4.Text = "Danh mục rừng theo nguồn góc và lập địa";
            customButton4.TextColor = Color.White;
            customButton4.Click += customButton4_Click;
            // 
            // customButton5
            // 
            customButton5.BackColor = Color.Transparent;
            customButton5.BorderColor = Color.Blue;
            customButton5.BorderRadius = 5;
            customButton5.BorderSize = 0;
            customButton5.ButtonColor = Color.Blue;
            customButton5.ButtonIcon = null;
            customButton5.ButtonType = Common.Button.ButtonType.Primary;
            customButton5.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton5.ForeColor = Color.White;
            customButton5.IconSize = 20;
            customButton5.IconSpacing = 5;
            customButton5.Location = new Point(425, 433);
            customButton5.Name = "customButton5";
            customButton5.Size = new Size(536, 50);
            customButton5.TabIndex = 9;
            customButton5.Text = "Danh mục thuộc tính lô đất";
            customButton5.TextColor = Color.White;
            customButton5.Click += customButton5_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(customButton7);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1467, 776);
            tabPage5.TabIndex = 2;
            tabPage5.Text = "Điểm trược lở";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // customButton7
            // 
            customButton7.BackColor = Color.Transparent;
            customButton7.BorderColor = Color.Blue;
            customButton7.BorderRadius = 5;
            customButton7.BorderSize = 0;
            customButton7.ButtonColor = Color.Blue;
            customButton7.ButtonIcon = null;
            customButton7.ButtonType = Common.Button.ButtonType.Primary;
            customButton7.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton7.ForeColor = Color.White;
            customButton7.IconSize = 20;
            customButton7.IconSpacing = 5;
            customButton7.Location = new Point(510, 363);
            customButton7.Name = "customButton7";
            customButton7.Size = new Size(446, 50);
            customButton7.TabIndex = 2;
            customButton7.Text = "Quản lý và tra cứu điểm trượt lở";
            customButton7.TextColor = Color.White;
            customButton7.Click += customButton7_Click;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(customButton8);
            tabPage6.Location = new Point(4, 29);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(1467, 776);
            tabPage6.TabIndex = 3;
            tabPage6.Text = "Điểm xảy ra lũ quét";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // customButton8
            // 
            customButton8.BackColor = Color.Transparent;
            customButton8.BorderColor = Color.Blue;
            customButton8.BorderRadius = 5;
            customButton8.BorderSize = 0;
            customButton8.ButtonColor = Color.Blue;
            customButton8.ButtonIcon = null;
            customButton8.ButtonType = Common.Button.ButtonType.Primary;
            customButton8.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton8.ForeColor = Color.White;
            customButton8.IconSize = 20;
            customButton8.IconSpacing = 5;
            customButton8.Location = new Point(510, 363);
            customButton8.Name = "customButton8";
            customButton8.Size = new Size(446, 50);
            customButton8.TabIndex = 3;
            customButton8.Text = "Quản lý và tra cứu lũ quét";
            customButton8.TextColor = Color.White;
            customButton8.Click += customButton8_Click;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(customButton9);
            tabPage7.Location = new Point(4, 29);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(1467, 776);
            tabPage7.TabIndex = 4;
            tabPage7.Text = "Báo cao thiên tai";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // customButton9
            // 
            customButton9.BackColor = Color.Transparent;
            customButton9.BorderColor = Color.Blue;
            customButton9.BorderRadius = 5;
            customButton9.BorderSize = 0;
            customButton9.ButtonColor = Color.Blue;
            customButton9.ButtonIcon = null;
            customButton9.ButtonType = Common.Button.ButtonType.Primary;
            customButton9.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton9.ForeColor = Color.White;
            customButton9.IconSize = 20;
            customButton9.IconSpacing = 5;
            customButton9.Location = new Point(510, 363);
            customButton9.Name = "customButton9";
            customButton9.Size = new Size(446, 50);
            customButton9.TabIndex = 4;
            customButton9.Text = "Quản lý và tra cứu thiên tai";
            customButton9.TextColor = Color.White;
            customButton9.Click += customButton9_Click;
            // 
            // customButton12
            // 
            customButton12.BackColor = Color.Transparent;
            customButton12.BorderColor = Color.Blue;
            customButton12.BorderRadius = 5;
            customButton12.BorderSize = 0;
            customButton12.ButtonColor = Color.Blue;
            customButton12.ButtonIcon = null;
            customButton12.ButtonType = Common.Button.ButtonType.Primary;
            customButton12.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton12.ForeColor = Color.White;
            customButton12.IconSize = 20;
            customButton12.IconSpacing = 5;
            customButton12.Location = new Point(465, 335);
            customButton12.Name = "customButton12";
            customButton12.Size = new Size(536, 50);
            customButton12.TabIndex = 9;
            customButton12.Text = "Quản lý người dùng";
            customButton12.TextColor = Color.White;
            customButton12.Click += customButton12_Click;
            // 
            // customButton13
            // 
            customButton13.BackColor = Color.Transparent;
            customButton13.BorderColor = Color.Blue;
            customButton13.BorderRadius = 5;
            customButton13.BorderSize = 0;
            customButton13.ButtonColor = Color.Blue;
            customButton13.ButtonIcon = null;
            customButton13.ButtonType = Common.Button.ButtonType.Primary;
            customButton13.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            customButton13.ForeColor = Color.White;
            customButton13.IconSize = 20;
            customButton13.IconSpacing = 5;
            customButton13.Location = new Point(465, 391);
            customButton13.Name = "customButton13";
            customButton13.Size = new Size(536, 50);
            customButton13.TabIndex = 9;
            customButton13.Text = "Quản lý nhóm người dùng";
            customButton13.TextColor = Color.White;
            customButton13.Click += customButton13_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1495, 854);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl3.ResumeLayout(false);
            tabPage8.ResumeLayout(false);
            tabPage9.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ucDefault ucDefault1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Common.Button.CustomButton customButton1;
        private Common.Button.CustomButton customButton2;
        private Common.Button.CustomButton customButton3;
        private Common.Button.CustomButton customButton4;
        private Common.Button.CustomButton customButton5;
        private Common.Button.CustomButton customButton6;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private Common.Button.CustomButton customButton7;
        private Common.Button.CustomButton customButton8;
        private Common.Button.CustomButton customButton9;
        private TabControl tabControl3;
        private TabPage tabPage8;
        private Common.Button.CustomButton customButton10;
        private Common.Button.CustomButton customButton11;
        private TabPage tabPage9;
        private Common.Button.CustomButton customButton12;
        private Common.Button.CustomButton customButton13;
    }
}