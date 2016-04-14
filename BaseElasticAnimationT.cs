using System;

namespace BrainbeanApps.ValueAnimation
{
    public class BaseElasticAnimation<T> : BaseAnimation<T>
    {
        /// <summary>
        /// Number of oscillations.
        /// </summary>
        public readonly int Oscillations;

        /// <summary>
        /// Value of springiness
        /// </summary>
        public readonly float Springiness;

        public BaseElasticAnimation(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            : base(valueOperations)
        {
            if (oscillations < 0)
                throw new ArgumentException();
            if (springiness < 0.0f)
                throw new ArgumentException();

            Oscillations = oscillations;
            Springiness = springiness;
        }
    }
}
