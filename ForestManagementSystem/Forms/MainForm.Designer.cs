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
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
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
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1481, 815);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quản lý hệ thống";
            tabPage1.UseVisualStyleBackColor = true;
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
            customButton6.Location = new Point(147, 124);
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
            customButton1.Location = new Point(271, 151);
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
            customButton2.Location = new Point(271, 207);
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
            customButton3.Location = new Point(271, 263);
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
            customButton4.Location = new Point(271, 319);
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
            customButton5.Location = new Point(271, 375);
            customButton5.Name = "customButton5";
            customButton5.Size = new Size(536, 50);
            customButton5.TabIndex = 9;
            customButton5.Text = "Danh mục thuộc tính lô đất";
            customButton5.TextColor = Color.White;
            customButton5.Click += customButton5_Click;
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
            tabPage2.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
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
    }
}