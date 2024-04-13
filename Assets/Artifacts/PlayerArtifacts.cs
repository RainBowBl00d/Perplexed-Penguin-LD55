using System.Collections.Generic;
using UnityEngine;

public class PlayerArtifacts : MonoBehaviour
{
    public List<Items> artifacts = new List<Items>();

    [SerializeField] KeyCode violinkeyCode;

    private void Update()
    {
        if (Input.GetKeyDown(violinkeyCode))
        {
            UseVioln();
        }
    }

    public void AddArtifact(GameObject artifact)
    {
        foreach (Items artifacty in artifacts)
        {
            if (artifacty.name == artifact.GetComponent<Artifact>().identify && !artifacty.isActive)
            {
                artifacty.isActive = true;
            }
        }

        Destroy(artifact);
    }

    public void UseVioln()
    {
        foreach (Items artifact in artifacts)
        {
            if (artifact.name == "Violin" && artifact.isActive)
            {
                artifact.gameObject.GetComponent<ViolinPower>().Power();
            }
        }
    }
}

[System.Serializable]
public class Items
{
    public string name;
    public bool isActive;
    public GameObject gameObject; 
}
