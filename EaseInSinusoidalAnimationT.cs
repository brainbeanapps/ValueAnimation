using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseInSinusoidalAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public EaseInSinusoidalAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseInSinusoidalAnimation(IValueOperations<T> valueOperations)
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = currentTime / duration;
            factor = 1.0f - (float)Math.Cos(factor * 0.5 * Math.PI);

            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
