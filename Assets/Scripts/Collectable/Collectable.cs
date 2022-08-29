using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
	protected ICollectableControl collectableController;

	public void Setup(ICollectableControl collectableController)
	{
		this.collectableController = collectableController;
		this.collectableController.onPickedUpEvent += DestroyObject;
	}

	public abstract void OnPickedUp();
	private void OnTriggerEnter(Collider other)
	{
		OnPickedUp();
	}

	private void DestroyObject(GameObject gameObject)
	{
		if (gameObject != this.gameObject)
		{
			return;
		}

		GameObject.Destroy(gameObject);
	}

	private void OnDisable()
	{
		this.collectableController.onPickedUpEvent -= DestroyObject;
	}

	private void OnDestroy()
	{
		this.collectableController.onPickedUpEvent -= DestroyObject;
	}

}
