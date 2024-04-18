using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public bool isInRoom;
    public float Satisfaction;
    public float TimeWaiting;
    [SerializeField] protected float patience;
    public float TimeInRoom;
    [SerializeField] protected float stayTime;
    
    
    public virtual void EnterRoom(Room room){}
    
    public virtual void ExitRoom(){}
}
