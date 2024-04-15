using UnityEngine.SceneManagement;
using UnityEngine;

public class BossIntroTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
        
    }
}

