namespace ForestManagementSystem.Forms
{
    partial class EditForm
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
            lbHeader = new Label();
            tbBody = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btCancel = new ForestManagementSystem.Common.Button.CustomButton();
            btOk = new ForestManagementSystem.Common.Button.CustomButton();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lbHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(tbBody, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ForeColor = Color.Black;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(57, 20, 57, 20);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 4;
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
            lbHeader.Size = new Size(683, 51);
            lbHeader.TabIndex = 3;
            lbHeader.Text = "Thêm";
            lbHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbBody
            // 
            tbBody.ColumnCount = 1;
            tbBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbBody.Dock = DockStyle.Fill;
            tbBody.Location = new Point(60, 74);
            tbBody.Name = "tbBody";
            tbBody.RowCount = 1;
            tbBody.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbBody.Size = new Size(680, 302);
            tbBody.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btCancel, 1, 0);
            tableLayoutPanel2.Controls.Add(btOk, 0, 0);
            tableLayoutPanel2.Location = new Point(434, 382);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(306, 45);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // btCancel
            // 
            btCancel.BackColor = Color.Transparent;
            btCancel.BorderColor = Color.Blue;
            btCancel.BorderRadius = 5;
            btCancel.BorderSize = 0;
            btCancel.ButtonColor = Color.FromArgb(108, 117, 125);
            btCancel.ButtonIcon = null;
            btCancel.ButtonType = Common.Button.ButtonType.Secondary;
            btCancel.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            btCancel.ForeColor = Color.White;
            btCancel.IconSize = 20;
            btCancel.IconSpacing = 5;
            btCancel.Location = new Point(156, 3);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(147, 39);
            btCancel.TabIndex = 0;
            btCancel.Text = "Hủy";
            btCancel.TextColor = Color.White;
            // 
            // btOk
            // 
            btOk.BackColor = Color.Transparent;
            btOk.BorderColor = Color.Blue;
            btOk.BorderRadius = 5;
            btOk.BorderSize = 0;
            btOk.ButtonColor = Color.Blue;
            btOk.ButtonIcon = null;
            btOk.ButtonType = Common.Button.ButtonType.Primary;
            btOk.Font = new Font("Arial", 14.8F, FontStyle.Bold);
            btOk.ForeColor = Color.White;
            btOk.IconSize = 20;
            btOk.IconSpacing = 5;
            btOk.Location = new Point(3, 3);
            btOk.Name = "btOk";
            btOk.Size = new Size(147, 39);
            btOk.TabIndex = 1;
            btOk.Text = "Xác nhận";
            btOk.TextColor = Color.White;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "EditForm";
            Text = "EditForm";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        public Label lbHeader;
        public TableLayoutPanel tbBody;
        public Common.Button.CustomButton btCancel;
        public Common.Button.CustomButton btOk;
    }
}