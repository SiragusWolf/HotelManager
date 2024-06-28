using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoRoom : MonoBehaviour, IClickable
{
    //Código a aplicar a cada Room del hotel
    
    //Referencia al script de hotel, ubicado en el gameobject parent, que contiene el grafo
    private Hotel hotelRef;
    
    private void Start()
    {
        hotelRef = GetComponentInParent<Hotel>();
    }

    public void OnClick(GameObject selectedObject)
    {
        //OnClick llamo al calculo de camino desde el origen (selected, debería ser el lugar en el que está el monstruo) al destino (room seleccionadoo)
        //hotelRef.CalcularCamino(selectedObject, this.gameObject);
        
        
        //OnClick llamo al calculo de camino desde el origen (seteado como el lobby del hotel) al destino (room seleccionadoo)
        hotelRef.CalcularCamino(this.gameObject);
    }
}
