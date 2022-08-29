using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController  
{
    Inventory inventory;

    public delegate void InventoryToggle();
    public event InventoryToggle inventoryToggleEvent;

    
    public bool InventoryOpen { get; private set; }

    public event Action<GameObject> onPickedUpEvent;


    GameObject inventoryUI;
    
    public InventoryController(GameObject inventoryUI, Inventory inventory)
    {
        this.inventory = inventory;
        this.inventoryUI = inventoryUI;
    }

    private void Awake()
    {
        InventoryOpen = false;
    }
    public void OnEnable()
    {
        inventoryToggleEvent += OpenCloseInventory;
    }

    public void Setup(Inventory inventory)
    {
        this.inventory = inventory;
    }
    public void OnDisable()
    {
        inventoryToggleEvent -= OpenCloseInventory;
    }
    public void OnPickedUp(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    public void Update()
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
                    inventoryUI.SetActive(false);
                    InventoryOpen = false;
                    break;
                }
            case false:
                {
                    //open inventory
                    inventoryUI.SetActive(true);
                    InventoryOpen = true;
                    break;
                }
        }
    }


}
