using System;

namespace BrainbeanApps.ValueAnimation
{
    public class ValueAnimator<T> : IValueAnimator<T>
        where T : struct, IComparable
    {
        public ValueAnimation<T> Animation { get; set; }
        public T? InitialValue { get; set; }
        public Func<T> InitialValueGetter { get; set; }
        public T? DeltaValue { get; set; }
        public Func<T> DeltaValueGetter { get; set; }
        public T? CurrentValue { get; private set; }
        public Action<T> CurrentValueSetter { get; set; }
        public float Delay { get; set; }
        public float Duration { get; set; }
        public float Position { get; set; }
        public bool IsPaused { get; set; }
        public float TimePassed { get; private set; }
        public bool IsCompleted
        {
            get
            {
                return TimePassed - Delay > Duration;
            }
        }
        public event EventHandler UpdatedEvent;
        public event EventHandler CompletedEvent;

        public void Process(float deltaTime)
        {
            if (IsPaused)
                return;
            var wasCompleted = IsCompleted;
            TimePassed += deltaTime;
            if (TimePassed < Delay || wasCompleted)
                return;

            if (InitialValue == null)
            {
                if (InitialValueGetter == null)
                    throw new InvalidOperationException();
                InitialValue = InitialValueGetter();
                if (InitialValue == null)
                    throw new InvalidOperationException();
            }

            if (DeltaValue == null)
            {
                if (DeltaValueGetter == null)
                    throw new InvalidOperationException();
                DeltaValue = DeltaValueGetter();
                if (DeltaValue == null)
                    throw new InvalidOperationException();
            }

            Position = Math.Min(TimePassed - Delay, Duration);
            CurrentValue = Animation(Position, Duration, InitialValue.Value, DeltaValue.Value);

            if (CurrentValueSetter != null)
                CurrentValueSetter(CurrentValue.Value);

            if (UpdatedEvent != null)
                UpdatedEvent(this, null);

            if (IsCompleted && CompletedEvent != null)
                CompletedEvent(this, null);
        }

        public void Reset()
        {
            if (InitialValueGetter != null)
                InitialValue = null;
            if (DeltaValueGetter != null)
                DeltaValue = null;
            CurrentValue = null;
            IsPaused = false;
            TimePassed = 0.0f;
        }
    }
}
