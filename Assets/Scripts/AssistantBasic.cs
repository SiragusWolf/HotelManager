using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssistantBasic : MonoBehaviour
{
    public bool isWorking = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Trabajando()
    {
        if (isWorking)
        {
            this.GameObject().SetActive(false);
        }
        else
        {
            this.GameObject().SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
