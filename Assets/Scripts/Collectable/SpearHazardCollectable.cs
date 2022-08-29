using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearHazardCollectable : Collectable
{
	public override void OnPickedUp()
	{
		CharacterController character = FindObjectOfType<CharacterController>();
		character.TakeDamage();
		this.collectableController.OnPickedUp(this.gameObject);
	}
}
