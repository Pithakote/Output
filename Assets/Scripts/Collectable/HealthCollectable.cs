using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : Collectable
{
	public override void OnPickedUp()
	{
		CharacterController character = FindObjectOfType<CharacterController>();
		character.BoostHealth();
		collectableController.OnPickedUp(this.gameObject);
	}
}
