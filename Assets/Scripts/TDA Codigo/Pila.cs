using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Pila<GameObject> : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private readonly List<GameObject> pila = new List<GameObject>();

    public void Push(GameObject item)
    {
        pila.Add(item);
    }

    public GameObject Pop()
    {
        if (pila.Count == 0)
        {
            throw new InvalidOperationException("La pila esta vacia");
        }

        GameObject item = pila[pila.Count - 1];
        pila.RemoveAt(pila.Count-1);
        return item;
    }

    public GameObject Peek()
    {
        if (pila.Count == 0)
        {
            throw new InvalidOperationException("La pila esta vacia");
        }

        return pila[pila.Count - 1];
    }

    public bool IsEmpty()
    {
        return pila.Count == 0;
    }

}
