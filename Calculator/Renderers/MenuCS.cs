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
    public class MenuCs : ToolStripProfessionalRenderer
    {
        private LeftMenuColorTable _colorTable;
        private bool _glossyEffect;
        private bool _bgglow;
        private int _toolstripRadius;
        private int _buttonRadius;

        public MenuCs()
        {
            ColorTable = new LeftMenuColorTable();
            GlossyEffect = true;
            BackgroundGlow = true;
            ToolStripRadius = 2;
            ButtonRadius = 2;
        }
        new public LeftMenuColorTable ColorTable
        {
            get { return _colorTable; }
            set { _colorTable = value; }
        }
        public int ButtonRadius
        {
            get { return _buttonRadius; }
            set { _buttonRadius = value; }
        }
        public int ToolStripRadius
        {
            get { return _toolstripRadius; }
            set { _toolstripRadius = value; }
        }
        public bool BackgroundGlow
        {
            get { return _bgglow; }
            set { _bgglow = value; }
        }
        public bool GlossyEffect
        {
            get { return _glossyEffect; }
            set { _glossyEffect = value; }
        }

        /* protected virtual void InitializeToolStripMenuItem(ToolStripMenuItem item)
         {
             item.AutoSize = false;
             item.Height = 26;
             item.TextAlign = ContentAlignment.MiddleLeft;

              /* foreach (ToolStripItem subitem in item.DropDownItems)
               {
                   if (subitem is ToolStripMenuItem)
                   {
                       InitializeToolStripMenuItem(subitem as ToolStripMenuItem);
                   }
               }
         }*/
        /* protected override void Initialize(ToolStrip toolStrip)
         {
             base.Initialize(toolStrip);

             toolStrip.AutoSize = false;
             toolStrip.Height = 26;
            // toolStrip.ForeColor = ColorTable.Text;
            // toolStrip.GripStyle = ToolStripGripStyle.Hidden;
         }*/
        /* protected override void InitializeItem(ToolStripItem item)
         {
             base.InitializeItem(item);

             //Don't Affect ForeColor of TextBoxes and ComboBoxes
             if (!((item is ToolStripTextBox) || (item is ToolStripComboBox)))
             {
                 item.ForeColor = ColorTable.Text;
             }

             item.Padding = new Padding(5);

             if (item is ToolStripSplitButton)
             {
                 ToolStripSplitButton btn = item as ToolStripSplitButton;
                 btn.DropDownButtonWidth = 18;

                 foreach (ToolStripItem subitem in btn.DropDownItems)
                 {
                     if (subitem is ToolStripMenuItem)
                     {
                         InitializeToolStripMenuItem(subitem as ToolStripMenuItem);
                     }
                 }
             }

             if (item is ToolStripDropDownButton)
             {
                 ToolStripDropDownButton btn = item as ToolStripDropDownButton;
                 btn.ShowDropDownArrow = false;

                 foreach (ToolStripItem subitem in btn.DropDownItems)
                 {
                     if (subitem is ToolStripMenuItem)
                     {
                         InitializeToolStripMenuItem(subitem as ToolStripMenuItem);
                     }
                 }
             }
         }*/
        private GraphicsPath GetToolStripRectangle(ToolStrip toolStrip)
        {
            return GraphicsTools.CreateRoundRectangle(
                new Rectangle(0, 0, toolStrip.Width - 1, toolStrip.Height - 1), ToolStripRadius);
        }
        private void DrawGlossyEffect(Graphics g, ToolStrip t)
        {
            DrawGlossyEffect(g, t, 0);
        }
        private void DrawGlossyEffect(Graphics g, ToolStrip t, int offset)
        {
            Rectangle glossyRect = new Rectangle(0, offset,
                    t.Width - 1,
                    (t.Height - 1) / 2);

            using (LinearGradientBrush b = new LinearGradientBrush(
                glossyRect.Location, new PointF(0, glossyRect.Bottom),
                ColorTable.GlossyEffectNorth,
                ColorTable.GlossyEffectSouth))
            {
                using (GraphicsPath border =
                    GraphicsTools.CreateTopRoundRectangle(glossyRect, ToolStripRadius))
                {
                    g.FillPath(b, border);
                }
            }
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

            Rectangle outerBorder = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
            Rectangle border = outerBorder; border.Inflate(-1, -1);
            Rectangle innerBorder = border; innerBorder.Inflate(-1, -1);
            Rectangle glossy = outerBorder; glossy.Height /= 2;
            Rectangle fill = innerBorder; fill.Height /= 2;
            Rectangle glow = Rectangle.FromLTRB(outerBorder.Left,
                outerBorder.Top + Convert.ToInt32(Convert.ToSingle(outerBorder.Height) * .5f),
                outerBorder.Right, outerBorder.Bottom);

            if (selected || pressed || checkd)
            {
                #region Layers

                //Outer border
                using (GraphicsPath path =
                    GraphicsTools.CreateRoundRectangle(outerBorder, ButtonRadius))
                {
                    using (Pen p = new Pen(ColorTable.ButtonOuterBorder))
                    {
                        g.DrawPath(p, path);
                    }
                }

                //Checked fill
                if (checkd)
                {
                    using (GraphicsPath path = GraphicsTools.CreateRoundRectangle(innerBorder, 2))
                    {
                        using (Brush b = new SolidBrush(selected ? ColorTable.CheckedButtonFillHot : ColorTable.CheckedButtonFill))
                        {
                            g.FillPath(b, path);
                        }
                    }
                }

                //Glossy effefct
                using (GraphicsPath path = GraphicsTools.CreateTopRoundRectangle(glossy, ButtonRadius))
                {
                    using (Brush b = new LinearGradientBrush (outerBorder,
                       //  new Point(0, glossy.Top),
                       //  new Point(0, glossy.Bottom),
                         ColorTable.GlossyEffectNorth,
                         ColorTable.GlossyEffectNorth, LinearGradientMode.Vertical))
                    {
                        g.FillPath(b, path);
                    }
                }

                //Border
                using (GraphicsPath path =
                    GraphicsTools.CreateRoundRectangle(border, ButtonRadius))
                {
                    using (Pen p = new Pen(ColorTable.ButtonBorder))
                    {
                        g.DrawPath(p, path);
                    }
                }

                Color fillNorth = pressed ? ColorTable.ButtonFillNorthPressed : ColorTable.ButtonFillNorth;
                Color fillSouth = pressed ? ColorTable.ButtonFillSouthPressed : ColorTable.ButtonFillSouth;

                //Fill
                using (GraphicsPath path = GraphicsTools.CreateTopRoundRectangle(fill, ButtonRadius))
                {
                    using (Brush b = new LinearGradientBrush(
                        new Point(0, fill.Top),
                        new Point(0, fill.Bottom),
                        fillNorth, fillSouth))
                    {
                        g.FillPath(b, path);
                    }
                }

                Color innerBorderColor = pressed || checkd ? ColorTable.ButtonInnerBorderPressed : ColorTable.ButtonInnerBorder;

                //Inner border
                using (GraphicsPath path =
                    GraphicsTools.CreateRoundRectangle(innerBorder, ButtonRadius))
                {
                    using (Pen p = new Pen(innerBorderColor))
                    {
                        g.DrawPath(p, path);
                    }
                }

                //Glow
                using (GraphicsPath clip = GraphicsTools.CreateRoundRectangle(glow, 2))
                {
                    g.SetClip(clip, CombineMode.Intersect);

                    Color glowColor = ColorTable.Glow;

                    if (checkd)
                    {
                        if (selected)
                        {
                            glowColor = ColorTable.CheckedGlowHot;
                        }
                        else
                        {
                            glowColor = ColorTable.CheckedGlow;
                        }
                    }

                    using (GraphicsPath brad = CreateBottomRadialPath(glow))
                    {
                        using (PathGradientBrush pgr = new PathGradientBrush(brad))
                        {
                            unchecked
                            {
                                int opacity = 255;
                                RectangleF bounds = brad.GetBounds();
                                pgr.CenterPoint = new PointF((bounds.Left + bounds.Right) / 2f, (bounds.Top + bounds.Bottom) / 2f);
                                pgr.CenterColor = Color.FromArgb(opacity, glowColor);
                                pgr.SurroundColors = new Color[] { Color.FromArgb(0, glowColor) };
                            }
                            g.FillPath(pgr, brad);
                        }
                    }
                    g.ResetClip();
                }
                
                #endregion
            }
        }
        private void DrawVistaMenuBackground(ToolStripItemRenderEventArgs e)
        {
            DrawVistaMenuBackground(e.Graphics,
            new Rectangle(Point.Empty, e.Item.Size),
            e.Item.Selected, e.Item.Owner is MenuStrip);
        }
        private void DrawVistaMenuBackground(Graphics g, Rectangle r, bool highlighted, bool isMainMenu)
        {
            //g.Clear(ColorTable.MenuBackground);

            int margin = 2;
            int left = 22;

            #region IconSeparator

            if (!isMainMenu)
            {
                using (Pen p = new Pen(ColorTable.MenuDark))
                {
                    g.DrawLine(p,
                                new Point(r.Left + left, r.Top),
                                new Point(r.Left + left, r.Height - margin));
                }


                using (Pen p = new Pen(ColorTable.MenuLight))
                {
                    g.DrawLine(p,
                                new Point(r.Left + left + 1, r.Top),
                                new Point(r.Left + left + 1, r.Height - margin));
                }
            }

            #endregion

            if (highlighted)
            {
                #region Draw Rectangle

                using (GraphicsPath path = GraphicsTools.CreateRoundRectangle(
                    new Rectangle(r.X-1, r.Y-1, r.Width+1, r.Height+1), 3))
                {

                    using (Brush b = new LinearGradientBrush(
                        new Point(0, 2), new Point(0, r.Height - 2), 
                        Color.FromArgb(69, 127, 150), 
                        Color.FromArgb(69, 127, 150)))
                    {
                        g.FillPath(b, path);
                    }


                    GraphicsPath pa2 = GraphicsTools.CreateRoundRectangle(
                    new Rectangle(r.X + margin, r.Y + margin, r.Width - margin * 2, r.Height - margin * 2), 3);

                    using (Brush b = new LinearGradientBrush(
                        new Point(0, 2), new Point(0, r.Height - 2),
                        ColorTable.MenuHighlightNorth,
                        ColorTable.MenuHighlightSouth))
                    {
                        g.FillPath(b, pa2);
                    }

                    using (Pen p = new Pen(Color.FromArgb(194, 202, 206)))
                    {
                        g.DrawPath(p, pa2);
                    }
                }

                #endregion
            }

        }
        private void DrawVistaMenuBorder(Graphics g, Rectangle r)
        {
            using (Pen p = new Pen(ColorTable.BackgroundGlow))
            {
                g.DrawRectangle(p, new Rectangle(r.Left, r.Top, r.Width -1, r.Height -1));
                g.DrawLine(p, r.Left, r.Top+1, r.Width, r.Top+1);
                g.DrawLine(p, r.Left, r.Bottom-2, r.Width, r.Bottom-2);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDownMenu)
            {
                #region Draw Rectangled Border

                DrawVistaMenuBorder(e.Graphics,
                    new Rectangle(Point.Empty, e.ToolStrip.Size));


                Rectangle r = new Rectangle(1, 2, e.ToolStrip.Width-3, e.ToolStrip.Height-1);
                {
                    using (Pen p = new Pen(ColorTable.MenuBackground))                   
                    {
                        e.Graphics.DrawRectangle(p, r);
                    }
                }

                #endregion
            }
            else
            {
                #region Draw Rounded Border

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (GraphicsPath path = GetToolStripRectangle(e.ToolStrip))
                {
                    using (Pen p = new Pen(ColorTable.BackgroundBorder))
                    {
                         e.Graphics.DrawPath(p, path);
                    }
                }
                #endregion
            }
        }
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDownMenu)
            {
                return;
            }

            #region Background

            using (LinearGradientBrush b = new LinearGradientBrush(
                Point.Empty, new PointF(0, e.ToolStrip.Height),
                ColorTable.BackgroundNorth,
                ColorTable.BackgroundSouth))
            {
                using (GraphicsPath border = GetToolStripRectangle(e.ToolStrip))
                {
                    e.Graphics.FillPath(b, border);
                }
            }

            #endregion

            /*if (GlossyEffect)
            {
                #region Glossy Effect

                DrawGlossyEffect(e.Graphics, e.ToolStrip, 1);

                #endregion 
            }*/

            if (BackgroundGlow)
            {
                #region BackroundGlow

                int glowSize = Convert.ToInt32(Convert.ToSingle(e.ToolStrip.Height) * 0.15f);
                Rectangle glow = new Rectangle(0,
                    e.ToolStrip.Height - glowSize - 1,
                    e.ToolStrip.Width - 1,
                    glowSize);

                using (LinearGradientBrush b = new LinearGradientBrush(
                    new Point(0, glow.Top - 1), new PointF(0, glow.Bottom),
                    Color.FromArgb(0, ColorTable.BackgroundGlow),
                    ColorTable.BackgroundGlow))
                {
                    using (GraphicsPath border =
                        GraphicsTools.CreateBottomRoundRectangle(glow, ToolStripRadius))
                    {
                        e.Graphics.FillPath(b, border);
                    }
                }
                #endregion
            }

        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {

            if (e.Item is ToolStripButton)
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            }

            if (e.Item is ToolStripMenuItem && !(e.Item.Owner is MenuStrip))
            {
                if (!(e.Item.Selected))
                {
                    e.TextColor = ColorTable.MenuText;
                }
                else
                {
                    e.TextColor = Color.Black;
                }

            }
            base.OnRenderItemText(e);
        }
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            DrawVistaButtonBackground(e);
        }

       /* protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            DrawVistaButtonBackground(e);

            ToolStripDropDownButton item = e.Item as ToolStripDropDownButton; if (item == null) return;

            Rectangle arrowBounds = new Rectangle(item.Width - 18, 0, 18, item.Height);

            DrawArrow(new ToolStripArrowRenderEventArgs(
                e.Graphics, e.Item,
                arrowBounds,
                ColorTable.DropDownArrow, ArrowDirection.Down));
        }*/

      /*  protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            DrawVistaButtonBackground(e);

            ToolStripSplitButton item = e.Item as ToolStripSplitButton; if (item == null) return;

            Rectangle arrowBounds = item.DropDownButtonBounds;
            Rectangle buttonBounds = new Rectangle(item.ButtonBounds.Location, new Size(item.ButtonBounds.Width + 2, item.ButtonBounds.Height));
            Rectangle dropDownBounds = item.DropDownButtonBounds;

            DrawVistaButtonBackground(e.Graphics, buttonBounds, item.ButtonSelected,
                item.ButtonPressed, false);

            DrawVistaButtonBackground(e.Graphics, dropDownBounds, item.DropDownButtonSelected,
                item.DropDownButtonPressed, false);

            DrawArrow(new ToolStripArrowRenderEventArgs(
                e.Graphics, e.Item,
                arrowBounds,
                ColorTable.DropDownArrow, ArrowDirection.Down));
        }*/

       protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            if (!e.Item.Enabled)
            {
                base.OnRenderItemImage(e);

            }
            else
            {
                if (e.Image != null)
                {
                    e.Graphics.DrawImage(e.Image, e.ImageRectangle);
                }
            }

        }
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {

            //base.OnRenderImageMargin(e);
            /* using (SolidBrush brush = new SolidBrush(Color.FromArgb(69, 127, 150)))
             {
                 e.Graphics.FillRectangle(brush, e.AffectedBounds);
             }*/
        }      
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Owner is MenuStrip)
            {
                DrawVistaButtonBackground(e);
            }
            else
            {
                if (e.Item.Selected)
                {
                    DrawVistaMenuBackground(e.Graphics,
                    new Rectangle(Point.Empty, e.Item.Size),
                    e.Item.Selected, e.Item.Owner is MenuStrip);
                }
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    Color c = Color.FromArgb(69, 127, 150);

                    using (SolidBrush brush = new SolidBrush(c))
                        e.Graphics.FillRectangle(brush, rc);
                }

            }
        }
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (e.Item.IsOnDropDown)
            {
                int left = 10;
                int right = e.Item.Width - 3;
                int top = e.Item.Height / 2; top--;

                e.Graphics.Clear(ColorTable.MenuBackground);

                using (Pen p = new Pen(ColorTable.SeparatorNorth))
                {
                    e.Graphics.DrawLine(p,
                        new Point(left, top),
                        new Point(right, top));
                }
            }
            else
            {
                int top = 13;
                int left = e.Item.Width / 2; left--;
                int height = e.Item.Height - top * 2;
                RectangleF separator = new RectangleF(left, top, 0.5f, height);

                using (Brush b = new LinearGradientBrush(
                    separator.Location,
                    new Point(Convert.ToInt32(separator.Left), Convert.ToInt32(separator.Bottom)),
                    ColorTable.SeparatorNorth, ColorTable.SeparatorSouth))
                {
                    e.Graphics.FillRectangle(b, separator);
                }
            }
        }
        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
         {
             DrawVistaButtonBackground(e);

             //Chevron is obtained from the character: » (Alt+0187)
             using (Brush b = new SolidBrush(e.Item.ForeColor))
             {
                 StringFormat sf = new StringFormat();
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                }
                //sf.Alignment = StringAlignment.Center;
                //sf.LineAlignment = StringAlignment.Center;

                Font f = new Font(e.Item.Font.FontFamily, 15);

                 e.Graphics.DrawString("»", f, b, new RectangleF(Point.Empty, e.Item.Size), sf);
             }

         }
         protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
          {
              if (e.Item is ToolStripMenuItem && !e.Item.Selected)
              {
                  e.ArrowColor = ColorTable.MenuText;
              }

             base.OnRenderArrow(e);
          }
        private static GraphicsPath CreateBottomRadialPath(Rectangle rectangle)
        {
            GraphicsPath path = new GraphicsPath();
            RectangleF rect = rectangle;
            rect.X -= rect.Width * .35f;
            rect.Y -= rect.Height * .15f;
            rect.Width *= 1.7f;
            rect.Height *= 2.3f;
            path.AddEllipse(rect);
            path.CloseFigure();
            return path;
        }
    }
    public class LeftMenuColorTable : ProfessionalColorTable
    {
        private Color _bgNorth;
        private Color _bgSouth;
        private Color _glossyNorth;
        private Color _glossySouth;
        private Color _bgborder;
        private Color _bgglow;
        private Color _text;
        private Color _buttonInnerBorder;
        private Color _buttonBorder;
        private Color _buttonOuterBorder;
        private Color _buttonFill;
        private Color _buttonFillPressed;
        private Color _glow;
        private Color _buttonInnerBorderPressed;
        private Color _buttonFillSouth;
        private Color _buttonFillSouthPressed;
        private Color _dropDownArrow;
        private Color _menuHighlight;
        private Color _menuHiglightNorth;
        private Color _menuHighlightSouth;
        private Color _menuBackground;
        private Color _menuDark;
        private Color _menuLight;
        private Color _separatorNorth;
        private Color _separatorSouth;
        private Color _menuText;
        private Color _checkedGlow;
        private Color _checkedButtonFill;
        private Color _checkedButtonFillHot;
        private Color _checkedGlowHot;

        public LeftMenuColorTable()
        {
            BackgroundNorth = Color.FromArgb(83, 156, 184);
            BackgroundSouth = Color.FromArgb(24, 35, 49);

            GlossyEffectNorth = Color.FromArgb(83, 156, 184);
            GlossyEffectSouth = Color.FromArgb(24, 35, 49);

            BackgroundBorder = Color.FromArgb(75, 106, 144);
            BackgroundGlow = Color.FromArgb(24, 35, 49);

            Text = Color.White;

            ButtonOuterBorder = Color.FromArgb(83, 156, 184);
           // ButtonInnerBorder = Color.FromArgb(191, 199, 206);
           // ButtonInnerBorderPressed = Color.FromArgb(75, 75, 75);
            ButtonBorder = Color.FromArgb(3, 6, 11);
            ButtonFillNorth = Color.FromArgb(85, Color.White);
            ButtonFillSouth = Color.FromArgb(1, Color.White);
            ButtonFillNorthPressed = Color.FromArgb(150, Color.Black);
            ButtonFillSouthPressed = Color.FromArgb(100, Color.Black);

            Glow = Color.FromArgb(48, 146, 206);
            DropDownArrow = Color.White;

            MenuHighlight = Color.FromArgb(109, 201, 238);
            MenuHighlightNorth = Color.FromArgb(25, MenuHighlight);
            MenuHighlightSouth = Color.FromArgb(102, MenuHighlight);
            MenuBackground = Color.FromArgb(69, 127, 150);
            MenuDark = Color.FromArgb(227, 227, 227);
            MenuLight = Color.White;

            SeparatorNorth = Color.Silver;
          //  SeparatorSouth = Color.White;

            MenuText = Color.White;

            CheckedGlow = Color.FromArgb(87, 182, 239);
            CheckedGlowHot = Color.FromArgb(112, 179, 255);
            CheckedButtonFill = Color.FromArgb(24, 128, 158);
            CheckedButtonFillHot = Color.FromArgb(15,142,191);
        }
        public Color GlossyEffectNorth
        {
            get { return _glossyNorth; }
            set { _glossyNorth = value; }
        }
        public Color GlossyEffectSouth
        {
            get { return _glossySouth; }
            set { _glossySouth = value; }
        }
        public Color CheckedGlowHot
        {
            get { return _checkedGlowHot; }
            set { _checkedGlowHot = value; }
        }
        public Color CheckedButtonFillHot
        {
            get { return _checkedButtonFillHot; }
            set { _checkedButtonFillHot = value; }
        }
        public Color CheckedButtonFill
        {
            get { return _checkedButtonFill; }
            set { _checkedButtonFill = value; }
        }
        public Color CheckedGlow
        {
            get { return _checkedGlow; }
            set { _checkedGlow = value; }
        }
        public Color ButtonFillSouthPressed
        {
            get { return _buttonFillSouthPressed; }
            set { _buttonFillSouthPressed = value; }
        }
        public Color ButtonFillSouth
        {
            get { return _buttonFillSouth; }
            set { _buttonFillSouth = value; }
        }
        public Color ButtonInnerBorderPressed
        {
            get { return _buttonInnerBorderPressed; }
            set { _buttonInnerBorderPressed = value; }
        }
        public Color ButtonFillNorth
        {
            get { return _buttonFill; }
            set { _buttonFill = value; }
        }
        public Color ButtonFillNorthPressed
        {
            get { return _buttonFillPressed; }
            set { _buttonFillPressed = value; }
        }
        public Color ButtonInnerBorder
        {
            get { return _buttonInnerBorder; }
            set { _buttonInnerBorder = value; }
        }
        public Color ButtonBorder
        {
            get { return _buttonBorder; }
            set { _buttonBorder = value; }
        }
        public Color ButtonOuterBorder
        {
            get { return _buttonOuterBorder; }
            set { _buttonOuterBorder = value; }
        }
        public Color Glow
        {
            get { return _glow; }
            set { _glow = value; }
        }
         public Color BackgroundGlow
         {
             get { return _bgglow; }
             set { _bgglow = value; }
         }      
         public Color BackgroundBorder
         {
             get { return _bgborder; }
             set { _bgborder = value; }
         }
         public Color BackgroundNorth
         {
             get { return _bgNorth; }
             set { _bgNorth = value; }
         }        
         public Color BackgroundSouth
         {
             get { return _bgSouth; }
             set { _bgSouth = value; }
         }
        public Color MenuLight
        {
            get { return _menuLight; }
            set { _menuLight = value; }
        }
        public Color MenuDark
        {
            get { return _menuDark; }
            set { _menuDark = value; }
        }
        public Color MenuBackground
        {
            get { return _menuBackground; }
            set { _menuBackground = value; }
        }
        public Color MenuHighlightSouth
        {
            get { return _menuHighlightSouth; }
            set { _menuHighlightSouth = value; }
        }

        public Color MenuHighlightNorth
        {
            get { return _menuHiglightNorth; }
            set { _menuHiglightNorth = value; }
        }
        public Color MenuHighlight
        {
            get { return _menuHighlight; }
            set { _menuHighlight = value; }
        }
        public Color Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public Color MenuText
        {
            get { return _menuText; }
            set { _menuText = value; }
        }
        public Color SeparatorNorth
        {
            get { return _separatorNorth; }
            set { _separatorNorth = value; }
        }
        public Color SeparatorSouth
        {
            get { return _separatorSouth; }
            set { _separatorSouth = value; }
        }
        public Color DropDownArrow
        {
            get { return _dropDownArrow; }
            set { _dropDownArrow = value; }
        }
    }
}