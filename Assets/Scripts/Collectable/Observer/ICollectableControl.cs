using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableControl
{
    //delegate void PickedUpEvent(GameObject gameObject);
    event Action <GameObject> onPickedUpEvent;
    void OnPickedUp(GameObject gameObject);
    
}

public interface IInventory
{
    event Action onAddedToInventory;
    event Action<InventoryCollectable> onItemSelected;
}
