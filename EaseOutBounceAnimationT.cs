using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutBounceAnimation<T> : BaseBounceAnimation<T>, IValueAnimation<T>
    {
        public EaseOutBounceAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseOutBounceAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            return base.GetValue(currentTime, duration, initialValue, deltaValue, true);
        }
    }
}
