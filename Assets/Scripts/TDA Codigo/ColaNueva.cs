using System;
using System.Collections;
using System.Collections.Generic;using TDA_Codigo;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColaNueva : MonoBehaviour, IColaInterface
{
   [SerializeField] private GameObject[] pfMonster;
   [SerializeField] private Transform[] posiciones;
   [SerializeField] private GameObject[] visualCola;
   public bool flag = true;
   public int contador = 0;
   public int colaIndex;
   public int contadorDequeue;
   
   
   //arreglos cola
   public GameObject[] items = new GameObject[9];
   public int index;
   public bool isActive;
   public GameObject end;
   public GameObject front;

   public static ColaNueva Instance;

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   private void Start()
   {
      flag = true;
      items = IniciarCola(9);
      index = 0;
      isActive = true;
      
   }
   private void Update()
   {
      colaIndex = ColaNueva.Instance.index;
   }
   public void ProbarEnqueue()
   {
      Instantiate(pfMonster[contador],visualCola[ColaNueva.Instance.index].transform,false);
      ColaNueva.Instance.Enqueue(pfMonster[contador]);
      Debug.Log("se añadio a index "+(ColaNueva.Instance.index-1));
      contador++;
      moverMonstros();
   }
   public void moverMonstros()
   {
      for (int i = 0; i < ColaNueva.Instance.items.Length; i++)
      {
         if (ColaNueva.Instance.items[i] != null)
         {
         }
      }
   }
   public void moverMonstros4()
   {
      int indexAux=ColaNueva.Instance.index;
      int auxWhile = 0;
      for (int i =indexAux;i>0;i--)
      {
         Transform aux=visualCola[i].transform.GetChild(0);
            aux.SetParent(visualCola[i-1].transform);
            aux.position = aux.parent.position;
      }

      contadorDequeue++;
      for (int i = 0; i < contadorDequeue; i++)
      {
         //visualCola[0].transform.GetChild(i).gameObject.SetActive(false);
      }
   }
   public void moverMonstros3()
   {
      int indexAux=ColaNueva.Instance.index;
      for (int i = 0; i < ColaNueva.Instance.index; i++)
      {
         
         if (ColaNueva.Instance.items[i] != null)
         {
            if (indexAux == 0)
            {
               visualCola[indexAux].SetActive(false);
               
            }
            else
            {
               GameObject aux = visualCola[indexAux];
               visualCola[indexAux].transform.position = posiciones[indexAux-1].position;
               visualCola[indexAux - 1] = aux;
               indexAux--;
               Debug.Log("se mueve copia a posicion "+(indexAux));
            }
         }
      }
   }
   public void MonstruoIngresando()
   {
      int monster = Random.Range(0, 4);
      Instantiate(pfMonster[monster],visualCola[ColaNueva.Instance.index].transform,false);
      visualCola[ColaNueva.Instance.index].transform.GetChild(0).transform.position = visualCola[ColaNueva.Instance.index].transform.position;
      ColaNueva.Instance.Enqueue(pfMonster[monster]);
      Debug.Log("se añadio a index "+(ColaNueva.Instance.index-1));
      moverMonstros();
   }
   public GameObject DequeueTest()
   {
      GameObject monstro;
      monstro =ColaNueva.Instance.Dequeue();
      Debug.Log("se recupero a "+monstro.name);

      monstro = visualCola[0].transform.GetChild(contadorDequeue).gameObject;
      moverMonstros4();
      return monstro;
   }
   public int conseguirCola()
   {
      int hijos = visualCola[0].transform.childCount;
      Transform aux = visualCola[0].transform;
      bool encontro = false;
      int retorno = -1;
      for (int i = 0; i <= contadorDequeue; i++)
      {
         //visualCola[0].transform.GetChild(i);
         if (visualCola[0].transform.GetChild(i).name.Equals(ColaNueva.Instance.items[0].name))
         {
            encontro = true;
            retorno = i;
         }
         else
         {
            encontro = false;
         }
      }

      if (encontro)
      {
         return retorno;
      }
      else
      {
         return -1;
      }
      
      // Debug.Log("***********cola pos 0 "+ _colaNueva.items[0].name);
      // Debug.Log("***********cola visual 0"+visualCola[0].transform.GetChild(contadorDequeue).name);
      
   }
   IEnumerator WaitAndMove(GameObject mostro)
   {
     
      yield return new WaitForSeconds(2);
      mostro.transform.position = posiciones[ColaNueva.Instance.index - 1].transform.position;
      Debug.Log("sacamos al 2do y lo movimo");
      
      
   }
   public GameObject[] IniciarCola(int cant)
   {
      return new GameObject[cant];
   }
   public GameObject Dequeue()
   {
      if (index != 0)
      {
         index--;
         GameObject dequeueItem = items[index];
         items[index] = null;
         return dequeueItem;
      }
      else
      {
         Debug.Log("La cola no existe");
         return null;
      }
   }
   public void Enqueue(GameObject newItem)
   {
      if (isActive && index < items.Length)
      {
         for (int i = 0; i < index; i++)
         {
            items[index - i] = items[index - 1 - i];
         }
      
         items[0] = newItem;
         index++;
      }
      else
      {
         Debug.Log("la cola no existe o esta llena");
      }
   }
   public void Clear()
   {
      for (int i = 0; i < items.Length; i++)
      {
         items[i] = null;
      }
      index = 0;
   }
   public GameObject FirstItem()
   {
      if (index != 0)
      {
         return items[index - 1];
      }
      else
      {
         Debug.Log("La cola no existe");
         return null;
      }
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
         throw new System.Exception("La cola no existe");
      }
   }
}
