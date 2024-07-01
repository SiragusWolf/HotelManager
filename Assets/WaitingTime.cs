using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingTime : MonoBehaviour
{

    float time = 0;

    void Start()
    {
        InputManager.Instance.SetTime.AddListener(UpdateTime);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

    }

    public void UpdateTime()
    {
        GameManager.Instance.WaitBestTimes((int)time);



    }
    
}
