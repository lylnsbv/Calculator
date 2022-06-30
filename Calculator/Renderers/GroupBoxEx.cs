using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace kssaiy.Renderers
{
    public class GroupBoxEx : GroupBox
    {
        public GroupBoxEx()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);

            this.Resize += new EventHandler(CustomGroupBox_Resize);

            /*this.SetStyle(ControlStyles.UserPaint |
                           ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.OptimizedDoubleBuffer,
                           true);*/
        }

        private void CustomGroupBox_Resize(object sender, EventArgs e)
        {
            if (this.Visible) this.Refresh();

        }

        private Color borderColor = Color.Black;
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        private Color textColor = Color.Black;
        [DefaultValue(typeof(Color), "Black")]
        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; this.Invalidate(); }
        }

        public static GraphicsPath CreatePath(float x, float y, float width, float height, float radius, bool RoundTopLeft, bool RoundTopRight, bool RoundBottomRight, bool RoundBottomLeft)
        {
            float xw = x + width;
            float yh = y + height;
            float xwr = xw - radius;
            float yhr = yh - radius;
            float xr = x + radius;
            float yr = y + radius;
            float r2 = radius * 2;
            float xwr2 = xw - r2;
            float yhr2 = yh - r2;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            //Top Left Corner

            if (RoundTopLeft)
            {
                p.AddArc(x, y, r2, r2, 180, 90);

            }
            else
            {
                p.AddLine(x, yr, x, y);
                p.AddLine(x, y, xr, y);

            }

            //Top Edge
            p.AddLine(xr, y, xwr, y);

            //Top Right Corner

            if (RoundTopRight)
            {
                p.AddArc(xwr2, y, r2, r2, 270, 90);
            }
            else
            {
                p.AddLine(xwr, y, xw, y);
                p.AddLine(xw, y, xw, yr);
            }


            //Right Edge
            p.AddLine(xw, yr, xw, yhr);

            //Bottom Right Corner

            if (RoundBottomRight)
            {
                p.AddArc(xwr2, yhr2, r2, r2, 0, 90);
            }
            else
            {
                p.AddLine(xw, yhr, xw, yh);
                p.AddLine(xw, yh, xwr, yh);
            }


            //Bottom Edge
            p.AddLine(xwr, yh, xr, yh);

            //Bottom Left Corner           

            if (RoundBottomLeft)
            {
                p.AddArc(x, yhr2, r2, r2, 90, 90);
            }
            else
            {
                p.AddLine(xr, yh, x, yh);
                p.AddLine(x, yh, x, yhr);
            }

            //Left Edge
            p.AddLine(x, yhr, x, yr);

            p.CloseFigure();
            return p;
        }

        private void DrawUnthemedGroupBoxWithText(Graphics g, Rectangle bounds,
            string groupBoxText, Font font, Color titleColor,
            TextFormatFlags flags, GroupBoxState state)
        {

            Rectangle rectangle = bounds;

            rectangle.Width -= 8;

            Size size = TextRenderer.MeasureText(g, groupBoxText, font,
                new Size(rectangle.Width, rectangle.Height), flags);

            rectangle.Width = size.Width;
            rectangle.Height = size.Height;

            if ((flags & TextFormatFlags.Right) == TextFormatFlags.Right)
                rectangle.X = (bounds.Right - rectangle.Width) - 8;
            else
                rectangle.X += 8;

            TextRenderer.DrawText(g, groupBoxText, font, rectangle, titleColor, flags);
            if (rectangle.Width > 0)
                rectangle.Inflate(2, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GroupBoxState state = base.Enabled ? GroupBoxState.Normal :
                GroupBoxState.Disabled;

            TextFormatFlags flags = TextFormatFlags.PreserveGraphicsTranslateTransform |
                TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.TextBoxControl |
                TextFormatFlags.WordBreak;

            Color titleColor = this.TextColor;

            if (!this.ShowKeyboardCues)
                flags |= TextFormatFlags.HidePrefix;
            if (this.RightToLeft == RightToLeft.Yes)
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            if (!this.Enabled)
                titleColor = SystemColors.GrayText;

            Rectangle borderRect = new Rectangle(0, 0, base.Width,
               base.Height);

            GraphicsPath gPath = CreatePath(borderRect.X + 5, borderRect.Y + 13, borderRect.Width - 10, borderRect.Height - 14, 5, true, true, true, true);

            using (var pen = new Pen(this.BorderColor))
            {
                e.Graphics.DrawPath(pen, gPath);
            }

            DrawUnthemedGroupBoxWithText(e.Graphics, borderRect, this.Text, this.Font, titleColor, flags, state);

            RaisePaintEvent(this, e);

            

        }
    }
}



