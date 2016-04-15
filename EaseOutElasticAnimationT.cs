using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutElasticAnimation<T> : BaseElasticAnimation<T>, IValueAnimation<T>
        where T : struct, IComparable
    {
        public EaseOutElasticAnimation(int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            : this(ValueAnimation.ValueOperations.For<T>(), oscillations, springiness)
        {
        }

        public EaseOutElasticAnimation(IValueOperations<T> valueOperations,
            int oscillations = ElasticAnimation.DefaultOscillations,
            float springiness = ElasticAnimation.DefalutSpringiness)
            : base(valueOperations, oscillations, springiness)
        {
        }

        public T GetValue(float currentTime, float duration, T initialValue, T deltaValue)
        {
            return base.GetValue(currentTime, duration, initialValue, deltaValue, true);
        }
    }
}
