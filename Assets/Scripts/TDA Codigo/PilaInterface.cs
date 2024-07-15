using System.Threading;
using UnityEngine;

namespace TDA_Codigo
{
    public interface IPilaInterface
    { 
        public GameObject[] InicializarPila(int cantidad, string name)
        {
            return new GameObject[cantidad];
        }
        public GameObject Pop();
        public void Push(GameObject newItem);
        public GameObject LastItem();
        public bool IsEmpty();
        public void Clear();
    }

       

}