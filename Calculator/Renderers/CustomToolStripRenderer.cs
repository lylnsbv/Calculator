using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kssaiy.Renderers
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer() { }

      /*  protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {

            Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Width);

            LinearGradientMode mode = LinearGradientMode.Vertical;
          //  Rectangle brushRect = Rectangle.Inflate(rect, 0, 150);
            //Brush brush = new LinearGradientBrush(brushRect, Color.WhiteSmoke, Color.SlateGray, mode);
            SolidBrush brush = new SolidBrush(Color.FromArgb(231, 232, 234));
            e.Graphics.FillRectangle(brush, rect);


        }*/

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            ToolStripButton button = e.Item as ToolStripButton;

            Color gradientBegin = new Color();
            Color gradientEnd = new Color();

            Rectangle borderRect = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
           
            if (button.Pressed || button.Checked)
            {
               
                Pen greenPen = new Pen(Color.FromArgb(124, 181, 204), 3);
                gradientBegin = Color.LightSlateGray;
                gradientEnd = Color.FromArgb(240, 237, 221);
                

                Brush b = new LinearGradientBrush(borderRect, gradientBegin, gradientEnd, LinearGradientMode.Vertical);
                GraphicsPath gPath = CreatePath(borderRect.X, borderRect.Y, borderRect.Width - 1, borderRect.Height - 1, 5, true, true, true, true);

                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.FillRectangle(b, borderRect);
                g.DrawRoundedRectangle(greenPen, 0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1, 5);
            }

            else if (button.Selected)
            {
                Pen greenPen = new Pen(Color.FromArgb(171, 209, 223), 3);
                gradientEnd = Color.LightGray;
                gradientBegin = Color.FromArgb(1, gradientEnd);

                Brush b = new LinearGradientBrush(borderRect, gradientBegin, gradientEnd, LinearGradientMode.Vertical);
                GraphicsPath gPath = CreatePath(borderRect.X, borderRect.Y, borderRect.Width - 1, borderRect.Height - 1, 5, true, true, true, true);

                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.FillRectangle(b, borderRect);
                g.DrawRoundedRectangle(greenPen, 0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1, 5);                
            }

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

    }

}
