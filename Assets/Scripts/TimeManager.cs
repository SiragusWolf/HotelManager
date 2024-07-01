using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mathf = UnityEngine.Mathf;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;

    public float dayDuration;

    public float totalTime = 0;

    [SerializeField] private bool ffw;

    public float TotalTime
    {
        get { return totalTime; }
    }

    float currentTime = 0;

    [SerializeField] private GameObject noche;
    //[SerializeField] private GameObject dia;
    

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        currentTime = totalTime % dayDuration;
        if (currentTime < (dayDuration * 0.3) || currentTime > (dayDuration * 0.8))
        {
            noche.SetActive(true);
        }
        else
        {
            noche.SetActive(false);
        }

        if (ffw)
        {
            totalTime += 25;
            ffw = false;
        }
    }

    public float GetHour()
    {
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursInDay * minutesInHour / dayDuration)%minutesInHour;
    }

    public string Clock24Hour()
    {
        //00:00
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    public string Clock12Hour()
    {
        int hour = Mathf.FloorToInt(GetHour());
        string abbreviation = "AM";

        if (hour >= 12)
        {
            abbreviation = "PM";
            hour -= 12;
        }

        if (hour == 0) hour = 12;

        return hour.ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") + " " + abbreviation;
    }
}
