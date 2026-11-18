# TextProgressbar

[![Support this project on Ko-fi](https://img.shields.io/badge/Ko--fi-Support-FF5E5B?logo=ko-fi&logoColor=white)](https://ko-fi.com/dwainhsnickles)
[![Donate on PayPal](https://img.shields.io/badge/PayPal-Donate-003087?logo=paypal&logoColor=white)](https://paypal.me/YTDPlatinum)

![HighTechProgressBar demo](preview.gif)

A custom WinForms `ProgressBar` control — now named **`HighTechProgressBar`** — with gradient rendering, border styling, text display, multiple render styles, and circular ring mode.

## Shapes

Set `Shape` to choose the geometry:

- `ProgressShape.Linear` — bar (default)
- `ProgressShape.Circular` — radial ring / donut indicator with `RingThickness`, `StartAngle`, `Clockwise`, and `RoundCaps`

Set `Orientation` to `Orientation.Vertical` for bottom-up vertical bars — blocks stack vertically, stripes become horizontal bands, and the shimmer sweeps upward.

In circular mode the track ring is always drawn; the progress sweep supports all `RenderStyle` values, including segmented ring blocks, neon glow, and a rotating shimmer wedge.

## Render styles

Set the `RenderStyle` property to choose how the progress fill is drawn:

| Style | Description |
|---|---|
| `Gradient` | Smooth three-color gradient fill |
| `Blocks3D` | Discrete blocks with a beveled 3D edge (`BlockDepth`, `BlockGap`, `BlockCount`) |
| `Segmented` | Rounded pill-style blocks (`BlockCornerRadius`) |
| `Neon` | Gradient fill with an outer glow (`GlowColor`, `GlowSpread`) |
| `Striped` | Scrolling stripes / dashes (pairs with shimmer) |

## Effects

- `CornerRadius` — rounds the bar, progress fill, and border (linear mode).
- `ShimmerEnabled` / `ShimmerSpeed` / `ShimmerColor` / `ShimmerDirection` — animated light sweep (linear) or rotating highlight wedge (circular), on a `Timer` that only runs while the control is visible.
- `BlockGradientMode` — per-block gradient direction (`Vertical`, `Horizontal`, `Diagonal`).

## Sample app

`TextProgressbar Sample` is a WinForms demo form whose bars are placed in the designer, so every style can be poked at from the property grid:

```
dotnet run --project "TextProgressbar Sample"
```

It shows the linear styles, the circular rings, vertical bars and the `GradientMode` directions.

## Credit

This project is based on / forked from [taancer/aProgressBar](https://github.com/taancer/aProgressBar) — *C# ProgressBar with Text*.

## Support

If this project saved you some time, you can leave a tip at
[ko-fi.com/dwainhsnickles](https://ko-fi.com/dwainhsnickles) (cards, no account needed) or
[paypal.me/YTDPlatinum](https://paypal.me/YTDPlatinum). Bug reports and pull requests are welcome too.
