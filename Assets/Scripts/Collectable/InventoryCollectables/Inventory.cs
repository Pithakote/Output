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
    int numberOfItems;
    Dictionary<string, InventoryStoredItem> inventoryItems = default;
    InventoryStoredItem inventoryStoredItem;
    InventoryDisplayPanel inventoryDisplayPanel;
    UIInventoryItemCell uiIntentoryCell;
    Transform inventoryDisplayContent;
    MonoBehaviour monoBehaviour;
    public event Action<GameObject> onPickedUpEvent;
    
    //public Dictionary<string, InventoryStoredItem> InventoryItems { get { return inventoryItems; } }

    public Inventory(InventoryDisplayPanel inventoryDisplayPanel,
                        UIInventoryItemCell uiIntentoryCell,
                        Transform inventoryDisplayContent,
                        MonoBehaviour monoBehaviour)
    {
        inventoryItems = new Dictionary<string, InventoryStoredItem>();
        this.inventoryDisplayPanel = inventoryDisplayPanel;
        this.uiIntentoryCell = uiIntentoryCell;
        this.inventoryDisplayContent = inventoryDisplayContent;
        this.monoBehaviour = monoBehaviour;
    }
 

    public void AddToDictionary(InventoryCollectable inventoryItem)
    {
        //inventoryStoredItem = new InventoryStoredItem(inventoryItem)
        if (inventoryItems.ContainsKey(inventoryItem.NameOfItem))
        {
            inventoryItems[inventoryItem.NameOfItem].NumberOfItems++;

            inventoryItems[inventoryItem.NameOfItem].itemCell.InventoryItemCounter.text = inventoryItems[inventoryItem.NameOfItem].NumberOfItems.ToString();
        }
        else
        {
            uiIntentoryCell.InventoryItemImage.sprite = inventoryItem.ImageOfItem;
            uiIntentoryCell.InventoryItemName.text = inventoryItem.NameOfItem;
            
            // this.monoBehaviour.StartCoroutine(WaitForInstantiation(inventoryItem));
            GameObject inventoryCell = GameObject.Instantiate(uiIntentoryCell.gameObject, Vector3.zero, Quaternion.identity, inventoryDisplayContent);

            //  yield return new WaitUntil(() => inventoryCell.activeInHierarchy);
            inventoryItems.Add(inventoryItem.NameOfItem, new InventoryStoredItem(inventoryItem, inventoryCell.GetComponent<UIInventoryItemCell>()));

            uiIntentoryCell.InventoryItemCounter.text = inventoryItems[inventoryItem.NameOfItem].NumberOfItems.ToString();

            inventoryCell.GetComponent<UIInventoryItemCell>().InventoryItemButton.Setup(inventoryDisplayPanel, inventoryItems[inventoryItem.NameOfItem]);
            inventoryCell.GetComponent<UIInventoryItemCell>().InventoryItemButton.SetupImages();

            

            
        }
    }

    IEnumerator WaitForInstantiation(InventoryCollectable inventoryItem)
    {
        GameObject inventoryCell = GameObject.Instantiate(uiIntentoryCell.gameObject, Vector3.zero, Quaternion.identity, inventoryDisplayContent);

        yield return new WaitUntil(() => inventoryCell.activeInHierarchy);

        inventoryCell.GetComponent<UIInventoryItemCell>().InventoryItemButton.Setup(inventoryDisplayPanel, inventoryItems[inventoryItem.NameOfItem]);

        inventoryItems.Add(inventoryItem.NameOfItem, new InventoryStoredItem(inventoryItem, inventoryCell.GetComponent<UIInventoryItemCell>()));

    }

    public int GetNumberOfItems()
    {
        int numofItems = default;
        List<InventoryCollectable> hams = new List<InventoryCollectable>();
        InventoryCollectable ham = default;

        
        return 0;
    }

    
}
