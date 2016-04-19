using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutBackAnimation<T> : BaseBackAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        public EaseOutBackAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseOutBackAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            return base.GetValue(currentTime, duration, initialValue, deltaValue, true);
        }
    }
}
