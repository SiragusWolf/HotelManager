using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColaTest : MonoBehaviour
{
    [SerializeField] private GameObject pfMonster;

    [SerializeField] private Transform colaFront;
    private List<GameObject> Clients = new List<GameObject>();
    public int position =0;
    
    
    
    public bool IsEmpty()
    {
        return !Clients.Any();
    }
    
    public void Enqueue(GameObject item)//instancia el prefab y lo mueve cada vez con un multiplicador de x (no funca) Xd
    {
        Vector3 posicionNueva = new Vector3(position,0,0);
        colaFront.position.Scale(posicionNueva);
        Debug.Log("position new vector: "+posicionNueva);
        Instantiate(item, colaFront.position,Quaternion.identity);
        Clients.Add(item);
        position++;
        Debug.Log("posicion nueva: "+position);
    }

    public GameObject Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("La cola esta vacia");
        }

        GameObject item = Clients[0];
        Clients.RemoveAt(0);
        return item;
    }

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(pfMonster, colaFront.position,Quaternion.identity);
    }
    

    public void MonstruoIngresando()
    {
        Enqueue(pfMonster);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
