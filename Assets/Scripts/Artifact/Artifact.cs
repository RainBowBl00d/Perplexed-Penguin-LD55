using UnityEngine;
public class Artifact : MonoBehaviour
{
    public string identify;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerArtifacts>().AddArtifact(gameObject);
        }
    }

}

