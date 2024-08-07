using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private AssistantsManager assManager;
    public PilaNueva _pilaNueva;
    public ColaNueva _ColaNueva;
    public UnityEvent SetTime = new UnityEvent();
    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        Instance = this; 
        _mainCamera = Camera.main;

        assManager = GameObject.FindGameObjectWithTag("AssistantManager").GetComponent<AssistantsManager>();
    }

 

    private Camera _mainCamera;
    [SerializeField] private GameObject _selectedObject;
    [SerializeField] public GameObject _clickedObject;
    [SerializeField] private GameObject _roomUpgrade;
    public bool roomOk;
    public GameObject selectedRoom;
    
    
    
    private void Update()
    {
        if (GameManager.Instance.isPause == true)
        {
            _selectedObject = null;
        }
    }
    
    
    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;
        
        //Debug.Log(rayhit.collider.gameObject.name);
        
        var tempMonoArray = rayhit.collider.gameObject.GetComponents<MonoBehaviour>();
 
        foreach (var monoBehaviour in tempMonoArray)
        {
            if (monoBehaviour is ISelectable tempSelectable)
            {
                if (_selectedObject != null)
                {
                    _selectedObject.GetComponent<ISelectable>().OnDeselect();
                }
                _selectedObject = rayhit.collider.gameObject;
                _selectedObject.GetComponent<ISelectable>().OnSelect();
                //Debug.Log(("Objeto ", _selectedObject.name, " seleccionado"));
                //tempSelectable.OnSelect();
                break;
            }
            
            if (monoBehaviour is IClickable tempClickable)
            {
                
                _clickedObject = rayhit.collider.gameObject;
                //Debug.Log(("Objeto ", _clickedObject.name, " clickeado"));
                
                if (_selectedObject != null)
                {
                    tempClickable.OnClick(_selectedObject);
                }

                break;
            }
        }
    }

    public void UpgradeRoom()
    {
        _selectedObject = _roomUpgrade;
    }

    public void RoomService()
    {
        //_selectedObject = assManager.Pop();
        //_selectedObject = nuevaPila.Pop();
        //_selectedObject= _pilaNueva.servicioHabitacion();
        if (_selectedObject == null)
        {
            Debug.Log("Se intento llamar el RoomService() pero error    --- -------------");
        }
    }

    public void recieveGuest()
    {
        GameObject peekCola = ColaNueva.Instance.FirstItem();
        _selectedObject = peekCola;
        //Debug.Log("se peekeo " + peekCola.name);
        SetTime.Invoke();
    }

    public void ACtivarService()
    {
        GameObject jaime = _pilaNueva.checkService();
  
       
        if (roomOk == true)
        {
            roomOk = false;
        }
        else
        {
            roomOk = true;
        }
        if (jaime == null) roomOk = false;
        _selectedObject = jaime;

    }

   

    public void clearSelected()
    {
        _selectedObject = null;
    }

    /*public static void GetInterfaces<T>(out List<T> resultList, GameObject objectToSearch) where T: class
    {
        MonoBehaviour[] list = objectToSearch.GetComponents<MonoBehaviour>();
        resultList = new List<T>();
        foreach(MonoBehaviour mb in list){
            if(mb is T){
                //found one
                resultList.Add((T)((System.Object)mb));
            }
        }
    }*/
}
