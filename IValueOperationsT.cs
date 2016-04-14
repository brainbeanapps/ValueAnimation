using System;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Defines math operations used by animator.
    /// </summary>
    public interface IValueOperations<T>
    {
        /// <summary>
        /// Add the specified l and r.
        /// </summary>
        /// <param name="l">Left operand.</param>
        /// <param name="r">Right operand.</param>
        T Add(T l, T r);

        /// <summary>
        /// Subtract the specified l and r.
        /// </summary>
        /// <param name="l">Left operand.</param>
        /// <param name="r">Right operand.</param>
        T Subtract(T l, T r);

        /// <summary>
        /// Scales the specified value by factor.
        /// </summary>
        /// <returns>The by single.</returns>
        /// <param name="value">Value.</param>
        /// <param name="factor">Factor.</param>
        T ScaleByFactor(T value, float factor);
    }
}
