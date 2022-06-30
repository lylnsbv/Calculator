using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kssaiy.Renderers
{
    class AdvancedComboBox : ComboBox
    {
        private Brush BorderBrush = new SolidBrush(SystemColors.WindowFrame);
        private Brush ArrowBrush = new SolidBrush(SystemColors.ControlText);
        private Brush DropButtonBrush = new SolidBrush(SystemColors.Control);
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
       // private static int WM_PAINT = 0x000F;

        private Color _ButtonColor = SystemColors.Control;

        public Color ButtonColor
        {
            get { return _ButtonColor; }
            set
            {
                _ButtonColor = value;
                DropButtonBrush = new SolidBrush(this.ButtonColor);
                this.Invalidate();
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case 0xf:
                    Graphics g = this.CreateGraphics();

                    //Draw the background of the dropdown button
                    Rectangle rect = new Rectangle(this.Width - 17, 0, 17, this.Height);
                    g.FillRectangle(DropButtonBrush, rect);

                    //Create the path for the arrow
                    System.Drawing.Drawing2D.GraphicsPath pth = new System.Drawing.Drawing2D.GraphicsPath();
                    PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                    PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                    PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
                    pth.AddLine(TopLeft, TopRight);
                    pth.AddLine(TopRight, Bottom);

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    //Determine the arrow's color.
                    if (this.DroppedDown)
                    {
                        ArrowBrush = new SolidBrush(SystemColors.HighlightText);
                    }
                    else
                    {
                        ArrowBrush = new SolidBrush(SystemColors.ControlText);
                    }

                    //Draw the arrow
                    g.FillPath(ArrowBrush, pth);

                    break;
                default:
                    break;
            }
        }

        [Category("Appearance")]
        public ButtonBorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                _borderStyle = value;
                Invalidate();
            }
        }

        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}