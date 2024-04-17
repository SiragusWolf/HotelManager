using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireman : Monster, ISelectable
{
    public void OnSelect()
    {
        Debug.Log("Fireman seleccionado");
    }

    public void OnDeselect()
    {
        Debug.Log("Fireman deseleccionado");
    }
}
