using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nodo
{
    public GameObject info;
    public Nodo sig;
}

public class ConjuntoDinamico : IConjuntoTDA
{
    Nodo c;
    public void InicializarConjunto()
    {
        c = null;

    }
    public bool ConjuntoVacio()
    {
        return (c == null);
    }
    public void Agregar(GameObject x)
    {
        /* Verifica que x no este en el conjunto */
        if (!this.Pertenece(x))
        {
            Nodo aux = new Nodo();
            aux.info = x;
            aux.sig = c;
            c = aux;
        }
    }
    public GameObject Elegir()
    {
        return c.info;
    }
    public void Sacar(GameObject x)
    {
        if (c != null)
        {
            // si es el primer elemento de la lista
            if (c.info == x)
            {
                c = c.sig;
            }
            else
            {
                Nodo aux = c;
                while (aux.sig != null && aux.sig.info != x)
                    aux = aux.sig;
                if (aux.sig != null)
                    aux.sig = aux.sig.sig;
            }
        }
    }
    public bool Pertenece(GameObject x)
    {
        Nodo aux = c;
        while ((aux != null) && (aux.info != x))
        {
            aux = aux.sig;
        }
        return (aux != null);
    }
}
