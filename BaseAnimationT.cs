using System;

namespace BrainbeanApps.ValueAnimation
{
    public abstract class BaseAnimation<T>
        where T : struct, IComparable
    {
        /// <summary>
        /// Operations for specific value type.
        /// </summary>
        public readonly IValueOperations<T> ValueOperations;

        public BaseAnimation(IValueOperations<T> valueOperations)
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            ValueOperations = valueOperations;
        }
    }
}
