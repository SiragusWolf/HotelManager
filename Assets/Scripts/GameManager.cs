using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Events;

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
    private bool gameEnded;

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

        bestTimes[0] = int.MaxValue;
        bestTimes[1] = int.MaxValue;
        bestTimes[2] = int.MaxValue;
    }

    private void Update()
    {
        if (gameEnded) return;

        timeSinceLastMonster += Time.deltaTime;
        if (timeSinceLastMonster > timeForNextMonster)
        {
            NewMonster();
            NewMonsterTime();
            timeSinceLastMonster = 0;
        }

        if (tm.TotalTime > tm.dayDuration * 3)
        {
            EndGame();
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
            isPause = true;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
    }

    private void NewMonster()
    {
        ColaNueva.Instance.MonstruoIngresando();
    }

    private void NewMonsterTime()
    {
        timeForNextMonster = Random.Range(5, 15);
    }

    private void EndGame()
    {
        gameEnded = true;
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

    public int[] bestTimes = new int[3];
    public UnityEvent NewBestTimes = new UnityEvent();

    public void WaitBestTimes(int time)
    {
        for (int i = 0; i < bestTimes.Length; i++)
        {
            if (time >= bestTimes[i]) continue;

            for (int j = bestTimes.Length - 1; j > i; j--)
            {
                bestTimes[j] = bestTimes[j - 1];
            }

            bestTimes[i] = time;
            break;
        }

        NewBestTimes.Invoke();
    }
}
