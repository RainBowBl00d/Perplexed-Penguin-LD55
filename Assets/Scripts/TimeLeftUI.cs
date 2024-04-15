using TMPro;
using UnityEngine;

public class TimeLeftUI : MonoBehaviour
{
    TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.RoundToInt(PlayerStats.instance.timeLeftTilEnd).ToString();
    }
}
