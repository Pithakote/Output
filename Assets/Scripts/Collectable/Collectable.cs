using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
	private CollectableController collectableController;
	public void Setup(CollectableController collectableController)
	{
		this.collectableController = collectableController;
	}
	public abstract void OnPickedUp(CollectableController collectableController);
	private void OnTriggerEnter(Collider other)
	{
		OnPickedUp(collectableController);
	}
}
