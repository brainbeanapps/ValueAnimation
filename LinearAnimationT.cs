using System;

namespace BrainbeanApps.ValueAnimation
{
    public class LinearAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        public LinearAnimation()
            : this(ValueAnimation.ValueOperations.For<T>())
        {
        }

        public LinearAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var value = ValueOperations.ScaleByFactor(deltaValue, currentTime / duration);
            return ValueOperations.Add(initialValue, value);
        }
    }
}
