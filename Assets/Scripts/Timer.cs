using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float timeElapsed;
    private int minutes, seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        timeElapsed = timeElapsed+0.05f;
        timerText.text = timeElapsed.ToString();
        minutes = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - minutes*60f ) / 10;

        timerText.text = string.Format("{0:00}:{1}0", minutes, seconds);

        //Debug.Log(timeElapsed*10);
    }
}
