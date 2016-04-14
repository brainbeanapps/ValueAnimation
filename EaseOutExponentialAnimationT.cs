using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutExponentialAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public EaseOutExponentialAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseOutExponentialAnimation(IValueOperations<T> valueOperations)
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = currentTime / duration;
            factor = -(float)Math.Pow(2.0f, -10.0f * factor) + 1.0f;

            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
