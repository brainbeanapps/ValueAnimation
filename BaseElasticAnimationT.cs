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

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue, bool isAttenuation)
        {
            if (!isAttenuation)
                currentTime = duration - currentTime;

            // TODO: calculate
            var value = default(T);

            if (!isAttenuation)
                value = ValueOperations.Subtract(deltaValue, value);

            return ValueOperations.Add(initialValue, value);
        }
    }
}
