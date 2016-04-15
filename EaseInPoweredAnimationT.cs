using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseInPoweredAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        /// <summary>
        /// The power.
        /// </summary>
        public readonly int Power;

        public EaseInPoweredAnimation(int power)
            : this(ValueAnimation.ValueOperations.For<T>(), power)
        {
        }

        public EaseInPoweredAnimation(IValueOperations<T> valueOperations, int power)
            : base(valueOperations)
        {
            Power = power;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = (float)Math.Pow(currentTime / duration, Power);
            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
