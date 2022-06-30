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
    class CustomLeftMenu : ToolStripProfessionalRenderer
    {
        Color Background = Color.FromArgb(89, 101, 112);
        Color ButtonFiilWest = Color.FromArgb(51, 60, 69);
        Color ButtonFiilEast = Color.FromArgb(121, 139, 154);
        Color ButtonOuterBorderWest = Color.FromArgb(77, 96, 120);
        Color ButtonOuterBorderEast = Color.FromArgb(144, 144, 144);
        Color ButtonInnerBorderWest = Color.FromArgb(36, 44, 54);
        Color ButtonInnerBorderEast = Color.FromArgb(92, 113, 139);

        int ButtonRadius = 2;
        public CustomLeftMenu()
        {
            
        }
        private GraphicsPath GetToolStripRectangle(ToolStrip toolStrip)
        {
            return GraphicsTools.CreateRoundRectangle(
                new Rectangle(0, 0, toolStrip.Width - 1, toolStrip.Height - 1), 1);
        }
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        private void DrawVistaButtonBackground(ToolStripItemRenderEventArgs e)
        {
            bool chk = false;

            if (e.Item is ToolStripButton)
            {
                chk = (e.Item as ToolStripButton).Checked;
            }

            DrawVistaButtonBackground(e.Graphics,
                new Rectangle(Point.Empty, e.Item.Size),
                e.Item.Selected,
                e.Item.Pressed,
                chk);
        }
        private void DrawVistaButtonBackground(Graphics g, Rectangle r, bool selected, bool pressed, bool checkd)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle border = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);

            if (selected)
            {
                //Border
                LinearGradientBrush bbrush = new LinearGradientBrush(border,
                    Color.Black, Color.White,
                    LinearGradientMode.Horizontal);

                using (GraphicsPath path = RoundedRect(border, ButtonRadius))
                {
                    using (Pen p = new Pen(bbrush))
                    {
                        g.DrawPath(p, path);
                    }                    
                }

                //Fill
                using (GraphicsPath path = RoundedRect(border, ButtonRadius))
                {
                    using (Brush b = new LinearGradientBrush(border,
                    ButtonFiilWest,
                    ButtonFiilEast,
                    LinearGradientMode.Horizontal))
                    {
                        g.FillPath(b, path);
                    }
                }
            }

            if (pressed)
            {
                 //Fill
                 using (GraphicsPath path = RoundedRect(border, ButtonRadius))
                 {
                     using (Brush b = new LinearGradientBrush(border,
                     ButtonFiilWest, 
                     ButtonFiilEast, 
                     LinearGradientMode.Horizontal))
                     {
                         g.FillPath(b, path);
                     }
                 }

                //Outer border
                LinearGradientBrush outbrush = new LinearGradientBrush(border,
                    ButtonOuterBorderWest,
                    ButtonOuterBorderEast, 
                    LinearGradientMode.Horizontal);
                using (GraphicsPath path = RoundedRect(border, ButtonRadius))
                {
                    using (Pen p = new Pen(outbrush))
                    {
                        g.DrawPath(p, path);
                    }
                }

                //Inner border
                Rectangle borderRect = border;
                borderRect.Inflate(-2,-2);
                LinearGradientBrush brush = new LinearGradientBrush(borderRect,
                    ButtonInnerBorderWest,
                    ButtonInnerBorderEast, 
                    LinearGradientMode.Horizontal);
                using (GraphicsPath path = RoundedRect(borderRect, ButtonRadius))
                {
                    using (Pen p = new Pen(brush, 2))
                    {
                        g.DrawPath(p, path);
                    }
                }
            }
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetToolStripRectangle(e.ToolStrip))
            {
                using (Pen p = new Pen(Background))
                {
                    e.Graphics.DrawPath(p, path);
                }
            }
            
        }
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.ToolStrip.Size);
            SolidBrush b = new SolidBrush(Background);
            e.Graphics.FillRectangle(b, rc);
        }
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            DrawVistaButtonBackground(e);
        }

    }
}
