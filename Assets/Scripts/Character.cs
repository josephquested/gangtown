using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	PickupController pickupController;
	Movement movement;
	Attack attack;
	Jump jump;

	void Awake ()
	{
		pickupController = GetComponentInChildren<PickupController>();
		movement = GetComponent<Movement>();
		attack = GetComponent<Attack>();
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

	public void RecieveHandInput (string input)
	{
		print("hand input " + input);
		attack.Throw(input);
		pickupController.PickupClosest(input);
		attack.lastThrown = null;
	}

	public void RecieveAttackInput (bool fire1, bool fire2)
	{
		if (fire1)
		{
			attack.RecieveAttackInput("right");
		}
		if (fire2)
		{
			attack.RecieveAttackInput("left");
		}
	}
}
