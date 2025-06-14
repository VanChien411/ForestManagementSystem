using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForestManagementSystem.Common.Text
{
    public partial class TextBoxControl : UserControl
    {    
        private TextBox textBox;
        private Panel borderPanel;
        private Panel innerPanel;
        private Color borderColor = Color.FromArgb(128, 128, 128);
        private Color focusBorderColor = Color.FromArgb(0, 120, 215);
        private int borderThickness = 1;

        public TextBoxControl()
        {
            InitializeComponent();
            InitializeCustomTextBox();
        }

        private void InitializeCustomTextBox()
        {
            textBox = new TextBox();
            borderPanel = new Panel();
            innerPanel = new Panel();

            // Configure TextBox
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.Location = new Point(5, 5);
            textBox.Size = new Size(borderPanel.Width - 10, borderPanel.Height - 10);
            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;

            // Configure Border Panel
            borderPanel.Size = new Size(200, 30);
            borderPanel.Padding = new Padding(borderThickness);
            borderPanel.BackColor = borderColor;
            borderPanel.Dock = DockStyle.Fill;

            // Configure Inner Panel
            innerPanel.Size = new Size(borderPanel.Width - (borderThickness * 2), borderPanel.Height - (borderThickness * 2));
            innerPanel.Location = new Point(borderThickness, borderThickness);
            innerPanel.BackColor = Color.White;
            innerPanel.Dock = DockStyle.Fill;
            innerPanel.Padding = new Padding(borderThickness);
            innerPanel.Controls.Add(textBox);
            borderPanel.Controls.Add(innerPanel);

            // Add borderPanel to UserControl
            this.Controls.Add(borderPanel);
            this.Size = new Size(200, 30);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            borderPanel.BackColor = focusBorderColor;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            borderPanel.BackColor = borderColor;
        }

        // Public properties
        [Category("Appearance")]
        public string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                if (!textBox.Focused)
                {
                    borderPanel.BackColor = value;
                }
            }
        }

        [Category("Appearance")]
        public Color FocusBorderColor
        {
            get => focusBorderColor;
            set => focusBorderColor = value;
        }

        [Category("Appearance")]
        public int BorderThickness
        {
            get => borderThickness;
            set
            {
                borderThickness = value;
                borderPanel.Padding = new Padding(value);
                innerPanel.Padding = new Padding(value);
            }
        }

        [Category("Appearance")]
        public Font Font
        {
            get => textBox.Font;
            set => textBox.Font = value;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (textBox != null)
            {
                textBox.Size = new Size(innerPanel.Width - 10, innerPanel.Height - 10);
            }
        }
    }
}
