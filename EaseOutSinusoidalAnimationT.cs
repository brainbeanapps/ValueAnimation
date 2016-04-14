using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutSinusoidalAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public EaseOutSinusoidalAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseOutSinusoidalAnimation(IValueOperations<T> valueOperations)
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = currentTime / duration;
            factor = (float)Math.Sin(factor * 0.5f * Math.PI);

            var value = ValueOperations.MultiplyBySingle(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
