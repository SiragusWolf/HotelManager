using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cola<TDA> : MonoBehaviour
{
    private List<TDA> Items = new List<TDA>();

    public bool IsEmpty()
    {
        return !Items.Any();
    }
    
    public void Enqueue(TDA item)
    {
        Items.Add(item);
    }

    public TDA Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("La cola esta vacia");
        }

        TDA item = Items[0];
        Items.RemoveAt(0);
        return item;
    }

    public TDA Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("La cola esta vacia");
        }
        return Items[0];
    }
}
