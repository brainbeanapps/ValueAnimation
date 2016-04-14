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
        {
            return Linear<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> Linear<T>(IValueOperations<T> valueOperations)
        {
            return new LinearAnimation<T>(valueOperations).GetValue;
        }
        #endregion

        #region Powered
        public static ValueAnimation<T> EaseInPowered<T>(int power)
        {
            return EaseInPowered<T>(ValueOperations.For<T>(), power);
        }

        public static ValueAnimation<T> EaseInPowered<T>(IValueOperations<T> valueOperations, int power)
        {
            return new EaseInPoweredAnimation<T>(valueOperations, power).GetValue;
        }

        public static ValueAnimation<T> EaseOutPowered<T>(int power)
        {
            return EaseOutPowered<T>(ValueOperations.For<T>(), power);
        }

        public static ValueAnimation<T> EaseOutPowered<T>(IValueOperations<T> valueOperations, int power)
        {
            return new EaseOutPoweredAnimation<T>(valueOperations, power).GetValue;
        }

        public static ValueAnimation<T> EaseInOutPowered<T>(int power)
        {
            return EaseInOutPowered<T>(ValueOperations.For<T>(), power);
        }

        public static ValueAnimation<T> EaseInOutPowered<T>(IValueOperations<T> valueOperations, int power)
        {
            return new DualAnimation<T>(valueOperations, EaseInPowered<T>(valueOperations, power),
                EaseOutPowered<T>(valueOperations, power)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInPowered<T>(int power)
        {
            return EaseOutInPowered<T>(ValueOperations.For<T>(), power);
        }

        public static ValueAnimation<T> EaseOutInPowered<T>(IValueOperations<T> valueOperations, int power)
        {
            return new DualAnimation<T>(valueOperations, EaseOutPowered<T>(valueOperations, power),
                EaseInPowered<T>(valueOperations, power)).GetValue;
        }
        #endregion

        #region Quadratic
        public static ValueAnimation<T> EaseInQuadratic<T>()
        {
            return EaseInQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuadratic<T>(IValueOperations<T> valueOperations)
        {
            return EaseInPowered(valueOperations, 2);
        }

        public static ValueAnimation<T> EaseOutQuadratic<T>()
        {
            return EaseOutQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuadratic<T>(IValueOperations<T> valueOperations)
        {
            return EaseOutPowered(valueOperations, 2);
        }

        public static ValueAnimation<T> EaseInOutQuadratic<T>()
        {
            return EaseInOutQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuadratic<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseInQuadratic<T>(valueOperations),
                EaseOutQuadratic<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInQuadratic<T>()
        {
            return EaseOutInQuadratic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInQuadratic<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseOutQuadratic<T>(valueOperations),
                EaseInQuadratic<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Cubic
        public static ValueAnimation<T> EaseInCubic<T>()
        {
            return EaseInCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInCubic<T>(IValueOperations<T> valueOperations)
        {
            return EaseInPowered(valueOperations, 3);
        }

        public static ValueAnimation<T> EaseOutCubic<T>()
        {
            return EaseOutCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutCubic<T>(IValueOperations<T> valueOperations)
        {
            return EaseOutPowered(valueOperations, 3);
        }

        public static ValueAnimation<T> EaseInOutCubic<T>()
        {
            return EaseInOutCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutCubic<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseInCubic<T>(valueOperations),
                EaseOutCubic<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInCubic<T>()
        {
            return EaseOutInCubic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInCubic<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseOutCubic<T>(valueOperations),
                EaseInCubic<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Quartic
        public static ValueAnimation<T> EaseInQuartic<T>()
        {
            return EaseInQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuartic<T>(IValueOperations<T> valueOperations)
        {
            return EaseInPowered(valueOperations, 4);
        }

        public static ValueAnimation<T> EaseOutQuartic<T>()
        {
            return EaseOutQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuartic<T>(IValueOperations<T> valueOperations)
        {
            return EaseOutPowered(valueOperations, 4);
        }

        public static ValueAnimation<T> EaseInOutQuartic<T>()
        {
            return EaseInOutQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuartic<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseInQuartic<T>(valueOperations),
                EaseOutQuartic<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInQuartic<T>()
        {
            return EaseInOutQuartic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInQuartic<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseOutQuartic<T>(valueOperations),
                EaseInQuartic<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Quintic
        public static ValueAnimation<T> EaseInQuintic<T>()
        {
            return EaseInQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInQuintic<T>(IValueOperations<T> valueOperations)
        {
            return EaseInPowered(valueOperations, 5);
        }

        public static ValueAnimation<T> EaseOutQuintic<T>()
        {
            return EaseOutQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutQuintic<T>(IValueOperations<T> valueOperations)
        {
            return EaseOutPowered(valueOperations, 5);
        }

        public static ValueAnimation<T> EaseInOutQuintic<T>()
        {
            return EaseInOutQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutQuintic<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseInQuintic<T>(valueOperations),
                EaseOutQuintic<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInQuintic<T>()
        {
            return EaseOutInQuintic<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInQuintic<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseOutQuintic<T>(valueOperations),
                EaseInQuintic<T>(valueOperations)).GetValue;
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
            return new DualAnimation<T>(valueOperations, EaseInSinusoidal<T>(valueOperations),
                EaseOutSinusoidal<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInSinusoidal<T>()
        {
            return EaseOutInSinusoidal<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInSinusoidal<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseOutSinusoidal<T>(valueOperations),
                EaseInSinusoidal<T>(valueOperations)).GetValue;
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
            return new DualAnimation<T>(valueOperations, EaseInExponential<T>(valueOperations),
                EaseOutExponential<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInExponential<T>()
        {
            return EaseOutInExponential<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInExponential<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseOutExponential<T>(valueOperations),
                EaseInExponential<T>(valueOperations)).GetValue;
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
            return new DualAnimation<T>(valueOperations, EaseInCircular<T>(valueOperations),
                EaseOutCircular<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInCircular<T>()
        {
            return EaseOutInCircular<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInCircular<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseOutCircular<T>(valueOperations),
                EaseInCircular<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Back
        #endregion

        #region Elastic
        public static ValueAnimation<T> EaseInElastic<T>(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
        {
            return EaseInElastic<T>(ValueOperations.For<T>(), oscillations, springiness);
        }

        public static ValueAnimation<T> EaseInElastic<T>(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
        {
            return new EaseInElasticAnimation<T>(valueOperations, oscillations, springiness).GetValue;
        }

        public static ValueAnimation<T> EaseOutElastic<T>(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
        {
            return EaseOutElastic<T>(ValueOperations.For<T>(), oscillations, springiness);
        }

        public static ValueAnimation<T> EaseOutElastic<T>(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
        {
            return new EaseOutElasticAnimation<T>(valueOperations, oscillations, springiness).GetValue;
        }

        public static ValueAnimation<T> EaseInOutElastic<T>(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
        {
            return EaseInOutElastic<T>(ValueOperations.For<T>(), oscillations, springiness);
        }

        public static ValueAnimation<T> EaseInOutElastic<T>(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
        {
            return new DualAnimation<T>(valueOperations, EaseInElastic<T>(valueOperations, oscillations, springiness),
                EaseOutElastic<T>(valueOperations, oscillations, springiness)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInElastic<T>(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
        {
            return EaseOutInElastic<T>(ValueOperations.For<T>(), oscillations, springiness);
        }

        public static ValueAnimation<T> EaseOutInElastic<T>(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
        {
            return new DualAnimation<T>(valueOperations, EaseOutElastic<T>(valueOperations, oscillations, springiness),
                EaseInElastic<T>(valueOperations, oscillations, springiness)).GetValue;
        }
        #endregion

        #region Bounce
        public static ValueAnimation<T> EaseInBounce<T>()
        {
            return EaseInBounce<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInBounce<T>(IValueOperations<T> valueOperations)
        {
            return new EaseInBounceAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseOutBounce<T>()
        {
            return EaseOutBounce<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutBounce<T>(IValueOperations<T> valueOperations)
        {
            return new EaseOutBounceAnimation<T>(valueOperations).GetValue;
        }

        public static ValueAnimation<T> EaseInOutBounce<T>()
        {
            return EaseInOutBounce<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseInOutBounce<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseInBounce<T>(valueOperations),
                EaseOutBounce<T>(valueOperations)).GetValue;
        }

        public static ValueAnimation<T> EaseOutInBounce<T>()
        {
            return EaseOutInBounce<T>(ValueOperations.For<T>());
        }

        public static ValueAnimation<T> EaseOutInBounce<T>(IValueOperations<T> valueOperations)
        {
            return new DualAnimation<T>(valueOperations, EaseOutBounce<T>(valueOperations),
                EaseInBounce<T>(valueOperations)).GetValue;
        }
        #endregion

        #region Bezier
        #endregion
    }
}
