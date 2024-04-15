using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactUI : MonoBehaviour
{
    public static ArtifactUI instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] public GameObject violinSquere;
    [SerializeField] public GameObject harfSquere;
    [SerializeField] public GameObject smallHarfSquere;
    [SerializeField] public GameObject guitarSquere;
    [SerializeField] public GameObject saxaphoneSquere;
}
