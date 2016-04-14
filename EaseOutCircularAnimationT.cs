using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutCircularAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
    {
        public EaseOutCircularAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseOutCircularAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
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
