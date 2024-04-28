using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaPosition : MonoBehaviour
{
    public GameObject currentAssistant;

    private void Awake()
    {
        if (currentAssistant != null)
        {
            currentAssistant.GetComponent<Assistant>().currentPosition = this.gameObject;
        }
    }

    public void clearPosition()
    {
        currentAssistant = null;
    }

    public void assignPosition(GameObject assistant)
    {
        currentAssistant = assistant;
    }
}
