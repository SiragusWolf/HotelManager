using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private float timeSinceLastMonster;
    [SerializeField] private float timeForNextMonster;
    private ColaTest MonsterQueue;
    private TimeManager tm;
    public float Currency;
    [SerializeField] private float satisfactionGoal;
    public float TotalSatisfaction;
    
    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        Instance = this;

        MonsterQueue = FindObjectOfType<ColaTest>();
        tm = FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        timeSinceLastMonster += Time.deltaTime;
        if (timeSinceLastMonster > timeForNextMonster)
        {
            NewMonster();
            NewMonsterTime();
            timeSinceLastMonster = 0;
        }

        if (tm.TotalTime > tm.dayDuration * 4)
        {
            if (TotalSatisfaction >= satisfactionGoal)
            {
                Debug.Log("You win!");
            }
            else
            {
                Debug.Log("You lose :(");
            }
        }
    }

    private void NewMonster()
    {
        MonsterQueue.MonstruoIngresando();
    }

    private void NewMonsterTime()
    {
        timeForNextMonster = Random.Range(5, 15);
    }
    
    

  
    
    

}
