using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrafoTDA
{
        void InicializarGrafo();
        void AgregarVertice(GameObject v);
        void EliminarVertice(GameObject v);
        IConjuntoTDA Vertices();
        void AgregarArista(GameObject v1, GameObject v2, int peso);
        void EliminarArista(GameObject v1, GameObject v2);
        bool ExisteArista(GameObject v1, GameObject v2);
        int PesoArista(GameObject v1, GameObject v2);
        IEnumerable<GameObject> ObtenerVertices();
}
