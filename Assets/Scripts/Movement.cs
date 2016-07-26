using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	Rigidbody rb;
	Jump jump;
	public float speed;

	public float baseSpeed;

	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
		jump = GetComponent<Jump>();
	}

	public void Move (float horizontal, float vertical)
	{
		UpdateMovementClamp(horizontal, vertical);
		Vector3 movement = new Vector3(horizontal, 0, vertical);
		rb.AddForce(movement * speed);
	}

	void UpdateMovementClamp (float horizontal, float vertical)
	{
		if (horizontal != 0 && vertical != 0)
		{
			speed = baseSpeed / 1.5f;
			return;
		}
		if (!jump.IsGrounded())
		{
			speed = baseSpeed / 2;
			return;
		}
		speed = baseSpeed;
	}
}
