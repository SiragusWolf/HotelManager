using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assistant : MonoBehaviour, ISelectable
{
    public bool isInRoom;
    private SpriteRenderer _spriteRenderer;
    public Room room;
    public float AssistantSkill;
    public float ServiceTime;
    public bool FireFriendly;
    public bool SlimeFriendly;
    public bool FishFriendly;
    public bool GhostFriendly;
    [SerializeField] private float TimeElapsed;
    private AssistantsManager assManager;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        assManager = GameObject.FindGameObjectWithTag("AssistantManager").GetComponent<AssistantsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRoom)
        {
            if (TimeElapsed < ServiceTime)
            {
                TimeElapsed += Time.deltaTime;
            }
            else
            {
                ExitRoom();
            }
        }
    }

    public void EnterRoom(Room room)
    {
        isInRoom = true;
        _spriteRenderer.enabled = false;
        transform.position = room.transform.position;
        this.room = room;
        assManager.RoomService(this.gameObject, room.gameObject);
    }

    public void ExitRoom()
    {
        isInRoom = false;
        room = null;
        _spriteRenderer.enabled = true;
        //transform.position = assManager.
    }

    public void OnSelect()
    {
        
    }

    public void OnDeselect()
    {
        
    }
}
