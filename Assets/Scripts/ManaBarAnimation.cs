using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarAnimation : MonoBehaviour
{
    Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = ((float)PlayerStats.instance.mana.health / (float)PlayerStats.instance.mana.maxHealth);
    }
}
