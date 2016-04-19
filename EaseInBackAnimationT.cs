using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseInBackAnimation<T> : BaseBackAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        public EaseInBackAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseInBackAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            return base.GetValue(currentTime, duration, initialValue, deltaValue, false);
        }
    }
}
