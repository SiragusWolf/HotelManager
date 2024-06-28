using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgDijkstra
{
    private GrafoDinamico grafo;
    private NodoGrafo origen;
    private Dictionary<GameObject, int> distancias;
    private Dictionary<GameObject, GameObject> previos;

    public AlgDijkstra(GrafoDinamico grafo, GameObject nodoOrigen)
    {
        this.grafo = grafo;
        this.origen = grafo.Vert2Nodo(nodoOrigen);

        distancias = new Dictionary<GameObject, int>();
        previos = new Dictionary<GameObject, GameObject>();

        // Inicializar distancias y previos
        foreach (GameObject v in grafo.ObtenerVertices())
        {
            distancias[v] = int.MaxValue;
            previos[v] = null;
        }
        distancias[nodoOrigen] = 0;

        EjecutarDijkstra();
    }

    private void EjecutarDijkstra()
    {
        List<GameObject> noVisitados = new List<GameObject>(grafo.ObtenerVertices());

        while (noVisitados.Count > 0)
        {
            // Encontrar nodo con la distancia mínima entre los no visitados
            GameObject u = null;
            int distanciaMinima = int.MaxValue;
            foreach (GameObject nodo in noVisitados)
            {
                if (distancias[nodo] < distanciaMinima)
                {
                    distanciaMinima = distancias[nodo];
                    u = nodo;
                }
            }

            noVisitados.Remove(u); // Marcar como visitado

            // Si u es null, significa que no quedan nodos accesibles y podemos salir del bucle
            if (u == null)
                break;

            // Actualizar distancias de los nodos adyacentes
            NodoGrafo nodoU = grafo.Vert2Nodo(u);
            NodoArista arista = nodoU.arista;
            while (arista != null)
            {
                GameObject v = arista.nodoDestino.valorNodo;
                int peso = arista.pesoArista;
                int distanciaActual = distancias[u] + peso;

                if (distanciaActual < distancias[v])
                {
                    distancias[v] = distanciaActual;
                    previos[v] = u;
                }

                arista = arista.sigArista;
            }
        }
    }

    public List<GameObject> ObtenerCamino(GameObject destino)
    {
        List<GameObject> camino = new List<GameObject>();
        GameObject actual = destino;
        while (actual != null)
        {
            camino.Insert(0, actual); // Insertar al inicio para obtener el camino en orden correcto
            actual = previos[actual];
        }
        return camino;
    }

    public int ObtenerDistancia(GameObject destino)
    {
        return distancias[destino];
    }
}