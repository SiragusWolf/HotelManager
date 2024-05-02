using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColaNueva : MonoBehaviour
{
   [SerializeField] private GameObject[] pfMonster;
   [SerializeField] private Transform[] posiciones;
   [SerializeField] private GameObject[] visualCola;
   public ColaOk _colaNueva;
   public bool flag =true;
   public int contador=0;
   public int colaIndex;
   public int contadorDequeue;
   private void Start()
   {
      _colaNueva = new ColaOk(9);
      flag = true;
   }

   private void Update()
   {
      colaIndex = _colaNueva.index;
    
   }
   

   public void ProbarEnqueue()
   {
      Instantiate(pfMonster[contador],visualCola[_colaNueva.index].transform,false);
      _colaNueva.Enqueue(pfMonster[contador]);
      Debug.Log("se añadio a index "+(_colaNueva.index-1));
         contador++;
         moverMonstros();
         //moverMonstros2();
         // for (int i = 0; i < _colaNueva.items.Length; i++)
         // {
         //    if (_colaNueva.items[i] != null)
         //    {
         //       Debug.Log("la posicion "+i+" de la cola no esta vacia");
         //       _colaNueva.items[i].transform.position = posiciones[i].position;
         //    }
         // }

         //Instantiate(_colaNueva.items[_colaNueva.index-1],posiciones[_colaNueva.index-1].position,quaternion.identity);
         //Instantiate(_colaNueva.items[_colaNueva.index-1],posiciones[_colaNueva.index-1].position,quaternion.identity);

   }


   public void moverMonstros()
   {
      for (int i = 0; i < _colaNueva.items.Length; i++)
      {
         if (_colaNueva.items[i] != null)
         {
            //Debug.Log("la posicion "+i+" de la cola no esta vacia");
            //_colaNueva.items[i].transform.position = posiciones[_colaNueva.index-1-i].position;
            //Debug.Log("se mueve a posicion "+(_colaNueva.index-1-i));
         }
      }
   }
   public void moverMonstros2()
   {
      for (int i = 0; i < _colaNueva.index; i++)
      {
         if (_colaNueva.items[i] != null)
         {
            //Debug.Log("la posicion "+i+" de la cola no esta vacia");
            visualCola[i].transform.position = posiciones[_colaNueva.index-1-i].position;
            Debug.Log("se mueve copia a posicion "+(_colaNueva.index-1-i));
         }
      }
   }

   public void moveToNext()
   {
      for (int i=0;i<visualCola.Length;i++)
      {
         if (i==0)
         {
            
           
            visualCola[i].transform.GetChild(0).gameObject.SetActive(false);
         }
         Transform aux;
         
      }
   }
   public void moverMonstros4()
   {
      int indexAux=_colaNueva.index;
      int auxWhile = 0;
      //moveToNext();
      for (int i =indexAux;i>0;i--)
      {
         Transform aux=visualCola[i].transform.GetChild(0);
            aux.SetParent(visualCola[i-1].transform);
            aux.position = aux.parent.position;

            //visualCola[i].transform.position = visualCola[i-1].transform.position;
            //visualCola[i].transform.GetChild(0).gameObject.transform.position = visualCola[i - 1].transform.position; //position = visualCola[i-1].transform.position;
            //visualCola[i].SetActive(false);
            // for (int j = 0; j < visualCola[i].transform.childCount; j++)
            // {
            //    visualCola[i].transform.GetChild(j).position = visualCola[i-1].transform.position;
            //    Debug.Log("Se movio a "+visualCola[i].transform.GetChild(0).gameObject.name +" a la posicion " +visualCola[i-1]);
            // }
            // if (visualCola[i].transform.childCount>0)
            // {
            //    // visualCola[i].transform.GetChild(0).position = visualCola[i-1].transform.position;
            //    // Debug.Log("Se movio a "+visualCola[i].transform.GetChild(0).gameObject.name +" a la posicion " +visualCola[i-1]);
            // }

      }

      contadorDequeue++;
      for (int i = 0; i < contadorDequeue; i++)
      {
         //visualCola[0].transform.GetChild(i).gameObject.SetActive(false);
      }
      //visualCola[0].transform.GetChild(0).gameObject.SetActive(false);
     

      // while(visualCola[0].transform.GetChild(auxWhile)!=null)
      // {
      //    visualCola[0].transform.GetChild(auxWhile).gameObject.SetActive(false);
      //    auxWhile++;
      // }

      
      //visualCola[0].SetActive(false);
   }
   
   public void moverMonstros3()
   {
      int indexAux=_colaNueva.index;
      for (int i = 0; i < _colaNueva.index; i++)
      {
         
         // si 5 es max 
         //objeto 5 aux
         //index 5 position mover a position 4
         //indexaux = null
         
         if (_colaNueva.items[i] != null)
         {
            if (indexAux == 0)
            {
               visualCola[indexAux].SetActive(false);
               
            }
            else
            {
               //indexAux--;
               GameObject aux = visualCola[indexAux];
               visualCola[indexAux].transform.position = posiciones[indexAux-1].position;
               visualCola[indexAux - 1] = aux;
               //visualCola[indexAux].SetActive(false);
               indexAux--;
               // index--;
               // GameObject dequeueItem = items[index];
               // items[index] = null;
               Debug.Log("se mueve copia a posicion "+(indexAux));
               // visualCola[i].transform.position = posiciones[i-1].position;
               // Debug.Log("se mueve copia a posicion "+(i-1));
               //GameObject aux = visualCola[i];
               // visualCola[i] = null;
               // visualCola[i - 1] = aux;
            }
            

         }
      }
   }





   public void MonstruoIngresando()
   {
      

      
      
      
      int monster = Random.Range(0, 4);
     
      //Instantiate(prefab);
      //Instantiate(visualCola[_colaNueva.index],posiciones[_colaNueva.index-1],true);
      Instantiate(pfMonster[monster],visualCola[_colaNueva.index].transform,false);
      visualCola[_colaNueva.index].transform.GetChild(0).transform.position = visualCola[_colaNueva.index].transform.position;
      _colaNueva.Enqueue(pfMonster[monster]);
      Debug.Log("se añadio a index "+(_colaNueva.index-1));
      moverMonstros();
      
      //Instantiate(visualCola[_colaNueva.index],posiciones[_colaNueva.index-1],true);
      //ProbarEnqueue();
      //prefab.SetActive(false);
      //moverMonstros2();
   }
   public GameObject DequeueTest()
   {
     
       GameObject monstro;
       monstro =_colaNueva.Dequeue();
       Debug.Log("se recupero a "+monstro.name);
       //monstro.SetActive(false);
       //monstro.transform.position = posiciones[_colaNueva.index - 1].transform.position;
       // for (int i = 0; i < _colaNueva.items.Length; i++)
       // {
       //    if (_colaNueva.items[i] != null)
       //    {
       //       Debug.Log("la posicion "+i+" de la cola no esta vacia");
       //       _colaNueva.items[i].transform.position = posiciones[i].position;
       //    }
       // }
       //recuperarMonstruos();
       //moverMonstros();
       //moverMonstros2();
       //moverMonstros3();

      //  if (contadorDequeue==0)
      // {
      //     monstro = visualCola[0].transform.GetChild(0).gameObject;
      //     return monstro;
      // }

      monstro = visualCola[0].transform.GetChild(contadorDequeue).gameObject;
      moverMonstros4();
      return monstro;

      // if (contadorDequeue==1)
      // {
       //    monstro = visualCola[0].transform.GetChild(0).gameObject;
       //    return monstro;
       // }
       // int indexRetornado = conseguirCola();
       // Debug.Log("index retornado "+indexRetornado);
       // if (indexRetornado != -1)
       // {
       //    monstro = visualCola[0].transform.GetChild(indexRetornado).gameObject;
       //    return monstro; 
       // }
       // else
       // {
       //    return null;
       // }
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
         if (visualCola[0].transform.GetChild(i).name.Equals(_colaNueva.items[0].name))
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
      mostro.transform.position = posiciones[_colaNueva.index - 1].transform.position;
      Debug.Log("sacamos al 2do y lo movimo");
      
      
   }

 
}

public class ColaOk
{
   public GameObject[] items = null;
   public int index;
   public bool isActive;
   public GameObject end;
   public GameObject front;
   

   public ColaOk(int tamaño)
   {
      items = new GameObject[tamaño];
      isActive = true;
      index = 0;
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

      // if (isActive)
      // {
      //    if (index == 0)
      //    {
      //       items[0] = newItem;
      //       //front = newItem;
      //       //Debug.Log("se agrego en la cola pos "+index+" y ahora se suma index+1");
      //       index++;
      //
      //    }else if(index<items.Length)
      //    {
      //       //items[index] = newItem;
      //       //Debug.Log("se agrego en la cola pos "+index+" y ahora se suma index+1");
      //       //index++;
      //    }
      //    else
      //    {
      //       //Debug.Log("se intento enqueue pero index no corresponde "+index);
      //    }
      //}
      // if (isActive && index < items.Length)
      // {
      //    for (int i = 0; i < items.Length; i++)
      //    {
      //       items[index - i] = items[index - 1 - i];
      //    }
      //
      //    items[0] = newItem;
      //    index++;
      // }
      // else
      // {
      //    Debug.Log("la cola no existe o esta llena");
      // }
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
