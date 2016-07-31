using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	CharacterController controller;
	Vector3 moveDirection = Vector3.zero;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	void Awake ()
	{
		controller = GetComponent<CharacterController>();
	}

	public void RecieveMovementInput (float horizontal, float vertical, bool jump)
	{
		if (controller.isGrounded)
		{
	   moveDirection = new Vector3(horizontal, 0, vertical);
	   moveDirection *= speed;
	   if (jump) moveDirection.y = jumpSpeed;
		}
		else
		{
	   moveDirection = new Vector3(horizontal, moveDirection.y, vertical);
	   moveDirection.x *= speed / 1.5f;
	   moveDirection.z *= speed / 1.5f;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
