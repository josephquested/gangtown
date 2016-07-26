using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	Movement movement;
	Jump jump;
	// public Weapon weapon;

	void Awake ()
	{
		movement = GetComponent<Movement>();
		jump = GetComponent<Jump>();
	}

	public void RecieveMovementInput (float horizontal, float vertial)
	{
		movement.Move(horizontal, vertial);
	}

	public void RecieveJumpInput ()
	{
		jump.ProcessJump();
	}

	public void RecieveFireInput (bool fire1)
	{
		// if (fire1)
		// {
		// 	weapon.RecieveFireInput();
		// }
	}
}
