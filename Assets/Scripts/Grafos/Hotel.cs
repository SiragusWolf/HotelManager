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

        AlgDijkstra dijkstra = new AlgDijkstra(puertasGrafo, puertas[o]);

        GameObject destino = puertas[d];
        List<GameObject> camino = dijkstra.ObtenerCamino(destino);
        
        IluminarCamino(destino, camino);
    }

    void IluminarCamino(GameObject destino, List<GameObject> camino)
    {
        foreach (GameObject paso in camino)
        {
            paso.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        destino.GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
