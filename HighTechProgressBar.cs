using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TextProgressbar
{
    public class HighTechProgressBar : ProgressBar
    {
        private Color _gradientColor1;
        private Color _gradientColor2;
        private Color _gradientColor3;
        private LinearGradientMode _gradientMode;

        private Color _backGradientColor1;
        private Color _backGradientColor2;
        private Color _backGradientColor3;

        private Color _borderColor;
        private int _borderWidth;
        private Color _progressBackColor;

        private Color _textColor;
        private ContentAlignment _textAlignment;
        private Point _textMargin;
        private Font _textFont;
        private string _text = string.Empty;

        // =========================================================
        // STYLE / EFFECTS
        // =========================================================

        private RenderStyle _style;
        private int _cornerRadius;
        private int _blockCount;
        private int _blockGap;
        private int _blockDepth;
        private int _blockCornerRadius;
        private BlockGradientMode _blockGradientMode;
        private Color _glowColor;
        private int _glowSpread;
        private bool _shimmerEnabled;
        private int _shimmerSpeed;
        private Color _shimmerColor;
        private ShimmerDirection _shimmerDirection;
        private float _shimmerPosition;
        private System.Windows.Forms.Timer? _shimmerTimer;

        // =========================================================
        // CIRCULAR MODE
        // =========================================================

        private ProgressShape _shape;
        private int _ringThickness;
        private float _startAngle;
        private bool _clockwise;
        private bool _roundCaps;
        private Orientation _orientation;

        // =========================================================
        // TEXT ALIGNMENT
        // =========================================================

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(ContentAlignment.MiddleCenter)]
        public ContentAlignment TextAlignment
        {
            get => _textAlignment;
            set
            {
                if (_textAlignment != value)
                {
                    _textAlignment = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // TEXT FONT
        // =========================================================

        [Browsable(true)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Content)]
        public Font TextFont
        {
            get => _textFont;
            set
            {
                if (_textFont != value)
                {
                    _textFont = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // TEXT COLOR
        // =========================================================

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "White")]
        public Color TextColor
        {
            get => _textColor;
            set
            {
                if (_textColor != value)
                {
                    _textColor = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // TEXT MARGIN
        // =========================================================
        [Browsable(true)]
        [Category("Layout")]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Point), "1,1")]
        public Point TextMargin
        {
            get => _textMargin;
            set
            {
                if (_textMargin != value)
                {
                    _textMargin = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // TEXT
        // =========================================================

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        public new string Text
        {
            get => _text;
            set
            {
                value ??= string.Empty;

                if (_text != value)
                {
                    _text = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // PROGRESS GRADIENT COLORS
        // =========================================================

        [Browsable(true)]
        [Category("Progress Gradient")]
        [DefaultValue(typeof(Color), "0,120,215")]
        public Color GradientColor1
        {
            get => _gradientColor1;
            set
            {
                if (_gradientColor1 != value)
                {
                    _gradientColor1 = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Progress Gradient")]
        [DefaultValue(typeof(Color), "128,0,255")]
        public Color GradientColor2
        {
            get => _gradientColor2;
            set
            {
                if (_gradientColor2 != value)
                {
                    _gradientColor2 = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Progress Gradient")]
        [DefaultValue(typeof(Color), "0,220,180")]
        public Color GradientColor3
        {
            get => _gradientColor3;
            set
            {
                if (_gradientColor3 != value)
                {
                    _gradientColor3 = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // BACKGROUND GRADIENT COLORS
        // =========================================================

        [Browsable(true)]
        [Category("Background Gradient")]
        [DefaultValue(typeof(Color), "35,35,35")]
        public Color BackGradientColor1
        {
            get => _backGradientColor1;
            set
            {
                if (_backGradientColor1 != value)
                {
                    _backGradientColor1 = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Background Gradient")]
        [DefaultValue(typeof(Color), "55,55,55")]
        public Color BackGradientColor2
        {
            get => _backGradientColor2;
            set
            {
                if (_backGradientColor2 != value)
                {
                    _backGradientColor2 = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Background Gradient")]
        [DefaultValue(typeof(Color), "25,25,25")]
        public Color BackGradientColor3
        {
            get => _backGradientColor3;
            set
            {
                if (_backGradientColor3 != value)
                {
                    _backGradientColor3 = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // GRADIENT DIRECTION
        // =========================================================

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(LinearGradientMode.Horizontal)]
        public LinearGradientMode GradientMode
        {
            get => _gradientMode;
            set
            {
                if (_gradientMode != value)
                {
                    _gradientMode = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // BORDER
        // =========================================================

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "90,90,90")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(1)]
        public int BorderWidth
        {
            get => _borderWidth;
            set
            {
                int newValue = Math.Max(0, value);

                if (_borderWidth != newValue)
                {
                    _borderWidth = newValue;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // BACKGROUND BASE COLOR
        // =========================================================

        [Browsable(true)]
        [Category("Background Gradient")]
        [DefaultValue(typeof(Color), "35,35,35")]
        public Color ProgressBackColor
        {
            get => _progressBackColor;
            set
            {
                if (_progressBackColor != value)
                {
                    _progressBackColor = value;

                    // Keep all three background colors synchronized
                    // when the base color is changed.
                    _backGradientColor1 = value;
                    _backGradientColor2 = value;
                    _backGradientColor3 = value;

                    Invalidate();
                }
            }
        }

        // =========================================================
        // STYLE
        // =========================================================

        [Browsable(true)]
        [Category("Style")]
        [DefaultValue(RenderStyle.Gradient)]
        public RenderStyle RenderStyle
        {
            get => _style;
            set
            {
                if (_style != value)
                {
                    _style = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Style")]
        [DefaultValue(0)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                int v = Math.Max(0, value);
                if (_cornerRadius != v)
                {
                    _cornerRadius = v;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // BLOCKS
        // =========================================================

        [Browsable(true)]
        [Category("Blocks")]
        [DefaultValue(20)]
        public int BlockCount
        {
            get => _blockCount;
            set
            {
                int v = Math.Max(1, Math.Min(200, value));
                if (_blockCount != v)
                {
                    _blockCount = v;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Blocks")]
        [DefaultValue(3)]
        public int BlockGap
        {
            get => _blockGap;
            set
            {
                int v = Math.Max(0, value);
                if (_blockGap != v)
                {
                    _blockGap = v;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Blocks")]
        [DefaultValue(8)]
        public int BlockDepth
        {
            get => _blockDepth;
            set
            {
                int v = Math.Max(0, Math.Min(64, value));
                if (_blockDepth != v)
                {
                    _blockDepth = v;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Blocks")]
        [DefaultValue(6)]
        public int BlockCornerRadius
        {
            get => _blockCornerRadius;
            set
            {
                int v = Math.Max(0, value);
                if (_blockCornerRadius != v)
                {
                    _blockCornerRadius = v;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Blocks")]
        [DefaultValue(BlockGradientMode.Vertical)]
        public BlockGradientMode BlockGradientMode
        {
            get => _blockGradientMode;
            set
            {
                if (_blockGradientMode != value)
                {
                    _blockGradientMode = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // NEON GLOW
        // =========================================================

        [Browsable(true)]
        [Category("Neon")]
        [DefaultValue(typeof(Color), "0,255,255")]
        public Color GlowColor
        {
            get => _glowColor;
            set
            {
                if (_glowColor != value)
                {
                    _glowColor = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Neon")]
        [DefaultValue(8)]
        public int GlowSpread
        {
            get => _glowSpread;
            set
            {
                int v = Math.Max(0, Math.Min(40, value));
                if (_glowSpread != v)
                {
                    _glowSpread = v;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // SHIMMER
        // =========================================================

        [Browsable(true)]
        [Category("Effects")]
        [DefaultValue(false)]
        public bool ShimmerEnabled
        {
            get => _shimmerEnabled;
            set
            {
                if (_shimmerEnabled != value)
                {
                    _shimmerEnabled = value;
                    UpdateShimmerTimer();
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Effects")]
        [DefaultValue(50)]
        public int ShimmerSpeed
        {
            get => _shimmerSpeed;
            set
            {
                int v = Math.Max(10, Math.Min(1000, value));
                if (_shimmerSpeed != v)
                {
                    _shimmerSpeed = v;
                    UpdateShimmerTimer();
                }
            }
        }

        [Browsable(true)]
        [Category("Effects")]
        [DefaultValue(typeof(Color), "255,255,255")]
        public Color ShimmerColor
        {
            get => _shimmerColor;
            set
            {
                if (_shimmerColor != value)
                {
                    _shimmerColor = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Effects")]
        [DefaultValue(ShimmerDirection.LeftToRight)]
        public ShimmerDirection ShimmerDirection
        {
            get => _shimmerDirection;
            set
            {
                if (_shimmerDirection != value)
                {
                    _shimmerDirection = value;
                }
            }
        }

        // =========================================================
        // SHAPE
        // =========================================================

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(ProgressShape.Linear)]
        public ProgressShape Shape
        {
            get => _shape;
            set
            {
                if (_shape != value)
                {
                    _shape = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // CIRCULAR
        // =========================================================

        [Browsable(true)]
        [Category("Circular")]
        [DefaultValue(14)]
        public int RingThickness
        {
            get => _ringThickness;
            set
            {
                int v = Math.Max(2, Math.Min(500, value));
                if (_ringThickness != v)
                {
                    _ringThickness = v;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Circular")]
        [DefaultValue(-90f)]
        public float StartAngle
        {
            get => _startAngle;
            set
            {
                if (_startAngle != value)
                {
                    _startAngle = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Circular")]
        [DefaultValue(true)]
        public bool Clockwise
        {
            get => _clockwise;
            set
            {
                if (_clockwise != value)
                {
                    _clockwise = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Circular")]
        [DefaultValue(true)]
        public bool RoundCaps
        {
            get => _roundCaps;
            set
            {
                if (_roundCaps != value)
                {
                    _roundCaps = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // ORIENTATION
        // =========================================================

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    Invalidate();
                }
            }
        }

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public HighTechProgressBar()
        {
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw,
                true);

            // -----------------------------------------------------
            // TEXT
            // -----------------------------------------------------

            _textAlignment =
                ContentAlignment.MiddleCenter;

            _textFont =
                new Font(
                    FontFamily.GenericSansSerif,
                    10,
                    FontStyle.Bold);

            _textColor =
                Color.White;

            _textMargin =
                new Point(1, 1);

            _text =
                string.Empty;

            // -----------------------------------------------------
            // PROGRESS GRADIENT
            // -----------------------------------------------------

            _gradientColor1 =
                Color.FromArgb(0, 120, 215);

            _gradientColor2 =
                Color.FromArgb(128, 0, 255);

            _gradientColor3 =
                Color.FromArgb(0, 220, 180);

            // -----------------------------------------------------
            // BACKGROUND GRADIENT
            // -----------------------------------------------------

            _backGradientColor1 =
                Color.FromArgb(35, 35, 35);

            _backGradientColor2 =
                Color.FromArgb(55, 55, 55);

            _backGradientColor3 =
                Color.FromArgb(25, 25, 25);

            _progressBackColor =
                Color.FromArgb(35, 35, 35);

            // -----------------------------------------------------
            // GRADIENT DIRECTION
            // -----------------------------------------------------

            _gradientMode =
                LinearGradientMode.Horizontal;

            // -----------------------------------------------------
            // BORDER
            // -----------------------------------------------------

            _borderColor =
                Color.FromArgb(90, 90, 90);

            _borderWidth = 1;

            // -----------------------------------------------------
            // STYLE / EFFECTS
            // -----------------------------------------------------

            _style = RenderStyle.Gradient;
            _cornerRadius = 0;

            _blockCount = 20;
            _blockGap = 3;
            _blockDepth = 8;
            _blockCornerRadius = 6;
            _blockGradientMode = BlockGradientMode.Vertical;

            _glowColor = Color.FromArgb(0, 255, 255);
            _glowSpread = 8;

            _shimmerEnabled = false;
            _shimmerSpeed = 50;
            _shimmerColor = Color.White;
            _shimmerDirection = ShimmerDirection.LeftToRight;
            _shimmerPosition = 0f;

            _shimmerTimer = new System.Windows.Forms.Timer();
            _shimmerTimer.Tick += OnShimmerTick;

            // -----------------------------------------------------
            // CIRCULAR
            // -----------------------------------------------------

            _shape = ProgressShape.Linear;
            _ringThickness = 14;
            _startAngle = -90f;
            _clockwise = true;
            _roundCaps = true;
            _orientation = Orientation.Horizontal;
        }

        // =========================================================
        // PAINT
        // =========================================================

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;

            Graphics g = e.Graphics;

            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            g.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

            g.PixelOffsetMode =
                PixelOffsetMode.HighQuality;

            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            // =====================================================
            // BACKGROUND
            // =====================================================

            using (LinearGradientBrush backgroundBrush =
                   CreateThreeColorGradientBrush(
                       rect,
                       BackGradientColor1,
                       BackGradientColor2,
                       BackGradientColor3))
            {
                if (_cornerRadius > 0)
                {
                    using (GraphicsPath bgPath =
                           CreateShapePath(
                               rect,
                               _cornerRadius))
                    {
                        g.FillPath(
                            backgroundBrush,
                            bgPath);
                    }
                }
                else
                {
                    g.FillRectangle(
                        backgroundBrush,
                        rect);
                }
            }

            if (_shape == ProgressShape.Circular)
            {
                PaintCircular(g, rect);
                DrawTextOverlay(g);
                return;
            }

            bool vertical =
                Orientation == Orientation.Vertical;

            // =====================================================
            // CALCULATE PROGRESS
            // =====================================================

            int progressWidth = 0;

            if (Maximum > Minimum)
            {
                double percent =
                    (double)(Value - Minimum) /
                    (Maximum - Minimum);

                percent =
                    Math.Max(
                        0,
                        Math.Min(
                            1,
                            percent));

                progressWidth =
                    (int)Math.Round(
                        (vertical
                            ? rect.Height
                            : rect.Width) * percent);
            }

            GraphicsPath? progressPath = null;
            Rectangle progressArea = Rectangle.Empty;

            // =====================================================
            // PROGRESS FILL
            // =====================================================

            if (progressWidth > 0)
            {
                int innerLength =
                    Math.Max(
                        1,
                        progressWidth -
                        BorderWidth * 2);

                int innerThickness =
                    Math.Max(
                        1,
                        (vertical
                            ? rect.Width
                            : rect.Height) -
                        BorderWidth * 2);

                Rectangle progressRect = vertical
                    ? new Rectangle(
                        rect.X + BorderWidth,
                        rect.Y + rect.Height - BorderWidth - innerLength,
                        innerThickness,
                        innerLength)
                    : new Rectangle(
                        rect.X + BorderWidth,
                        rect.Y + BorderWidth,
                        innerLength,
                        innerThickness);

                progressArea = progressRect;

                int progressRadius =
                    Math.Max(
                        0,
                        _cornerRadius - BorderWidth);

                progressPath =
                    CreateShapePath(
                        progressRect,
                        progressRadius);

                switch (_style)
                {
                    case RenderStyle.Blocks3D:
                        DrawBlocks(
                            g,
                            progressRect,
                            rounded: false);
                        break;

                    case RenderStyle.Segmented:
                        DrawBlocks(
                            g,
                            progressRect,
                            rounded: true);
                        break;

                    case RenderStyle.Neon:
                        DrawNeon(
                            g,
                            progressRect,
                            progressPath);
                        break;

                    case RenderStyle.Striped:
                        DrawStriped(
                            g,
                            progressRect,
                            progressPath);
                        break;

                    default:
                        DrawGradientFill(
                            g,
                            progressRect,
                            progressPath);
                        break;
                }
            }

            // =====================================================
            // BORDER
            // =====================================================

            if (BorderWidth > 0)
            {
                using (Pen borderPen =
                       new Pen(
                           BorderColor,
                           BorderWidth))
                {
                    if (_cornerRadius > 0)
                    {
                        using (GraphicsPath borderPath =
                               CreateShapePath(
                                   new Rectangle(
                                       BorderWidth / 2,
                                       BorderWidth / 2,
                                       Math.Max(
                                           1,
                                           rect.Width - BorderWidth),
                                       Math.Max(
                                           1,
                                           rect.Height - BorderWidth)),
                                   Math.Max(
                                       1,
                                       _cornerRadius - BorderWidth / 2)))
                        {
                            g.DrawPath(
                                borderPen,
                                borderPath);
                        }
                    }
                    else
                    {
                        Rectangle borderRect =
                            new Rectangle(
                                BorderWidth / 2,
                                BorderWidth / 2,
                                Math.Max(
                                    1,
                                    rect.Width - BorderWidth),
                                Math.Max(
                                    1,
                                    rect.Height - BorderWidth));

                        g.DrawRectangle(
                            borderPen,
                            borderRect);
                    }
                }
            }

            // =====================================================
            // SHIMMER OVERLAY
            // =====================================================

            if (_shimmerEnabled &&
                progressWidth > 0 &&
                progressPath != null)
            {
                DrawShimmer(
                    g,
                    progressArea,
                    progressPath);
            }

            progressPath?.Dispose();

            // =====================================================
            // TEXT
            // =====================================================

            DrawTextOverlay(g);
        }

        // =========================================================
        // TEXT OVERLAY (SHARED BY LINEAR + CIRCULAR)
        // =========================================================

        private void DrawTextOverlay(Graphics g)
        {
            if (string.IsNullOrEmpty(Text) ||
                TextFont == null)
                return;

            using (SolidBrush textBrush =
                   new SolidBrush(TextColor))
            {
                Point location =
                    GetTextLocation(g);

                g.DrawString(
                    Text,
                    TextFont,
                    textBrush,
                    location);
            }
        }

        // =========================================================
        // SHAPE PATH (ROUNDED OR PLAIN RECTANGLE)
        // =========================================================

        private static GraphicsPath CreateShapePath(
            Rectangle rectangle,
            int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0 ||
                rectangle.Width <= 0 ||
                rectangle.Height <= 0)
            {
                path.AddRectangle(rectangle);
                return path;
            }

            int d =
                Math.Min(
                    radius * 2,
                    Math.Min(
                        rectangle.Width,
                        rectangle.Height));

            int x = rectangle.X;
            int y = rectangle.Y;
            int w = rectangle.Width;
            int h = rectangle.Height;

            path.AddArc(x, y, d, d, 180, 90);
            path.AddArc(x + w - d, y, d, d, 270, 90);
            path.AddArc(x + w - d, y + h - d, d, d, 0, 90);
            path.AddArc(x, y + h - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        // =========================================================
        // GRADIENT FILL (CLIPPED TO PROGRESS SHAPE)
        // =========================================================

        private void DrawGradientFill(
            Graphics g,
            Rectangle progressRect,
            GraphicsPath progressPath)
        {
            using (LinearGradientBrush progressBrush =
                   CreateThreeColorGradientBrush(
                       progressRect,
                       GradientColor1,
                       GradientColor2,
                       GradientColor3))
            {
                if (progressPath != null)
                {
                    g.FillPath(
                        progressBrush,
                        progressPath);
                }
                else
                {
                    g.FillRectangle(
                        progressBrush,
                        progressRect);
                }
            }
        }

        // =========================================================
        // BLOCK RENDERING (3D BEVEL OR ROUNDED SEGMENTS)
        // =========================================================

        private void DrawBlocks(
            Graphics g,
            Rectangle area,
            bool rounded)
        {
            bool vertical =
                Orientation == Orientation.Vertical;

            int gap = Math.Max(0, BlockGap);

            int areaLength =
                vertical ? area.Height : area.Width;

            int maxBlocks =
                Math.Max(
                    1,
                    (areaLength + gap) /
                    (gap + 3));

            int count =
                Math.Max(
                    1,
                    Math.Min(
                        BlockCount,
                        maxBlocks));

            int totalGap =
                gap * (count - 1);

            int blockLength =
                (areaLength - totalGap) / count;

            if (blockLength <= 0)
                return;

            int usedLength =
                count * blockLength + totalGap;

            int startOffset =
                (areaLength - usedLength) / 2;

            int radius = 0;

            if (rounded)
            {
                radius =
                    Math.Min(
                        BlockCornerRadius,
                        Math.Min(
                            blockLength,
                            vertical ? area.Width : area.Height) / 2);
            }

            for (int i = 0; i < count; i++)
            {
                Rectangle blockRect = vertical
                    ? new Rectangle(
                        area.X,
                        area.Y + startOffset + i * (blockLength + gap),
                        area.Width,
                        blockLength)
                    : new Rectangle(
                        area.X + startOffset + i * (blockLength + gap),
                        area.Y,
                        blockLength,
                        area.Height);

                using (LinearGradientBrush blockBrush =
                       CreateBlockBrush(blockRect))
                {
                    if (radius > 0)
                    {
                        using (GraphicsPath blockPath =
                               CreateShapePath(
                                   blockRect,
                                   radius))
                        {
                            g.FillPath(
                                blockBrush,
                                blockPath);
                        }
                    }
                    else
                    {
                        g.FillRectangle(
                            blockBrush,
                            blockRect);
                    }
                }

                if (!rounded && BlockDepth > 0)
                {
                    DrawBlockBevel(
                        g,
                        blockRect);
                }
            }
        }

        // =========================================================
        // PER-BLOCK GRADIENT BRUSH
        // =========================================================

        private LinearGradientBrush CreateBlockBrush(
            Rectangle blockRect)
        {
            Point p1;
            Point p2;

            switch (_blockGradientMode)
            {
                case BlockGradientMode.Horizontal:
                    p1 = new Point(blockRect.Left, blockRect.Top);
                    p2 = new Point(blockRect.Right, blockRect.Top);
                    break;

                case BlockGradientMode.Diagonal:
                    p1 = new Point(blockRect.Left, blockRect.Bottom);
                    p2 = new Point(blockRect.Right, blockRect.Top);
                    break;

                default:
                    p1 = new Point(blockRect.Left, blockRect.Top);
                    p2 = new Point(blockRect.Left, blockRect.Bottom);
                    break;
            }

            LinearGradientBrush brush =
                new LinearGradientBrush(
                    p1,
                    p2,
                    GradientColor1,
                    GradientColor3);

            brush.InterpolationColors =
                new ColorBlend
                {
                    Colors = new[]
                    {
                        GradientColor1,
                        GradientColor2,
                        GradientColor3
                    },
                    Positions = new[]
                    {
                        0.0f,
                        0.5f,
                        1.0f
                    }
                };

            return brush;
        }

        // =========================================================
        // 3D BEVEL FOR BLOCKS
        // =========================================================

        private void DrawBlockBevel(
            Graphics g,
            Rectangle blockRect)
        {
            int depth =
                Math.Min(
                    BlockDepth,
                    Math.Max(
                        1,
                        blockRect.Height / 2));

            // Top highlight edge
            using (Pen highlightPen =
                   new Pen(
                       ControlPaint.Light(
                           GradientColor2,
                           0.6f),
                       1.5f))
            {
                g.DrawLine(
                    highlightPen,
                    blockRect.Left + 1,
                    blockRect.Top + 0.75f,
                    blockRect.Right - 1,
                    blockRect.Top + 0.75f);
            }

            // Bottom shadow band
            Rectangle shadowRect =
                new Rectangle(
                    blockRect.Left + 1,
                    blockRect.Bottom - depth,
                    Math.Max(1, blockRect.Width - 2),
                    depth);

            using (LinearGradientBrush shadowBrush =
                   new LinearGradientBrush(
                       shadowRect,
                       Color.FromArgb(0, GradientColor1),
                       Color.FromArgb(170, Color.Black),
                       LinearGradientMode.Vertical))
            {
                g.FillRectangle(
                    shadowBrush,
                    shadowRect);
            }

            // Bottom dark edge line
            using (Pen edgePen =
                   new Pen(
                       Color.FromArgb(200, Color.Black),
                       1f))
            {
                g.DrawLine(
                    edgePen,
                    blockRect.Left + 1,
                    blockRect.Bottom - 0.5f,
                    blockRect.Right - 1,
                    blockRect.Bottom - 0.5f);
            }
        }

        // =========================================================
        // NEON GLOW RENDERING
        // =========================================================

        private void DrawNeon(
            Graphics g,
            Rectangle progressRect,
            GraphicsPath progressPath)
        {
            // Outer glow strokes (wide -> narrow)
            if (_glowSpread > 0)
            {
                for (int i = _glowSpread; i >= 1; i--)
                {
                    int alpha =
                        (int)(70.0 *
                              (1.0 -
                               (double)i /
                               (_glowSpread + 1)));

                    using (Pen glowPen =
                           new Pen(
                               Color.FromArgb(
                                   alpha,
                                   _glowColor),
                               i * 1.8f))
                    {
                        g.DrawPath(
                            glowPen,
                            progressPath);
                    }
                }
            }

            // Gradient fill on top of inner glow
            DrawGradientFill(
                g,
                progressRect,
                progressPath);

            // Bright core outline
            using (Pen corePen =
                   new Pen(
                       Color.FromArgb(220, _glowColor),
                       1.4f))
            {
                g.DrawPath(
                    corePen,
                    progressPath);
            }
        }

        // =========================================================
        // STRIPED RENDERING (SCROLLING BARS)
        // =========================================================

        private void DrawStriped(
            Graphics g,
            Rectangle progressRect,
            GraphicsPath progressPath)
        {
            DrawGradientFill(
                g,
                progressRect,
                progressPath);

            bool vertical =
                Orientation == Orientation.Vertical;

            int stripeCount =
                Math.Max(
                    4,
                    (vertical
                        ? progressRect.Height
                        : progressRect.Width) / 28);

            int stripeSize =
                Math.Max(
                    4,
                    (vertical
                        ? progressRect.Height
                        : progressRect.Width) /
                    (stripeCount * 2));

            float offset =
                _shimmerEnabled
                    ? _shimmerPosition %
                      (stripeSize * 2f)
                    : 0f;

            GraphicsState state = g.Save();
            g.SetClip(
                progressPath,
                CombineMode.Intersect);

            using (SolidBrush stripeBrush =
                   new SolidBrush(
                       Color.FromArgb(
                           70,
                           Color.White)))
            {
                if (vertical)
                {
                    for (int y =
                             progressRect.Top -
                             stripeSize * 2 +
                             (int)offset;
                         y < progressRect.Bottom;
                         y += stripeSize * 2)
                    {
                        g.FillRectangle(
                            stripeBrush,
                            progressRect.Left,
                            y,
                            progressRect.Width,
                            stripeSize);
                    }
                }
                else
                {
                    for (int x =
                             progressRect.Left -
                             stripeSize * 2 +
                             (int)offset;
                         x < progressRect.Right;
                         x += stripeSize * 2)
                    {
                        g.FillRectangle(
                            stripeBrush,
                            x,
                            progressRect.Top,
                            stripeSize,
                            progressRect.Height);
                    }
                }
            }

            g.Restore(state);
        }

        // =========================================================
        // SHIMMER SWEEP OVERLAY
        // =========================================================

        private void DrawShimmer(
            Graphics g,
            Rectangle area,
            GraphicsPath clipPath)
        {
            bool vertical =
                Orientation == Orientation.Vertical;

            float axisLength =
                vertical ? area.Height : area.Width;

            float band =
                Math.Max(
                    24f,
                    axisLength / 4f);

            float span =
                axisLength + band * 2f;

            float pos =
                (_shimmerPosition % span) - band;

            GraphicsState state = g.Save();

            g.SetClip(
                clipPath,
                CombineMode.Intersect);

            if (vertical)
            {
                g.TranslateTransform(
                    area.X + area.Width / 2f,
                    area.Y + pos + band / 2f);
            }
            else
            {
                g.TranslateTransform(
                    area.X + pos + band / 2f,
                    area.Y + area.Height / 2f);
            }

            g.RotateTransform(vertical ? 72f : -18f);

            float h =
                Math.Max(area.Width, area.Height) * 3f;

            using (LinearGradientBrush shimmerBrush =
                   new LinearGradientBrush(
                       new RectangleF(
                           -band / 2f,
                           -h / 2f,
                           band,
                           h),
                       Color.Transparent,
                       Color.FromArgb(90, _shimmerColor),
                       LinearGradientMode.Horizontal))
            {
                g.FillRectangle(
                    shimmerBrush,
                    -band / 2f,
                    -h / 2f,
                    band,
                    h);
            }

            g.Restore(state);
        }

        // =========================================================
        // SHIMMER TIMER
        // =========================================================

        private void UpdateShimmerTimer()
        {
            if (_shimmerTimer == null)
                return;

            bool shouldRun =
                _shimmerEnabled && IsHandleCreated;

            if (shouldRun && !_shimmerTimer.Enabled)
                _shimmerTimer.Start();
            else if (!shouldRun && _shimmerTimer.Enabled)
                _shimmerTimer.Stop();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateShimmerTimer();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            _shimmerTimer?.Stop();
            base.OnHandleDestroyed(e);
        }

        private void OnShimmerTick(
            object? sender,
            EventArgs e)
        {
            float axis =
                Orientation == Orientation.Vertical
                    ? Height
                    : Width;

            float band =
                Math.Max(
                    24f,
                    axis / 4f);

            float span =
                axis + band * 2f;

            float step =
                Math.Max(
                    3f,
                    axis / 45f);

            if (_shimmerDirection ==
                ShimmerDirection.LeftToRight)
            {
                _shimmerPosition += step;
            }
            else
            {
                _shimmerPosition -= step;
            }

            _shimmerPosition =
                (_shimmerPosition % span + span) % span;

            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _shimmerTimer?.Stop();
                _shimmerTimer?.Dispose();
                _shimmerTimer = null;
            }

            base.Dispose(disposing);
        }

        // =========================================================
        // THREE-COLOR GRADIENT BRUSH
        // =========================================================

        private LinearGradientMode EffectiveGradientMode()
        {
            // A horizontal gradient looks wrong on a vertical bar;
            // coerce it to vertical so thin bars still look right.
            if (Orientation == Orientation.Vertical &&
                _gradientMode == LinearGradientMode.Horizontal)
            {
                return LinearGradientMode.Vertical;
            }

            return _gradientMode;
        }

        private LinearGradientBrush CreateThreeColorGradientBrush(
            Rectangle rectangle,
            Color color1,
            Color color2,
            Color color3)
        {
            LinearGradientBrush brush =
                new LinearGradientBrush(
                    rectangle,
                    color1,
                    color3,
                    EffectiveGradientMode());

            brush.InterpolationColors =
                new ColorBlend
                {
                    Colors = new[]
                    {
                        color1,
                        color2,
                        color3
                    },

                    Positions = new[]
                    {
                        0.0f,
                        0.5f,
                        1.0f
                    }
                };

            return brush;
        }

        // =========================================================
        // TEXT POSITION
        // =========================================================

        private Point GetTextLocation(Graphics g)
        {
            if (TextAlignment !=
                ContentAlignment.TopLeft)
            {
                SizeF sizeText =
                    g.MeasureString(
                        Text,
                        TextFont);

                switch (TextAlignment)
                {
                    case ContentAlignment.TopCenter:

                        return new Point(
                            Convert.ToInt32(
                                Width / 2 -
                                sizeText.Width / 2),
                            TextMargin.Y);

                    case ContentAlignment.TopRight:

                        return new Point(
                            Convert.ToInt32(
                                Width -
                                sizeText.Width -
                                TextMargin.X),
                            TextMargin.Y);

                    case ContentAlignment.MiddleLeft:

                        return new Point(
                            TextMargin.X,
                            Convert.ToInt32(
                                Height / 2 -
                                sizeText.Height / 2));

                    case ContentAlignment.MiddleCenter:

                        return new Point(
                            Convert.ToInt32(
                                Width / 2 -
                                sizeText.Width / 2),
                            Convert.ToInt32(
                                Height / 2 -
                                sizeText.Height / 2));

                    case ContentAlignment.MiddleRight:

                        return new Point(
                            Convert.ToInt32(
                                Width -
                                sizeText.Width -
                                TextMargin.X),
                            Convert.ToInt32(
                                Height / 2 -
                                sizeText.Height / 2));

                    case ContentAlignment.BottomLeft:

                        return new Point(
                            TextMargin.X,
                            Convert.ToInt32(
                                Height -
                                sizeText.Height -
                                TextMargin.Y));

                    case ContentAlignment.BottomCenter:

                        return new Point(
                            Convert.ToInt32(
                                Width / 2 -
                                sizeText.Width / 2),
                            Convert.ToInt32(
                                Height -
                                sizeText.Height -
                                TextMargin.Y));

                    case ContentAlignment.BottomRight:

                        return new Point(
                            Convert.ToInt32(
                                Width -
                                sizeText.Width -
                                TextMargin.X),
                            Convert.ToInt32(
                                Height -
                                sizeText.Height -
                                TextMargin.Y));
                }
            }

            return TextMargin;
        }

        // =========================================================
        // CIRCULAR PROGRESS
        // =========================================================

        private void PaintCircular(
            Graphics g,
            Rectangle rect)
        {
            float percent = (float)GetPercent();

            int border = Math.Max(0, BorderWidth);

            float ringRadius =
                (Math.Min(rect.Width, rect.Height) -
                 border * 2f - _ringThickness) / 2f +
                _ringThickness / 2f;

            if (ringRadius <= _ringThickness / 2f + 1f)
                return;

            PointF center = new PointF(
                rect.X + rect.Width / 2f,
                rect.Y + rect.Height / 2f);

            float outerR = ringRadius + _ringThickness / 2f;
            float innerR = ringRadius - _ringThickness / 2f;

            RectangleF outerBounds = new RectangleF(
                center.X - outerR,
                center.Y - outerR,
                outerR * 2f,
                outerR * 2f);

            RectangleF innerBounds = new RectangleF(
                center.X - innerR,
                center.Y - innerR,
                innerR * 2f,
                innerR * 2f);

            float dir = _clockwise ? 1f : -1f;
            float start = _startAngle;
            float sweep = percent * 360f * dir;

            // -------------------------------------------------
            // TRACK RING (FULL ANNULUS)
            // -------------------------------------------------

            using (GraphicsPath trackPath =
                   CreateAnnulusPath(
                       outerBounds,
                       innerBounds))
            using (LinearGradientBrush trackBrush =
                   CreateThreeColorGradientBrush(
                       Rectangle.Round(outerBounds),
                       BackGradientColor1,
                       BackGradientColor2,
                       BackGradientColor3))
            {
                g.FillPath(trackBrush, trackPath);
            }

            // -------------------------------------------------
            // BORDER (CIRCLE AROUND CONTROL)
            // -------------------------------------------------

            if (BorderWidth > 0)
            {
                float br =
                    Math.Min(rect.Width, rect.Height) / 2f -
                    BorderWidth / 2f;

                RectangleF borderBounds = new RectangleF(
                    center.X - br,
                    center.Y - br,
                    br * 2f,
                    br * 2f);

                using (Pen borderPen =
                       new Pen(BorderColor, BorderWidth))
                {
                    g.DrawEllipse(borderPen, borderBounds);
                }
            }

            if (percent <= 0f)
                return;

            bool segmented =
                _renderStyleIsBlocks();

            // -------------------------------------------------
            // NEON GLOW (BEHIND THE RING)
            // -------------------------------------------------

            if (_style == RenderStyle.Neon && _glowSpread > 0)
            {
                for (int i = _glowSpread; i >= 1; i--)
                {
                    int alpha =
                        (int)(70.0 *
                              (1.0 -
                               (double)i /
                               (_glowSpread + 1)));

                    using (Pen glowPen =
                           new Pen(
                               Color.FromArgb(alpha, _glowColor),
                               _ringThickness + i * 1.8f))
                    {
                        DrawRingArc(
                            g,
                            glowPen,
                            center,
                            ringRadius,
                            start,
                            sweep);
                    }
                }
            }

            // -------------------------------------------------
            // PROGRESS RING
            // -------------------------------------------------

            if (segmented)
            {
                DrawCircularBlocks(
                    g,
                    center,
                    ringRadius,
                    _ringThickness,
                    outerBounds,
                    innerBounds,
                    start,
                    sweep,
                    dir);
            }
            else
            {
                DrawCircularGradientArc(
                    g,
                    center,
                    outerBounds,
                    innerBounds,
                    start,
                    sweep);

                // Striped: moving dash highlights
                if (_style == RenderStyle.Striped)
                {
                    DrawCircularStripes(
                        g,
                        center,
                        outerBounds,
                        innerBounds,
                        start,
                        sweep,
                        dir);
                }

                // Round caps on arc ends
                if (_roundCaps &&
                    Math.Abs(sweep) < 360f)
                {
                    DrawRingCap(
                        g,
                        center,
                        ringRadius,
                        _ringThickness,
                        start,
                        dir);

                    DrawRingCap(
                        g,
                        center,
                        ringRadius,
                        _ringThickness,
                        start + sweep,
                        dir);
                }
            }

            // -------------------------------------------------
            // NEON CORE OUTLINE
            // -------------------------------------------------

            if (_style == RenderStyle.Neon)
            {
                using (Pen corePen =
                       new Pen(
                           Color.FromArgb(220, _glowColor),
                           1.4f))
                {
                    DrawRingArc(
                        g,
                        corePen,
                        center,
                        ringRadius + _ringThickness / 2f - 0.7f,
                        start,
                        sweep);

                    DrawRingArc(
                        g,
                        corePen,
                        center,
                        ringRadius - _ringThickness / 2f + 0.7f,
                        start,
                        sweep);
                }
            }

            // -------------------------------------------------
            // SHIMMER (ROTATING SWEEP WEDGE)
            // -------------------------------------------------

            if (_shimmerEnabled)
            {
                DrawCircularShimmer(
                    g,
                    center,
                    outerBounds,
                    innerBounds,
                    start,
                    sweep,
                    dir);
            }
        }

        private bool _renderStyleIsBlocks() =>
            _style == RenderStyle.Blocks3D ||
            _style == RenderStyle.Segmented;

        // =========================================================
        // CIRCULAR HELPERS
        // =========================================================

        private double GetPercent()
        {
            if (Maximum <= Minimum)
                return 0.0;

            return Math.Max(
                0.0,
                Math.Min(
                    1.0,
                    (double)(Value - Minimum) /
                    (Maximum - Minimum)));
        }

        private static float NormalizeAngle(float a)
        {
            a %= 360f;
            return a < 0 ? a + 360f : a;
        }

        private PointF PolarPoint(
            PointF center,
            float radius,
            float angleDeg)
        {
            float rad = angleDeg * (float)Math.PI / 180f;
            return new PointF(
                center.X + radius * (float)Math.Cos(rad),
                center.Y + radius * (float)Math.Sin(rad));
        }

        private static GraphicsPath CreateAnnulusPath(
            RectangleF outerBounds,
            RectangleF innerBounds)
        {
            GraphicsPath path = new GraphicsPath();
            path.FillMode = FillMode.Alternate;
            path.AddEllipse(outerBounds);
            path.AddEllipse(innerBounds);
            return path;
        }

        private void DrawRingArc(
            Graphics g,
            Pen pen,
            PointF center,
            float radius,
            float startAngle,
            float sweepAngle)
        {
            float d = Math.Min(
                Math.Abs(sweepAngle),
                360f);

            if (d <= 0.01f)
                return;

            RectangleF b = new RectangleF(
                center.X - radius,
                center.Y - radius,
                radius * 2f,
                radius * 2f);

            if (d >= 359.9f)
            {
                g.DrawEllipse(pen, b);
            }
            else
            {
                g.DrawArc(pen, b, startAngle, sweepAngle);
            }
        }

        /// <summary>
        /// 3-stop gradient sampled at t in [0,1].
        /// </summary>
        private Color SampleGradient(float t)
        {
            t = Math.Max(0f, Math.Min(1f, t));

            if (t < 0.5f)
            {
                float k = t * 2f;
                return LerpColor(GradientColor1, GradientColor2, k);
            }

            float k2 = (t - 0.5f) * 2f;
            return LerpColor(GradientColor2, GradientColor3, k2);
        }

        private static Color LerpColor(Color a, Color b, float t)
        {
            return Color.FromArgb(
                (int)(a.A + (b.A - a.A) * t),
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        // =========================================================
        // CIRCULAR SEGMENTED BLOCKS
        // =========================================================

        private void DrawCircularBlocks(
            Graphics g,
            PointF center,
            float ringRadius,
            float thickness,
            RectangleF outerBounds,
            RectangleF innerBounds,
            float start,
            float sweep,
            float dir)
        {
            int count = Math.Max(4, Math.Min(BlockCount, 120));
            float slot = 360f / count;
            float gap = Math.Max(0f, Math.Min(30f, BlockGap));
            float segAngle = slot - gap;

            float absSweep = Math.Abs(sweep);
            bool is3D = _style == RenderStyle.Blocks3D;

            for (int i = 0; i < count; i++)
            {
                float segStart = i * slot;
                float visStart = Math.Max(segStart, 0f);
                float visEnd = Math.Min(segStart + segAngle, absSweep);

                // Account for sweep direction offset:
                // visible region is [0, absSweep] measured along dir
                // from 'start'. Convert to absolute angles.
                float a0 = NormalizeAngle(start + dir * visStart);
                float a1 = NormalizeAngle(start + dir * visEnd);

                if (visEnd <= visStart + 0.05f)
                    continue;

                // Rebuild sector from a0 sweeping toward a1
                float actualSweep =
                    NormalizeAngle(a1 - a0);
                if (dir < 0)
                    actualSweep = -actualSweep;
                // normalize to signed small angle
                float signed = a1 - a0;
                while (signed > 180f) signed -= 360f;
                while (signed < -180f) signed += 360f;
                actualSweep = signed;

                float midAngle =
                    NormalizeAngle(a0 + actualSweep / 2f);
                Color segColor =
                    SampleGradient(midAngle / 360f);

                float outerR = ringRadius + thickness / 2f;
                float innerR = ringRadius - thickness / 2f;

                // 3D drop shadow (Blocks3D only)
                if (is3D && BlockDepth > 0)
                {
                    using (GraphicsPath shadowPath =
                           CreateSectorPathManual(
                               center, outerR + 1.5f, innerR - 1.5f,
                               a0, actualSweep))
                    using (SolidBrush shadowBrush =
                           new SolidBrush(
                               Color.FromArgb(110, Color.Black)))
                    {
                        g.TranslateTransform(0, 2f);
                        g.FillPath(shadowBrush, shadowPath);
                        g.TranslateTransform(0, -2f);
                    }
                }

                using (GraphicsPath segPath =
                       CreateSectorPathManual(
                           center, outerR, innerR,
                           a0, actualSweep))
                using (SolidBrush segBrush =
                       new SolidBrush(segColor))
                {
                    g.FillPath(segBrush, segPath);
                }

                // Top highlight edge (3D bevel)
                if (is3D)
                {
                    using (Pen hiPen =
                           new Pen(
                               ControlPaint.Light(segColor, 0.5f),
                               1.4f))
                    {
                        DrawRingArc(
                            g, hiPen, center,
                            outerR - 0.8f,
                            a0, actualSweep);
                    }
                }

                // Rounded caps for Segmented style
                if (_style == RenderStyle.Segmented)
                {
                    DrawRingCap(g, center, ringRadius, thickness,
                                a0, dir);
                    DrawRingCap(g, center, ringRadius, thickness,
                                a0 + actualSweep, dir);
                }
            }
        }

        /// <summary>
        /// Annular sector built from explicit polyline points.
        /// Angles: 0 = 3 o'clock, positive = clockwise.
        /// </summary>
        private GraphicsPath CreateSectorPathManual(
            PointF center,
            float outerR,
            float innerR,
            float startAngle,
            float sweepAngle)
        {
            GraphicsPath path = new GraphicsPath();

            float absSweep = Math.Abs(sweepAngle);
            int steps = Math.Max(1, (int)(absSweep / 3f));

            // Outer edge
            for (int i = 0; i <= steps; i++)
            {
                float a = startAngle + sweepAngle * i / steps;
                PointF p = PolarPoint(center, outerR, a);
                if (i == 0) path.StartFigure();
                else path.AddLine(path.PathPoints[^1], p);
            }

            // Line to inner arc end, then inner edge back
            float endAngle = startAngle + sweepAngle;
            PointF innerEnd = PolarPoint(center, innerR, endAngle);
            path.AddLine(path.PathPoints[^1], innerEnd);

            for (int i = steps; i >= 0; i--)
            {
                float a = startAngle + sweepAngle * i / steps;
                PointF p = PolarPoint(center, innerR, a);
                path.AddLine(path.PathPoints[^1], p);
            }

            path.CloseFigure();
            return path;
        }

        private void DrawRingCap(
            Graphics g,
            PointF center,
            float ringRadius,
            float thickness,
            float angleDeg,
            float dir)
        {
            PointF capCenter =
                PolarPoint(center, ringRadius, angleDeg);

            float capR = thickness / 2f;

            // Color sampled at cap angle
            Color capColor =
                SampleGradient(NormalizeAngle(angleDeg) / 360f);

            using (SolidBrush capBrush =
                   new SolidBrush(capColor))
            {
                g.FillEllipse(
                    capBrush,
                    capCenter.X - capR,
                    capCenter.Y - capR,
                    capR * 2f,
                    capR * 2f);
            }
        }

        // =========================================================
        // CIRCULAR SMOOTH (ANGULAR GRADIENT) ARC
        // =========================================================

        private void DrawCircularGradientArc(
            Graphics g,
            PointF center,
            RectangleF outerBounds,
            RectangleF innerBounds,
            float start,
            float sweep)
        {
            float outerR = outerBounds.Width / 2f;
            float innerR = innerBounds.Width / 2f;

            int slices = Math.Max(
                4,
                Math.Min(180, (int)(Math.Abs(sweep) / 2f)));

            for (int i = 0; i < slices; i++)
            {
                float a0 = start + sweep * i / slices;
                float a1 = start + sweep * (i + 1) / slices;
                float mid = (a0 + a1) / 2f;

                Color c = SampleGradient(
                    NormalizeAngle(mid) / 360f);

                using (GraphicsPath slice =
                       CreateSectorPathManual(
                           center, outerR, innerR, a0, a1 - a0))
                using (SolidBrush brush =
                       new SolidBrush(c))
                {
                    g.FillPath(brush, slice);
                }
            }
        }

        // =========================================================
        // CIRCULAR STRIPES (DASHES ALONG THE RING)
        // =========================================================

        private void DrawCircularStripes(
            Graphics g,
            PointF center,
            RectangleF outerBounds,
            RectangleF innerBounds,
            float start,
            float sweep,
            float dir)
        {
            float outerR = outerBounds.Width / 2f;
            float innerR = innerBounds.Width / 2f;

            const int dashCount = 8;
            const float dashDeg = 22f;
            const float spacing = 360f / dashCount;

            float absSweep = Math.Abs(sweep);

            // Rotate dash phase with shimmer position
            float phase =
                _shimmerEnabled
                    ? (_shimmerPosition / Math.Max(1f, Width)) * 360f
                    : 0f;

            for (int d = 0; d < dashCount; d++)
            {
                float dashCenter =
                    start + dir * (phase + d * spacing);

                float d0 = dashCenter - dashDeg / 2f * dir;
                float d1 = dashCenter + dashDeg / 2f * dir;

                // Intersect dash with [0, absSweep] progress region
                float vis0 = Math.Max(
                    Math.Min(Math.Abs(d0 - start), absSweep), 0f);
                // compute overlap in "progress space"
                float p0 = Math.Abs(d0 - start);
                float p1 = Math.Abs(d1 - start);
                float lo = Math.Max(Math.Min(p0, p1), 0f);
                float hi = Math.Min(Math.Max(p0, p1), absSweep);

                if (hi <= lo + 0.5f)
                    continue;

                // Map back to absolute angles
                float s0 = start + dir * lo;
                float s1 = start + dir * hi;

                using (GraphicsPath dashPath =
                       CreateSectorPathManual(
                           center, outerR, innerR, s0, s1 - s0))
                using (SolidBrush dashBrush =
                       new SolidBrush(
                           Color.FromArgb(80, Color.White)))
                {
                    g.FillPath(dashBrush, dashPath);
                }
            }
        }

        // =========================================================
        // CIRCULAR SHIMMER (ROTATING HIGHLIGHT WEDGE)
        // =========================================================

        private void DrawCircularShimmer(
            Graphics g,
            PointF center,
            RectangleF outerBounds,
            RectangleF innerBounds,
            float start,
            float sweep,
            float dir)
        {
            float outerR = outerBounds.Width / 2f;
            float innerR = innerBounds.Width / 2f;

            // Map shimmer position (pixels) to degrees around ring
            float circumference = (float)(2.0 * Math.PI * outerR);
            float degPerPixel = 360f / Math.Max(1f, circumference);

            float posDeg = _shimmerPosition * degPerPixel;
            if (_shimmerDirection == ShimmerDirection.RightToLeft)
                posDeg = -posDeg;

            float wedge = 55f;

            // Clip everything to the progress sweep sector
            using (GraphicsPath clip =
                   CreateSectorPathManual(
                       center, outerR + 2f, innerR - 2f,
                       start, sweep))
            {
                GraphicsState state = g.Save();
                g.SetClip(clip);

                // 3 stacked wedges for soft edges
                for (int i = 0; i < 3; i++)
                {
                    float t = i / 2f;
                    float wa = wedge * (1f - 0.45f * t);
                    int alpha = (int)(70 - 55 * t);

                    float w0 = posDeg - wa / 2f;
                    float w1 = posDeg + wa / 2f;

                    using (GraphicsPath wedgePath =
                           CreateSectorPathManual(
                               center, outerR, innerR, w0, w1 - w0))
                    using (SolidBrush wb =
                           new SolidBrush(
                               Color.FromArgb(alpha, _shimmerColor)))
                    {
                        g.FillPath(wb, wedgePath);
                    }
                }

                g.Restore(state);
            }
        }

        // =========================================================
        // FORCE REPAINT WHEN VALUE CHANGES
        // =========================================================

        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(0)]
        public new int Value
        {
            get => base.Value;

            set
            {
                int newValue =
                    Math.Max(
                        Minimum,
                        Math.Min(
                            Maximum,
                            value));

                if (base.Value != newValue)
                {
                    base.Value = newValue;
                    Invalidate();
                }
            }
        }
    }
}
