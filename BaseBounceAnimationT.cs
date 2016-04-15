using System;

namespace BrainbeanApps.ValueAnimation
{
    public abstract class BaseBounceAnimation<T> : BaseAnimation<T>
        where T : struct, IComparable
    {
        public BaseBounceAnimation(IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue, bool isAttenuation)
        {
            if (!isAttenuation)
                currentTime = duration - currentTime;
            var progress = currentTime / duration;

            float factor;
            if (progress < (1.0f / 2.75f))
                factor = 7.5625f * progress * progress;
            else if (progress < (2.0f / 2.75f))
            {
                var t = progress - 1.5f / 2.75f;
                factor = 7.5625f * t * t + 0.75f;
            }
            else if (progress < (2.5f / 2.75f))
            {
                var t = progress - 2.25f / 2.75f;
                factor = 7.5625f * t * t + 0.9375f;
            }
            else
            {
                var t = progress - 2.625f / 2.75f;
                factor = 7.5625f * t * t + 0.984375f;
            }

            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
            if (!isAttenuation)
                value = ValueOperations.Subtract(deltaValue, value);

            return ValueOperations.Add(initialValue, value);
        }
    }
}
