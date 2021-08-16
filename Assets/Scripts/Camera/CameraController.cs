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
		cameraTrans.position.x = character.transform.position.x;
		cameraTrans.position.y = character.transform.position.y + FOLLOW_DIST_UP;
		cameraTrans.position.z = character.transform.position.z + FOLLOW_DIST_BACK;
		cameraTrans.LookAt(character.transform);
	}
}
