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
        ABBNode newNode = Instantiate(nodePrefab);
        newNode.transform.SetParent(GameObject.Find("Canvas").transform);
        newNode.score = valueToAdd;
        bool nodeAdded = false;
        if (!root)
        {
            root = newNode;
            newNode.isRoot = true;
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
