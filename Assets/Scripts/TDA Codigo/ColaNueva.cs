using System.Collections;
using TDA_Codigo;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColaNueva : MonoBehaviour, IColaInterface
{
   [SerializeField] private GameObject[] pfMonster;
   [SerializeField] private GameObject[] visualCola;
   public bool flag = true;
   public int contador = 0;
   public int colaIndex;
   public int contadorDequeue;

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
      contadorDequeue = 0;
      isActive = true;
   }

   private void Update()
   {
      colaIndex = index;
   }

   public void ProbarEnqueue()
   {
      if (pfMonster.Length == 0)
      {
         Debug.Log("No hay prefabs de monstruos cargados");
         return;
      }

      if (contador >= pfMonster.Length)
      {
         contador = 0;
      }

      GameObject monsterInstance = Instantiate(pfMonster[contador]);
      Enqueue(monsterInstance);
      contador++;
   }

   public void moverMonstros()
   {
      RefreshVisualPositions();
   }

   public void moverMonstros4()
   {
      RefreshVisualPositions();
   }

   public void moverMonstros3()
   {
      RefreshVisualPositions();
   }

   public void MonstruoIngresando()
   {
      if (pfMonster.Length == 0)
      {
         Debug.Log("No hay prefabs de monstruos cargados");
         return;
      }

      int monster = Random.Range(0, pfMonster.Length);
      GameObject monsterInstance = Instantiate(pfMonster[monster]);
      Enqueue(monsterInstance);
   }

   public GameObject DequeueTest()
   {
      GameObject monstro = Dequeue();
      if (monstro != null)
      {
         Debug.Log("se recupero a " + monstro.name);
      }

      return monstro;
   }

   public int conseguirCola()
   {
      return IsEmpty() ? -1 : 0;
   }

   IEnumerator WaitAndMove(GameObject mostro)
   {
      yield return new WaitForSeconds(2);
      RefreshVisualPositions();
      Debug.Log("sacamos al 2do y lo movimo");
   }

   public GameObject[] IniciarCola(int cant)
   {
      return new GameObject[cant];
   }

   public GameObject Dequeue()
   {
      if (index == 0)
      {
         Debug.Log("La cola no existe");
         return null;
      }

      GameObject dequeueItem = items[0];

      for (int i = 1; i < index; i++)
      {
         items[i - 1] = items[i];
      }

      index--;
      items[index] = null;
      contadorDequeue++;

      if (dequeueItem != null)
      {
         dequeueItem.transform.SetParent(null, true);
      }

      RefreshVisualPositions();
      return dequeueItem;
   }

   public void Enqueue(GameObject newItem)
   {
      if (!isActive)
      {
         Debug.Log("la cola no existe");
         DestroyIfSceneObject(newItem);
         return;
      }

      if (newItem == null)
      {
         Debug.Log("no se puede agregar un monstruo nulo");
         return;
      }

      if (index >= items.Length || index >= visualCola.Length)
      {
         Debug.Log("la cola esta llena");
         DestroyIfSceneObject(newItem);
         return;
      }

      items[index] = newItem;
      Monster monster = newItem.GetComponent<Monster>();
      if (monster != null)
      {
         monster.BeginWaiting();
      }

      index++;
      Debug.Log("se anadio a index " + (index - 1));
      RefreshVisualPositions();
   }

   public void Clear()
   {
      for (int i = 0; i < items.Length; i++)
      {
         items[i] = null;
      }

      index = 0;
      contadorDequeue = 0;
      RefreshVisualPositions();
   }

   public GameObject FirstItem()
   {
      if (index != 0)
      {
         return items[0];
      }

      Debug.Log("La cola no existe");
      return null;
   }

   public bool IsEmpty()
   {
      if (!isActive)
      {
         throw new System.Exception("La cola no existe");
      }

      return index == 0;
   }

   private void RefreshVisualPositions()
   {
      for (int i = 0; i < index; i++)
      {
         if (items[i] == null || i >= visualCola.Length || visualCola[i] == null)
         {
            continue;
         }

         Transform slot = visualCola[i].transform;
         items[i].transform.SetParent(slot, false);
         items[i].transform.localPosition = Vector3.zero;
      }
   }

   private void DestroyIfSceneObject(GameObject item)
   {
      if (item != null && item.scene.IsValid())
      {
         Destroy(item);
      }
   }
}
