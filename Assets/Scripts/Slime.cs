using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster, ISelectable
{
    public void OnSelect()
    {
        Debug.Log("Slime seleccionado");
    }

    public void OnDeselect()
    {
        Debug.Log("Slime deseleccionado");
    }
}
