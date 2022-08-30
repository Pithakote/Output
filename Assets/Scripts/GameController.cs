using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
	public static GameController Instance { get; private set; }

	[Header("UI Controller Referenced")]
	[SerializeField] private Transform UIControllerObject;
	[SerializeField] GameObject InventoryUI;

	[Header("Original variables that came with the project")]
	public CharacterController characterController;
	public bool hardMode;

	[Header("Inventory object references")]

	[Space(0)]
	[Header("Inventory Display Panel")]
	[SerializeField] Image inventoryDisplayImage;
	[SerializeField] TMP_Text inventoryItemNameText;
	[SerializeField] TMP_Text inventoryItemDescriptionText;
	[SerializeField] TMP_Text inventoryCounter;

	[Space(1)]
	[Header("Inventory Item Cells")]	
	[SerializeField] GameObject InventoryItemCell;
	[SerializeField] private UIInventoryItemCell inventoryItemsCell;
	[SerializeField] Transform inventoryDisplayContent;
	
	private InventoryDisplayPanel inventoryDisplayPanel;
	private Inventory InventoryObject;
	private CameraController cameraController;
	private CollectableController collectableController;
	private UIController UIController;
	public InventoryController InventoryController { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else if (Instance != null && FindObjectOfType<GameController>() != null)
		{
			Destroy(this.gameObject);
		}

		if (UIControllerObject == null)
		{
			UIControllerObject = transform.Find("UI");
		}

		inventoryItemsCell = InventoryItemCell.GetComponent<UIInventoryItemCell>();
		inventoryDisplayPanel = new InventoryDisplayPanel(inventoryDisplayImage, inventoryItemNameText, inventoryItemDescriptionText);
		InventoryObject = new Inventory(this);

		InventoryController = new InventoryController(InventoryUI, InventoryObject, inventoryDisplayPanel, inventoryItemsCell, inventoryCounter, inventoryDisplayContent);
		

		cameraController = new CameraController(transform.Find("Camera").GetComponent<Camera>(), characterController);
		collectableController = new CollectableController(transform.Find("Collectables"));
		StarController starController = GetComponent<StarController>();
		UIController = new UIController(UIControllerObject, characterController, starController);


	}

	void Start()
    {
		if (hardMode)
		{
			int startHealth = characterController.MaxHealth / 2;
			characterController.SetHealth(startHealth);
		}
	}

	private void Update()
	{
		UIController.Update();
		InventoryController.Update();
	}

	private void LateUpdate()
	{
		cameraController.LateUpdate();
	}

	private void OnEnable()
	{
		InventoryController.OnEnable();
	}

	private void OnDisable()
	{
		InventoryController.OnDisable();
	}
}
