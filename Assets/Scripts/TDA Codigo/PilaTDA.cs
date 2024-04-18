using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PilaTDA : MonoBehaviour
{
// PILA DINAMICA CON LISTAS ENLAZADAS
    public class Nodo<TDA>
    {
        public TDA Item { get; set; }
        public Nodo<TDA> Next { get; set; }
    }

    public class PilaDinamica<TDA>
    {
        private Nodo<TDA> top;

        public void Push(TDA item)
        {
            var nodo = new Nodo<TDA> { Item = item, Next = top };
            top = nodo;
        }

        public TDA Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("la pila esta vacia");
            }

            TDA item = top.Item;
            top = top.Next;
            return item;
        }

        public TDA Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException("la pila esta vacia");
            }

            return top.Item;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }

}
