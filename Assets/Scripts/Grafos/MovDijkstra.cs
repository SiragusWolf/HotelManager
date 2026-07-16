using System.Collections.Generic;
using UnityEngine;

public class MovDijkstra : MonoBehaviour
{
    [SerializeField] private float speed;

    private bool arrivedToDestination = true;

    private List<GameObject> pasos = new List<GameObject>();
    private List<bool> pasosCumplidos = new List<bool>();
    private Vector3 destinoPos;
    private Vector3 proximoNodoPos;
    private SpriteRenderer _spriteRenderer;

    private Vector3 posInicial;

    private void Start()
    {
        posInicial = transform.position;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (arrivedToDestination) return;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, proximoNodoPos, step);

        if (!Mathf.Approximately(proximoNodoPos.y, transform.position.y))
        {
            _spriteRenderer.enabled = false;
        }
        else
        {
            _spriteRenderer.enabled = true;
        }

        if (proximoNodoPos.x < transform.position.x)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }

        if (proximoNodoPos != transform.position) return;

        if (transform.position == destinoPos)
        {
            arrivedToDestination = true;
            _spriteRenderer.enabled = false;
            return;
        }

        GameObject siguienteNodo = proximoNodo();
        if (siguienteNodo != null)
        {
            proximoNodoPos = siguienteNodo.transform.position;
        }
    }

    public void Movimiento(Hotel hotelR, GameObject destino)
    {
        pasos = hotelR.DevolverCamino(destino);
        pasosCumplidos = new List<bool>();
        arrivedToDestination = false;
        destinoPos = destino.transform.position;

        foreach (var paso in pasos)
        {
            pasosCumplidos.Add(false);
        }

        GameObject siguienteNodo = proximoNodo();
        if (siguienteNodo != null)
        {
            proximoNodoPos = siguienteNodo.transform.position;
        }
    }

    private GameObject proximoNodo()
    {
        GameObject nodo = null;
        Vector3 currentPos = transform.position;

        for (int i = 0; i < pasosCumplidos.Count; i++)
        {
            if (currentPos == pasos[i].transform.position)
            {
                pasosCumplidos[i] = true;
            }
        }

        for (int i = 0; i < pasosCumplidos.Count; i++)
        {
            if (!pasosCumplidos[i])
            {
                nodo = pasos[i];
                return nodo;
            }
        }

        return nodo;
    }

    private void ResetPos()
    {
        transform.position = posInicial;
        proximoNodoPos = posInicial;
    }
}
