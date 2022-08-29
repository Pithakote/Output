﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[Header("UI Controller Referenced")]
	[SerializeField] private Transform UIControllerObject;
	 

	public CharacterController characterController;
	public bool hardMode;

	private Inventory InventoryObject;
	private CameraController cameraController;
	private CollectableController collectableController;
	private UIController UIController;
	private InventoryController InventoryController;

	private void Awake()
	{
		if (UIControllerObject == null)
		{
			UIControllerObject = transform.Find("UI");
		}

		InventoryObject = new Inventory();
		cameraController = new CameraController(transform.Find("Camera").GetComponent<Camera>(), characterController);
		collectableController = new CollectableController(transform.Find("Collectables"), InventoryObject);
		StarController starController = GetComponent<StarController>();
		UIController = new UIController(UIControllerObject, characterController, starController);
		InventoryController = GetComponent<InventoryController>();
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
	}

	private void LateUpdate()
	{
		cameraController.LateUpdate();
	}
}
