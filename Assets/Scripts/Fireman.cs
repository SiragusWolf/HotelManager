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
    private float assistantMod;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        isInRoom = false;
        //this.transform.position = new Vector3(0, 0, 0);
    }

    public void Update()
    {
        if (!isInRoom)
        {
            //_rb.velocity = new Vector2(2, 0);
            TimeWaiting += Time.deltaTime;
            if (TimeWaiting > patience)
            {
                Satisfaction -= Time.deltaTime * 0.1f;
                //Debug.Log(this.name + " esta impaciente!");
            }
        }

        if (!isInRoom) return;
        
            if (room.isAssisted)
            {
                assistantMod = room.currentAssistantRef.AssistantSkill;
                if (room.currentAssistantRef.FireFriendly)
                {
                    assistantMod = room.currentAssistantRef.AssistantSkill * 2;
                }
            }
            else
            {
                assistantMod = 0;
            }
            
            TimeInRoom += Time.deltaTime;
            Satisfaction += Time.deltaTime * room.roomLevel + Time.deltaTime * assistantMod;
            
            if (TimeInRoom > stayTime)
            {
                Debug.Log(this.name + " se va! Satisfacción final: " + Satisfaction);
                room.roomCleared();
                if (Satisfaction > 0)
                {
                    GameManager.Instance.Currency += Satisfaction;
                    GameManager.Instance.TotalSatisfaction += Satisfaction;
                    BusquedaBinaria.Instance.AddNode(Satisfaction);
                }
                //room.currentMonster = null;
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
    }

    public void OnSelect()
    {
        //Debug.Log("Fireman seleccionado");
    }

    public void OnDeselect()
    {
        //Debug.Log("Fireman deseleccionado");
    }

    public override void EnterRoom(Room room)
    {
        isInRoom = true;
        //_spriteRenderer.enabled = false;
        //transform.position = room.transform.position;

        GameManager.Instance.WaitBestTimes((int)TimeWaiting);
        GameObject hotelObj = GameObject.FindGameObjectWithTag("Hotel");
        Hotel hotelRef = hotelObj.GetComponent<Hotel>();
        
        this.room = room;
        GetComponent<MovDijkstra>().Movimiento(hotelRef, this.room.gameObject);
    }

    public override void moveUpQueue()
    {
        //_rb.velocity = new Vector2(5*Time.deltaTime, 0);
    }
}
