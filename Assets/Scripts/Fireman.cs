using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireman : Monster, ISelectable
{
    private SpriteRenderer _spriteRenderer;
    private Room room;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (!isInRoom)
        {
            TimeWaiting += Time.deltaTime;
            if (TimeWaiting > patience)
            {
                Satisfaction -= Time.deltaTime * 0.1f;
                Debug.Log(this.name + " está impaciente!");
            }
            
        }

        if (isInRoom)
        {
            TimeInRoom += Time.deltaTime;
            if (TimeInRoom > stayTime)
            {
                Debug.Log(this.name + " se va! Satisfacción final: " + Satisfaction);
                room.isOccupied = false;
                //room.currentMonster = null;
                Destroy(this.gameObject);
            }
        }
    }

    public void OnSelect()
    {
        Debug.Log("Fireman seleccionado");
    }

    public void OnDeselect()
    {
        Debug.Log("Fireman deseleccionado");
    }

    public override void EnterRoom(Room room)
    {
        isInRoom = true;
        _spriteRenderer.enabled = false;
        transform.position = room.transform.position;
        this.room = room;
    }
    
    
}
