using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUpgrade : MonoBehaviour, ISelectable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        Debug.Log("Upgrade listo");
    }

    public void OnDeselect()
    {
        Debug.Log("Upgrade deseleccionado");
    }
}
