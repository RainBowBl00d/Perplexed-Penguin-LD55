using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarAnimation : MonoBehaviour
{
    Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = ((float)PlayerStats.instance.health.health / (float)PlayerStats.instance.health.maxHealth);
    }
}
