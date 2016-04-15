using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseInBounceAnimation<T> : BaseBounceAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        public EaseInBounceAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseInBounceAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            return base.GetValue(currentTime, duration, initialValue, deltaValue, false);
        }
    }
}
