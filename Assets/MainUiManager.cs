using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUiManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Timez[0] = "";
        Timez[1] = "";
        Timez[2] = "";

        GameManager.Instance.NewBestTimes.AddListener(SetTimez);

    }

    private string [] Timez = new string[3];
    public TextMeshProUGUI BestTime1;
    public TextMeshProUGUI BestTime2;
    public TextMeshProUGUI BestTime3;
   

    private void SetTimez()
    {
        int[] NewTimezA = GameManager.Instance.bestTimes;
        if (NewTimezA[0] == int.MaxValue)
        {
            Timez[0] = 0 + " s";
        }
        else
        {
            Timez[0] = NewTimezA[0] + " s";
        }


        if (NewTimezA[1] == int.MaxValue)
        {
            Timez[1] = 0 + " s";
        }
        else
        {
            Timez[1] = NewTimezA[1] + " s";
        }


        if (NewTimezA[2] == int.MaxValue)
        {
            Timez[2] = 0 + " s";
        }
        else
        {
            Timez[2] = NewTimezA[2] + " s";
        }
        

        BestTime1.text = Timez[0];
        BestTime2.text = Timez[1];
        BestTime3.text = Timez[2];
    }
}
