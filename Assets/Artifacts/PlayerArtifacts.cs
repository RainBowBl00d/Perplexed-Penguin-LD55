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
    
    [SerializeField] private GameObject Button1;
    [SerializeField] private GameObject Button2;
    [SerializeField] private GameObject Button3;
    [SerializeField] private GameObject Button4;
    [SerializeField] private GameObject Button5;

    float timeLeftHarf = 0f;
    float timeLeftSmallHarf = 0f;

    [SerializeField] float cooldownHarf = 0f;
    [SerializeField] float cooldownSmallharf = 0f;




    private void Update()
    {
        timeLeftHarf += Time.deltaTime;
        timeLeftSmallHarf += Time.deltaTime;
        if (Input.GetKeyDown(violinKeyCode) )
        {
            UseVioln();
        }
        if (Input.GetKeyDown(harfKeyCode)  && cooldownSmallharf <= timeLeftSmallHarf)
        {
            UseHarf();
            timeLeftHarf = 0f;

        }
        if (Input.GetKeyDown(smallHarfKeyCode) && cooldownHarf <= timeLeftHarf)
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
                AudioManager.instance.Play(artifacty.name);
                artifacty.isActive = true;
                // Debug.Log("viiul " + artifact.GetComponent<Artifact>().identify);
                
                switch (artifact.GetComponent<Artifact>().identify)
                {
                    case "violin":
                        Button1.SetActive(true);
                        return;
                    case "Guitar":
                        Button2.SetActive(true);
                        return;
                    case "smallharf":
                        Button3.SetActive(true);
                        return;
                    case "saz":
                        Button4.SetActive(true);
                        return;
                    case "Harf":
                        Button5.SetActive(true);
                        return;
                
                }
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
