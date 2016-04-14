using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseInPoweredAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// The power.
        /// </summary>
        public readonly int Power;

        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public EaseInPoweredAnimation(int power)
            : this(power, ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseInPoweredAnimation(int power, IValueOperations<T> valueOperations)
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            Power = power;
            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = (float)Math.Pow(currentTime / duration, Power);
            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
