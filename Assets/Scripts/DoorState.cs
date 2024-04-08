using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState : MonoBehaviour
{
    public bool isOpen;
    private int openTimeElapsed;
    [SerializeField] private int openTimer;
    [SerializeField] private GameObject open_door;
    [SerializeField] private GameObject closed_door;

    void Update()
    {
        if (isOpen)
        {
            open_door.SetActive(true);
            openTimeElapsed++;
            if (openTimeElapsed > openTimer)
            {
                isOpen = false;
                open_door.SetActive(false);
                openTimeElapsed = 0;
            }
        }
    }
}
