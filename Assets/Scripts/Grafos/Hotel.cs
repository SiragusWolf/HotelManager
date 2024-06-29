using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotel : MonoBehaviour
{
    private GrafoDinamico puertasGrafo = new GrafoDinamico();
    [SerializeField] private GameObject[] puertas;
    [SerializeField] private GameObject[] pasillos;

    public int o;
    public int d;
    
    void Start()
    {
        puertasGrafo.InicializarGrafo();
        foreach (GameObject puerta in puertas)
        {
            puertasGrafo.AgregarVertice(puerta);
        }

        foreach (GameObject pasillo in pasillos)
        {
            Arista aux = pasillo.GetComponent<Arista>();
            puertasGrafo.AgregarArista(aux.v1, aux.v2, aux.peso);
        }

        
    }

    public void CalcularCamino(GameObject destino)
    {
        AlgDijkstra dijkstra = new AlgDijkstra(puertasGrafo, puertas[0]);

        //GameObject destino = puertas[d];
        
        List<GameObject> camino = dijkstra.ObtenerCamino(destino);
        
        IluminarCamino(destino, camino);
    }
    
    public List<GameObject> DevolverCamino(GameObject destino)
    {
        AlgDijkstra dijkstra = new AlgDijkstra(puertasGrafo, puertas[0]);

        //GameObject destino = puertas[d];
        
        List<GameObject> camino = dijkstra.ObtenerCamino(destino);

        return camino;
    }

    void IluminarCamino(GameObject destino, List<GameObject> camino)
    {
        
        
        foreach (GameObject paso in camino)
        {
            paso.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        
        camino[0].GetComponent<SpriteRenderer>().color = Color.green;
        camino[1].GetComponent<SpriteRenderer>().color = Color.cyan;
        
        destino.GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    void Update()
    {
        
    }
}
