using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace ForestManagementSystem.Common.Button
{
    [ToolboxItem(true)]
    public partial class CustomButton : Control
    {
        #region Fields
        private int borderSize = 0;
        private int borderRadius = 5;
        private Color borderColor = Color.Blue;
        private bool isFocused = false;
        private bool isHovered = false;
        private bool isPressed = false;
        private Color buttonColor = Color.Blue;
        private Color textColor = Color.White;
        private Image? buttonIcon;
        private ButtonType buttonType = ButtonType.Primary;
        private int iconSize = 20;
        private int iconSpacing = 5;
        #endregion

        #region Properties
        [Category("Custom Button")]
        [Description("The size of the button's border")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        [Category("Custom Button")]
        [Description("The radius of the button's corners")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        [Category("Custom Button")]
        [Description("The color of the button's border")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Custom Button")]
        [Description("The background color of the button")]
        public Color ButtonColor
        {
            get { return buttonColor; }
            set
            {
                buttonColor = value;
                Invalidate();
            }
        }

        [Category("Custom Button")]
        [Description("The color of the button's text")]
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                Invalidate();
            }
        }

        [Category("Custom Button")]
        [Description("The icon displayed on the button")]
        public Image? ButtonIcon
        {
            get { return buttonIcon; }
            set
            {
                buttonIcon = value;
                Invalidate();
            }
        }

        [Category("Custom Button")]
        [Description("The type of button style")]
        public ButtonType ButtonType
        {
            get { return buttonType; }
            set
            {
                buttonType = value;
                UpdateButtonType();
                Invalidate();
            }
        }

        [Category("Custom Button")]
        [Description("The size of the button's icon")]
        public int IconSize
        {
            get { return iconSize; }
            set
            {
                iconSize = value;
                Invalidate();
            }
        }

        [Category("Custom Button")]
        [Description("The spacing between the icon and text")]
        public int IconSpacing
        {
            get { return iconSpacing; }
            set
            {
                iconSpacing = value;
                Invalidate();
            }
        }
        #endregion

        #region Constructor
        public CustomButton()
        {
            SetStyle(ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.SupportsTransparentBackColor, true);

            Size = new Size(150, 40);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = new Font("Arial", 14.8F, FontStyle.Bold);
            Cursor = Cursors.Hand;
            UpdateButtonType();
        }
        #endregion

        #region Methods
        private void UpdateButtonType()
        {
            switch (buttonType)
            {
                case ButtonType.Primary:
                    buttonColor = Color.Blue;
                    textColor = Color.White;
                    break;
                case ButtonType.Secondary:
                    buttonColor = Color.FromArgb(108, 117, 125);
                    textColor = Color.White;
                    break;
                case ButtonType.Success:
                    buttonColor = Color.FromArgb(40, 167, 69);
                    textColor = Color.White;
                    break;
                case ButtonType.Danger:
                    buttonColor = Color.FromArgb(220, 53, 69);
                    textColor = Color.White;
                    break;
                case ButtonType.Warning:
                    buttonColor = Color.FromArgb(255, 193, 7);
                    textColor = Color.Black;
                    break;
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            graph.TextRenderingHint = TextRenderingHint.AntiAlias;

            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

            Color buttonColor = this.buttonColor;
            if (isPressed)
                buttonColor = ControlPaint.Dark(buttonColor, 0.1f);
            else if (isHovered)
                buttonColor = ControlPaint.Light(buttonColor, 0.1f);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(Parent?.BackColor ?? Color.White, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    Region = new Region(pathSurface);
                    graph.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                        graph.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                graph.SmoothingMode = SmoothingMode.None;
                Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        graph.DrawRectangle(penBorder, 0, 0, Width - 0.5F, Height - 0.5F);
                    }
                }
            }

            using (SolidBrush brush = new SolidBrush(buttonColor))
            {
                graph.FillRectangle(brush, rectBorder);
            }

            // Draw icon if exists
            if (buttonIcon != null)
            {
                int iconX = borderSize + iconSpacing;
                int iconY = (Height - iconSize) / 2;
                graph.DrawImage(buttonIcon, iconX, iconY, iconSize, iconSize);
            }

            // Draw text
            using (SolidBrush brush = new SolidBrush(textColor))
            {
                StringFormat stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                int textX = borderSize + (buttonIcon != null ? iconSize + iconSpacing * 2 : 0);
                Rectangle textRect = new Rectangle(textX, 0, Width - textX - borderSize, Height);
                graph.DrawString(Text, Font, brush, textRect, stringFormat);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            isPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isPressed = false;
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            isFocused = true;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            isFocused = false;
            Invalidate();
        }
        #endregion
    }

    [TypeConverter(typeof(EnumConverter))]
    public enum ButtonType
    {
        Primary,
        Secondary,
        Success,
        Danger,
        Warning
    }
}
