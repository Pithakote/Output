using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItemButton : UIButton
{
    [SerializeField]
    InventoryDisplayPanel displayPanel = default;
    [SerializeField] InventoryStoredItem inventoryStoredItem = default;

    protected override void Awake()
    {
        base.Awake();
        
    }

    public void Setup(InventoryDisplayPanel displayPanel, InventoryStoredItem inventoryStoredItem)
    {
        this.displayPanel = displayPanel;
        this.inventoryStoredItem = inventoryStoredItem;
    }

    protected override void onButtonClick()
    {
        //displayPanel.SetDisplayProperties();
        SetupImages();
    }

    public void SetupImages()
    {

        Debug.Log("The current gameobject is: " + this.gameObject.name);
        this.displayPanel.SetDisplayProperties(this.inventoryStoredItem.InventoryItem.ImageOfItem,
                                            this.inventoryStoredItem.InventoryItem.NameOfItem,
                                            this.inventoryStoredItem.InventoryItem.DescriptionOfItem);
    }
}

