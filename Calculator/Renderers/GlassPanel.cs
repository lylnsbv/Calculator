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
    public class GlassPanel : Panel
    {
       /* private const int WS_EX_TRANSPARENT = 0x20;
        private int opacity = 50;*/

        private int radius = 20;               

        public GlassPanel()
        {
            SetStyle(ControlStyles.Opaque, true);
        }

        public GlassPanel(IContainer con)
        {
            con.Add(this);
        }

       /* [DefaultValue(50)]
        public int Opacity
        {
            get
            { return this.opacity;}

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("50");
                    this.opacity = value;
            }
        }*/

        [DefaultValue(20)]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
            }
        }

       /* protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cpar = base.CreateParams;
                cpar.ExStyle = cpar.ExStyle | WS_EX_TRANSPARENT;
                return cpar;
            }

        }*/

        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();

            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
           
            GraphPath.CloseFigure();
            return GraphPath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF Rect = new RectangleF(0, 0, this.Width-1, this.Height-1);            
            GraphicsPath GraphPath = GetRoundPath(Rect, 40);

            using (var brush = new SolidBrush(Color.FromArgb
                (144, 151, 159)))
              // (this.opacity * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillPath(brush, GraphPath);
                e.Graphics.DrawPath(Pens.White, GraphPath);               
            }
        }       
    }
}
