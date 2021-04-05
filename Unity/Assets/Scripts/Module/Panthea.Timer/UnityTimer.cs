using UnityEngine;

    public class UnityTimer
    {
        private float TimeScale { get; set; }
        private int CountingPause { get; set; }

        public bool IsPause()
        {
            return Time.timeScale == 0;
        }
        
        public void SetTimeScale(float scale)
        {
            TimeScale = scale;
        }
        
        public void Pause()
        {
            if(CountingPause == 0)
                TimeScale = Time.timeScale;
            Time.timeScale = 0;
            CountingPause++;
        }

        public void Resume()
        {
            CountingPause = Mathf.Max(0, CountingPause - 1);
            if (CountingPause <= 0)
            {
                Time.timeScale = TimeScale;
            }
        }
    }
