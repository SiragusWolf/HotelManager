using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, IClickable
{
    [SerializeField] bool isOccupied;
    [SerializeField] private GameObject currentMonster;
    
    public void OnClick(GameObject selectedObject)
    {
        if (selectedObject.GetComponent<Monster>() != null && !isOccupied)
        {
            GetComponent<DoorState>().isOpen = true;
            currentMonster = selectedObject;
            selectedObject.GetComponent<Monster>().EnterRoom();
            isOccupied = true;
            Debug.Log(("Se metió al monstruo ", selectedObject.name));
        }
    }
}