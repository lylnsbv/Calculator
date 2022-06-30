using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kssaiy.Renderers
{
    public class SmothCsPanel: Panel
    {
        #region -  BackColor1  -
        private Color mBackColor1;

        [DefaultValue(typeof(Color), "0x000000")]
        public Color Color1
        {
            get { return mBackColor1; }
            set { mBackColor1 = value; Invalidate(); }
        }
        #endregion

        #region -  BackColor2  -
        private Color mBackColor2;

        [DefaultValue(typeof(Color), "0xFF0000")]
        public Color Color2
        {
            get { return mBackColor2; }
            set { mBackColor2 = value; Invalidate(); }
        }
        #endregion

        #region -  Radius  -
        private int _radius = 5;

        [DefaultValue(5)]
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;  Invalidate(); }
        }
        #endregion

        #region - LineColor  -
        private Color lineColor;

        [DefaultValue(typeof(Color), "0xFF0000")]
        public Color LineColor
        {
            get { return lineColor; }
            set { lineColor = value; Invalidate(); }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
          {
            if (ClientRectangle.Width == 0 || ClientRectangle.Height == 0) return;
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, mBackColor1, mBackColor2, LinearGradientMode.Vertical);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillRoundedRectangle(brush, 0, 0, this.Width-1, this.Height-1, Radius);
            g.DrawRoundedRectangle(new Pen(ControlPaint.Light(LineColor, 0.00f)), 0, 0, this.Width-1, this.Height-1, Radius);
          }
    }

    static class GraphicsExtension
    {
        private static GraphicsPath GenerateRoundedRectangle(
            this Graphics graphics,
            RectangleF rectangle,
            float radius)
        {
            float diameter;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0.0F)
            {
                path.AddRectangle(rectangle);
                path.CloseFigure();
                return path;
            }
            else
            {
                if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
                    return graphics.GenerateCapsule(rectangle);
                diameter = radius * 2.0F;
                SizeF sizeF = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rectangle.Location, sizeF);
                path.AddArc(arc, 180, 90);
                arc.X = rectangle.Right - diameter;
                path.AddArc(arc, 270, 90);
                arc.Y = rectangle.Bottom - diameter;
                path.AddArc(arc, 0, 90);
                arc.X = rectangle.Left;
                path.AddArc(arc, 90, 90);
                path.CloseFigure();
            }
            return path;
        }

        private static GraphicsPath GenerateCapsule(
            this Graphics graphics,
            RectangleF baseRect)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (baseRect.Width > baseRect.Height)
                {
                    diameter = baseRect.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    diameter = baseRect.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else path.AddEllipse(baseRect);
            }
            catch { path.AddEllipse(baseRect); }
            finally { path.CloseFigure(); }
            return path;
        }

        public static void DrawRoundedRectangle(
        this Graphics graphics,
        Pen pen,
        float x,
        float y,
        float width,
        float height,
        float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }

        public static void DrawRoundedRectangle(
            this Graphics graphics,
            Pen pen,
            int x,
            int y,
            int width,
            int height,
            int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                Convert.ToSingle(x),
                Convert.ToSingle(y),
                Convert.ToSingle(width),
                Convert.ToSingle(height),
                Convert.ToSingle(radius));
        }

        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            float x,
            float y,
            float width,
            float height,
            float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }

        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            int x,
            int y,
            int width,
            int height,
            int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                Convert.ToSingle(x),
                Convert.ToSingle(y),
                Convert.ToSingle(width),
                Convert.ToSingle(height),
                Convert.ToSingle(radius));
        }
    }
}
