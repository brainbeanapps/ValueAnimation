using System;
using System.Linq;
using Gtk;
using Gdk;
using BrainbeanApps.ValueAnimation;

public partial class MainWindow: Gtk.Window
{
    public const float Scale = 0.75f;
    public const int ValueSteps = 200;
    public const int VerticalSpacing = 48;
    public const int HorizontalSpacing = 16;
    public const int AnimationAreaWidth = (int)(Scale * 160);
    public const int AnimationAreaHeight = (int)(Scale * 120);
    public const int TitleFontSize = (int)(Scale * 16);

    private struct Value<T>
    {
        public T x;
        public T y;
    }

    private class Animation
    {
        public ValueAnimation<float> ValueAnimation { get; set; }
        public string Title { get; set; }
        public Value<float>[] Values { get; set; }
    }

    private Animation[] animations;

    public MainWindow()
        : base(Gtk.WindowType.Toplevel)
    {
        Build();

        animations = new Animation[] {
            ConstructAnimation(ValueAnimations.Linear<float>(), "linear"),

            ConstructAnimation(ValueAnimations.EaseInCircular<float>(), "circular-in"),
            ConstructAnimation(ValueAnimations.EaseOutCircular<float>(), "circular-out"),
            ConstructAnimation(ValueAnimations.EaseInOutCircular<float>(), "circular-in-out"),
            ConstructAnimation(ValueAnimations.EaseOutInCircular<float>(), "circular-out-in"),

            ConstructAnimation(ValueAnimations.EaseInExponential<float>(), "exponential-in"),
            ConstructAnimation(ValueAnimations.EaseOutExponential<float>(), "exponential-out"),
            ConstructAnimation(ValueAnimations.EaseInOutExponential<float>(), "exponential-in-out"),
            ConstructAnimation(ValueAnimations.EaseOutInExponential<float>(), "exponential-out-in"),

            ConstructAnimation(ValueAnimations.EaseInSinusoidal<float>(), "sinusoidal-in"),
            ConstructAnimation(ValueAnimations.EaseOutSinusoidal<float>(), "sinusoidal-out"),
            ConstructAnimation(ValueAnimations.EaseInOutSinusoidal<float>(), "sinusoidal-in-out"),
            ConstructAnimation(ValueAnimations.EaseOutInSinusoidal<float>(), "sinusoidal-out-in"),

            ConstructAnimation(ValueAnimations.EaseInQuadratic<float>(), "quadratic-in"),
            ConstructAnimation(ValueAnimations.EaseOutQuadratic<float>(), "quadratic-out"),
            ConstructAnimation(ValueAnimations.EaseInOutQuadratic<float>(), "quadratic-in-out"),
            ConstructAnimation(ValueAnimations.EaseOutInQuadratic<float>(), "quadratic-out-in"),

            ConstructAnimation(ValueAnimations.EaseInCubic<float>(), "cubic-in"),
            ConstructAnimation(ValueAnimations.EaseOutCubic<float>(), "cubic-out"),
            ConstructAnimation(ValueAnimations.EaseInOutCubic<float>(), "cubic-in-out"),
            ConstructAnimation(ValueAnimations.EaseOutInCubic<float>(), "cubic-out-in"),

            ConstructAnimation(ValueAnimations.EaseInQuartic<float>(), "quartic-in"),
            ConstructAnimation(ValueAnimations.EaseOutQuartic<float>(), "quartic-out"),
            ConstructAnimation(ValueAnimations.EaseInOutQuartic<float>(), "quartic-in-out"),
            ConstructAnimation(ValueAnimations.EaseOutInQuartic<float>(), "quartic-out-in"),

            ConstructAnimation(ValueAnimations.EaseInQuintic<float>(), "quintic-in"),
            ConstructAnimation(ValueAnimations.EaseOutQuintic<float>(), "quintic-out"),
            ConstructAnimation(ValueAnimations.EaseInOutQuintic<float>(), "quintic-in-out"),
            ConstructAnimation(ValueAnimations.EaseOutInQuintic<float>(), "quintic-out-in"),

            ConstructAnimation(ValueAnimations.EaseInElastic<float>(), "elastic-in"),
            ConstructAnimation(ValueAnimations.EaseOutElastic<float>(), "elastic-out"),
            ConstructAnimation(ValueAnimations.EaseInOutElastic<float>(), "elastic-in-out"),
            ConstructAnimation(ValueAnimations.EaseOutInElastic<float>(), "elastic-out-in")
        };

        drawingArea.ExposeEvent += DrawingArea_ExposeEvent;
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
        
    void DrawingArea_ExposeEvent(object o, ExposeEventArgs args)
    {
        DrawAnimations(drawingArea);
    }

    static Animation ConstructAnimation(ValueAnimation<float> valueAnimation, string title)
    {
        var animation = new Animation();
        animation.ValueAnimation = valueAnimation;
        animation.Title = title;
        animation.Values = new Value<float>[ValueSteps];

        var valueStep = 1.0f / (ValueSteps - 1);
        for (var stepIdx = 0; stepIdx < ValueSteps; stepIdx++)
        {
            animation.Values[stepIdx] = new Value<float>() { 
                x = valueStep * stepIdx,
                y = valueAnimation(valueStep * stepIdx, 1.0f, 0.0f, 1.0f)
            };
        }

        return animation;
    }

    void DrawAnimations(Gtk.Widget gtkWidget)
    {
        var gdkWindow = gtkWidget.GdkWindow;
        var pangoContext = gtkWidget.CreatePangoContext();

        int width;
        int height;
        gdkWindow.GetSize(out width, out height);

        if (width <= 0 || height <= 0)
            return;

        var cols = width / (AnimationAreaWidth + HorizontalSpacing / 2);
        var rows = height / (AnimationAreaHeight + VerticalSpacing / 2);

        if (cols <= 0 || rows <= 0)
            return;

        for (var animationIdx = 0; animationIdx < animations.Length; animationIdx++)
        {
            var animation = animations[animationIdx];

            var rowIdx = animationIdx / cols;
            var colIdx = animationIdx % cols;

            var x = colIdx * (AnimationAreaWidth + HorizontalSpacing / 2) + HorizontalSpacing / 2;
            var y = rowIdx * (AnimationAreaHeight + VerticalSpacing / 2) + VerticalSpacing / 2;
            var frame = new Rectangle(x, y, AnimationAreaWidth, AnimationAreaHeight);

            var graphLeft = frame.Left + 1;
            var graphBottom = frame.Bottom;
            var graphWidth = frame.Width - 2;
            var graphHeight = frame.Height - 1;

            var gcGraph = new Gdk.GC(gdkWindow);
            gcGraph.RgbFgColor = new Gdk.Color(0xFE, 0x80, 0xB9);
            gcGraph.RgbBgColor = new Gdk.Color(0, 0, 0);
            var points = animation.Values
                .Select(value => new Point(
                    graphLeft + (int)(value.x * graphWidth), graphBottom - (int)(value.y * graphHeight)))
                .ToArray();
            gdkWindow.DrawLines(gcGraph, points);

            var gcFrame = new Gdk.GC(gdkWindow);
            gcFrame.RgbFgColor = new Gdk.Color(128, 128, 128);
            gcFrame.RgbBgColor = new Gdk.Color(0, 0, 0);
            gdkWindow.DrawRectangle(gcFrame, false, frame);

            var pangoTitleLayout = new Pango.Layout(pangoContext);
            pangoTitleLayout.FontDescription = Pango.FontDescription.FromString("monospace condensed " + TitleFontSize);
            pangoTitleLayout.SetText(animation.Title);
            int titleWidth = -1;
            int titleHeight = -1;
            pangoTitleLayout.GetSize(out titleWidth, out titleHeight);
            titleWidth = (int)(titleWidth / Pango.Scale.PangoScale);
            titleHeight = (int)(titleHeight / Pango.Scale.PangoScale);
            var titleX = frame.Left + (frame.Width - titleWidth) / 2;
            var titleY = frame.Bottom + 2;
            var gcFrameTitle = new Gdk.GC(gdkWindow);
            gcFrameTitle.RgbFgColor = new Gdk.Color(128, 128, 128);
            gcFrameTitle.RgbBgColor = new Gdk.Color(0, 0, 0);
            gdkWindow.DrawLayout(gcFrameTitle, titleX, titleY, pangoTitleLayout);
        }
    }
}
