using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController  
{
    public InventoryController(Inventory inventory)
    {
       
    }

   

    public event Action<GameObject> onPickedUpEvent;

    public void OnPickedUp(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
}
