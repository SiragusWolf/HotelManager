using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster, ISelectable
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
                Destroy(this.gameObject);
            }
        }
    }
    public void OnSelect()
    {
        Debug.Log("Slime seleccionado");
    }

    public void OnDeselect()
    {
        Debug.Log("Slime deseleccionado");
    }
    
    public override void EnterRoom(Room room)
    {
        isInRoom = true;
        _spriteRenderer.enabled = false;
        transform.position = room.transform.position;
        this.room = room;
    }
}
