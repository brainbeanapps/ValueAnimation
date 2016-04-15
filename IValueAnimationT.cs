using System;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Defines method to obtain value from animation.
    /// </summary>
    public interface IValueAnimation<T>
        where T : struct, IComparable
    {
        /// <summary>
        /// Gets the value at specified time.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="currentTime">Current time in seconds.</param>
        /// <param name="duration">Duration in seconds.</param>
        /// <param name="initialValue">Initial value.</param>
        /// <param name="deltaValue">Delta value.</param>
        T GetValue(float currentTime, float duration, T initialValue, T deltaValue);
    }
}
