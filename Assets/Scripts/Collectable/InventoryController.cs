using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController  : MonoBehaviour
{
    public delegate void InventoryToggle();
    public event InventoryToggle inventoryToggleEvent;

    [SerializeField] GameObject InventoryUI;
    public bool InventoryOpen { get; private set; }

    public event Action<GameObject> onPickedUpEvent;

    private void Awake()
    {
        InventoryOpen = false;
    }
    private void OnEnable()
    {
        inventoryToggleEvent += OpenCloseInventory;
    }

    private void OnDisable()
    {
        inventoryToggleEvent -= OpenCloseInventory;
    }
    public void OnPickedUp(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryToggleFunc();
        }
    }
    public void InventoryToggleFunc()
    {
        inventoryToggleEvent.Invoke();
    }
    private void OpenCloseInventory()
    {
        switch (InventoryOpen)
        {
            case true:
                {
                    //close inventory
                    InventoryUI.SetActive(false);
                    InventoryOpen = false;
                    break;
                }
            case false:
                {
                    //open inventory
                    InventoryUI.SetActive(true);
                    InventoryOpen = true;
                    break;
                }
        }
    }


}
