using System;
using UnityEngine;

namespace Becloned
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float _gameTime;
        
        public float Timer { get; private set; }
        public event Action OnTimeFinished;

        private void Start()
        {
            Timer = _gameTime;           
        }

        private void Update()
        {
            ExecuteTimer();
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
    }
}

