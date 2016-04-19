using System;

namespace BrainbeanApps.ValueAnimation
{
    public abstract class BaseBackAnimation<T> : BaseAnimation<T>
        where T : struct, IComparable
    {
        public const float C = 1.70158f;

        public BaseBackAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue, bool isAttenuation)
        {
            if (isAttenuation)
                currentTime = duration - currentTime;
            var t = currentTime / duration;

            var factor = t * t * ((C + 1.0f)*t - C);

            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            if (isAttenuation)
                value = ValueOperations.Subtract(deltaValue, value);

            return ValueOperations.Add(initialValue, value);
        }
    }
}
