using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutPoweredAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        /// <summary>
        /// The power.
        /// </summary>
        public readonly int Power;

        public EaseOutPoweredAnimation(int power)
            : this(ValueAnimation.ValueOperations.For<T>(), power)
        {
        }

        public EaseOutPoweredAnimation(IValueOperations<T> valueOperations, int power)
            : base(valueOperations)
        {
            Power = power;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = 1.0f - (float)Math.Pow(1.0f - currentTime / duration, Power);
            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
