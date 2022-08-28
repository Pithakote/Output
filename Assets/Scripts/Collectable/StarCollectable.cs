using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : Collectable
{
	[SerializeField] private Collider starCollider;
	private CollectableController collectableController;

	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();

		if (starCollider == null)
		{
			starCollider = GetComponent<BoxCollider>();
		}
	}

	public override void OnPickedUp(CollectableController collectableController)
	{
		this.collectableController = collectableController;
	 	StarController starController = FindObjectOfType<StarController>();

		starController.PickupStar();
		starCollider.enabled = false;
		animator.SetTrigger("pickedUp");
	}

	public void OnAnimationComplete()
	{
		collectableController.OnPickedUp(this);
	}
}
