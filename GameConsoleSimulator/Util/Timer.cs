using System;
using NodaTime;

namespace Chess.Utility
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

        public void Start()
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
        
        public void Start(Duration duration)
        {
            this.Duration = duration;
            base.Start();
        }
    }
}