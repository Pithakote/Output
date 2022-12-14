using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CameraController
{
	private const float FOLLOW_DIST_BACK = -10f;
	private const float FOLLOW_DIST_UP = 10f;
	private Transform cameraTrans;
	private CharacterController character;

	public CameraController(Camera camera, CharacterController character)
	{
		this.cameraTrans = camera.transform;
		this.character = character;
	}

	public void LateUpdate()
	{
		//transform.position's individual axis cannot be modified individually, instead we have to change the entire position
		cameraTrans.position = new Vector3(character.transform.position.x,
											character.transform.position.y + FOLLOW_DIST_UP,
											character.transform.position.z + FOLLOW_DIST_BACK);

		cameraTrans.LookAt(character.transform);
	}
}
