using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : Collectable
{
	private CollectableController collectableController;

	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public override void OnPickedUp(CollectableController collectableController)
	{
		this.collectableController = collectableController;
	 	StarController starController = FindObjectOfType<StarController>();

		starController.PickupStar();
		animator.SetTrigger("pickedUp");
	}

	public void OnAnimationComplete()
	{
		collectableController.OnPickedUp(this);
	}
}
