using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	Movement movement;
	Attack attack;
	Jump jump;

	public Hand leftHand;
	public Hand rightHand;

	void Awake ()
	{
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
		if (input == "right") rightHand.RecieveHandInput();
		if (input == "left") leftHand.RecieveHandInput();
	}

	public void RecieveAttackInput (bool fire1, bool fire2)
	{
		if (fire1)
		{
			attack.RecieveAttackInput(rightHand);
		}
		if (fire2)
		{
			attack.RecieveAttackInput(leftHand);
		}
	}
}
