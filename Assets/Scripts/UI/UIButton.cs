using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class UIButton : MonoBehaviour
{
    protected GameController gameControllerInstance = default;

    protected Button uiButton;
    private void Awake()
    {
        uiButton = GetComponent<Button>();
    }

    protected virtual void OnEnable()
    {
        uiButton.onClick.AddListener(onButtonClick);
    }

    protected virtual void Start()
    {
        gameControllerInstance = GameController.Instance;
    }

    protected virtual void OnDisable()
    {
        uiButton.onClick.RemoveListener(onButtonClick);
    }

    void onButtonClick()
    {
        gameControllerInstance.InventoryController.InventoryToggleFunc();
    }
}
