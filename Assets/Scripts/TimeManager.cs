using System;
using UnityEngine;

namespace Becloned
{
    public class TimeManager : MonoBehaviour
    {
        private float _gameTime = 50f;
        
        public float Timer { get; private set; }
        public event Action OnTimeFinished;

        public const string EnhancedTimeKey = "Enhanced Time";

        private void Start()
        {
            SetTimer();
        }

        private void Update()
        {
            ExecuteTimer();
        }

        private void SetTimer()
        {
            if (PlayerPrefs.HasKey(EnhancedTimeKey))
            {
                Timer = PlayerPrefs.GetFloat(EnhancedTimeKey, _gameTime);
                ClearTimer();
            }
            else
            {
                Timer = _gameTime;
            }
        }

        private void ExecuteTimer()
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                // add game over 
                if (OnTimeFinished != null)
                {
                    OnTimeFinished();
                }

                return;
            }
        }

        public void SetEnhancedTimer(int enhancedTime)
        {
            PlayerPrefs.SetFloat(EnhancedTimeKey, enhancedTime);
        }

        private void ClearTimer()
        {
            PlayerPrefs.DeleteKey(EnhancedTimeKey);
        }
    }
}

