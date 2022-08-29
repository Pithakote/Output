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
    public Image inventoryDisplayImage { get; private set; }
    public TMP_Text inventoryItemNameText { get; private set; }
    public TMP_Text inventoryItemDescriptionText { get; private set; }

    public InventoryDisplayPanel(Image displayImage,
                                TMP_Text displayName,
                                TMP_Text displayDescription)
    {
        inventoryDisplayImage = displayImage;
        inventoryItemNameText = displayName;
        inventoryItemDescriptionText = displayDescription;
    }
}

class InventoryStoredItem
{
    public InventoryCollectable InventoryItem;
    public int NumberOfItems;
    
    public InventoryStoredItem(InventoryCollectable inventoryItem)
    {
        InventoryItem = inventoryItem;
        NumberOfItems++;
    }
}
public class Inventory 
{    
    int numberOfItems;
    Dictionary<string, InventoryStoredItem> inventoryItems = default;
    InventoryStoredItem inventoryStoredItem;
    InventoryDisplayPanel inventoryDisplayPanel;
    UIInventoryItemCell uiIntentoryCell;
    Transform inventoryDisplayContent;
    public event Action<GameObject> onPickedUpEvent;
    
    //public Dictionary<string, InventoryStoredItem> InventoryItems { get { return inventoryItems; } }

    public Inventory(InventoryDisplayPanel inventoryDisplayPanel,
                        UIInventoryItemCell uiIntentoryCell,
                        Transform inventoryDisplayContent)
    {
        inventoryItems = new Dictionary<string, InventoryStoredItem>();
        this.inventoryDisplayPanel = inventoryDisplayPanel;
        this.uiIntentoryCell = uiIntentoryCell;
        this.inventoryDisplayContent = inventoryDisplayContent;
    }
 

    public void AddToDictionary(InventoryCollectable inventoryItem)
    {
        //inventoryStoredItem = new InventoryStoredItem(inventoryItem);

       if (inventoryItems.ContainsKey(inventoryItem.NameOfItem))
        {
            inventoryItems[inventoryItem.NameOfItem].NumberOfItems++;


        }
        else
        {
            inventoryItems.Add(inventoryItem.NameOfItem, new InventoryStoredItem(inventoryItem));

            uiIntentoryCell.InventoryItemImage.sprite = inventoryItem.ImageOfItem;
            uiIntentoryCell.InventoryItemName.text = inventoryItem.NameOfItem;
            uiIntentoryCell.InventoryItemCounter.text = inventoryItems[inventoryItem.NameOfItem].NumberOfItems.ToString();

            GameObject.Instantiate(uiIntentoryCell.gameObject,Vector3.zero, Quaternion.identity,inventoryDisplayContent);
           
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
