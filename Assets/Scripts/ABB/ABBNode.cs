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

    private void Start()
    {
        textValue = GetComponent<Text>();
        textValue.text = score.ToString();
        tf = GetComponent<RectTransform>();

    }


    private void Update()
    {
        if (isRoot)
        {
            tf.position = rootPosition;
        }

        if (lowNode)
        {
            lowNode.tf.position = tf.position - tf.up * 15 - tf.right * 25;
        }

        if (highNode)
        {
            highNode.tf.position = tf.position + tf.right * 25 - tf.up * 15;
        }
    }
}
