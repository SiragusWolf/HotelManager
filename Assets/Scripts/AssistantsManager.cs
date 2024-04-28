using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class AssistantsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Assistants = new List<GameObject>();
    [SerializeField] private bool isWaiting  = false;
    [SerializeField] private GameObject[] Rooms;
    public int roomClick = 0;
    
    public List<GameObject> Positions;

    //[SerializeField] private PilaTDA _pilaTda;
    
    public void RoomService(GameObject assistant, GameObject selectedRoom)
    {
        if (assistant != null)
        {
            Debug.Log("Se trajo a "+ assistant.name + " a la habitacion " + selectedRoom.name);
            //despues de x tiempo returnWorker()
            //StartCoroutine(WaitAndPush(assistant));
        }
        else
        {
            Debug.Log("No hay asistentes disponibles");
        }
        
        roomClick++;
    }
    
    IEnumerator WaitAndPush(GameObject assistant)
    {
        isWaiting = true;
        //5seg delay
        yield return new WaitForSeconds(5);
        
        assistant.GetComponent<Assistant>().room.assistantCleared();
        //guarda nuevamente
        Push(assistant);
        Debug.Log("trabajador volvio: "+assistant.name);
        //assistant.SetActive(true);
    }

    public void Push(GameObject assistant)
    {
        assistant.GetComponent<Assistant>().room.assistantCleared();
        Assistants.Add(assistant);
        Debug.Log("trabajador volvio: "+assistant.name);
    }
    
    public void returnWorker(GameObject worker)
    {
        //push a la pila
        //saca al worker de la habitacion
    }

    public void _Push(GameObject Worker)
    {
        Assistants.Add(Worker);
    }

    public GameObject Pop()
    {
        if (Assistants.Count == 0)
        {
            throw new InvalidOperationException("La pila esta vacia");
        }
        GameObject assistant = Assistants[Assistants.Count - 1];
        Assistants.RemoveAt(Assistants.Count-1);
        //assistant.SetActive(false);//posible a sacar
        return assistant;
    }

    public GameObject getLastPosition()
    {
        GameObject LastPosition = null;
        if (Positions[0].GetComponent<PilaPosition>().currentAssistant == null)
        {
            LastPosition = Positions[0];
        } else if (Positions[1].GetComponent<PilaPosition>().currentAssistant == null)
        {
            LastPosition = Positions[1];
        }else if (Positions[2].GetComponent<PilaPosition>().currentAssistant == null)
        {
            LastPosition = Positions[2];
        }
            
        /*for (int i = 0; i < Positions.Count; i++)
        {
            var _position = Positions[i].GetComponent<PilaPosition>();
            //_position.checkForAssistant();
            if (_position.currentAssistant != null)
            {
                return Positions[i];
            }
        }*/
        return LastPosition;
    }
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     //Workers.Push(transform.position);
        //     Debug.Log("Posicion guardada : "+transform.position);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.O) && Assistants.Count >0 && !isWaiting)
        // {
        //     //Vector3 lastWorker = Workers.Pop();
        //     transform.position = lastWorker;
        //     Debug.Log("Movido a la posicion guardada: "+Assistants);
        //
        //     StartCoroutine(WaitAndPush(lastWorker));
        //
        // }
        //
        
    }

}
