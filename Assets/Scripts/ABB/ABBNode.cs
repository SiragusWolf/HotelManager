using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABBNode : MonoBehaviour
{
    public float score;
    public ABBNode parentNode;
    public ABBNode lowNode;
    public ABBNode highNode;

    public RectTransform tf;
    private Text textValue;
    public bool isRoot;
    public Vector3 rootPosition;

    private void Awake()
    {
        textValue = GetComponent<Text>();
        tf = GetComponent<RectTransform>();
    }

    private void Start()
    {
        UpdateText();

    }


    private void Update()
    {
        if (tf == null)
        {
            tf = GetComponent<RectTransform>();
            if (tf == null) return;
        }

        UpdateText();

        if (isRoot)
        {
            tf.position = rootPosition;
        }

        if (lowNode)
        {
            RectTransform lowTransform = lowNode.GetRectTransform();
            if (lowTransform != null)
            {
                lowTransform.position = tf.position - tf.up * 15 - tf.right * 25;
            }
        }

        if (highNode)
        {
            RectTransform highTransform = highNode.GetRectTransform();
            if (highTransform != null)
            {
                highTransform.position = tf.position + tf.right * 25 - tf.up * 15;
            }
        }
    }

    private RectTransform GetRectTransform()
    {
        if (tf == null)
        {
            tf = GetComponent<RectTransform>();
        }

        return tf;
    }

    private void UpdateText()
    {
        if (textValue == null)
        {
            textValue = GetComponent<Text>();
        }

        if (textValue != null)
        {
            textValue.text = score.ToString("0");
        }
    }
}
