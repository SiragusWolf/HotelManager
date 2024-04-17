using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private GameObject _selectedObject;
    [SerializeField] private GameObject _clickedObject;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;
        
        Debug.Log(rayhit.collider.gameObject.name);
        
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
                Debug.Log(("Objeto ", _clickedObject.name, " clickeado"));
                
                if (_selectedObject != null)
                {
                    tempClickable.OnClick(_selectedObject);
                }

                break;
            }
        }
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
