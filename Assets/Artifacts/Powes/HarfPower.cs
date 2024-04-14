using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarfPower : MonoBehaviour
{
    [SerializeField] int addTime;
    public void Power()
    {
        CountDown.instance.timeLeft += addTime;
    }
}
