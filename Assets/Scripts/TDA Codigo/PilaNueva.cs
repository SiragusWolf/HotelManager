using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TDA_Codigo;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PilaNueva : MonoBehaviour, IPilaInterface
{
    public static PilaNueva Instance;
    // public PilaNueva _pila;
    // public PilaNueva _pilaAux;

    [SerializeField] public GameObject Jaime1;
    [SerializeField] public GameObject Jaime2;
    [SerializeField] public GameObject Jaime3;

    [SerializeField] public GameObject[] standBy;
    [SerializeField] public GameObject[] trabajando;
    [SerializeField] public Transform[] standByPos;
    [SerializeField] public Transform[] trabajandoPos;
    
    
    [SerializeField] public GameObject Room;
    public int copiaIndex;
    public int copiaIndexAuxiliar;
    
    //Nueva implementacion interfaz
    public GameObject[] items = null;
    public GameObject[] itemsAux = null;
    public int index;
    public int indexAux;
    public bool isActive;
    public bool isActiveAux;
    public string name;
    public string nameAux;
    
    
    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        Instance = this; 
    }
    public void Start()
    {
        
        isActive = true;
        isActiveAux = true;
        
        index = 0;
        indexAux = 0;
        items = InicializarPila(3,"-pila");
        itemsAux = InicializarPila(3,"-pilaAux");
        CargarPila();
    }
    private void Update()
    {
        copiaIndex = index;
        copiaIndexAuxiliar = indexAux;
    }
    public void pruebaPop()
    {
        GameObject jaime = Pop();//se saca de pilaStandBy (3) y se manda a pilaWork(0)
        trabajando[indexAux] = jaime; //simula la pila solo para observar
        //index es 3-1 en pop por ende lo manda al array[2]
        //jaime.transform.position = trabajandoPos[_pilaAux.index].position;
        PushAux(jaime);
    }
    public void pruebaPush()
    {
        GameObject jaime =PopAux(); //retorno de work(1) a standby(2)
        Debug.Log("se intenta popear de working a standby"+jaime.name+" "+indexAux + nameAux);
        //index siendo 2 se dejaria StandbyPosition[2].position
        jaime.transform.position = standByPos[index].position;
        trabajando[indexAux] = jaime; //simula la pila StandBy
        Push(jaime);
    }
    public void volverAlServicio(GameObject asistente)
    {
        GameObject jaime =PopAux(); //retorno de work(1) a standby(2)
        //index siendo 2 se dejaria StandbyPosition[2].position
        jaime.transform.position = standByPos[index].position;
        trabajando[indexAux] = asistente; //simula la pila StandBy
        Debug.Log("se pusheo a "+jaime.name+" y se recibio como parametro:  "+asistente.name);
        Push(asistente);
    }
    public GameObject servicioHabitacion()
    {
 
        GameObject jaime = Pop(); //se saca de pilaStandBy (3) y se manda a pilaWork(0)
        //index es 3-1 en pop por ende lo manda al array[2]
        //jaime.transform.position = trabajandoPos[_pilaAux.index].position;
        trabajando[indexAux] = jaime; //simula la pila solo para observar
        PushAux(jaime);
        return jaime;

    }   
    public void CargarPila()
    {
        Push(Jaime1);
        Push(Jaime2);
        Push(Jaime3);
        copiaIndex = index;
    }
    public GameObject checkService()
    {
        return LastItem();
    }
    public GameObject[] InicializarPila(int cantidad, string nombre)
    {
        return new GameObject[cantidad];
    }
    
    public GameObject Pop()
    {
        if (index != 0)
        {
            index--;
            GameObject popItem = items[index];
            items[index] = null;
            Debug.Log("pop: " +popItem.name);
            return popItem;
        }
        else
        {
            throw new System.Exception("La pila no existe");
        }
    }

    public void Push(GameObject newItem)
    {
         
        if (isActive && index < items.Length)
        {
            items[index] = newItem;
            index++;
            Debug.Log("se intenta pushear "+ newItem+" en index:"+index + " de pila "+name);
        }
        else
        {
            throw new System.Exception("error al pushear, esta llena o :"+isActive);
        }
    }
    public GameObject LastItem()
    {
        if(index !=0)
        {
            return items[index - 1];
        }
        else
        {
            return null;
        }
    }
    public GameObject PopAux()
    {
        if (indexAux != -1)
        {
            indexAux--;
            GameObject popItem = items[indexAux];
            itemsAux[indexAux] = null;
            Debug.Log("pop: " +popItem.name);
            return popItem;
        }
        else
        {
            throw new System.Exception("La pila no existe");
        }
    }

    public void PushAux(GameObject newItem)
    {
         
        if (isActiveAux && indexAux < items.Length)
        {
            items[indexAux] = newItem;
            indexAux++;
            Debug.Log("se intenta pushear "+ newItem+" en index:"+indexAux + " de pila "+nameAux);
        }
        else
        {
            throw new System.Exception("error al pushear, esta llena o :"+isActiveAux);
        }
    }

    public GameObject LastItemAux()
    {
        if(indexAux !=0)
        {
            return items[indexAux - 1];
        }
        else
        {
            return null;
        }
    }
    
    
    public void Clear()
    {
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }
        index = 0;
    }

    public bool IsEmpty()
    {
        if (isActive)
        {
            if (index == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new System.Exception("La pila no existe");
        }
    }
    
    
}