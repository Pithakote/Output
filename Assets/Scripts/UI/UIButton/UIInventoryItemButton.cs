using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItemButton : UIButton
{
    [SerializeField]
    InventoryDisplayPanel displayPanel = default;
    [SerializeField] InventoryStoredItem inventoryStoredItem = default;
    IInventory iController;
    protected override void Awake()
    {
        base.Awake();
        
    }

    public void Setup(InventoryDisplayPanel displayPanel, InventoryStoredItem inventoryStoredItem, IInventory iController)
    {
        this.displayPanel = displayPanel;
        this.inventoryStoredItem = inventoryStoredItem;
        this.iController = iController;

        this.iController.onItemSelected += SelectCell;
    }
    private void OnDisable()
    {
        this.iController.onItemSelected -= SelectCell;
    }

    private void OnDestroy()
    {
        this.iController.onItemSelected -= SelectCell;
    }
     void SelectCell(InventoryCollectable iCollectable = null)
    {
        SetupImages();
        iCollectable = this.inventoryStoredItem.InventoryItem;
    }

    protected override void onButtonClick()
    {
        //displayPanel.SetDisplayProperties();
        SelectCell();
    }

    void SetupImages()
    {

        Debug.Log("The current gameobject is: " + this.gameObject.name);
        this.displayPanel.SetDisplayProperties(this.inventoryStoredItem.InventoryItem.ImageOfItem,
                                            this.inventoryStoredItem.InventoryItem.NameOfItem,
                                            this.inventoryStoredItem.InventoryItem.DescriptionOfItem);
    }
}

