using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseInExponentialAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        public EaseInExponentialAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseInExponentialAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = currentTime / duration;
            factor = (float)Math.Pow(2.0f, 10.0f * (factor - 1.0f));

            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
