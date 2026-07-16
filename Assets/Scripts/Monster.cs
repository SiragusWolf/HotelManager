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
    private bool waitingTimeRegistered;
    private float queueEnteredAt;
    private bool hasQueueEnterTime;
    
    
    public virtual void EnterRoom(Room room){}
    
    public virtual void ExitRoom(){}
    
    public virtual void moveUpQueue(){}

    public void BeginWaiting()
    {
        isInRoom = false;
        TimeWaiting = 0;
        TimeInRoom = 0;
        waitingTimeRegistered = false;
        queueEnteredAt = Time.time;
        hasQueueEnterTime = true;
    }

    protected void RegisterWaitingTime()
    {
        if (waitingTimeRegistered || GameManager.Instance == null) return;

        float waitTime = hasQueueEnterTime ? Time.time - queueEnteredAt : TimeWaiting;
        GameManager.Instance.WaitBestTimes(Mathf.RoundToInt(waitTime));
        waitingTimeRegistered = true;
    }
}
