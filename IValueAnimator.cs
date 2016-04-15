using System;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Defines methods to manipulate value animator.
    /// </summary>
    public interface IValueAnimator
    {
        /// <summary>
        /// Gets and sets the delay of the animation start.
        /// </summary>
        /// <value>The delay, measured in seconds.</value>
        float Delay { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        float Duration { get; set; }

        /// <summary>
        /// Gets the position of the animation.
        /// </summary>
        /// <value>The position, measured in seconds.</value>
        float Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is paused.
        /// </summary>
        /// <value><c>true</c> if this instance is paused; otherwise, <c>false</c>.</value>
        bool IsPaused { get; set; }

        /// <summary>
        /// Gets the time passed.
        /// </summary>
        /// <value>The time passed.</value>
        float TimePassed { get; }

        /// <summary>
        /// Gets a value indicating whether the animation is completed.
        /// </summary>
        /// <value><c>true</c> if the animation is completed; otherwise, <c>false</c>.</value>
        bool IsCompleted { get; }

        /// <summary>
        /// Process the animation using the specified deltaTime.
        /// </summary>
        /// <param name="deltaTime">Delta time.</param>
        void Process(float deltaTime);

        /// <summary>
        /// Reset this instance.
        /// </summary>
        void Reset();

        //        /// <summary>
//        /// Occurs when the animation is started.
//        /// </summary>
//        event EventHandler<ValueAnimatorEventArgs> StartedEvent;

//        /// <summary>
//        /// Occurs when the animation is suspended.
//        /// </summary>
//        event EventHandler Suspended;
//
//        /// <summary>
//        /// Occurs when the animation is resumed.
//        /// </summary>
//        event EventHandler Resumed;
//

//

        /// <summary>
        /// Occurs when the animation is updated.
        /// </summary>
        event EventHandler UpdatedEvent;

        /// <summary>
        /// Occurs when the animation is completed.
        /// </summary>
        event EventHandler CompletedEvent;
    }
}
