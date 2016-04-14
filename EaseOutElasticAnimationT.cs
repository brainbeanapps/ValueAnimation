using System;

namespace BrainbeanApps.ValueAnimation
{
    public class EaseOutElasticAnimation<T> : BaseElasticAnimation<T>, IValueAnimation<T>
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
//            var factor = (float)Math.Pow(currentTime / duration, Power);
//            var value = ValueOperations.ScaleByFactor(deltaValue, factor);
//            return ValueOperations.Add(initialValue, value);
            return default(T);
        }
    }
}
