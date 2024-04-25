using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireman : Monster, ISelectable
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Room room;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (!isInRoom)
        {
            _rb.velocity = new Vector2(2, 0);
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
            Satisfaction += Time.deltaTime * room.roomLevel;
            if (TimeInRoom > stayTime)
            {
                Debug.Log(this.name + " se va! Satisfacción final: " + Satisfaction);
                room.isOccupied = false;
                if (Satisfaction > 0)
                {
                    GameManager.Instance.Currency += Satisfaction;
                }
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

    public override void moveUpQueue()
    {
        _rb.velocity = new Vector2(5*Time.deltaTime, 0);
    }
}
