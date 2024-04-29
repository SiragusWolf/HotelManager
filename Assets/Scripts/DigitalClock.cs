using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    private TimeManager tm;
    private TextMeshProUGUI display;

    public bool _24HourClock = true;

    void Start()
    {
        tm = FindObjectOfType<TimeManager>();
        display = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        display.text = _24HourClock ? tm.Clock24Hour() : tm.Clock12Hour();
    }
}
