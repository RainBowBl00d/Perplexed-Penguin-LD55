using System.Collections.Generic;
using UnityEngine;

public class PlayerArtifacts : MonoBehaviour
{
    public List<Items> artifacts = new List<Items>();

    [SerializeField] KeyCode violinKeyCode;
    [SerializeField] KeyCode harfKeyCode;
    [SerializeField] KeyCode smallHarfKeyCode;
    [SerializeField] KeyCode quitarKeyCode;
    [SerializeField] KeyCode sazKeyCode;

    float timeLeftHarf = 0f;
    float timeLeftSmallHarf = 0f;

    [SerializeField] float cooldownHarf = 0f;
    [SerializeField] float cooldownSmallharf = 0f;




    private void Update()
    {
        timeLeftHarf += Time.deltaTime;
        timeLeftSmallHarf += Time.deltaTime;
        if (Input.GetKeyDown(violinKeyCode) && cooldownHarf <= timeLeftHarf)
        {
            UseVioln();
            timeLeftHarf = 0f;
        }
        if (Input.GetKeyDown(harfKeyCode)  && cooldownSmallharf <= timeLeftSmallHarf)
        {
            UseHarf();
            timeLeftSmallHarf = 0f;
        }
        if (Input.GetKeyDown(smallHarfKeyCode) && cooldownSmallharf <= timeLeftSmallHarf)
        {
            UseSmallHarf();
        }
        if (Input.GetKeyDown(quitarKeyCode))
        {
            UseGuitar();
        }
        if (Input.GetKeyDown(sazKeyCode))
        {
            UseSaz();
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
    public void UseHarf()
    {
        foreach (Items artifact in artifacts)
        {
            if (artifact.name == "Harf" && artifact.isActive)
            {
                artifact.gameObject.GetComponent<HarfPower>().Power();
            }
        }
    }
    public void UseSmallHarf()
    {
        foreach (Items artifact in artifacts)
        {
            if (artifact.name == "smallharf" && artifact.isActive)
            {
                artifact.gameObject.GetComponent<smallHarf>().Power();
            }
        }
    }
    public void UseGuitar()
    {
        foreach (Items artifact in artifacts)
        {
            if (artifact.name == "Guitar" && artifact.isActive)
            {
                artifact.gameObject.GetComponent<GuitarPower>().Power();
            }
        }
    }
    public void UseSaz()
    {
        foreach (Items artifact in artifacts)
        {
            if (artifact.name == "saz" && artifact.isActive)
            {
                artifact.gameObject.GetComponent<sazPower>().Power();
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
