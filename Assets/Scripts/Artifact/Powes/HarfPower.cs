using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarfPower : MonoBehaviour
{
    [SerializeField] int addTime;
    public void Power()
    {
        if (addTime + PlayerStats.instance.timeLeftTilEnd > 120f) return;
        PlayerStats.instance.timeLeftTilEnd += addTime;
    }
}
