using System;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Value animations.
    /// </summary>
    public static class ValueAnimations
    {
        public static ValueAnimation<T> Linear<T>()
        {
            return Linear<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> Linear<T>(IValueOperations<T> valueOperations)
        {
            return new LinearAnimation<T>(valueOperations).GetValue;
        }

        #region Powered
        public static ValueAnimation<T> EaseInPowered<T>(int power)
        {
            return EaseInPowered<T>(power, ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInPowered<T>(int power, IValueOperations<T> valueOperations)
        {
            return new EaseInPoweredAnimation<T>(power, valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutPowered<T>(int power)
        {
            return EaseOutPowered<T>(power, ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutPowered<T>(int power, IValueOperations<T> valueOperations)
        {
            return new EaseOutPoweredAnimation<T>(power, valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutPowered<T>(int power)
        {
            return EaseInOutPowered<T>(power, ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutPowered<T>(int power, IValueOperations<T> valueOperations)
        {
            return new EaseInOutAnimation<T>(EaseInPowered<T>(power, valueOperations),
                EaseOutPowered<T>(power, valueOperations), valueOperations).GetValue;
        }
        #endregion

        #region Quadratic
        public static ValueAnimation<T> EaseInQuadratic<T>()
        {
            return EaseInQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuadratic<T>(IValueOperations<T> valueOperations)
        {
            return EaseInPowered(2, valueOperations);
        }

        public static ValueAnimation<T> EaseOutQuadratic<T>()
        {
            return EaseOutQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuadratic<T>(IValueOperations<T> valueOperations)
        {
            return EaseOutPowered(2, valueOperations);
        }

        public static ValueAnimation<T> EaseInOutQuadratic<T>()
        {
            return EaseInOutQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuadratic<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInOutAnimation<T>(EaseInQuadratic<T>(valueOperations), EaseOutQuadratic<T>(valueOperations),
                valueOperations).GetValue;
        }
        #endregion

        #region Cubic
        public static ValueAnimation<T> EaseInCubic<T>()
        {
            return EaseInCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInCubic<T>(IValueOperations<T> valueOperations)
        {
            return EaseInPowered(3, valueOperations);
        }

        public static ValueAnimation<T> EaseOutCubic<T>()
        {
            return EaseOutCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutCubic<T>(IValueOperations<T> valueOperations)
        {
            return EaseOutPowered(3, valueOperations);
        }

        public static ValueAnimation<T> EaseInOutCubic<T>()
        {
            return EaseInOutCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutCubic<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInOutAnimation<T>(EaseInCubic<T>(valueOperations), EaseOutCubic<T>(valueOperations),
                valueOperations).GetValue;
        }
        #endregion

        #region Quartic
        public static ValueAnimation<T> EaseInQuartic<T>()
        {
            return EaseInQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuartic<T>(IValueOperations<T> valueOperations)
        {
            return EaseInPowered(4, valueOperations);
        }

        public static ValueAnimation<T> EaseOutQuartic<T>()
        {
            return EaseOutQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuartic<T>(IValueOperations<T> valueOperations)
        {
            return EaseOutPowered(4, valueOperations);
        }

        public static ValueAnimation<T> EaseInOutQuartic<T>()
        {
            return EaseInOutQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuartic<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInOutAnimation<T>(EaseInQuartic<T>(valueOperations), EaseOutQuartic<T>(valueOperations),
                valueOperations).GetValue;
        }
        #endregion

        #region Quintic
        public static ValueAnimation<T> EaseInQuintic<T>()
        {
            return EaseInQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuintic<T>(IValueOperations<T> valueOperations)
        {
            return EaseInPowered(5, valueOperations);
        }

        public static ValueAnimation<T> EaseOutQuintic<T>()
        {
            return EaseOutQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuintic<T>(IValueOperations<T> valueOperations)
        {
            return EaseOutPowered(5, valueOperations);
        }

        public static ValueAnimation<T> EaseInOutQuintic<T>()
        {
            return EaseInOutQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuintic<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInOutAnimation<T>(EaseInQuintic<T>(valueOperations), EaseOutQuintic<T>(valueOperations),
                valueOperations).GetValue;
        }
        #endregion

        #region Sinusoidal
        public static ValueAnimation<T> EaseInSinusoidal<T>()
        {
            return EaseInSinusoidal<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInSinusoidal<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInSinusoidalAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutSinusoidal<T>()
        {
            return EaseOutSinusoidal<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutSinusoidal<T>(IValueOperations<T> valueOperations)
        {
            return new EaseOutSinusoidalAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutSinusoidal<T>()
        {
            return EaseInOutSinusoidal<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutSinusoidal<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInOutAnimation<T>(EaseInSinusoidal<T>(valueOperations), EaseOutSinusoidal<T>(valueOperations),
                valueOperations).GetValue;
        }
        #endregion

        #region Exponential
        public static ValueAnimation<T> EaseInExponential<T>()
        {
            return EaseInExponential<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInExponential<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInExponentialAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutExponential<T>()
        {
            return EaseOutExponential<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutExponential<T>(IValueOperations<T> valueOperations)
        {
            return new EaseOutExponentialAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutExponential<T>()
        {
            return EaseInOutExponential<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutExponential<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInOutAnimation<T>(EaseInExponential<T>(valueOperations), EaseOutExponential<T>(valueOperations),
                valueOperations).GetValue;
        }
        #endregion

        #region Circular
        public static ValueAnimation<T> EaseInCircular<T>()
        {
            return EaseInCircular<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInCircular<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInCircularAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutCircular<T>()
        {
            return EaseOutCircular<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutCircular<T>(IValueOperations<T> valueOperations)
        {
            return new EaseOutCircularAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutCircular<T>()
        {
            return EaseInOutCircular<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutCircular<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInOutAnimation<T>(EaseInCircular<T>(valueOperations), EaseOutCircular<T>(valueOperations),
                valueOperations).GetValue;
        }
        #endregion

        #region Back
        #endregion

        #region Elastic
        #endregion

        #region Bounce
        #endregion

        #region Bezier
        #endregion
    }
}
