using System;

namespace BrainbeanApps.ValueAnimation
{
    public class SingleValueOperations : IValueOperations<Single>
    {
        public Single Add(Single l, Single r)
        {
            return l + r;
        }

        public Single Subtract(Single l, Single r)
        {
            return l - r;
        }

        public Single MultiplyBySingle(Single value, float factor)
        {
            return value * factor;
        }

        public Single DivideByTwo(Single value)
        {
            return value * 0.5f;
        }
    }
}
