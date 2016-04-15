using System;

namespace BrainbeanApps.ValueAnimation
{
    public delegate T ValueAnimation<T>(float currentTime, float duration, T initialValue, T deltaValue)
        where T : struct, IComparable;
}
