using System;
using System.Collections.Generic;

namespace BrainbeanApps.ValueAnimation
{
    /// <summary>
    /// Value operations register.
    /// </summary>
    public static class ValueOperations
    {
        /// <summary>
        /// The register.
        /// </summary>
        private static readonly IDictionary<Type, object> register = new Dictionary<Type, object>();

        static ValueOperations()
        {
            register.Add(typeof(Int32), new Int32ValueOperations());
            register.Add(typeof(Single), new SingleValueOperations());
        }

        /// <summary>
        /// Gets the IValueOperations<T> instance for specified type
        /// </summary>
        /// <typeparam name="T">Type in the IValueOperations<T> instance.</typeparam>
        public static IValueOperations<T> For<T>()
            where T : struct, IComparable
        {
            lock (register)
            {
                object valueOperations;
                if (!register.TryGetValue(typeof(T), out valueOperations))
                    throw new ArgumentException();
                return (IValueOperations<T>)valueOperations;
            }
        }

        /// <summary>
        /// Registers the IValueOperations<T> instance for specified type.
        /// </summary>
        /// <param name="valueOperations">Value operations.</param>
        /// <typeparam name="T">Type in the IValueOperations<T> instance.</typeparam>
        public static void RegisterFor<T>(IValueOperations<T> valueOperations)
            where T : struct, IComparable
        {
            if (valueOperations == null)
                throw new ArgumentNullException();

            lock (register)
            {
                try
                {
                    register.Add(typeof(T), valueOperations);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Unregisters the IValueOperations<T> instance for specified type.
        /// </summary>
        /// <typeparam name="T">Type in the IValueOperations<T> instance.</typeparam>
        public static void UnregisterFor<T>()
            where T : struct, IComparable
        {
            lock (register)
            {
                if (!register.Remove(typeof(T)))
                    throw new ArgumentException();
            }
        }
    }
}
