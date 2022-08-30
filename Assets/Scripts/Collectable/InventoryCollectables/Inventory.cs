using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemsDisplayCell
{
    [SerializeField] Image inventoryItemImage;
    [SerializeField] TMP_Text inventoryItemName;
    [SerializeField] TMP_Text inventoryItemCounter;

    public InventoryItemsDisplayCell(Image displayImage,
                                TMP_Text displayName,
                                TMP_Text displayCounter)
    {
        inventoryItemImage = displayImage;
        inventoryItemName = displayName;
        inventoryItemCounter = displayCounter;
    }
}
public class InventoryDisplayPanel
{
    public Image inventoryDisplayImage { get; set; }
    public TMP_Text inventoryItemNameText { get; set; }
    public TMP_Text inventoryItemDescriptionText { get; set; }

    public InventoryDisplayPanel(Image displayImage,
                                TMP_Text displayName,
                                TMP_Text displayDescription)
    {
        inventoryDisplayImage = displayImage;
        inventoryItemNameText = displayName;
        inventoryItemDescriptionText = displayDescription;
    }

    public void SetDisplayProperties(Sprite imageSprite, string nameOfItem, string descriptionOfItem)
    {
        inventoryDisplayImage.sprite = imageSprite;
        inventoryItemNameText.text = nameOfItem;
        inventoryItemDescriptionText.text = descriptionOfItem;
    }
}

public class InventoryStoredItem
{
    public InventoryCollectable InventoryItem;
    public int NumberOfItems;
    public UIInventoryItemCell itemCell;

    public InventoryStoredItem(InventoryCollectable inventoryItem, UIInventoryItemCell itemCell)
    {
        InventoryItem = inventoryItem;
        this.itemCell = itemCell;
        NumberOfItems++;
    }
}
public class Inventory 
{    
    public int NumberOfItems { get; private set; }
    int maxNumberOfItems = 100;
    public int MaxNumberOfItems { get { return maxNumberOfItems; } }
    Dictionary<string, InventoryStoredItem> inventoryItems = default;
    InventoryStoredItem inventoryStoredItem;
    IInventory IController;
    MonoBehaviour monoBehaviour;
    public event Action<GameObject> onPickedUpEvent;
    
    public Dictionary<string, InventoryStoredItem> InventoryItems { get { return inventoryItems; } }

    public Inventory(MonoBehaviour monoBehaviour)
    {
        inventoryItems = new Dictionary<string, InventoryStoredItem>();
        this.monoBehaviour = monoBehaviour;
    }

    public void Setup(IInventory IController)
    {
        this.IController = IController;
        this.IController.onAddedToInventory += IncreaseNumber; 
    }
    
    private void IncreaseNumber()
    {
        NumberOfItems++;
    }

    public bool CanBeAdded()
    {
        if (NumberOfItems >= maxNumberOfItems)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    


    public int GetNumberOfItems()
    {
        int numofItems = default;
        List<InventoryCollectable> hams = new List<InventoryCollectable>();
        InventoryCollectable ham = default;

        
        return 0;
    }

    
}
