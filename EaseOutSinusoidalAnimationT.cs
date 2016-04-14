using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutSinusoidalAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
    {
        public EaseOutSinusoidalAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseOutSinusoidalAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = currentTime / duration;
            factor = (float)Math.Sin(factor * 0.5f * Math.PI);

            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
