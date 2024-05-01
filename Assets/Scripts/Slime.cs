using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster, ISelectable
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Room room;
    private float assistantMod = 0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (!isInRoom)
        {
            _rb.velocity = new Vector2(3, 0);
            TimeWaiting += Time.deltaTime;
            if (TimeWaiting > patience)
            {
                Satisfaction -= Time.deltaTime * 0.1f;
                //Debug.Log(this.name + " está impaciente!");
            }
        }

        if (isInRoom)
        {
            if (room.isAssisted)
            {
                assistantMod = room.currentAssistantRef.AssistantSkill;
                if (room.currentAssistantRef.SlimeFriendly)
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
                }
                Destroy(this.gameObject);
            }
        }
    }
    public void OnSelect()
    {
        //Debug.Log("Slime seleccionado");
    }

    public void OnDeselect()
    {
        //Debug.Log("Slime deseleccionado");
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
