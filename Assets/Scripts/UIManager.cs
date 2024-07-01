using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject currencyCounter;
    private TextMeshProUGUI currencyCounterRef;
    public GameObject infoService;

    // Update is called once per frame
    private void Start()
    {
        currencyCounterRef = currencyCounter.GetComponent<TextMeshProUGUI>();

        Timez[0] = "";
        Timez[1] = "";
        Timez[2] = "";

        GameManager.Instance.NewBestTimes.AddListener(SetTimez);



    }

    void Update()
    {
        currencyCounterRef.text = Mathf.FloorToInt(GameManager.Instance.Currency).ToString();
        if (InputManager.Instance.roomOk)
        {
            infoService.SetActive(true);
        }
        else
        {
            infoService.SetActive(false);
        }
    }



    private string [] Timez = new string[3];
    public TextMeshProUGUI BestTime1;
    public TextMeshProUGUI BestTime2;
    public TextMeshProUGUI BestTime3;
   

    private void SetTimez()
    {
        int[] NewTimezA = GameManager.Instance.bestTimes;
        Timez[0] = NewTimezA[0] + " s";
        Timez[1] = NewTimezA[1] + " s";
        Timez[2] = NewTimezA[2] + " s";

        BestTime1.text = Timez[0];
        BestTime2.text = Timez[1];
        BestTime3.text = Timez[2];
    }

}
