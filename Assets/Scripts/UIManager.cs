using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject currencyCounter;
    private TextMeshProUGUI currencyCounterRef;

    // Update is called once per frame
    private void Start()
    {
        currencyCounterRef = currencyCounter.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        currencyCounterRef.text = Mathf.FloorToInt(GameManager.Instance.Currency).ToString();
    }
}
