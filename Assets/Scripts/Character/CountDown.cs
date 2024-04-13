using System;
using UnityEngine;

namespace Character
{
    public class CountDown : MonoBehaviour {
        public int timeLeft = 120;

        private void Start()
        {
            InvokeRepeating(nameof(updateTimeLeft), 0, 1f);
        }
   
        void updateTimeLeft()
        {   
            timeLeft -= 1;
            if (timeLeft <= 0)
            {   
                // gameObject.GetComponent<Health>().Death();
                GameObject.FindWithTag("Player").GetComponent<Health>().Death();
            }
        }
    }
}
