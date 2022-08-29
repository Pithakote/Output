using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryButton : UIButton
{
    protected override void onButtonClick()
    {
        gameControllerInstance.InventoryController.InventoryToggleFunc();
    }
}
