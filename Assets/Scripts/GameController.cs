using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController Instance { get; private set; }

	[Header("UI Controller Referenced")]
	[SerializeField] private Transform UIControllerObject;
	[SerializeField] GameObject InventoryUI;

	public CharacterController characterController;
	public bool hardMode;

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

		InventoryObject = new Inventory();
		cameraController = new CameraController(transform.Find("Camera").GetComponent<Camera>(), characterController);
		collectableController = new CollectableController(transform.Find("Collectables"), InventoryObject);
		StarController starController = GetComponent<StarController>();
		InventoryController = new InventoryController(InventoryUI, InventoryObject);
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
