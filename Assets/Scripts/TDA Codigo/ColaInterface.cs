using UnityEngine;

namespace TDA_Codigo
{
    public interface IColaInterface
    { 
       public GameObject[] IniciarCola(int cant)
        {
            return new GameObject[cant];
        }
       public bool IsEmpty();
       public void Enqueue(GameObject prefab);
       public GameObject Dequeue();
       public GameObject FirstItem();
       public void Clear();
    }
    
    
    

    
    
    
    
    
    
    
    
}