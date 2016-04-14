using System;
using System.Linq;
using Gtk;
using Gdk;
using BrainbeanApps.ValueAnimation;

public partial class MainWindow: Gtk.Window
{
    public const int ValueSteps = 100;
    public const int VerticalSpacing = 48;
    public const int HorizontalSpacing = 16;
    public const int AnimationAreaWidth = 160;
    public const int AnimationAreaHeight = 120;

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
            ConstructAnimation(ValueAnimations.Linear<float>(), "Linear (float)"),

            ConstructAnimation(ValueAnimations.EaseInCircular<float>(), "Circular EaseIn (float)"),
            ConstructAnimation(ValueAnimations.EaseOutCircular<float>(), "Circular EaseOut (float)"),
            ConstructAnimation(ValueAnimations.EaseInOutCircular<float>(), "Circular EaseInOut (float)"),

            ConstructAnimation(ValueAnimations.EaseInExponential<float>(), "Exponential EaseIn (float)"),
            ConstructAnimation(ValueAnimations.EaseOutExponential<float>(), "Exponential EaseOut (float)"),
            ConstructAnimation(ValueAnimations.EaseInOutExponential<float>(), "Exponential EaseInOut (float)"),

            ConstructAnimation(ValueAnimations.EaseInSinusoidal<float>(), "Sinusoidal EaseIn (float)"),
            ConstructAnimation(ValueAnimations.EaseOutSinusoidal<float>(), "Sinusoidal EaseOut (float)"),
            ConstructAnimation(ValueAnimations.EaseInOutSinusoidal<float>(), "Sinusoidal EaseInOut (float)"),

            ConstructAnimation(ValueAnimations.EaseInQuadratic<float>(), "Quadratic EaseIn (float)"),
            ConstructAnimation(ValueAnimations.EaseOutQuadratic<float>(), "Quadratic EaseOut (float)"),
            ConstructAnimation(ValueAnimations.EaseInOutQuadratic<float>(), "Quadratic EaseInOut (float)"),

            ConstructAnimation(ValueAnimations.EaseInCubic<float>(), "Cubic EaseIn (float)"),
            ConstructAnimation(ValueAnimations.EaseOutCubic<float>(), "Cubic EaseOut (float)"),
            ConstructAnimation(ValueAnimations.EaseInOutCubic<float>(), "Cubic EaseInOut (float)"),

            ConstructAnimation(ValueAnimations.EaseInQuartic<float>(), "Quartic EaseIn (float)"),
            ConstructAnimation(ValueAnimations.EaseOutQuartic<float>(), "Quartic EaseOut (float)"),
            ConstructAnimation(ValueAnimations.EaseInOutQuartic<float>(), "Quartic EaseInOut (float)"),

            ConstructAnimation(ValueAnimations.EaseInQuintic<float>(), "Quintic EaseIn (float)"),
            ConstructAnimation(ValueAnimations.EaseOutQuintic<float>(), "Quintic EaseOut (float)"),
            ConstructAnimation(ValueAnimations.EaseInOutQuintic<float>(), "Quintic EaseInOut (float)")

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
            var graphBottom = frame.Bottom - 1;
            var graphWidth = frame.Width - 2;
            var graphHeight = frame.Height - 2;

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
