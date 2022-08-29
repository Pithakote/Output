using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIInventoryItemCell : MonoBehaviour
{
    [Header("Inventory Item Cells")]
    [SerializeField] Image inventoryItemImage;
    [SerializeField] TMP_Text inventoryItemName;
    [SerializeField] TMP_Text inventoryItemCounter;
    [SerializeField] UIInventoryItemButton inventoryItemButton;

    public Image InventoryItemImage { get { return inventoryItemImage; } }
    public TMP_Text InventoryItemName { get { return inventoryItemName; } }
    public TMP_Text InventoryItemCounter { get { return inventoryItemCounter; } }
    public UIInventoryItemButton InventoryItemButton { get { return inventoryItemButton; } }
}
