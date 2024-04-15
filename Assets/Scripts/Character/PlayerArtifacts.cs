using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerArtifacts : MonoBehaviour
{
    public void AddArtifact(GameObject artifact)
    {
        foreach (Items artifacty in PlayerStats.instance.artifacts)
        {
            if (artifacty.name == artifact.GetComponent<Artifact>().identify && !artifacty.isActive)
            {
                artifacty.isActive = true;
                artifacty.picture.SetActive(true);

            }
        }

        Destroy(artifact);
    }

    public void UseVioln(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton()) return;
        foreach (Items artifact in PlayerStats.instance.artifacts)
        {
            if (artifact.name == "Violin" && artifact.isActive && PlayerStats.instance.mana.health > PlayerStats.instance.manaCostViolin)
            {
                PlayerStats.instance.mana.SubtractHealt(PlayerStats.instance.manaCostViolin);
                artifact.gameObject.GetComponent<ViolinPower>().Power();
                
            }
        }
    }
    public void UseHarf(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton()) return;
        foreach (Items artifact in PlayerStats.instance.artifacts)
        {
            if (artifact.name == "Harf" && artifact.isActive && PlayerStats.instance.mana.health > PlayerStats.instance.manaCostHarf)
            {
                PlayerStats.instance.mana.SubtractHealt(PlayerStats.instance.manaCostHarf);
                artifact.gameObject.GetComponent<HarfPower>().Power();
            }
        }
    }
    public void UseSmallHarf(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton()) return;
        foreach (Items artifact in PlayerStats.instance.artifacts)
        {
            if (artifact.name == "Small Harf" && artifact.isActive && PlayerStats.instance.mana.health > PlayerStats.instance.manaCostSmallHarf)
            {
                PlayerStats.instance.mana.SubtractHealt(PlayerStats.instance.manaCostSmallHarf);
                artifact.gameObject.GetComponent<smallHarf>().Power();
            }
        }
    }

    public void UseGuitar(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton()) return;
        foreach (Items artifact in PlayerStats.instance.artifacts)
        {
            if (artifact.name == "Guitar" && artifact.isActive && PlayerStats.instance.mana.health > PlayerStats.instance.manaCostGuitar)
            {
                PlayerStats.instance.mana.SubtractHealt(PlayerStats.instance.manaCostGuitar);
                artifact.gameObject.GetComponent<GuitarPower>().Power();
            }
        }
    }
    public void UseSaz(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton()) return;
        foreach (Items artifact in PlayerStats.instance.artifacts)
        {
            if (artifact.name == "Saxaphone" && artifact.isActive && PlayerStats.instance.mana.health > PlayerStats.instance.manaCostSaxaphone)
            {
                PlayerStats.instance.mana.SubtractHealt(PlayerStats.instance.manaCostSaxaphone);
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
    public GameObject picture;
}
