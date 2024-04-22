using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, IClickable
{
    public int roomLevel;
    
    public bool isOccupied;
    public GameObject currentMonster;

    private void Update()
    {
        if (isOccupied)
        {
            currentMonster.GetComponent<Monster>().TimeInRoom += Time.deltaTime;
        }
    }

    public void OnClick(GameObject selectedObject)
    {
        if (selectedObject.GetComponent<Monster>() != null && !isOccupied)
        {
            GetComponent<DoorState>().isOpen = true;
            currentMonster = selectedObject;
            selectedObject.GetComponent<Monster>().EnterRoom(this);
            isOccupied = true;
            Debug.Log(("Se metió al monstruo ", selectedObject.name));
        }
    }

    private void levelUp()
    {
        
    }

    private void updateLevel()
    {
        
    }
    
}