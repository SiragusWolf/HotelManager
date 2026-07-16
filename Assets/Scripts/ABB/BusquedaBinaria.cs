using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusquedaBinaria : MonoBehaviour
{

    public ABBNode root;
    public ABBNode nodePrefab;
    private ABBNode currentNode;
    public static BusquedaBinaria Instance;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    public void scoreOff()
    {
        gameObject.SetActive(false);
    }

    public void scoreOn()
    {
        gameObject.SetActive(true);
    }
    public void AddNode(float valueToAdd)
    {
        //valueToAdd = float.Parse(inputBox.text);
        Transform scoreParent = GetScoreParent();
        ABBNode newNode = CreateNode(scoreParent);
        newNode.score = valueToAdd;
        bool nodeAdded = false;
        if (!root)
        {
            root = newNode;
            newNode.isRoot = true;
            if (newNode.rootPosition == Vector3.zero)
            {
                newNode.rootPosition = scoreParent.position;
            }
        }
        else
        {
            currentNode = root;
            while (!nodeAdded)
            {
                if (newNode.score > currentNode.score)
                {
                    if (currentNode.highNode)
                    {
                        currentNode = currentNode.highNode;
                    }
                    else
                    {
                        currentNode.highNode = newNode;
                        newNode.parentNode = currentNode;
                        nodeAdded = true;
                    }
                }else if (newNode.score < currentNode.score)
                {
                    if (currentNode.lowNode)
                    {
                        currentNode = currentNode.lowNode;
                    }
                    else
                    {
                        currentNode.lowNode = newNode;
                        newNode.parentNode = currentNode;
                        nodeAdded = true;
                    }
                }
                else
                {
                    nodeAdded = true;
                    Destroy(newNode.gameObject);
                }
            }
        }
    }

    private Transform GetScoreParent()
    {
        GameObject scoreObject = GameObject.Find("ABB Score");
        return scoreObject != null ? scoreObject.transform : transform;
    }

    private ABBNode CreateNode(Transform parent)
    {
        ABBNode newNode;
        if (nodePrefab != null)
        {
            newNode = Instantiate(nodePrefab, parent);
        }
        else
        {
            GameObject nodeObject = new GameObject("ABB Node");
            nodeObject.transform.SetParent(parent, false);

            RectTransform rectTransform = nodeObject.AddComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(80, 24);

            Text text = nodeObject.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;

            newNode = nodeObject.AddComponent<ABBNode>();
        }

        return newNode;
    }

    public ABBNode FindNode(float valueToFind)
    {
        //valueToFind = float.Parse(inputBox.text);
        if (root)
        {
            currentNode = root;
            if (valueToFind == root.score)
            {
                return root;
            }

            while (currentNode.score != valueToFind)
            {
                if (valueToFind < currentNode.score)
                {
                    if (currentNode.lowNode)
                    {
                        currentNode = currentNode.lowNode;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (valueToFind > currentNode.score)
                {
                    if (currentNode.highNode)
                    {
                        currentNode = currentNode.highNode;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (currentNode.score == valueToFind)
            {
                return currentNode;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }



    public void RemoveNode(float valueToRemove)
    {
        //  valueToRemove = float.Parse(inputBox.text);
        ABBNode nodeToremove = FindNode(valueToRemove);
        bool removingHigh;
        if (nodeToremove)
        {
            if (nodeToremove == nodeToremove.parentNode.lowNode)
            {
                removingHigh = false;
            }
            else
            {
                removingHigh = true;
            }

            if (removingHigh)
            {
                if (nodeToremove.lowNode && !nodeToremove.highNode)
                {
                    nodeToremove.parentNode.highNode = nodeToremove.lowNode;
                    nodeToremove.lowNode.parentNode = nodeToremove.parentNode;
                    Destroy(nodeToremove.gameObject);
                    return;
                }
                else if(nodeToremove.highNode&& !nodeToremove.lowNode)
                {
                    nodeToremove.parentNode.highNode = nodeToremove.highNode;
                    nodeToremove.highNode.parentNode = nodeToremove.parentNode;
                    Destroy(nodeToremove.gameObject);
                    return;
                }
            }
        }
    }
}
