using System;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Value animations.
    /// </summary>
    public static class ValueAnimations
    {
        #region Linear
        public static ValueAnimation<T> Linear<T>()
            where T : struct, IComparable
        {
            return Linear<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> Linear<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new LinearAnimation<T>(valueOperations).GetValue;
        }
        #endregion

        #region Powered
        public static ValueAnimation<T> EaseInPowered<T>(int power)
            where T : struct, IComparable
        {
            return EaseInPowered<T>(ValueOperations.For<T>(), power);
        }

        public static ValueAnimation<T> EaseInPowered<T>(IValueOperations<T> valueOperations, int power)
            where T : struct, IComparable
        {
            return new EaseInPoweredAnimation<T>(valueOperations, power).GetValue;
        }

        public static ValueAnimation<T> EaseOutPowered<T>(int power)
            where T : struct, IComparable
        {
            return EaseOutPowered<T>(ValueOperations.For<T>(), power);
        }

        public static ValueAnimation<T> EaseOutPowered<T>(IValueOperations<T> valueOperations, int power)
            where T : struct, IComparable
        {
            return new EaseOutPoweredAnimation<T>(valueOperations, power).GetValue;
        }

        public static ValueAnimation<T> EaseInOutPowered<T>(int power)
            where T : struct, IComparable
        {
            return EaseInOutPowered<T>(ValueOperations.For<T>(), power);
        }

        public static ValueAnimation<T> EaseInOutPowered<T>(IValueOperations<T> valueOperations, int power)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInPowered<T>(valueOperations, power),
                EaseOutPowered<T>(valueOperations, power)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInPowered<T>(int power)
            where T : struct, IComparable
        {
            return EaseOutInPowered<T>(ValueOperations.For<T>(), power);
        }

        public static ValueAnimation<T> EaseOutInPowered<T>(IValueOperations<T> valueOperations, int power)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutPowered<T>(valueOperations, power),
                EaseInPowered<T>(valueOperations, power)).GetValue;
        }
        #endregion

        #region Quadratic
        public static ValueAnimation<T> EaseInQuadratic<T>()
            where T : struct, IComparable
        {
            return EaseInQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuadratic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return EaseInPowered(valueOperations, 2);
        }

        public static ValueAnimation<T> EaseOutQuadratic<T>()
            where T : struct, IComparable
        {
            return EaseOutQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuadratic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return EaseOutPowered(valueOperations, 2);
        }

        public static ValueAnimation<T> EaseInOutQuadratic<T>()
            where T : struct, IComparable
        {
            return EaseInOutQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuadratic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInQuadratic<T>(valueOperations),
                EaseOutQuadratic<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInQuadratic<T>()
            where T : struct, IComparable
        {
            return EaseOutInQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInQuadratic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutQuadratic<T>(valueOperations),
                EaseInQuadratic<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Cubic
        public static ValueAnimation<T> EaseInCubic<T>()
            where T : struct, IComparable
        {
            return EaseInCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInCubic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return EaseInPowered(valueOperations, 3);
        }

        public static ValueAnimation<T> EaseOutCubic<T>()
            where T : struct, IComparable
        {
            return EaseOutCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutCubic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return EaseOutPowered(valueOperations, 3);
        }

        public static ValueAnimation<T> EaseInOutCubic<T>()
            where T : struct, IComparable
        {
            return EaseInOutCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutCubic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInCubic<T>(valueOperations),
                EaseOutCubic<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInCubic<T>()
            where T : struct, IComparable
        {
            return EaseOutInCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInCubic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutCubic<T>(valueOperations),
                EaseInCubic<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Quartic
        public static ValueAnimation<T> EaseInQuartic<T>()
            where T : struct, IComparable
        {
            return EaseInQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuartic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return EaseInPowered(valueOperations, 4);
        }

        public static ValueAnimation<T> EaseOutQuartic<T>()
            where T : struct, IComparable
        {
            return EaseOutQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuartic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return EaseOutPowered(valueOperations, 4);
        }

        public static ValueAnimation<T> EaseInOutQuartic<T>()
            where T : struct, IComparable
        {
            return EaseInOutQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuartic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInQuartic<T>(valueOperations),
                EaseOutQuartic<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInQuartic<T>()
            where T : struct, IComparable
        {
            return EaseInOutQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInQuartic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutQuartic<T>(valueOperations),
                EaseInQuartic<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Quintic
        public static ValueAnimation<T> EaseInQuintic<T>()
            where T : struct, IComparable
        {
            return EaseInQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuintic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return EaseInPowered(valueOperations, 5);
        }

        public static ValueAnimation<T> EaseOutQuintic<T>()
            where T : struct, IComparable
        {
            return EaseOutQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuintic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return EaseOutPowered(valueOperations, 5);
        }

        public static ValueAnimation<T> EaseInOutQuintic<T>()
            where T : struct, IComparable
        {
            return EaseInOutQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuintic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInQuintic<T>(valueOperations),
                EaseOutQuintic<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInQuintic<T>()
            where T : struct, IComparable
        {
            return EaseOutInQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInQuintic<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutQuintic<T>(valueOperations),
                EaseInQuintic<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Sinusoidal
        public static ValueAnimation<T> EaseInSinusoidal<T>()
            where T : struct, IComparable
        {
            return EaseInSinusoidal<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInSinusoidal<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseInSinusoidalAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutSinusoidal<T>()
            where T : struct, IComparable
        {
            return EaseOutSinusoidal<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutSinusoidal<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseOutSinusoidalAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutSinusoidal<T>()
            where T : struct, IComparable
        {
            return EaseInOutSinusoidal<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutSinusoidal<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInSinusoidal<T>(valueOperations),
                EaseOutSinusoidal<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInSinusoidal<T>()
            where T : struct, IComparable
        {
            return EaseOutInSinusoidal<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInSinusoidal<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutSinusoidal<T>(valueOperations),
                EaseInSinusoidal<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Exponential
        public static ValueAnimation<T> EaseInExponential<T>()
            where T : struct, IComparable
        {
            return EaseInExponential<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInExponential<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseInExponentialAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutExponential<T>()
            where T : struct, IComparable
        {
            return EaseOutExponential<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutExponential<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseOutExponentialAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutExponential<T>()
            where T : struct, IComparable
        {
            return EaseInOutExponential<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutExponential<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInExponential<T>(valueOperations),
                EaseOutExponential<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInExponential<T>()
            where T : struct, IComparable
        {
            return EaseOutInExponential<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInExponential<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutExponential<T>(valueOperations),
                EaseInExponential<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Circular
        public static ValueAnimation<T> EaseInCircular<T>()
            where T : struct, IComparable
        {
            return EaseInCircular<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInCircular<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseInCircularAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutCircular<T>()
            where T : struct, IComparable
        {
            return EaseOutCircular<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutCircular<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseOutCircularAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutCircular<T>()
            where T : struct, IComparable
        {
            return EaseInOutCircular<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutCircular<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInCircular<T>(valueOperations),
                EaseOutCircular<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInCircular<T>()
            where T : struct, IComparable
        {
            return EaseOutInCircular<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInCircular<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutCircular<T>(valueOperations),
                EaseInCircular<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Back
        public static ValueAnimation<T> EaseInBack<T>()
            where T : struct, IComparable
        {
            return EaseInBack<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInBack<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseInBackAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutBack<T>()
            where T : struct, IComparable
        {
            return EaseOutBack<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutBack<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseOutBackAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutBack<T>()
            where T : struct, IComparable
        {
            return EaseInOutBack<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutBack<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInBack<T>(valueOperations),
                EaseOutBack<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInBack<T>()
            where T : struct, IComparable
        {
            return EaseOutInBack<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInBack<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutBack<T>(valueOperations),
                EaseInBack<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Elastic
        public static ValueAnimation<T> EaseInElastic<T>(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            where T : struct, IComparable
        {
            return EaseInElastic<T>(ValueOperations.For<T>(), oscillations, springiness);
        }

        public static ValueAnimation<T> EaseInElastic<T>(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            where T : struct, IComparable
        {
            return new EaseInElasticAnimation<T>(valueOperations, oscillations, springiness).GetValue;
        }

        public static ValueAnimation<T> EaseOutElastic<T>(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            where T : struct, IComparable
        {
            return EaseOutElastic<T>(ValueOperations.For<T>(), oscillations, springiness);
        }

        public static ValueAnimation<T> EaseOutElastic<T>(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            where T : struct, IComparable
        {
            return new EaseOutElasticAnimation<T>(valueOperations, oscillations, springiness).GetValue;
        }

        public static ValueAnimation<T> EaseInOutElastic<T>(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            where T : struct, IComparable
        {
            return EaseInOutElastic<T>(ValueOperations.For<T>(), oscillations, springiness);
        }

        public static ValueAnimation<T> EaseInOutElastic<T>(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInElastic<T>(valueOperations, oscillations, springiness),
                EaseOutElastic<T>(valueOperations, oscillations, springiness)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInElastic<T>(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            where T : struct, IComparable
        {
            return EaseOutInElastic<T>(ValueOperations.For<T>(), oscillations, springiness);
        }

        public static ValueAnimation<T> EaseOutInElastic<T>(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutElastic<T>(valueOperations, oscillations, springiness),
                EaseInElastic<T>(valueOperations, oscillations, springiness)).GetValue;
        }
        #endregion

        #region Bounce
        public static ValueAnimation<T> EaseInBounce<T>()
            where T : struct, IComparable
        {
            return EaseInBounce<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInBounce<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseInBounceAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutBounce<T>()
            where T : struct, IComparable
        {
            return EaseOutBounce<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutBounce<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new EaseOutBounceAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutBounce<T>()
            where T : struct, IComparable
        {
            return EaseInOutBounce<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutBounce<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseInBounce<T>(valueOperations),
                EaseOutBounce<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInBounce<T>()
            where T : struct, IComparable
        {
            return EaseOutInBounce<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInBounce<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            return new DualAnimation<T>(valueOperations, EaseOutBounce<T>(valueOperations),
                EaseInBounce<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Bezier
        //TODO: Add Bezier
        #endregion
    }
}
