namespace TextProgressbar
{
    /// <summary>
    /// Visual rendering style for <see cref="HighTechProgressBar"/>.
    /// </summary>
    public enum RenderStyle
    {
        /// <summary>Smooth three-color gradient fill (original rendering).</summary>
        Gradient,

        /// <summary>Discrete blocks with a 3D beveled edge.</summary>
        Blocks3D,

        /// <summary>Discrete blocks with rounded (pill) corners.</summary>
        Segmented,

        /// <summary>Gradient fill surrounded by a neon glow.</summary>
        Neon,

        /// <summary>Horizontal stripes that scroll when shimmer is enabled.</summary>
        Striped
    }
}

/// <summary>
/// Direction of the shimmer highlight sweep.
/// </summary>
public enum ShimmerDirection
{
    LeftToRight,
    RightToLeft
}

/// <summary>
/// Gradient direction used inside individual blocks.
/// </summary>
public enum BlockGradientMode
{
    Vertical,
    Horizontal,
    Diagonal
}

/// <summary>
/// Overall geometry of the progress indicator.
/// </summary>
public enum ProgressShape
{
    /// <summary>Classic horizontal bar.</summary>
    Linear,

    /// <summary>Radial ring / donut indicator.</summary>
    Circular
}
