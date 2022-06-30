using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kssaiy.Renderers
{
    public partial class CSProgressBar : ProgressBar
    {
        private SolidBrush brush = null;

        public CSProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (brush == null || brush.Color != this.ForeColor)
                brush = new SolidBrush(this.ForeColor);

            Rectangle rect = ClientRectangle;
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(this.BackColor), rect);

            rect.Inflate(-1, -1);

            if (Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);              
                g.FillRectangle(brush, clip);
            }
        }
    }
}