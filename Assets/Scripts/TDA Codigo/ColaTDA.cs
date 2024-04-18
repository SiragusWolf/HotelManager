using System;
using UnityEngine;

public class ColaTDA : MonoBehaviour
{
    public class Nodo<TDA>
    {
        public TDA Item { get; set; }
        public Nodo<TDA> Next { get; set; }
    }

    public class ColaDinamica<TDA>
    {
        private Nodo<TDA> front;
        private Nodo<TDA> end;

        public void Enqueue(TDA item)
        {
            var nodo = new Nodo<TDA> { Item = item, Next = null };
            if (IsEmpty())
            {
                front = nodo;
            }
            else
            {
                end.Next = nodo;
            }
            end = nodo;
        }

        public TDA Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola esta vacia");
            }
            TDA item = front.Item;
            front = front.Next;
            if (front == null)
            {
                end = null;
            }
            return item;
        }

        public TDA Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola esta vaica");
            }

            return front.Item;
        }

        public bool IsEmpty()
        {
            return end == null;
        }
        
    }
}