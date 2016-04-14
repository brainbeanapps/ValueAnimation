using System;

namespace BrainbeanApps.ValueAnimation
{
    public class LinearAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public LinearAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public LinearAnimation(IValueOperations<T> valueOperations)
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var value = ValueOperations.MultiplyBySingle(deltaValue, currentTime / duration);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
