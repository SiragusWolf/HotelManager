using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isOccupied;
    private Monster currentMonster;
    
    public Monster CurrentMonster
    {
        get => currentMonster;
        set => currentMonster = value;
    }
    
    
}
