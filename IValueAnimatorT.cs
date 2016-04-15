using System;

namespace BrainbeanApps.ValueAnimation
{
    public interface IValueAnimator<T> : IValueAnimator
        where T : struct, IComparable
    {
        /// <summary>
        /// Gets or sets the animation.
        /// </summary>
        /// <value>The animation.</value>
        ValueAnimation<T> Animation { get; set; }

        /// <summary>
        /// Gets or sets the initial value.
        /// </summary>
        /// <value>The initial value.</value>
        T? InitialValue { get; set; }

        /// <summary>
        /// Gets or sets the initial value getter.
        /// </summary>
        /// <value>The initial value getter.</value>
        Func<T> InitialValueGetter { get; set; }

        /// <summary>
        /// Gets or sets the delta value.
        /// </summary>
        /// <value>The delta value.</value>
        T? DeltaValue { get; set; }

        /// <summary>
        /// Gets or sets the delta value getter.
        /// </summary>
        /// <value>The delta value getter.</value>
        Func<T> DeltaValueGetter { get; set; }

        /// <summary>
        /// Gets the current value.
        /// </summary>
        /// <value>The current value.</value>
        T? CurrentValue { get; }

        /// <summary>
        /// Gets or sets the current value setter.
        /// </summary>
        /// <value>The current value setter.</value>
        Action<T> CurrentValueSetter { get; set; }
    }
}
