using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
	protected ICollectableControl collectableController;

	private void OnEnable()
	{
		if (this.collectableController == null)
		{
			return;			
		}

		this.collectableController.onPickedUpEvent += DestroyObject;
	}

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
		//needs to un-subscribe when disabled because it will still try to refer to the
		//disabled object if it is not un-subscribed
		this.collectableController.onPickedUpEvent -= DestroyObject;
	}

	private void OnDestroy()
	{
		//needs to un-subscribe when disabled because it will still try to refer to the
		//destroyed object if it is not un-subscribed
		this.collectableController.onPickedUpEvent -= DestroyObject;
	}

}
