using System.Collections.Generic;
using UnityEngine;

public class PlayerArtifacts : MonoBehaviour
{
    public List<GameObject> artifacts = new List<GameObject>();

    [SerializeField ] KeyCode violinkeyCode;

    private void Update()
    {
        if (Input.GetKeyDown(violinkeyCode))
        {
            UseVioln();
        }
    }




    public void AddArtifact(GameObject artifact)
    {
        if (!artifacts.Contains(artifact))
        {
            GameObject clone = Instantiate(artifact);
            Destroy(artifact);
            artifacts.Add(clone);
        }
    }
    public void UseVioln()
    {
        foreach (GameObject artifact in artifacts)
        {
            if(artifact.GetComponent<Artifact>().identify == "Violin")
            {
                Debug.Log("Here");
                artifact.GetComponent<ViolinPower>().Power();
            }
        }
    }

}
