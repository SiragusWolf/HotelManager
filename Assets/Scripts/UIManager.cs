using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject currencyCounter;
    private TextMeshProUGUI currencyCounterRef;
    public GameObject infoService;

    // Update is called once per frame
    private void Start()
    {
        currencyCounterRef = currencyCounter.GetComponent<TextMeshProUGUI>();

        /*Timez[0] = "";
        Timez[1] = "";
        Timez[2] = "";

        GameManager.Instance.NewBestTimes.AddListener(SetTimez);*/



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



    /*private string [] Timez = new string[3];
    public TextMeshProUGUI MayTime;
    public TextMeshProUGUI MidTime;
    public TextMeshProUGUI MenTime;
   

    private void SetTimez()
    {
        int[] NewTimezA = GameManager.Instance.bestTimes;
        Timez[0] = NewTimezA[0] + " s";
        Timez[1] = NewTimezA[1] + " s";
        Timez[2] = NewTimezA[2] + " s";

        //MayTime.text = Timez[0];
        MidTime.text = Timez[1];
        MenTime.text = Timez[2];
    }*/

}
