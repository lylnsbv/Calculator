using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace kssaiy.Renderers
{
    class TransparantButton : Button
    {
        private System.ComponentModel.Container components = null;
        private Pen _pen = null;
        SolidBrush _brushInside = null;

        #region -  Image  -
        private Image mImage;
        /// <summary>
        /// The image displayed on the button that 
        /// is used to help the user identify
        /// it's function if the text is ambiguous.
        /// </summary>
        [Category("Image"),
         DefaultValue(null),
         Description("The image displayed on the button that " +
                     "is used to help the user identify" +
                     "it's function if the text is ambiguous.")]

        new public Image Image
        {
            get { return mImage; }
            set { mImage = value; this.Invalidate(); }
        }

        private ContentAlignment mImageAlign = ContentAlignment.MiddleLeft;
        [Category("Image"),
         DefaultValue(typeof(ContentAlignment), "MiddleLeft"),
         Description("The alignment of the image " +
                     "in relation to the button.")]
        new public ContentAlignment ImageAlign
        {
            get { return mImageAlign; }
            set { mImageAlign = value; this.Invalidate(); }
        }

        private Size mImageSize = new Size(24, 24);
        [Category("Image"),
        DefaultValue(typeof(Size), "24, 24"),
        Description("The size of the image to be displayed on the" +
                    "button. This property defaults to 24x24.")]

        public Size ImageSize
        {
            get { return mImageSize; }
            set { mImageSize = value; this.Invalidate(); }
        }

        #endregion

        public TransparantButton()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            FlatAppearance.MouseDownBackColor = GetDarkerColor(Color.DarkKhaki, 10);
            FlatAppearance.MouseOverBackColor = Color.DarkKhaki;

            _pen = new Pen(BackColor);
            _brushInside = new SolidBrush(BackColor);
        }

        private void InitializeComponent()
        {
            this.Enter += new System.EventHandler(this.TransparantButton_Enter);
            this.Leave += new System.EventHandler(this.TransparantButton_Leave);
            this.MouseEnter += new System.EventHandler(this.TransparantButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TransparantButton_MouseLeave);
            this.MouseUp += new MouseEventHandler(this.TransparantButton_MouseUp);
            this.MouseDown += new MouseEventHandler(this.TransparantButton_MouseDown);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.GammaCorrected;
            g.CompositingMode = CompositingMode.SourceOver;

            g.FillEllipse(new SolidBrush(BackColor), 0, 0, ClientSize.Width, ClientSize.Height);
            DrawImage(g);
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(1, 1, ClientSize.Width - 3, ClientSize.Height - 3);
            this.Region = new Region(grPath);
        }

        private void DrawImage(Graphics g)
        {
            if (this.Image == null) { return; }
            Rectangle r = new Rectangle(8, 8, this.ImageSize.Width, this.ImageSize.Height);
            switch (this.ImageAlign)
            {
                case ContentAlignment.TopCenter:
                    r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2, 8, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.TopRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width, 8, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleLeft:
                    r = new Rectangle(8, this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleCenter:
                    r = new Rectangle((this.Width / 2 - (this.Text.Length / 2 + this.ImageSize.Width) - 10), this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width, this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomLeft:
                    r = new Rectangle(8, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomCenter:
                    r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
                    break;
            }
            g.DrawImage(this.Image, r);
        }

        private void TransparantButton_MouseDown(object sender, MouseEventArgs e)
        {
            _pen.Color = GetDarkerColor(Color.DarkKhaki, 20);
            _brushInside.Color = GetDarkerColor(Color.DarkKhaki, 40);
            this.Invalidate();
        }

        private void TransparantButton_MouseUp(object sender, MouseEventArgs e)
        {
            _pen.Color = GetLighterColor(this.BackColor, 5);
            _brushInside.Color = GetLighterColor(this.BackColor, 10);
            this.Invalidate();
        }

        private void TransparantButton_MouseLeave(object sender, System.EventArgs e)
        {
            _pen.Color = BackColor;
            _brushInside.Color = BackColor;
            this.Invalidate();
        }

        private void TransparantButton_MouseEnter(object sender, System.EventArgs e)
        {
            _pen.Color = GetLighterColor(Color.DarkKhaki, 5);
            _brushInside.Color = GetLighterColor(Color.DarkKhaki, 10);
            this.Invalidate();
        }

        private void TransparantButton_Enter(object sender, System.EventArgs e)
        {
            _pen.Color = GetLighterColor(Color.DarkKhaki, 5);
            _brushInside.Color = GetLighterColor(Color.DarkKhaki, 10);
            this.Invalidate();
        }

        private void TransparantButton_Leave(object sender, System.EventArgs e)
        {
            _pen.Color = BackColor;
            _brushInside.Color = BackColor;
            this.Invalidate();
        }

        private Color GetLighterColor(Color color, byte intensity)
        {
            int r, g, b;
            r = color.R + intensity;
            g = color.G + intensity;
            b = color.B + intensity;
            if (r > 255 || r < 0) r *= -1;
            if (g > 255 || g < 0) g *= -1;
            if (b > 255 || b < 0) b *= -1;
            return Color.FromArgb(255, (byte)r, (byte)g, (byte)b);
        }

        private Color GetDarkerColor(Color color, byte intensity)
        {
            int r, g, b;
            r = color.R - intensity;
            g = color.G - intensity;
            b = color.B - intensity;
            if (r > 255 || r < 0) r *= -1;
            if (g > 255 || g < 0) g *= -1;
            if (b > 255 || b < 0) b *= -1;
            return Color.FromArgb(255, (byte)r, (byte)g, (byte)b);
        }
    }
}
