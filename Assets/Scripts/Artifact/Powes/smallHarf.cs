using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallHarf : MonoBehaviour

{
    [SerializeField] int healing;
    public void Power()
    {
        PlayerStats.instance.health.AddHealth(healing);
    }
}
