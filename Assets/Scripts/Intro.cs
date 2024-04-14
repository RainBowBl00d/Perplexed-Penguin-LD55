using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private int index = 1;

    public void buttonNext()
    {
        index += 1;

        switch (index) {
            case 2 :
                GameObject.Find("panel1").SetActive(false);
                GameObject.Find("panel2").SetActive(true);
                return;
            case 3:
                GameObject.Find("panel2").SetActive(false);
                GameObject.Find("panel3").SetActive(true);
                return;
            case 4:
                GameObject.Find("panel3").SetActive(false);
                GameObject.Find("panel4").SetActive(true);
                return;
            case 5:
                SceneManager.LoadScene(2);
                return;
                
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
