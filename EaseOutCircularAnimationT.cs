using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutCircularAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public EaseOutCircularAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseOutCircularAnimation(IValueOperations<T> valueOperations)
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = currentTime / duration;
            factor -= 1.0f;
            factor = (float)Math.Sqrt(1.0f - factor*factor);

            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
