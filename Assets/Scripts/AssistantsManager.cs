using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantsManager : MonoBehaviour
{
    //[SerializeField] private List<GameObject> Workers = new List<GameObject>();
    [SerializeField] private List<GameObject> Workers = new List<GameObject>();
    [SerializeField] private bool isWaiting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Workers.Push(transform.position);
            Debug.Log("Posicion guardada : "+transform.position);
        }

        if (Input.GetKeyDown(KeyCode.O) && Workers.Count >0 && !isWaiting)
        {
            Vector3 lastWorker = Workers.Pop();
            transform.position = lastWorker;
            Debug.Log("Movido a la posicion guardada: "+lastWorker);

            StartCoroutine(WaitAndPush(lastWorker));

        }

        IEnumerator WaitAndPush(Vector3 position)
        {
            isWaiting = true;
            //5seg delay
            yield return new WaitForSeconds(5);
            
            //guarda nuevamente
            Workers.Push(position);
            Debug.Log("Posicion re-guardada: "+position);
            isWaiting = false;
        }
    }
    public void Push(GameObject item)
    {
        pila.Add(item);
    }

    public void Pop()
    {
        
    }
}
