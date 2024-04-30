using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Room : MonoBehaviour, IClickable
{
    public int roomLevel;
    
    public bool isOccupied;
    public bool isAssisted;
    public GameObject currentMonster;
    public GameObject currentAssistant;
    public Assistant currentAssistantRef;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] doorLevelSprites;

    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        updateLevelSprite();
    }

    private void Update()
    {
        /*if (isOccupied)
        {
            //currentMonster.GetComponent<Monster>().TimeInRoom += Time.deltaTime;
        }*/
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
            InputManager.Instance.clearSelected();
        }
        else if (selectedObject.GetComponent<RoomUpgrade>() != null)
        {
            levelUp();
            InputManager.Instance.clearSelected();
        }
        else if (selectedObject.GetComponent<Assistant>() != null && isOccupied && InputManager.Instance.roomOk == true)
        {
            GetComponent<DoorState>().isOpen = true;
            //currentAssistant = selectedObject;
            //currentAssistant =InputManager.Instance._pilaNueva.servicioHabitacion();
            currentAssistant = InputManager.Instance._pilaNueva._pilaAux.LastItem();
            InputManager.Instance._pilaNueva.pruebaPop();
            isAssisted = true;
            currentAssistantRef = currentAssistant.GetComponent<Assistant>();
            InputManager.Instance.roomOk = false;
            
            
            
            
            
            // currentAssistant.transform.position = this.transform.position;
            currentAssistantRef.EnterRoom(this);
        }
    }

    private void levelUp()
    {
        if (roomLevel < 2 && GameManager.Instance.Currency >= 100)
        {
            GameManager.Instance.Currency -= 100;
            roomLevel++;
        } else if (GameManager.Instance.Currency < 100)
        {
            Debug.Log("No tenes suficiente oro!");
        }
        updateLevelSprite();
    }

    private void updateLevelSprite()
    {
        if (roomLevel > 2)
        {
            roomLevel = 2;
        }
        _spriteRenderer.sprite = doorLevelSprites[roomLevel];
    }

    public void roomCleared()
    {
        currentMonster = null;
        isOccupied = false;
    }

    public void assistantCleared()
    {
        currentAssistant = null;
        isAssisted = false;
    }
}