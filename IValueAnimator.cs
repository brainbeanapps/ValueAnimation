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
        /// Gets a value indicating whether the animation is running.
        /// </summary>
        /// <value><c>true</c> if the animation is running; otherwise, <c>false</c>.</value>
        bool IsRunning { get; }

        /// <summary>
        /// Gets the duration of the animation.
        /// </summary>
        /// <value>The duration, measured in seconds.</value>
        float Duration { get; set; }

        /// <summary>
        /// Gets the position of the animation.
        /// </summary>
        /// <value>The position, measured in seconds.</value>
        float Position { get; set; }

        /// <summary>
        /// Gets the time since the animation start.
        /// </summary>
        /// <value>The time since the animation start, measured in seconds.</value>
        float TimeSinceStart { get; }

        /// <summary>
        /// Gets a value indicating whether the animation is completed.
        /// </summary>
        /// <value><c>true</c> if the animation is completed; otherwise, <c>false</c>.</value>
        bool IsCompleted { get; }

        /// <summary>
        /// Occurs when the animation is started.
        /// </summary>
        event EventHandler Started;

        /// <summary>
        /// Occurs when the animation is suspended.
        /// </summary>
        event EventHandler Suspended;

        /// <summary>
        /// Occurs when the animation is resumed.
        /// </summary>
        event EventHandler Resumed;

        /// <summary>
        /// Occurs when the animation is completed.
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// Occurs when the animation is updated.
        /// </summary>
        event EventHandler Updated;

        /// <summary>
        /// Suspend the animation.
        /// </summary>
        void Suspend();

        /// <summary>
        /// Resume the animation.
        /// </summary>
        void Resume();

        /// <summary>
        /// Restart the animation.
        /// </summary>
        void Restart();

        /// <summary>
        /// Gets or sets the object that contains data about the animation.
        /// </summary>
        /// <value>An Object that contains data about the animation. The default is null.</value>
        object Tag { get; set; }

        // type of animation (function?)
    }
}
