using System;

namespace BrainbeanApps.ValueAnimation
{
    public class Int32ValueOperations : IValueOperations<Int32>
    {
        public Int32 Add(Int32 l, Int32 r)
        {
            return l + r;
        }

        public Int32 Subtract(Int32 l, Int32 r)
        {
            return l - r;
        }

        public Int32 ScaleByFactor(Int32 value, float factor)
        {
            return (Int32)(value * factor);
        }
    }
}
