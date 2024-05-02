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
    public ColaNueva monsterQueueNueva;
    private TimeManager tm;
    public float Currency;
    [SerializeField] private float satisfactionGoal;
    public float TotalSatisfaction;

    public GameObject UIWin;
    public GameObject UILose;
    public GameObject[] Piso2;

    public bool isPause;
    public GameObject pauseUI;
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
                UIWin.SetActive(true);
            }
            else
            {
                UILose.SetActive(true);
                Debug.Log("You lose :(");
            }
        }
    }

    public void ComprarPiso2()
    {
        if (Currency > 300)
        {
            for (int i = 0; i < Piso2.Length; i++)
            {
                Piso2[i].SetActive(true);
            }

            Currency -= 300;
        }


    }


    public void Pausa()
    {
        if (isPause == false)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            //InputManager.Instance.gameObject.SetActive(false);
            isPause = true;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
            //InputManager.Instance.gameObject.SetActive(false);
            isPause = false;
        }
    }

private void NewMonster()
    {
        //MonsterQueue.MonstruoIngresando();
        monsterQueueNueva.MonstruoIngresando();
    }

    private void NewMonsterTime()
    {
        timeForNextMonster = Random.Range(5, 15);
    }
    
    

  
    
    

}
