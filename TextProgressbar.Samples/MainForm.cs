using System.Drawing;

namespace TextProgressbar.Samples;

public class MainForm : Form
{
    private static readonly Color BgColor = Color.FromArgb(22, 22, 28);
    private static readonly Color PanelColor = Color.FromArgb(32, 32, 40);
    private static readonly Color LabelColor = Color.FromArgb(220, 220, 230);

    private readonly List<HighTechProgressBar> _bars = new();
    private readonly List<TrackBar> _trackBars = new();
    private readonly System.Windows.Forms.Timer _animTimer = new();
    private int _animValue;
    private int _animDir = 1;

    public MainForm()
    {
        Text = "HighTechProgressBar — Effects Showcase";
        BackColor = BgColor;
        ForeColor = LabelColor;
        ClientSize = new Size(980, 800);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 9f);

        BuildBarsPanel();
        BuildEffectsPanel();
        BuildAnimation();
    }

    // =========================================================
    // LEFT: BAR SHOWCASE
    // =========================================================

    private void BuildBarsPanel()
    {
        var title = new Label
        {
            Text = "RenderStyle showcase — drag a slider or press Animate",
            ForeColor = LabelColor,
            AutoSize = true,
            Location = new Point(16, 12),
            Font = new Font("Segoe UI", 11f, FontStyle.Bold)
        };
        Controls.Add(title);

        var specs = new (string Name, Action<HighTechProgressBar> Configure)[]
        {
            ("Gradient", b =>
            {
                b.RenderStyle = RenderStyle.Gradient;
                b.GradientColor1 = Color.FromArgb(0, 120, 215);
                b.GradientColor2 = Color.FromArgb(128, 0, 255);
                b.GradientColor3 = Color.FromArgb(0, 220, 180);
            }),
            ("Blocks3D", b =>
            {
                b.RenderStyle = RenderStyle.Blocks3D;
                b.BlockCount = 24;
                b.BlockGap = 4;
                b.BlockDepth = 10;
                b.GradientColor1 = Color.FromArgb(255, 140, 0);
                b.GradientColor2 = Color.FromArgb(255, 60, 0);
                b.GradientColor3 = Color.FromArgb(255, 200, 60);
            }),
            ("Segmented", b =>
            {
                b.RenderStyle = RenderStyle.Segmented;
                b.BlockCount = 28;
                b.BlockGap = 3;
                b.BlockCornerRadius = 9;
                b.GradientColor1 = Color.FromArgb(0, 200, 120);
                b.GradientColor2 = Color.FromArgb(0, 230, 200);
                b.GradientColor3 = Color.FromArgb(40, 160, 255);
            }),
            ("Neon", b =>
            {
                b.RenderStyle = RenderStyle.Neon;
                b.GlowColor = Color.FromArgb(255, 80, 220);
                b.GlowSpread = 12;
                b.GradientColor1 = Color.FromArgb(120, 0, 200);
                b.GradientColor2 = Color.FromArgb(255, 0, 180);
                b.GradientColor3 = Color.FromArgb(255, 120, 240);
            }),
            ("Striped", b =>
            {
                b.RenderStyle = RenderStyle.Striped;
                b.GradientColor1 = Color.FromArgb(0, 180, 255);
                b.GradientColor2 = Color.FromArgb(0, 90, 200);
                b.GradientColor3 = Color.FromArgb(120, 255, 255);
                b.ShimmerEnabled = true;
            })
        };

        int y = 48;
        foreach (var (name, configure) in specs)
        {
            var caption = new Label
            {
                Text = name,
                ForeColor = LabelColor,
                AutoSize = true,
                Location = new Point(16, y + 4),
                Font = new Font("Consolas", 10f, FontStyle.Bold)
            };
            Controls.Add(caption);

            var bar = new HighTechProgressBar
            {
                Location = new Point(110, y),
                Size = new Size(520, 28),
                Maximum = 100,
                Minimum = 0,
                BorderWidth = 1,
                BorderColor = Color.FromArgb(70, 70, 85),
                BackGradientColor1 = Color.FromArgb(38, 38, 48),
                BackGradientColor2 = Color.FromArgb(55, 55, 70),
                BackGradientColor3 = Color.FromArgb(30, 30, 40),
                TextAlignment = ContentAlignment.MiddleCenter
            };
            configure(bar);
            bar.Value = 0;
            bar.Text = "0%";

            var track = new TrackBar
            {
                Location = new Point(110, y + 34),
                Size = new Size(520, 45),
                Minimum = 0,
                Maximum = 100,
                TickStyle = TickStyle.None,
                BackColor = BgColor
            };

            track.ValueChanged += (_, _) =>
            {
                bar.Value = track.Value;
                bar.Text = $"{track.Value}%";
            };

            Controls.Add(bar);
            Controls.Add(track);
            _bars.Add(bar);
            _trackBars.Add(track);

            y += 88;
        }

        BuildCircularSection(y + 16);
    }

    // =========================================================
    // CIRCULAR STYLES
    // =========================================================

    private void BuildCircularSection(int top)
    {
        var title = new Label
        {
            Text = "Circular styles",
            ForeColor = LabelColor,
            AutoSize = true,
            Location = new Point(16, top),
            Font = new Font("Segoe UI", 11f, FontStyle.Bold)
        };
        Controls.Add(title);

        var specs = new (string Name, Action<HighTechProgressBar> Configure)[]
        {
            ("Ring Gradient", b =>
            {
                b.Shape = ProgressShape.Circular;
                b.RenderStyle = RenderStyle.Gradient;
                b.RingThickness = 16;
                b.GradientColor1 = Color.FromArgb(0, 220, 255);
                b.GradientColor2 = Color.FromArgb(60, 120, 255);
                b.GradientColor3 = Color.FromArgb(200, 80, 255);
            }),
            ("Ring Blocks", b =>
            {
                b.Shape = ProgressShape.Circular;
                b.RenderStyle = RenderStyle.Blocks3D;
                b.RingThickness = 16;
                b.BlockCount = 30;
                b.BlockGap = 4;
                b.BlockDepth = 6;
                b.GradientColor1 = Color.FromArgb(255, 190, 60);
                b.GradientColor2 = Color.FromArgb(255, 110, 40);
                b.GradientColor3 = Color.FromArgb(255, 60, 120);
            }),
            ("Ring Neon", b =>
            {
                b.Shape = ProgressShape.Circular;
                b.RenderStyle = RenderStyle.Neon;
                b.RingThickness = 16;
                b.GlowColor = Color.FromArgb(160, 255, 60);
                b.GlowSpread = 10;
                b.GradientColor1 = Color.FromArgb(40, 180, 60);
                b.GradientColor2 = Color.FromArgb(160, 255, 60);
                b.GradientColor3 = Color.FromArgb(0, 220, 255);
            })
        };

        int x = 16;
        foreach (var (name, configure) in specs)
        {
            var caption = new Label
            {
                Text = name,
                ForeColor = LabelColor,
                AutoSize = true,
                Location = new Point(x, top + 32),
                Font = new Font("Consolas", 9f, FontStyle.Bold)
            };
            Controls.Add(caption);

            var bar = new HighTechProgressBar
            {
                Location = new Point(x, top + 54),
                Size = new Size(150, 150),
                Maximum = 100,
                Minimum = 0,
                BorderWidth = 1,
                BorderColor = Color.FromArgb(70, 70, 85),
                BackGradientColor1 = Color.FromArgb(38, 38, 48),
                BackGradientColor2 = Color.FromArgb(55, 55, 70),
                BackGradientColor3 = Color.FromArgb(30, 30, 40),
                TextAlignment = ContentAlignment.MiddleCenter
            };
            configure(bar);
            bar.Value = 0;
            bar.Text = "0%";

            var track = new TrackBar
            {
                Location = new Point(x, top + 208),
                Size = new Size(150, 45),
                Minimum = 0,
                Maximum = 100,
                TickStyle = TickStyle.None,
                BackColor = BgColor
            };

            track.ValueChanged += (_, _) =>
            {
                bar.Value = track.Value;
                bar.Text = $"{track.Value}%";
            };

            Controls.Add(bar);
            Controls.Add(track);
            _bars.Add(bar);
            _trackBars.Add(track);

            x += 210;
        }
    }

    // =========================================================
    // RIGHT: GLOBAL EFFECT CONTROLS
    // =========================================================

    private void BuildEffectsPanel()
    {
        var panel = new Panel
        {
            Location = new Point(648, 48),
            Size = new Size(316, 710),
            BackColor = PanelColor,
            BorderStyle = BorderStyle.FixedSingle
        };
        Controls.Add(panel);

        var title = new Label
        {
            Text = "Global effects (applies to all)",
            ForeColor = LabelColor,
            AutoSize = true,
            Location = new Point(12, 10),
            Font = new Font("Segoe UI", 10f, FontStyle.Bold)
        };
        panel.Controls.Add(title);

        int y = 40;

        // Corner radius
        AddLabel(panel, "Corner radius", 12, y);
        var numRadius = new NumericUpDown
        {
            Location = new Point(170, y - 3),
            Size = new Size(70, 23),
            Minimum = 0,
            Maximum = 60,
            Value = 10
        };
        numRadius.ValueChanged += (_, _) =>
        {
            foreach (var b in _bars) b.CornerRadius = (int)numRadius.Value;
        };
        panel.Controls.Add(numRadius);
        y += 34;
        foreach (var b in _bars) b.CornerRadius = 10;

        // Shimmer
        var chkShimmer = new CheckBox
        {
            Text = "Shimmer sweep",
            ForeColor = LabelColor,
            AutoSize = true,
            Location = new Point(12, y),
            BackColor = PanelColor
        };
        chkShimmer.CheckedChanged += (_, _) =>
        {
            foreach (var b in _bars) b.ShimmerEnabled = chkShimmer.Checked;
        };
        panel.Controls.Add(chkShimmer);
        chkShimmer.Checked = true;
        y += 30;

        AddLabel(panel, "Shimmer speed", 12, y);
        var trackSpeed = AddTrack(panel, 170, y - 6, 134, 10, 200, 50);
        var lblSpeed = AddValueLabel(panel, 310, y - 4);
        trackSpeed.Scroll += (_, _) =>
        {
            lblSpeed.Text = trackSpeed.Value.ToString();
            foreach (var b in _bars) b.ShimmerSpeed = trackSpeed.Value;
        };
        trackSpeed.Value = 50;
        lblSpeed.Text = "50";
        y += 46;

        // Glow
        AddLabel(panel, "Glow spread", 12, y);
        var trackGlow = AddTrack(panel, 170, y - 6, 134, 0, 30, 8);
        var lblGlow = AddValueLabel(panel, 310, y - 4);
        trackGlow.Scroll += (_, _) =>
        {
            lblGlow.Text = trackGlow.Value.ToString();
            foreach (var b in _bars) b.GlowSpread = trackGlow.Value;
        };
        trackGlow.Value = 8;
        lblGlow.Text = "8";
        y += 46;

        var btnGlow = new Button
        {
            Text = "Glow color...",
            Location = new Point(12, y),
            Size = new Size(120, 26),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(50, 50, 62),
            ForeColor = LabelColor
        };
        btnGlow.Click += (_, _) =>
        {
            using var dlg = new ColorDialog { Color = _bars[3].GlowColor };
            if (dlg.ShowDialog(this) == DialogResult.OK)
                foreach (var b in _bars) b.GlowColor = dlg.Color;
        };
        panel.Controls.Add(btnGlow);
        y += 38;

        // Blocks
        AddLabel(panel, "Block count", 12, y);
        var trackCount = AddTrack(panel, 170, y - 6, 134, 4, 60, 24);
        var lblCount = AddValueLabel(panel, 310, y - 4);
        trackCount.Scroll += (_, _) =>
        {
            lblCount.Text = trackCount.Value.ToString();
            foreach (var b in _bars)
                if (b.RenderStyle is RenderStyle.Blocks3D or RenderStyle.Segmented)
                    b.BlockCount = trackCount.Value;
        };
        trackCount.Value = 24;
        lblCount.Text = "24";
        y += 46;

        AddLabel(panel, "Block gap", 12, y);
        var trackGap = AddTrack(panel, 170, y - 6, 134, 0, 12, 3);
        var lblGap = AddValueLabel(panel, 310, y - 4);
        trackGap.Scroll += (_, _) =>
        {
            lblGap.Text = trackGap.Value.ToString();
            foreach (var b in _bars)
                if (b.RenderStyle is RenderStyle.Blocks3D or RenderStyle.Segmented)
                    b.BlockGap = trackGap.Value;
        };
        trackGap.Value = 3;
        lblGap.Text = "3";
        y += 46;

        AddLabel(panel, "Block depth", 12, y);
        var trackDepth = AddTrack(panel, 170, y - 6, 134, 0, 20, 10);
        var lblDepth = AddValueLabel(panel, 310, y - 4);
        trackDepth.Scroll += (_, _) =>
        {
            lblDepth.Text = trackDepth.Value.ToString();
            foreach (var b in _bars)
                if (b.RenderStyle == RenderStyle.Blocks3D)
                    b.BlockDepth = trackDepth.Value;
        };
        trackDepth.Value = 10;
        lblDepth.Text = "10";
        y += 46;

        // Animation
        var chkAnim = new CheckBox
        {
            Text = "Auto animate",
            ForeColor = LabelColor,
            AutoSize = true,
            Location = new Point(12, y + 6),
            BackColor = PanelColor
        };
        chkAnim.CheckedChanged += (_, _) =>
        {
            if (chkAnim.Checked) _animTimer.Start();
            else _animTimer.Stop();
        };
        panel.Controls.Add(chkAnim);

        var btnReset = new Button
        {
            Text = "Reset values",
            Location = new Point(180, y + 2),
            Size = new Size(120, 26),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(50, 50, 62),
            ForeColor = LabelColor
        };
        btnReset.Click += (_, _) =>
        {
            _animValue = 0;
            _animDir = 1;
            foreach (var tb in _trackBars) tb.Value = 0;
        };
        panel.Controls.Add(btnReset);

        BuildVerticalSection(panel);
    }

    // =========================================================
    // VERTICAL 3D SAMPLES
    // =========================================================

    private void BuildVerticalSection(Panel panel)
    {
        var title = new Label
        {
            Text = "Vertical 3D",
            ForeColor = LabelColor,
            AutoSize = true,
            Location = new Point(12, 445),
            Font = new Font("Segoe UI", 10f, FontStyle.Bold)
        };
        panel.Controls.Add(title);

        var specs = new (string Name, Action<HighTechProgressBar> Configure)[]
        {
            ("3D Blocks", b =>
            {
                b.Orientation = Orientation.Vertical;
                b.RenderStyle = RenderStyle.Blocks3D;
                b.BlockCount = 12;
                b.BlockGap = 3;
                b.BlockDepth = 8;
                b.BlockGradientMode = BlockGradientMode.Vertical;
                b.GradientColor1 = Color.FromArgb(255, 170, 40);
                b.GradientColor2 = Color.FromArgb(255, 90, 30);
                b.GradientColor3 = Color.FromArgb(255, 200, 80);
            }),
            ("3D Segments", b =>
            {
                b.Orientation = Orientation.Vertical;
                b.RenderStyle = RenderStyle.Segmented;
                b.BlockCount = 12;
                b.BlockGap = 3;
                b.BlockCornerRadius = 10;
                b.BlockGradientMode = BlockGradientMode.Vertical;
                b.GradientColor1 = Color.FromArgb(40, 220, 120);
                b.GradientColor2 = Color.FromArgb(0, 200, 200);
                b.GradientColor3 = Color.FromArgb(40, 120, 255);
            }),
            ("Neon", b =>
            {
                b.Orientation = Orientation.Vertical;
                b.RenderStyle = RenderStyle.Neon;
                b.GlowColor = Color.FromArgb(255, 60, 200);
                b.GlowSpread = 10;
                b.GradientColor1 = Color.FromArgb(160, 0, 200);
                b.GradientColor2 = Color.FromArgb(255, 0, 160);
                b.GradientColor3 = Color.FromArgb(255, 140, 220);
            })
        };

        int x = 12;
        foreach (var (name, configure) in specs)
        {
            var caption = new Label
            {
                Text = name,
                ForeColor = LabelColor,
                AutoSize = true,
                Location = new Point(x, 468),
                Font = new Font("Consolas", 8f, FontStyle.Bold)
            };
            panel.Controls.Add(caption);

            var bar = new HighTechProgressBar
            {
                Location = new Point(x, 492),
                Size = new Size(56, 180),
                Maximum = 100,
                Minimum = 0,
                BorderWidth = 1,
                BorderColor = Color.FromArgb(70, 70, 85),
                BackGradientColor1 = Color.FromArgb(38, 38, 48),
                BackGradientColor2 = Color.FromArgb(55, 55, 70),
                BackGradientColor3 = Color.FromArgb(30, 30, 40),
                TextAlignment = ContentAlignment.MiddleCenter
            };
            configure(bar);
            bar.Value = 0;
            bar.Text = "0%";

            var track = new TrackBar
            {
                Location = new Point(x + 64, 492),
                Size = new Size(26, 180),
                Minimum = 0,
                Maximum = 100,
                TickStyle = TickStyle.None,
                BackColor = PanelColor,
                Orientation = Orientation.Vertical
            };

            track.ValueChanged += (_, _) =>
            {
                bar.Value = track.Value;
                bar.Text = $"{track.Value}%";
            };

            panel.Controls.Add(bar);
            panel.Controls.Add(track);
            _bars.Add(bar);
            _trackBars.Add(track);

            x += 102;
        }
    }

    // =========================================================
    // HELPERS
    // =========================================================

    private static void AddLabel(Control parent, string text, int x, int y)
    {
        parent.Controls.Add(new Label
        {
            Text = text,
            ForeColor = LabelColor,
            AutoSize = true,
            Location = new Point(x, y)
        });
    }

    private static TrackBar AddTrack(Control parent, int x, int y, int w,
        int min, int max, int value)
    {
        var t = new TrackBar
        {
            Location = new Point(x, y),
            Size = new Size(w, 45),
            Minimum = min,
            Maximum = max,
            Value = value,
            TickStyle = TickStyle.None,
            BackColor = PanelColor
        };
        parent.Controls.Add(t);
        return t;
    }

    private static Label AddValueLabel(Control parent, int x, int y)
    {
        var l = new Label
        {
            Text = "0",
            ForeColor = Color.FromArgb(140, 220, 255),
            AutoSize = true,
            Location = new Point(x, y),
            Font = new Font("Consolas", 9f)
        };
        parent.Controls.Add(l);
        return l;
    }

    // =========================================================
    // ANIMATION
    // =========================================================

    private void BuildAnimation()
    {
        _animTimer.Interval = 40;
        _animTimer.Tick += (_, _) =>
        {
            _animValue += _animDir * 2;
            if (_animValue >= 100) { _animValue = 100; _animDir = -1; }
            if (_animValue <= 0) { _animValue = 0; _animDir = 1; }
            foreach (var tb in _trackBars) tb.Value = _animValue;
        };
    }
}
