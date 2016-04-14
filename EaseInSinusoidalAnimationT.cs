using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseInSinusoidalAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
    {
        public EaseInSinusoidalAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseInSinusoidalAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
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
