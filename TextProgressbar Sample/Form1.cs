namespace TextProgressbar_Sample
{
    public partial class Form1 : Form
    {
        private sealed class BarState
        {
            public int Value;
            public int Step;
        }

        private readonly Random _random = new();
        private readonly List<TextProgressbar.HighTechProgressBar> _bars = new();
        private readonly Dictionary<TextProgressbar.HighTechProgressBar, BarState> _states = new();

        public Form1()
        {
            InitializeComponent();

            _bars.AddRange(new[]
            {
                barGradient, barBlocks3D, barSegmented, barNeon, barStriped,
                ringGradient, ringNeon, ringSegmented, ringBlocks,
                barVertBlocks, barVertSegmented, barVertNeon,
                barDirLtr, barDirRtl, barDirTtb, barDirDiag
            });

            // Give every bar its own random starting value and speed.
            foreach (TextProgressbar.HighTechProgressBar bar in _bars)
            {
                int value = _random.Next(0, 101);
                int step = _random.Next(2, 7) * (_random.Next(2) == 0 ? 1 : -1);

                _states[bar] = new BarState { Value = value, Step = step };

                // The control writes its own "42%" text on every value change.
                bar.Value = value;
            }
        }

        private void animationTimer_Tick(object? sender, EventArgs e)
        {
            foreach (TextProgressbar.HighTechProgressBar bar in _bars)
            {
                BarState state = _states[bar];

                // Random nudge each tick so no two bars move in step.
                state.Value += state.Step + _random.Next(-1, 2);

                if (state.Value >= 100)
                {
                    state.Value = 100;
                    state.Step = -Math.Abs(state.Step);
                }
                else if (state.Value <= 0)
                {
                    state.Value = 0;
                    state.Step = Math.Abs(state.Step);
                }

                bar.Value = state.Value;
            }
        }
    }
}
