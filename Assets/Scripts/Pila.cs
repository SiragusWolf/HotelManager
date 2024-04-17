using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Pila<TDA> : MonoBehaviour
{
    private readonly List<TDA> pila = new List<TDA>();

    public void Push(TDA item)
    {
        pila.Add(item);
    }

    public TDA Pop()
    {
        if (pila.Count == 0)
        {
            throw new InvalidOperationException("La pila esta vacia");
        }

        TDA item = pila[pila.Count - 1];
        pila.RemoveAt(pila.Count-1);
        return item;
    }

    public TDA Peek()
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
