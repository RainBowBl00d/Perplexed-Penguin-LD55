using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private int index = 1;
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject panel3;
    [SerializeField] private GameObject panel4;

    public void buttonNext()
    {
        index += 1;

        switch (index) {
            case 2 : 
                panel1.SetActive(false);
                panel2.SetActive(true);
                return;
            case 3:
                panel2.SetActive(false);
                panel3.SetActive(true);
                return;
            case 4:
                panel3.SetActive(false);
                panel4.SetActive(true);
                return;
            case 5:
                SceneManager.LoadScene(2);
                return;
                
        }
    }
    #region Instance Managment
    public static Intro instance;
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
