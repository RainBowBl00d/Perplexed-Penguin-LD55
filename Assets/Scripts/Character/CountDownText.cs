using Character;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

    public class CountDownText : MonoBehaviour
    {
        TMP_Text _timerText;

        // Start is called before the first frame update
        void Start()
        {
            _timerText = GetComponent<TMP_Text>();
            InvokeRepeating(nameof(updateTimer), 0, 1f);
        }
        

        void updateTimer()
        {   
            Debug.Log(gameObject.GetComponent<CountDown>().timeLeft.ToString());
            _timerText.text = gameObject.GetComponent<CountDown>().timeLeft.ToString();
        }
        #region Instance Managment
        public static CountDownText instance;
        void InstanceAwake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else Destroy(gameObject);
        }
  
        #endregion
    
    }
    
    

