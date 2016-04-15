using System;

namespace BrainbeanApps.ValueAnimation
{
    public abstract class BaseElasticAnimation<T> : BaseAnimation<T>
        where T : struct, IComparable
    {
        //TODO: Add Bounces count and Bounciness

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
            if (springiness <= 0.0f)
                throw new ArgumentException();

            Oscillations = oscillations;
            Springiness = springiness;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue, bool isAttenuation)
        {
            if (!isAttenuation)
                currentTime = duration - currentTime;
            var progress = currentTime / duration;

            var p = duration / Springiness;
            var s = p / (Oscillations + 1);
            var f = Math.Pow(2, -10.0f * progress) * Math.Sin((progress * duration - s) * (2 * Math.PI) / p);
            var factor = (float)(f + 1.0f);

            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            if (!isAttenuation)
                value = ValueOperations.Subtract(deltaValue, value);

            return ValueOperations.Add(initialValue, value);
        }
    }
}
