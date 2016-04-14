using System;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Implements the EaseInOut animation using EaseIn and EaseOut animations.
    /// </summary>
    public class DualAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// The first animation.
        /// </summary>
        public readonly ValueAnimation<T> FirstAnimation;

        /// <summary>
        /// The second animation.
        /// </summary>
        public readonly ValueAnimation<T> SecondAnimation;

        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public DualAnimation(ValueAnimation<T> firstAnimation, ValueAnimation<T> secondAnimation)
            : this(firstAnimation, secondAnimation, ValueAnimation.ValueOperations.For<T>())
        {
        }

        public DualAnimation(ValueAnimation<T> firstAnimation, ValueAnimation<T> secondAnimation,
            IValueOperations<T> valueOperations)
        {
            if (firstAnimation == null)
                throw new ArgumentNullException();
            if (secondAnimation == null)
                throw new ArgumentNullException();
            if (valueOperations == null)
                throw new ArgumentNullException();

            FirstAnimation = firstAnimation;
            SecondAnimation = secondAnimation;
            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var halfDuration = 0.5f * duration;
            var halfDelta = ValueOperations.ScaleByFactor(deltaValue, 0.5f);

            if (currentTime < halfDuration)
                return FirstAnimation(currentTime, halfDuration, initialValue, halfDelta);
            else
            {
                return SecondAnimation(currentTime - halfDuration, halfDuration,
                    ValueOperations.Add(initialValue, halfDelta), halfDelta);
            }
        }
    }
}
