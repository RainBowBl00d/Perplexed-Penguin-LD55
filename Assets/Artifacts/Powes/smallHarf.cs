using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallHarf : MonoBehaviour

{
    [SerializeField] int healing;
    public void Power()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().AddHealth(healing);
    }
}
