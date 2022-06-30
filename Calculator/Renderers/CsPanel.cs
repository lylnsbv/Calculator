
namespace kssaiy.Renderers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class CsPanel : Panel
    {
        public CsPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);           

            this.Resize += new EventHandler(CustomPanel_Resize);

            /*this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer,
                          true);*/

        }

        private void CustomPanel_Resize(object sender, EventArgs e)
        {
            if (this.Visible) this.Refresh();

        }



        #region -  BackColor  -
        private Color mBackColor;

        [DefaultValue(typeof(Color), "0xFF0000")]
        public Color Color
        {
            get { return mBackColor; }
            set { mBackColor = value; Invalidate(); }
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


        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                if (ClientRectangle.Width == 0 || ClientRectangle.Height == 0) return;
                LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, mBackColor2, mBackColor, LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, ClientRectangle);
                
            }
            catch 
            //(Exception ex)
            {
              //MessageBox.Show(ex.Message);
            }
            
        }

    }
} 