using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] GameObject emptyInventoryItem = default;
    int numberOfItems;
    Dictionary<string, InventoryStoredItem> inventoryItems = default;
    InventoryStoredItem inventoryStoredItem;
    public event Action<GameObject> onPickedUpEvent;
    
    //public Dictionary<string, InventoryStoredItem> InventoryItems { get { return inventoryItems; } }

    public Inventory()
    {
        inventoryItems = new Dictionary<string, InventoryStoredItem>();
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
