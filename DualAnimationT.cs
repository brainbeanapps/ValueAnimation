using System;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Implements the EaseInOut animation using EaseIn and EaseOut animations.
    /// </summary>
    public class DualAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        /// <summary>
        /// The first animation.
        /// </summary>
        public readonly ValueAnimation<T> FirstAnimation;

        /// <summary>
        /// The second animation.
        /// </summary>
        public readonly ValueAnimation<T> SecondAnimation;

        public DualAnimation(ValueAnimation<T> firstAnimation, ValueAnimation<T> secondAnimation)
            : this(ValueAnimation.ValueOperations.For<T>(), firstAnimation, secondAnimation)
        {
        }

        public DualAnimation(IValueOperations<T> valueOperations, ValueAnimation<T> firstAnimation,
            ValueAnimation<T> secondAnimation)
            : base(valueOperations)
        {
            if (firstAnimation == null)
                throw new ArgumentNullException();
            if (secondAnimation == null)
                throw new ArgumentNullException();

            FirstAnimation = firstAnimation;
            SecondAnimation = secondAnimation;
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
