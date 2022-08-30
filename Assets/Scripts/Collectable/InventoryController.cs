using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryController  : IInventory
{
    Inventory inventory;

    public delegate void InventoryToggle();
    public event InventoryToggle inventoryToggleEvent;
    public event Action onAddedToInventory;

    InventoryDisplayPanel inventoryDisplayPanel;
    UIInventoryItemCell uiIntentoryCell;
    Transform inventoryDisplayContent;
    TMP_Text inventoryCounter;
    public bool InventoryOpen { get; private set; }

    


    GameObject inventoryUI;
    
    public Inventory Inventory { get { return inventory; } }

    public InventoryController(GameObject inventoryUI,
                                Inventory inventory,
                                InventoryDisplayPanel inventoryDisplayPanel,
                                UIInventoryItemCell uiIntentoryCell,
                                TMP_Text inventoryCounter,
                                Transform inventoryDisplayContent)
    {
        this.inventory = inventory;
        this.inventoryUI = inventoryUI;
        this.inventoryDisplayPanel = inventoryDisplayPanel;
        this.uiIntentoryCell = uiIntentoryCell;
        this.inventoryDisplayContent = inventoryDisplayContent;
        this.inventoryCounter = inventoryCounter;

        this.inventory.Setup(this);
    }

    private void Awake()
    {
        InventoryOpen = false;
    }
    public void OnEnable()
    {
        inventoryToggleEvent += OpenCloseInventory;
        onAddedToInventory += UpdateCounterAdd;
    }

    private void UpdateCounterAdd()
    {
        this.inventoryCounter.text = "(" + inventory.NumberOfItems + "/" + inventory.MaxNumberOfItems + ")";
    }

    public void Setup(Inventory inventory)
    {
        this.inventory = inventory;
    }
    public void OnDisable()
    {
        inventoryToggleEvent -= OpenCloseInventory;
        onAddedToInventory -= UpdateCounterAdd;
    }
    public void OnPickedUp(GameObject gameObject)
    {
        
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
    public bool CanItemsBeAdded()
    {
       return inventory.CanBeAdded();
    }

    public void AddToDictionary(InventoryCollectable inventoryItem)
    {
        //inventoryStoredItem = new InventoryStoredItem(inventoryItem)
        if (this.inventory.InventoryItems.ContainsKey(inventoryItem.NameOfItem))
        {
            this.inventory.InventoryItems[inventoryItem.NameOfItem].NumberOfItems++;

            this.inventory.InventoryItems[inventoryItem.NameOfItem].itemCell.InventoryItemCounter.text = this.inventory.InventoryItems[inventoryItem.NameOfItem].NumberOfItems.ToString();

        }
        else
        {
            uiIntentoryCell.InventoryItemImage.sprite = inventoryItem.ImageOfItem;
            uiIntentoryCell.InventoryItemName.text = inventoryItem.NameOfItem;

            // this.monoBehaviour.StartCoroutine(WaitForInstantiation(inventoryItem));
            GameObject inventoryCell = GameObject.Instantiate(uiIntentoryCell.gameObject, Vector3.zero, Quaternion.identity, inventoryDisplayContent);

            //  yield return new WaitUntil(() => inventoryCell.activeInHierarchy);
            this.inventory.InventoryItems.Add(inventoryItem.NameOfItem, new InventoryStoredItem(inventoryItem, inventoryCell.GetComponent<UIInventoryItemCell>()));

            uiIntentoryCell.InventoryItemCounter.text = this.inventory.InventoryItems[inventoryItem.NameOfItem].NumberOfItems.ToString();

            inventoryCell.GetComponent<UIInventoryItemCell>().InventoryItemButton.Setup(inventoryDisplayPanel, this.inventory.InventoryItems[inventoryItem.NameOfItem]);
            inventoryCell.GetComponent<UIInventoryItemCell>().InventoryItemButton.SetupImages();
        }

        onAddedToInventory.Invoke();
    }


}
