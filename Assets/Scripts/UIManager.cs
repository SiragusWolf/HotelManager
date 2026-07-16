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
    private TextMeshProUGUI infoServiceRef;

    // Update is called once per frame
    private void Start()
    {
        currencyCounterRef = currencyCounter.GetComponent<TextMeshProUGUI>();
        infoServiceRef = infoService.GetComponent<TextMeshProUGUI>();

        /*Timez[0] = "";
        Timez[1] = "";
        Timez[2] = "";

        GameManager.Instance.NewBestTimes.AddListener(SetTimez);*/



    }

    void Update()
    {
        currencyCounterRef.text = Mathf.FloorToInt(GameManager.Instance.Currency).ToString();
        if (InputManager.Instance.serviceSelectionMode)
        {
            infoService.SetActive(true);
            UpdateServiceInfo();
        }
        else
        {
            infoService.SetActive(false);
        }
    }

    private void UpdateServiceInfo()
    {
        if (infoServiceRef == null) return;

        GameObject assistantObject = GetSelectedAssistant();
        Assistant assistant = assistantObject != null ? assistantObject.GetComponent<Assistant>() : null;

        if (assistant == null)
        {
            infoServiceRef.text = "Elige un mayordomo";
            return;
        }

        infoServiceRef.text = assistantObject.name + " | Hab " + assistant.AssistantSkill.ToString("0") + " | " + GetAffinityText(assistant);
    }

    private GameObject GetSelectedAssistant()
    {
        if (InputManager.Instance != null && InputManager.Instance.SelectedServiceAssistant != null)
        {
            return InputManager.Instance.SelectedServiceAssistant;
        }

        if (InputManager.Instance != null && InputManager.Instance.SelectedObject != null)
        {
            Assistant selectedAssistant = InputManager.Instance.SelectedObject.GetComponent<Assistant>();
            if (selectedAssistant != null && PilaNueva.Instance != null && PilaNueva.Instance.IsAvailable(InputManager.Instance.SelectedObject))
            {
                return InputManager.Instance.SelectedObject;
            }
        }

        return null;
    }

    private string GetAffinityText(Assistant assistant)
    {
        List<string> affinities = new List<string>();

        if (assistant.FireFriendly) affinities.Add("Fuego");
        if (assistant.SlimeFriendly) affinities.Add("Slime");
        if (assistant.FishFriendly) affinities.Add("Pez");
        if (assistant.GhostFriendly) affinities.Add("Fantasma");

        return affinities.Count > 0 ? string.Join(", ", affinities) : "General";
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
