using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColaTest : MonoBehaviour
{
    
    [SerializeField] private GameObject[] pfMonster;
    
    [SerializeField] private Transform colaFront;
    [SerializeField] private Transform colaStart;
    [SerializeField] private List<GameObject> Clients = new List<GameObject>();
    public int position =0;
    public bool IsEmpty()
    {
        return !Clients.Any();
    }
    
    /*void Update()
    {
        for (int i = 0; i < Clients.Count; i++)
        {
            var monsterIndex = Clients[i].GetComponent<Monster>();
            Clients[i].transform.position += new Vector3(5*Time.deltaTime, 0, 0);
            Debug.Log(Clients[i].name + "se esta intentando mover");
        }
    }*/
    
    public void Enqueue(GameObject item)//instancia el prefab y lo mueve cada vez con un multiplicador de x (no funca) Xd
    {
        /*Vector3 posicionNueva = new Vector3(position,0,0);
        colaFront.position.Scale(posicionNueva);
        Debug.Log("position new vector: "+posicionNueva);*/
        Instantiate(item, colaStart.position,Quaternion.identity);
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

    public void MonstruoIngresando()
    {
        int monster = Random.Range(0, pfMonster.Length);
        Enqueue(pfMonster[monster]);
    }


}
