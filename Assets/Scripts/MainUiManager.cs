using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUiManager : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NewBestTimes.AddListener(SetTimez);
        }
        SetTimez();
    }

    private void Update()
    {
        SetTimez();
    }

    public TextMeshProUGUI BestTime1;
    public TextMeshProUGUI BestTime2;
    public TextMeshProUGUI BestTime3;
   

    private void SetTimez()
    {
        if (GameManager.Instance == null) return;

        int[] bestTimes = GameManager.Instance.bestTimes;

        BestTime1.text = FormatBestService(1, bestTimes[0]);
        BestTime2.text = FormatBestService(2, bestTimes[1]);
        BestTime3.text = FormatBestService(3, bestTimes[2]);
    }

    private string FormatBestService(int position, int time)
    {
        if (time == int.MaxValue)
        {
            return position + ". --";
        }

        return position + ". " + time + " s";
    }
}
