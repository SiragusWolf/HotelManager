using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PilaNueva : MonoBehaviour
{
    public static PilaNueva Instance;
    public PilaOk _pila;
    public PilaOk _pilaAux;

    [SerializeField] public GameObject Jaime1;
    [SerializeField] public GameObject Jaime2;
    [SerializeField] public GameObject Jaime3;

    [SerializeField] public GameObject[] standBy;
    [SerializeField] public GameObject[] trabajando;
    [SerializeField] public Transform[] standByPos;
    [SerializeField] public Transform[] trabajandoPos;
    
    
    [SerializeField] public GameObject Room;
    //[SerializeField] public GameObject RoomSelected;
    public int copiaIndex;
    public int copiaIndexAuxiliar;

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
        _pila = new PilaOk(3,"-pila");
        _pilaAux = new PilaOk(3,"-pilaAux");
        //Jaime1.transform.position = posiciones[]
        iniciarPila();
    }

    private void Update()
    {
        copiaIndex = _pila.index;
        copiaIndexAuxiliar = _pilaAux.index;
    }

    public void pruebaPop()
    {
        GameObject jaime = _pila.Pop();//se saca de pilaStandBy (3) y se manda a pilaWork(0)
        //index es 3-1 en pop por ende lo manda al array[2]
        //jaime.transform.position = trabajandoPos[_pilaAux.index].position;
        trabajando[_pilaAux.index] = jaime; //simula la pila solo para observar
        _pilaAux.Push(jaime);
    }
    public GameObject servicioHabitacion()
    {
 
            GameObject jaime = _pila.Pop(); //se saca de pilaStandBy (3) y se manda a pilaWork(0)
            //index es 3-1 en pop por ende lo manda al array[2]
            //jaime.transform.position = trabajandoPos[_pilaAux.index].position;
            trabajando[_pilaAux.index] = jaime; //simula la pila solo para observar
            _pilaAux.Push(jaime);
            return jaime;

    }   

    public void pruebaPush()
    {
        GameObject jaime =_pilaAux.Pop(); //retorno de work(1) a standby(2)
        Debug.Log("se intenta popear de working a standby"+jaime.name+" "+_pilaAux.index + _pilaAux.name);
        //index siendo 2 se dejaria StandbyPosition[2].position
        jaime.transform.position = standByPos[_pila.index].position;
        trabajando[_pilaAux.index] = jaime; //simula la pila StandBy
        _pila.Push(jaime);
    }
    public void volverAlServicio(GameObject asistente)
    {
        GameObject jaime =_pilaAux.Pop(); //retorno de work(1) a standby(2)
        //index siendo 2 se dejaria StandbyPosition[2].position
        jaime.transform.position = standByPos[_pila.index].position;
        trabajando[_pilaAux.index] = asistente; //simula la pila StandBy
        Debug.Log("se pusheo a "+jaime.name+" y se recibio como parametro:  "+asistente.name);
        _pila.Push(asistente);
    }


    public void iniciarPila()
    {
        _pila.Push(Jaime1);
        _pila.Push(Jaime2);
        _pila.Push(Jaime3);
        copiaIndex = _pila.index;
    }

    public GameObject checkService()
    {
        return _pila.LastItem();
    }
  
 

        // Room = InputManager.Instance.getRoom();
        // if (Room != null)
        // {
        //     GameObject asistente = _pila.LastItem();
        //     asistente.transform.position = Room.transform.position;
        //     copiaIndex = _pila.index;
        //     trabajando[copiaIndex - 1] = asistente;
        //     Debug.Log(asistente.name+ " fue enviado a la room se encuentra en trabajando["+(copiaIndex-1)+"]");
        //     //RoomSelected.transform.position;
        // }
        // else
        // {
        //     Debug.Log("No se selecciono ninguna habitacion");
        // }
    //}

}












public class PilaOk
{
    public GameObject[] items = null;
    public int index;
    public bool isActive;
    public string name;

    public PilaOk(int cantidad,string nombre)
    {
        items = new GameObject[cantidad];
        isActive = true;
        index = 0;
        name = nombre;
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
            //throw new System.Exception("la pila no existe");
        }
    }
    
    
    
}
