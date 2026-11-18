namespace TextProgressbar_Sample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelTitle = new Label();
            labelLinear = new Label();
            captionGradient = new Label();
            barGradient = new TextProgressbar.HighTechProgressBar();
            captionBlocks3D = new Label();
            barBlocks3D = new TextProgressbar.HighTechProgressBar();
            captionSegmented = new Label();
            barSegmented = new TextProgressbar.HighTechProgressBar();
            captionNeon = new Label();
            barNeon = new TextProgressbar.HighTechProgressBar();
            captionStriped = new Label();
            barStriped = new TextProgressbar.HighTechProgressBar();
            labelRings = new Label();
            captionRingGradient = new Label();
            ringGradient = new TextProgressbar.HighTechProgressBar();
            captionRingNeon = new Label();
            ringNeon = new TextProgressbar.HighTechProgressBar();
            captionRingSegmented = new Label();
            ringSegmented = new TextProgressbar.HighTechProgressBar();
            captionRingBlocks = new Label();
            ringBlocks = new TextProgressbar.HighTechProgressBar();
            labelFooter = new Label();
            labelVertical = new Label();
            captionVertBlocks = new Label();
            barVertBlocks = new TextProgressbar.HighTechProgressBar();
            captionVertSegmented = new Label();
            barVertSegmented = new TextProgressbar.HighTechProgressBar();
            captionVertNeon = new Label();
            barVertNeon = new TextProgressbar.HighTechProgressBar();
            labelDirections = new Label();
            captionDirLtr = new Label();
            barDirLtr = new TextProgressbar.HighTechProgressBar();
            captionDirRtl = new Label();
            barDirRtl = new TextProgressbar.HighTechProgressBar();
            captionDirTtb = new Label();
            barDirTtb = new TextProgressbar.HighTechProgressBar();
            captionDirDiag = new Label();
            barDirDiag = new TextProgressbar.HighTechProgressBar();
            animationTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(140, 220, 255);
            labelTitle.Location = new Point(16, 12);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(476, 25);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "HighTechProgressBar - round, high tech and regular";
            // 
            // labelLinear
            // 
            labelLinear.AutoSize = true;
            labelLinear.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelLinear.ForeColor = Color.FromArgb(220, 220, 230);
            labelLinear.Location = new Point(16, 50);
            labelLinear.Name = "labelLinear";
            labelLinear.Size = new Size(208, 19);
            labelLinear.TabIndex = 1;
            labelLinear.Text = "Regular / linear bar examples";
            // 
            // captionGradient
            // 
            captionGradient.AutoSize = true;
            captionGradient.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionGradient.ForeColor = Color.FromArgb(220, 220, 230);
            captionGradient.Location = new Point(16, 81);
            captionGradient.Name = "captionGradient";
            captionGradient.Size = new Size(133, 14);
            captionGradient.TabIndex = 2;
            captionGradient.Text = "Gradient (regular)";
            // 
            // barGradient
            // 
            barGradient.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barGradient.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barGradient.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barGradient.CornerRadius = 10;
            barGradient.GlowColor = Color.FromArgb(0, 255, 255);
            barGradient.GradientColor1 = Color.Silver;
            barGradient.GradientColor2 = Color.Black;
            barGradient.GradientColor3 = Color.Silver;
            barGradient.GradientMode = TextProgressbar.GradientMode.TopToBottom;
            barGradient.Location = new Point(180, 74);
            barGradient.Name = "barGradient";
            barGradient.Size = new Size(480, 28);
            barGradient.TabIndex = 3;
            barGradient.Text = "50%";
            barGradient.Value = 50;
            // 
            // captionBlocks3D
            // 
            captionBlocks3D.AutoSize = true;
            captionBlocks3D.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionBlocks3D.ForeColor = Color.FromArgb(220, 220, 230);
            captionBlocks3D.Location = new Point(16, 129);
            captionBlocks3D.Name = "captionBlocks3D";
            captionBlocks3D.Size = new Size(98, 14);
            captionBlocks3D.TabIndex = 4;
            captionBlocks3D.Text = "Blocks3D (3D)";
            // 
            // barBlocks3D
            // 
            barBlocks3D.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barBlocks3D.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barBlocks3D.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barBlocks3D.BlockCount = 26;
            barBlocks3D.BlockDepth = 10;
            barBlocks3D.BlockGap = 4;
            barBlocks3D.CornerRadius = 10;
            barBlocks3D.GlowColor = Color.FromArgb(0, 255, 255);
            barBlocks3D.GradientColor1 = Color.Cyan;
            barBlocks3D.GradientColor2 = Color.Blue;
            barBlocks3D.GradientColor3 = Color.FromArgb(192, 255, 255);
            barBlocks3D.GradientMode = TextProgressbar.GradientMode.TopToBottom;
            barBlocks3D.Location = new Point(180, 122);
            barBlocks3D.Name = "barBlocks3D";
            barBlocks3D.RenderStyle = TextProgressbar.RenderStyle.Blocks3D;
            barBlocks3D.Size = new Size(480, 28);
            barBlocks3D.TabIndex = 5;
            barBlocks3D.Text = "30%";
            barBlocks3D.Value = 30;
            // 
            // captionSegmented
            // 
            captionSegmented.AutoSize = true;
            captionSegmented.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionSegmented.ForeColor = Color.FromArgb(220, 220, 230);
            captionSegmented.Location = new Point(16, 177);
            captionSegmented.Name = "captionSegmented";
            captionSegmented.Size = new Size(126, 14);
            captionSegmented.TabIndex = 6;
            captionSegmented.Text = "Segmented (pills)";
            // 
            // barSegmented
            // 
            barSegmented.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barSegmented.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barSegmented.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barSegmented.BlockCornerRadius = 9;
            barSegmented.BlockCount = 30;
            barSegmented.CornerRadius = 10;
            barSegmented.GlowColor = Color.FromArgb(0, 255, 255);
            barSegmented.GradientColor1 = Color.FromArgb(0, 200, 120);
            barSegmented.GradientColor2 = Color.FromArgb(0, 230, 200);
            barSegmented.GradientColor3 = Color.FromArgb(40, 160, 255);
            barSegmented.Location = new Point(180, 170);
            barSegmented.Name = "barSegmented";
            barSegmented.RenderStyle = TextProgressbar.RenderStyle.Segmented;
            barSegmented.Size = new Size(480, 28);
            barSegmented.TabIndex = 7;
            barSegmented.Text = "40%";
            barSegmented.Value = 40;
            // 
            // captionNeon
            // 
            captionNeon.AutoSize = true;
            captionNeon.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionNeon.ForeColor = Color.FromArgb(220, 220, 230);
            captionNeon.Location = new Point(16, 225);
            captionNeon.Name = "captionNeon";
            captionNeon.Size = new Size(119, 14);
            captionNeon.TabIndex = 8;
            captionNeon.Text = "Neon (high tech)";
            // 
            // barNeon
            // 
            barNeon.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barNeon.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barNeon.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barNeon.CornerRadius = 10;
            barNeon.GlowColor = Color.FromArgb(255, 80, 220);
            barNeon.GlowSpread = 12;
            barNeon.GradientColor1 = Color.FromArgb(120, 0, 200);
            barNeon.GradientColor2 = Color.FromArgb(255, 0, 180);
            barNeon.GradientColor3 = Color.FromArgb(255, 120, 240);
            barNeon.Location = new Point(180, 218);
            barNeon.Name = "barNeon";
            barNeon.RenderStyle = TextProgressbar.RenderStyle.Neon;
            barNeon.ShimmerEnabled = true;
            barNeon.Size = new Size(480, 28);
            barNeon.TabIndex = 9;
            barNeon.Text = "60%";
            barNeon.Value = 60;
            // 
            // captionStriped
            // 
            captionStriped.AutoSize = true;
            captionStriped.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionStriped.ForeColor = Color.FromArgb(220, 220, 230);
            captionStriped.Location = new Point(16, 273);
            captionStriped.Name = "captionStriped";
            captionStriped.Size = new Size(140, 14);
            captionStriped.TabIndex = 10;
            captionStriped.Text = "Striped (high tech)";
            // 
            // barStriped
            // 
            barStriped.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barStriped.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barStriped.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barStriped.CornerRadius = 10;
            barStriped.GlowColor = Color.FromArgb(0, 255, 255);
            barStriped.GradientColor1 = Color.FromArgb(0, 180, 255);
            barStriped.GradientColor2 = Color.FromArgb(0, 90, 200);
            barStriped.GradientColor3 = Color.FromArgb(120, 255, 255);
            barStriped.Location = new Point(180, 266);
            barStriped.Name = "barStriped";
            barStriped.RenderStyle = TextProgressbar.RenderStyle.Striped;
            barStriped.ShimmerEnabled = true;
            barStriped.Size = new Size(480, 28);
            barStriped.TabIndex = 11;
            barStriped.Text = "70%";
            barStriped.Value = 70;
            // 
            // labelRings
            // 
            labelRings.AutoSize = true;
            labelRings.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelRings.ForeColor = Color.FromArgb(220, 220, 230);
            labelRings.Location = new Point(16, 312);
            labelRings.Name = "labelRings";
            labelRings.Size = new Size(151, 19);
            labelRings.TabIndex = 12;
            labelRings.Text = "Round ring examples";
            // 
            // captionRingGradient
            // 
            captionRingGradient.AutoSize = true;
            captionRingGradient.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionRingGradient.ForeColor = Color.FromArgb(220, 220, 230);
            captionRingGradient.Location = new Point(16, 342);
            captionRingGradient.Name = "captionRingGradient";
            captionRingGradient.Size = new Size(98, 14);
            captionRingGradient.TabIndex = 13;
            captionRingGradient.Text = "Ring gradient";
            // 
            // ringGradient
            // 
            ringGradient.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            ringGradient.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            ringGradient.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            ringGradient.GlowColor = Color.FromArgb(0, 255, 255);
            ringGradient.GradientColor1 = Color.FromArgb(0, 220, 255);
            ringGradient.GradientColor2 = Color.FromArgb(60, 120, 255);
            ringGradient.GradientColor3 = Color.FromArgb(200, 80, 255);
            ringGradient.Location = new Point(16, 364);
            ringGradient.Name = "ringGradient";
            ringGradient.RingThickness = 16;
            ringGradient.Shape = ProgressShape.Circular;
            ringGradient.Size = new Size(150, 150);
            ringGradient.TabIndex = 14;
            ringGradient.Text = "25%";
            ringGradient.Value = 25;
            // 
            // captionRingNeon
            // 
            captionRingNeon.AutoSize = true;
            captionRingNeon.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionRingNeon.ForeColor = Color.FromArgb(220, 220, 230);
            captionRingNeon.Location = new Point(186, 342);
            captionRingNeon.Name = "captionRingNeon";
            captionRingNeon.Size = new Size(70, 14);
            captionRingNeon.TabIndex = 15;
            captionRingNeon.Text = "Ring neon";
            // 
            // ringNeon
            // 
            ringNeon.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            ringNeon.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            ringNeon.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            ringNeon.GlowColor = Color.FromArgb(160, 255, 60);
            ringNeon.GlowSpread = 10;
            ringNeon.GradientColor1 = Color.FromArgb(40, 180, 60);
            ringNeon.GradientColor2 = Color.FromArgb(160, 255, 60);
            ringNeon.GradientColor3 = Color.FromArgb(0, 220, 255);
            ringNeon.Location = new Point(186, 364);
            ringNeon.Name = "ringNeon";
            ringNeon.RenderStyle = TextProgressbar.RenderStyle.Neon;
            ringNeon.RingThickness = 16;
            ringNeon.Shape = ProgressShape.Circular;
            ringNeon.Size = new Size(150, 150);
            ringNeon.TabIndex = 16;
            ringNeon.Text = "50%";
            ringNeon.Value = 50;
            // 
            // captionRingSegmented
            // 
            captionRingSegmented.AutoSize = true;
            captionRingSegmented.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionRingSegmented.ForeColor = Color.FromArgb(220, 220, 230);
            captionRingSegmented.Location = new Point(356, 342);
            captionRingSegmented.Name = "captionRingSegmented";
            captionRingSegmented.Size = new Size(105, 14);
            captionRingSegmented.TabIndex = 17;
            captionRingSegmented.Text = "Ring segmented";
            // 
            // ringSegmented
            // 
            ringSegmented.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            ringSegmented.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            ringSegmented.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            ringSegmented.BlockCount = 30;
            ringSegmented.BlockGap = 4;
            ringSegmented.Clockwise = false;
            ringSegmented.GlowColor = Color.FromArgb(0, 255, 255);
            ringSegmented.GradientColor1 = Color.FromArgb(0, 200, 120);
            ringSegmented.GradientColor2 = Color.FromArgb(0, 230, 200);
            ringSegmented.GradientColor3 = Color.FromArgb(40, 160, 255);
            ringSegmented.Location = new Point(356, 364);
            ringSegmented.Name = "ringSegmented";
            ringSegmented.RenderStyle = TextProgressbar.RenderStyle.Segmented;
            ringSegmented.RingThickness = 18;
            ringSegmented.Shape = ProgressShape.Circular;
            ringSegmented.Size = new Size(150, 150);
            ringSegmented.TabIndex = 18;
            ringSegmented.Text = "70%";
            ringSegmented.Value = 70;
            // 
            // captionRingBlocks
            // 
            captionRingBlocks.AutoSize = true;
            captionRingBlocks.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionRingBlocks.ForeColor = Color.FromArgb(220, 220, 230);
            captionRingBlocks.Location = new Point(526, 342);
            captionRingBlocks.Name = "captionRingBlocks";
            captionRingBlocks.Size = new Size(105, 14);
            captionRingBlocks.TabIndex = 19;
            captionRingBlocks.Text = "Ring 3D blocks";
            // 
            // ringBlocks
            // 
            ringBlocks.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            ringBlocks.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            ringBlocks.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            ringBlocks.BlockCount = 30;
            ringBlocks.BlockDepth = 6;
            ringBlocks.BlockGap = 4;
            ringBlocks.GlowColor = Color.FromArgb(0, 255, 255);
            ringBlocks.GradientColor1 = Color.FromArgb(255, 190, 60);
            ringBlocks.GradientColor2 = Color.FromArgb(255, 110, 40);
            ringBlocks.GradientColor3 = Color.FromArgb(255, 60, 120);
            ringBlocks.Location = new Point(526, 364);
            ringBlocks.Name = "ringBlocks";
            ringBlocks.RenderStyle = TextProgressbar.RenderStyle.Blocks3D;
            ringBlocks.RingThickness = 16;
            ringBlocks.Shape = ProgressShape.Circular;
            ringBlocks.Size = new Size(150, 150);
            ringBlocks.TabIndex = 20;
            ringBlocks.Text = "80%";
            ringBlocks.Value = 80;
            // 
            // labelFooter
            // 
            labelFooter.AutoSize = true;
            labelFooter.ForeColor = Color.FromArgb(150, 150, 165);
            labelFooter.Location = new Point(16, 792);
            labelFooter.Name = "labelFooter";
            labelFooter.Size = new Size(373, 15);
            labelFooter.TabIndex = 27;
            labelFooter.Text = "Values animate on their own - every bar can be edited in the designer.";
            // 
            // labelVertical
            // 
            labelVertical.AutoSize = true;
            labelVertical.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelVertical.ForeColor = Color.FromArgb(220, 220, 230);
            labelVertical.Location = new Point(16, 548);
            labelVertical.Name = "labelVertical";
            labelVertical.Size = new Size(154, 19);
            labelVertical.TabIndex = 22;
            labelVertical.Text = "Vertical bar examples";
            // 
            // captionVertBlocks
            // 
            captionVertBlocks.AutoSize = true;
            captionVertBlocks.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionVertBlocks.ForeColor = Color.FromArgb(220, 220, 230);
            captionVertBlocks.Location = new Point(16, 578);
            captionVertBlocks.Name = "captionVertBlocks";
            captionVertBlocks.Size = new Size(70, 14);
            captionVertBlocks.TabIndex = 23;
            captionVertBlocks.Text = "3D blocks";
            // 
            // barVertBlocks
            // 
            barVertBlocks.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barVertBlocks.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barVertBlocks.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barVertBlocks.BlockCount = 12;
            barVertBlocks.CornerRadius = 10;
            barVertBlocks.GlowColor = Color.FromArgb(0, 255, 255);
            barVertBlocks.GradientColor1 = Color.FromArgb(255, 170, 40);
            barVertBlocks.GradientColor2 = Color.FromArgb(255, 90, 30);
            barVertBlocks.GradientColor3 = Color.FromArgb(255, 200, 80);
            barVertBlocks.Location = new Point(16, 598);
            barVertBlocks.Name = "barVertBlocks";
            barVertBlocks.Orientation = Orientation.Vertical;
            barVertBlocks.RenderStyle = TextProgressbar.RenderStyle.Blocks3D;
            barVertBlocks.Size = new Size(56, 180);
            barVertBlocks.TabIndex = 24;
            barVertBlocks.Text = "20%";
            barVertBlocks.Value = 20;
            // 
            // captionVertSegmented
            // 
            captionVertSegmented.AutoSize = true;
            captionVertSegmented.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionVertSegmented.ForeColor = Color.FromArgb(220, 220, 230);
            captionVertSegmented.Location = new Point(106, 578);
            captionVertSegmented.Name = "captionVertSegmented";
            captionVertSegmented.Size = new Size(63, 14);
            captionVertSegmented.TabIndex = 25;
            captionVertSegmented.Text = "Segments";
            // 
            // barVertSegmented
            // 
            barVertSegmented.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barVertSegmented.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barVertSegmented.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barVertSegmented.BlockCornerRadius = 10;
            barVertSegmented.BlockCount = 12;
            barVertSegmented.CornerRadius = 10;
            barVertSegmented.GlowColor = Color.FromArgb(0, 255, 255);
            barVertSegmented.GradientColor1 = Color.FromArgb(40, 220, 120);
            barVertSegmented.GradientColor2 = Color.FromArgb(0, 200, 200);
            barVertSegmented.GradientColor3 = Color.FromArgb(40, 120, 255);
            barVertSegmented.Location = new Point(106, 598);
            barVertSegmented.Name = "barVertSegmented";
            barVertSegmented.Orientation = Orientation.Vertical;
            barVertSegmented.RenderStyle = TextProgressbar.RenderStyle.Segmented;
            barVertSegmented.Size = new Size(56, 180);
            barVertSegmented.TabIndex = 26;
            barVertSegmented.Text = "40%";
            barVertSegmented.Value = 40;
            // 
            // captionVertNeon
            // 
            captionVertNeon.AutoSize = true;
            captionVertNeon.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionVertNeon.ForeColor = Color.FromArgb(220, 220, 230);
            captionVertNeon.Location = new Point(196, 578);
            captionVertNeon.Name = "captionVertNeon";
            captionVertNeon.Size = new Size(35, 14);
            captionVertNeon.TabIndex = 28;
            captionVertNeon.Text = "Neon";
            // 
            // barVertNeon
            // 
            barVertNeon.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barVertNeon.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barVertNeon.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barVertNeon.CornerRadius = 10;
            barVertNeon.GlowColor = Color.FromArgb(255, 60, 200);
            barVertNeon.GlowSpread = 10;
            barVertNeon.GradientColor1 = Color.FromArgb(160, 0, 200);
            barVertNeon.GradientColor2 = Color.FromArgb(255, 0, 160);
            barVertNeon.GradientColor3 = Color.FromArgb(255, 140, 220);
            barVertNeon.Location = new Point(196, 598);
            barVertNeon.Name = "barVertNeon";
            barVertNeon.Orientation = Orientation.Vertical;
            barVertNeon.RenderStyle = TextProgressbar.RenderStyle.Neon;
            barVertNeon.ShimmerEnabled = true;
            barVertNeon.Size = new Size(56, 180);
            barVertNeon.TabIndex = 29;
            barVertNeon.Text = "70%";
            barVertNeon.Value = 70;
            // 
            // labelDirections
            // 
            labelDirections.AutoSize = true;
            labelDirections.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelDirections.ForeColor = Color.FromArgb(220, 220, 230);
            labelDirections.Location = new Point(300, 548);
            labelDirections.Name = "labelDirections";
            labelDirections.Size = new Size(149, 19);
            labelDirections.TabIndex = 30;
            labelDirections.Text = "Directional gradients";
            // 
            // captionDirLtr
            // 
            captionDirLtr.AutoSize = true;
            captionDirLtr.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionDirLtr.ForeColor = Color.FromArgb(220, 220, 230);
            captionDirLtr.Location = new Point(300, 578);
            captionDirLtr.Name = "captionDirLtr";
            captionDirLtr.Size = new Size(98, 14);
            captionDirLtr.TabIndex = 31;
            captionDirLtr.Text = "Left to right";
            // 
            // barDirLtr
            // 
            barDirLtr.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barDirLtr.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barDirLtr.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barDirLtr.CornerRadius = 10;
            barDirLtr.GlowColor = Color.FromArgb(0, 255, 255);
            barDirLtr.GradientColor1 = Color.FromArgb(0, 150, 255);
            barDirLtr.GradientColor2 = Color.FromArgb(150, 0, 255);
            barDirLtr.GradientColor3 = Color.FromArgb(0, 230, 190);
            barDirLtr.Location = new Point(300, 596);
            barDirLtr.Name = "barDirLtr";
            barDirLtr.Size = new Size(430, 26);
            barDirLtr.TabIndex = 32;
            barDirLtr.Text = "25%";
            barDirLtr.Value = 25;
            // 
            // captionDirRtl
            // 
            captionDirRtl.AutoSize = true;
            captionDirRtl.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionDirRtl.ForeColor = Color.FromArgb(220, 220, 230);
            captionDirRtl.Location = new Point(300, 632);
            captionDirRtl.Name = "captionDirRtl";
            captionDirRtl.Size = new Size(98, 14);
            captionDirRtl.TabIndex = 33;
            captionDirRtl.Text = "Right to left";
            // 
            // barDirRtl
            // 
            barDirRtl.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barDirRtl.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barDirRtl.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barDirRtl.CornerRadius = 10;
            barDirRtl.GlowColor = Color.FromArgb(0, 255, 255);
            barDirRtl.GradientColor1 = Color.FromArgb(0, 150, 255);
            barDirRtl.GradientColor2 = Color.FromArgb(150, 0, 255);
            barDirRtl.GradientColor3 = Color.FromArgb(0, 230, 190);
            barDirRtl.GradientMode = TextProgressbar.GradientMode.RightToLeft;
            barDirRtl.Location = new Point(300, 650);
            barDirRtl.Name = "barDirRtl";
            barDirRtl.Size = new Size(430, 26);
            barDirRtl.TabIndex = 34;
            barDirRtl.Text = "35%";
            barDirRtl.Value = 35;
            // 
            // captionDirTtb
            // 
            captionDirTtb.AutoSize = true;
            captionDirTtb.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionDirTtb.ForeColor = Color.FromArgb(220, 220, 230);
            captionDirTtb.Location = new Point(300, 686);
            captionDirTtb.Name = "captionDirTtb";
            captionDirTtb.Size = new Size(98, 14);
            captionDirTtb.TabIndex = 35;
            captionDirTtb.Text = "Top to bottom";
            // 
            // barDirTtb
            // 
            barDirTtb.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barDirTtb.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barDirTtb.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barDirTtb.CornerRadius = 10;
            barDirTtb.GlowColor = Color.FromArgb(0, 255, 255);
            barDirTtb.GradientColor1 = Color.FromArgb(255, 200, 60);
            barDirTtb.GradientColor2 = Color.FromArgb(255, 110, 40);
            barDirTtb.GradientColor3 = Color.FromArgb(255, 60, 120);
            barDirTtb.GradientMode = TextProgressbar.GradientMode.TopToBottom;
            barDirTtb.Location = new Point(300, 704);
            barDirTtb.Name = "barDirTtb";
            barDirTtb.Size = new Size(430, 26);
            barDirTtb.TabIndex = 36;
            barDirTtb.Text = "45%";
            barDirTtb.Value = 45;
            // 
            // captionDirDiag
            // 
            captionDirDiag.AutoSize = true;
            captionDirDiag.Font = new Font("Consolas", 9F, FontStyle.Bold);
            captionDirDiag.ForeColor = Color.FromArgb(220, 220, 230);
            captionDirDiag.Location = new Point(300, 740);
            captionDirDiag.Name = "captionDirDiag";
            captionDirDiag.Size = new Size(84, 14);
            captionDirDiag.TabIndex = 37;
            captionDirDiag.Text = "Diagonal up";
            // 
            // barDirDiag
            // 
            barDirDiag.BackGradientColor1 = Color.FromArgb(35, 35, 45);
            barDirDiag.BackGradientColor2 = Color.FromArgb(55, 55, 70);
            barDirDiag.BackGradientColor3 = Color.FromArgb(25, 25, 32);
            barDirDiag.CornerRadius = 10;
            barDirDiag.GlowColor = Color.FromArgb(0, 255, 255);
            barDirDiag.GradientColor1 = Color.FromArgb(40, 220, 120);
            barDirDiag.GradientColor2 = Color.FromArgb(0, 200, 220);
            barDirDiag.GradientColor3 = Color.FromArgb(40, 120, 255);
            barDirDiag.GradientMode = TextProgressbar.GradientMode.DiagonalUp;
            barDirDiag.Location = new Point(300, 758);
            barDirDiag.Name = "barDirDiag";
            barDirDiag.Size = new Size(430, 26);
            barDirDiag.TabIndex = 38;
            barDirDiag.Text = "60%";
            barDirDiag.Value = 60;
            // 
            // animationTimer
            // 
            animationTimer.Enabled = true;
            animationTimer.Interval = 600;
            animationTimer.Tick += animationTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 22, 28);
            ClientSize = new Size(780, 820);
            Controls.Add(labelDirections);
            Controls.Add(captionDirLtr);
            Controls.Add(barDirLtr);
            Controls.Add(captionDirRtl);
            Controls.Add(barDirRtl);
            Controls.Add(captionDirTtb);
            Controls.Add(barDirTtb);
            Controls.Add(captionDirDiag);
            Controls.Add(barDirDiag);
            Controls.Add(labelVertical);
            Controls.Add(captionVertBlocks);
            Controls.Add(barVertBlocks);
            Controls.Add(captionVertSegmented);
            Controls.Add(barVertSegmented);
            Controls.Add(captionVertNeon);
            Controls.Add(barVertNeon);
            Controls.Add(labelFooter);
            Controls.Add(captionRingBlocks);
            Controls.Add(ringBlocks);
            Controls.Add(captionRingSegmented);
            Controls.Add(ringSegmented);
            Controls.Add(captionRingNeon);
            Controls.Add(ringNeon);
            Controls.Add(captionRingGradient);
            Controls.Add(ringGradient);
            Controls.Add(labelRings);
            Controls.Add(captionStriped);
            Controls.Add(barStriped);
            Controls.Add(captionNeon);
            Controls.Add(barNeon);
            Controls.Add(captionSegmented);
            Controls.Add(barSegmented);
            Controls.Add(captionBlocks3D);
            Controls.Add(barBlocks3D);
            Controls.Add(captionGradient);
            Controls.Add(barGradient);
            Controls.Add(labelLinear);
            Controls.Add(labelTitle);
            ForeColor = Color.FromArgb(220, 220, 230);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HighTechProgressBar - examples";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelLinear;
        private Label captionGradient;
        private Label captionBlocks3D;
        private Label captionSegmented;
        private Label captionNeon;
        private Label captionStriped;
        private Label labelRings;
        private Label captionRingGradient;
        private Label captionRingNeon;
        private Label captionRingSegmented;
        private Label captionRingBlocks;
        private Label labelFooter;
        private Label labelVertical;
        private Label captionVertBlocks;
        private Label captionVertSegmented;
        private Label captionVertNeon;
        private System.Windows.Forms.Timer animationTimer;
        private TextProgressbar.HighTechProgressBar barGradient;
        private TextProgressbar.HighTechProgressBar barBlocks3D;
        private TextProgressbar.HighTechProgressBar barSegmented;
        private TextProgressbar.HighTechProgressBar barNeon;
        private TextProgressbar.HighTechProgressBar barStriped;
        private TextProgressbar.HighTechProgressBar ringGradient;
        private TextProgressbar.HighTechProgressBar ringNeon;
        private TextProgressbar.HighTechProgressBar ringSegmented;
        private TextProgressbar.HighTechProgressBar ringBlocks;
        private TextProgressbar.HighTechProgressBar barVertBlocks;
        private TextProgressbar.HighTechProgressBar barVertSegmented;
        private TextProgressbar.HighTechProgressBar barVertNeon;
        private Label labelDirections;
        private Label captionDirLtr;
        private Label captionDirRtl;
        private Label captionDirTtb;
        private Label captionDirDiag;
        private TextProgressbar.HighTechProgressBar barDirLtr;
        private TextProgressbar.HighTechProgressBar barDirRtl;
        private TextProgressbar.HighTechProgressBar barDirTtb;
        private TextProgressbar.HighTechProgressBar barDirDiag;
    }
}
