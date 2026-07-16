using TDA_Codigo;
using UnityEngine;

public class PilaNueva : MonoBehaviour, IPilaInterface
{
    public static PilaNueva Instance;

    [SerializeField] public GameObject Jaime1;
    [SerializeField] public GameObject Jaime2;
    [SerializeField] public GameObject Jaime3;

    [SerializeField] public GameObject[] standBy;
    [SerializeField] public GameObject[] trabajando;
    [SerializeField] public Transform[] standByPos;
    [SerializeField] public Transform[] trabajandoPos;

    [SerializeField] public GameObject Room;
    public int copiaIndex;
    public int copiaIndexAuxiliar;

    public GameObject[] items = null;
    public GameObject[] itemsAux = null;
    public int index;
    public int indexAux;
    public bool isActive;
    public bool isActiveAux;
    public string name;
    public string nameAux;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    public void Start()
    {
        isActive = true;
        isActiveAux = true;

        index = 0;
        indexAux = 0;
        items = InicializarPila(3, "-pila");
        itemsAux = InicializarPila(3, "-pilaAux");
        CargarPila();
    }

    private void Update()
    {
        copiaIndex = index;
        copiaIndexAuxiliar = indexAux;
    }

    public void pruebaPop()
    {
        GameObject jaime = Pop();
        if (jaime == null) return;

        PushAux(jaime);
        RefreshAssistantPositions();
    }

    public void pruebaPush()
    {
        GameObject jaime = PopAux();
        if (jaime == null) return;

        Debug.Log("se intenta popear de working a standby" + jaime.name + " " + indexAux + nameAux);
        Push(jaime);
        RefreshAssistantPositions();
    }

    public void volverAlServicio(GameObject asistente)
    {
        if (asistente == null) return;

        RemoveFromAux(asistente);
        if (Contains(items, index, asistente)) return;

        Debug.Log("se pusheo a " + asistente.name + " y se recibio como parametro: " + asistente.name);
        Push(asistente);
        RefreshAssistantPositions();
    }

    public GameObject servicioHabitacion()
    {
        GameObject jaime = Pop();
        if (jaime == null) return null;

        PushAux(jaime);
        RefreshAssistantPositions();
        return jaime;
    }

    public void CargarPila()
    {
        Push(Jaime1);
        Push(Jaime2);
        Push(Jaime3);
        copiaIndex = index;
        RefreshAssistantPositions();
    }

    public GameObject checkService()
    {
        return LastItem();
    }

    public bool IsAvailable(GameObject assistant)
    {
        return Contains(items, index, assistant);
    }

    public bool StartService(GameObject assistant)
    {
        if (!RemoveFromAvailable(assistant))
        {
            return false;
        }

        PushAux(assistant);
        RefreshAssistantPositions();
        return true;
    }

    public GameObject[] InicializarPila(int cantidad, string nombre)
    {
        return new GameObject[cantidad];
    }

    public GameObject Pop()
    {
        if (index != 0)
        {
            index--;
            GameObject popItem = items[index];
            items[index] = null;
            Debug.Log("pop: " + popItem.name);
            return popItem;
        }

        Debug.Log("La pila no existe");
        return null;
    }

    public void Push(GameObject newItem)
    {
        if (newItem == null) return;
        if (Contains(items, index, newItem)) return;

        if (isActive && index < items.Length)
        {
            items[index] = newItem;
            index++;
            Debug.Log("se intenta pushear " + newItem + " en index:" + index + " de pila " + name);
        }
        else
        {
            Debug.Log("error al pushear, esta llena o :" + isActive);
        }
    }

    public GameObject LastItem()
    {
        if (index != 0)
        {
            return items[index - 1];
        }

        return null;
    }

    public GameObject PopAux()
    {
        if (indexAux != 0)
        {
            indexAux--;
            GameObject popItem = itemsAux[indexAux];
            itemsAux[indexAux] = null;
            Debug.Log("pop: " + popItem.name);
            return popItem;
        }

        Debug.Log("La pila no existe");
        return null;
    }

    public void PushAux(GameObject newItem)
    {
        if (newItem == null) return;
        if (Contains(itemsAux, indexAux, newItem)) return;

        if (isActiveAux && indexAux < itemsAux.Length)
        {
            itemsAux[indexAux] = newItem;
            indexAux++;
            Debug.Log("se intenta pushear " + newItem + " en index:" + indexAux + " de pila " + nameAux);
        }
        else
        {
            Debug.Log("error al pushear, esta llena o :" + isActiveAux);
        }
    }

    public GameObject LastItemAux()
    {
        if (indexAux != 0)
        {
            return itemsAux[indexAux - 1];
        }

        return null;
    }

    public void Clear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }

        for (int i = 0; i < itemsAux.Length; i++)
        {
            itemsAux[i] = null;
        }

        index = 0;
        indexAux = 0;
        RefreshAssistantPositions();
    }

    public bool IsEmpty()
    {
        if (!isActive)
        {
            throw new System.Exception("La pila no existe");
        }

        return index == 0;
    }

    private void RemoveFromAux(GameObject assistant)
    {
        for (int i = 0; i < indexAux; i++)
        {
            if (itemsAux[i] != assistant) continue;

            for (int j = i + 1; j < indexAux; j++)
            {
                itemsAux[j - 1] = itemsAux[j];
            }

            indexAux--;
            itemsAux[indexAux] = null;
            return;
        }
    }

    private bool RemoveFromAvailable(GameObject assistant)
    {
        for (int i = 0; i < index; i++)
        {
            if (items[i] != assistant) continue;

            for (int j = i + 1; j < index; j++)
            {
                items[j - 1] = items[j];
            }

            index--;
            items[index] = null;
            return true;
        }

        return false;
    }

    private bool Contains(GameObject[] stack, int count, GameObject item)
    {
        if (stack == null || item == null) return false;

        for (int i = 0; i < count; i++)
        {
            if (stack[i] == item)
            {
                return true;
            }
        }

        return false;
    }

    private void RefreshAssistantPositions()
    {
        if (items == null || itemsAux == null) return;

        for (int i = 0; i < index; i++)
        {
            if (items[i] != null && standByPos != null && i < standByPos.Length && standByPos[i] != null)
            {
                items[i].transform.position = standByPos[i].position;
            }
        }

        for (int i = 0; i < indexAux; i++)
        {
            if (itemsAux[i] != null && trabajandoPos != null && i < trabajandoPos.Length && trabajandoPos[i] != null)
            {
                itemsAux[i].transform.position = trabajandoPos[i].position;
            }

            if (trabajando != null && i < trabajando.Length)
            {
                trabajando[i] = itemsAux[i];
            }
        }

        if (trabajando == null) return;

        for (int i = indexAux; i < trabajando.Length; i++)
        {
            trabajando[i] = null;
        }
    }
}
