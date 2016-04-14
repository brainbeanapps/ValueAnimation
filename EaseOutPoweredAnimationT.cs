﻿using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutPoweredAnimation<T> : IValueAnimation<T>
    {
        /// <summary>
        /// The power.
        /// </summary>
        public readonly int Power;

        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public EaseOutPoweredAnimation(int power)
            : this(power, ValueAnimation.ValueOperations.For<T>())
        {
        }

        public EaseOutPoweredAnimation(int power, IValueOperations<T> valueOperations)
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            Power = power;
            ValueOperations = valueOperations;
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            var factor = 1.0f - (float)Math.Pow(1.0f - currentTime / duration, Power);
            var value = ValueOperations.MultiplyBySingle(deltaValue, factor);
            return ValueOperations.Add(initialValue, value);
        }
    }
}