﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Implements single animation using multiple nested animations
    /// </summary>
    public class MultiAnimation<T> : BaseAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        /// <summary>
        /// Nested animations.
        /// </summary>
        public readonly Tuple<float, ValueAnimation<T>>[] NestedAnimations;

        public MultiAnimation(params ValueAnimation<T>[] nestedAnimations)
            : this(nestedAnimations, ValueAnimation.ValueOperations.For<T>())
        {
        }

        public MultiAnimation(IEnumerable<ValueAnimation<T>> nestedAnimations)
            : this(nestedAnimations, ValueAnimation.ValueOperations.For<T>())
        {
        }

        public MultiAnimation(IEnumerable<ValueAnimation<T>> nestedAnimations, IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
            if (nestedAnimations == null)
                throw new ArgumentNullException();
            if (nestedAnimations.Count() <= 0)
                throw new ArgumentException();

            var length = 1.0f / nestedAnimations.Count();
            NestedAnimations = nestedAnimations.Select(x => new Tuple<float, ValueAnimation<T>>(length, x)).ToArray();
        }

        public MultiAnimation(IEnumerable<Tuple<float, ValueAnimation<T>>> nestedAnimations)
            : this(nestedAnimations, ValueAnimation.ValueOperations.For<T>())
        {
        }

        public MultiAnimation(IEnumerable<Tuple<float, ValueAnimation<T>>> nestedAnimations,
            IValueOperations<T> valueOperations)
            : base(valueOperations)
        {
            if (nestedAnimations == null)
                throw new ArgumentNullException();
            if (nestedAnimations.Count() <= 0)
                throw new ArgumentException();
            if (nestedAnimations.Any(x => x.Item1 < 0.0f || x.Item1 > 1.0f))
                throw new ArgumentException();
            if (nestedAnimations.Sum(x => x.Item1) > 1.0f)
                throw new ArgumentException();

            NestedAnimations = nestedAnimations.ToArray();
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var progress = currentTime / duration;
            int nestedAnimationIndex = 0;
            var playedNestedAnimations = 0.0f;
            for (; nestedAnimationIndex < NestedAnimations.Length; nestedAnimationIndex++)
            {
                var length = NestedAnimations[nestedAnimationIndex].Item1;
                if (progress <= playedNestedAnimations + length)
                    break;
                playedNestedAnimations += length;
            }
            if (nestedAnimationIndex == NestedAnimations.Length)
                nestedAnimationIndex--;

            var nestedAnimation = NestedAnimations[nestedAnimationIndex];
            var nestedCurrentTime = currentTime - playedNestedAnimations * duration;
            var nestedDuration = nestedAnimation.Item1 * duration;
            var nestedInitialValue = ValueOperations.Add(initialValue,
                ValueOperations.ScaleByFactor(deltaValue, playedNestedAnimations));
            var nestedDeltaValue = ValueOperations.ScaleByFactor(deltaValue, nestedAnimation.Item1);
            return nestedAnimation.Item2(nestedCurrentTime, nestedDuration, nestedInitialValue, nestedDeltaValue);
        }
    }
}
