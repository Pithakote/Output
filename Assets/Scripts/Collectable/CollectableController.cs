using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CollectableController : ICollectableControl
{
	public event Action <GameObject> onPickedUpEvent;

	public CollectableController(Transform collectableContainer, CharacterController character)
	{
		Collectable[] collectables = collectableContainer.GetComponentsInChildren<Collectable>();
		foreach(Collectable collectable in collectables)
		{
			collectable.Setup(this);
		}
	}

	public void OnPickedUp(GameObject gameObject)
	{
		onPickedUpEvent.Invoke(gameObject);
	}
}
