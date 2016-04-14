using System;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Implements the EaseInOut animation using EaseIn and EaseOut animations.
    /// </summary>
    public class EaseInOutAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// Gets the EaseIn animation.
        /// </summary>
        /// <value>The EaseIn animation.</value>
        public readonly ValueAnimation<T> EaseInAnimation;

        /// <summary>
        /// Gets the EaseOut animation.
        /// </summary>
        /// <value>The EaseOut animation.</value>
        public readonly ValueAnimation<T> EaseOutAnimation;

        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public EaseInOutAnimation(ValueAnimation<T> easeInAnimation, ValueAnimation<T> easeOutAnimation)
            : this(easeInAnimation, easeOutAnimation, ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseInOutAnimation(ValueAnimation<T> easeInAnimation, ValueAnimation<T> easeOutAnimation,
            IValueOperations<T> valueOperations)
        {
            if (easeInAnimation == null)
                throw new ArgumentNullException();
            if (easeOutAnimation == null)
                throw new ArgumentNullException();
            if (valueOperations == null)
                throw new ArgumentNullException();

            EaseInAnimation = easeInAnimation;
            EaseOutAnimation = easeOutAnimation;
            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var halfDuration = 0.5f * duration;
            var halfDelta = ValueOperations.DivideByTwo(deltaValue);

            if (currentTime < halfDuration)
                return EaseInAnimation(currentTime, halfDuration, initialValue, halfDelta);
            else
            {
                return EaseOutAnimation(currentTime - halfDuration, halfDuration,
                    ValueOperations.Add(initialValue, halfDelta), halfDelta);
            }
        }
    }
}
