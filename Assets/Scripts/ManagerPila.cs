using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ManagerPila : MonoBehaviour
{
    [FormerlySerializedAs("pila")] [SerializeField]private List<GameObject> pilaEspera = new List<GameObject>();
    [FormerlySerializedAs("jaimesEnLaburo")] [SerializeField] private List<GameObject> pilaActive = new List<GameObject>();
    [SerializeField] private List<Transform> pilaLocations = new List<Transform>();
    
    [SerializeField] private GameObject prefabJaime;
    [SerializeField] public GameObject warning;
    public GameObject[] habitaciones;
    public int RoomIndex =0;
    
    //pila trabajadores activos
    public void PushPilaActive(GameObject item,GameObject room)
    {
        pilaActive.Add(item);
        item.transform.position = room.transform.position;
        Debug.Log("jaime nro: "+item.name + " guardado en la posicion " + (pilaActive.Count-1));
    }
    public GameObject PopPilaActiva()
    {
        
        if (pilaActive.Count == 0)
        {
            throw new InvalidOperationException("Activos esta vacia");

        }

        GameObject item = pilaActive[pilaActive.Count - 1];
        pilaActive.RemoveAt(pilaActive.Count-1);
        return item;
    }
    
    //pila trabajadores standby
    public void Push(GameObject item)
    {
        /*
        if (pila.Count >= 3)
        {
            throw new InvalidOperationException("Pila Llena");
        }*/
            pilaEspera.Add(item);
            item.transform.position = pilaLocations[pilaEspera.Count - 1].transform.position;
            Debug.Log("jaime nro: "+pilaEspera.Count);
    }
    
    public GameObject Pop()
    {
        if (pilaEspera.Count == 0)
        {
            throw new InvalidOperationException("La pila esta vacia");

        }

        GameObject item = pilaEspera[pilaEspera.Count - 1];
        pilaEspera.RemoveAt(pilaEspera.Count-1);
        return item;
    }

    public GameObject Peek()
    {
        if (pilaEspera.Count == 0)
        {
            throw new InvalidOperationException("La pila esta vacia");
        }

        return pilaEspera[pilaEspera.Count - 1];
    }

    public bool IsEmpty()
    {
        return pilaEspera.Count == 0;
    }

    public bool ActivaIsEmpty()
    {
        return pilaActive.Count == 0;
    }


    public void SendJaime() //manda del standby al active
    {
        RoomIndex++;
       
            GameObject Jaime = Pop();
            PushPilaActive(Jaime,habitaciones[RoomIndex]);
           // Jaime.transform.position = habitaciones[RoomIndex].transform.position;
            //Debug.Log("Todos los jaimes estan trabajanding");

    }
    public void CallJaime() //return del active a standby
    {
        if (!IsEmpty())
        {
            //GameObject jaimeLaburador = pilaActive[pilaActive.Count-1];
            GameObject jaimeReturn = PopPilaActiva();
            Push(jaimeReturn);
            
            pilaActive.RemoveAt(pilaActive.Count-1);
        }
        else
        {
            Debug.Log("No hay ningun jaime laburando");
        }
        
        
        //abre ventana con jaimes
        //selecciona una de las opciones
        //mete a jaime a la pila de disponibles
        //Push(prefabJaime);
    }
}
