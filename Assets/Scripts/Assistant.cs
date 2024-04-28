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
    //forma provisional de darle "tipos" a los asistentes
    [SerializeField] private float TimeElapsed;
    private AssistantsManager assManager;
    public GameObject currentPosition;
    private GameObject newPosition;

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
        transform.position = room.transform.position;
        _spriteRenderer.enabled = false;
        this.room = room;
        assManager.RoomService(this.gameObject, room.gameObject);
        currentPosition.GetComponent<PilaPosition>().clearPosition();
    }

    public void ExitRoom()
    {
        _spriteRenderer.enabled = true;
        room.assistantCleared();
        assManager.Push(this.gameObject);

        newPosition = assManager.getLastPosition();
        newPosition.GetComponent<PilaPosition>().assignPosition(this.gameObject);
        transform.position = newPosition.GetComponent<Transform>().position;
        isInRoom = false;
        room = null;
        //newPosition = null;
    }

    public void OnSelect()
    {
        
    }

    public void OnDeselect()
    {
        
    }
}
