using System;
using NodaTime;

namespace GameConsoleSimulator.Util
{
    public class Timer 
    {
        private Instant startTime;
        
        public Duration TimeElapsed 
        {
            get 
            {
                if (Started == false)
                {
                    throw new Exception("Timer was never started.");
                }

                Instant currentTime = SystemClock.Instance.GetCurrentInstant();
                Duration timeElapsed = currentTime - startTime;
                return timeElapsed;
            }
        }
        
        public bool Started { get; private set; } = false;

        public virtual void Start()
        {
            Reset();
            Started = true;
        }

        public Duration Stop()
        {
            Duration timeElapsed = TimeElapsed;
            Started = false;
            return timeElapsed;
        }
        
        public void Reset()
        {
            startTime = SystemClock.Instance.GetCurrentInstant();
        }
    }
    
    public class CountdownTimer : Timer
    {
        public Duration Duration { get; set; }

        public bool Complete
        {
            get { return (TimeElapsed >= Duration); }
        }

        public override void Start()
        {
            Start(Duration);
        }

        public void Start(Duration duration)
        {
            this.Duration = duration;
            base.Start();
        }
    }
}