using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	Movement movement;
	Attack attack;
	public Hand leftHand;
	public Hand rightHand;

	void Awake ()
	{
		attack = GetComponent<Attack>();
		movement = GetComponent<Movement>();
	}

	public void RecieveMovementInput (float horizontal, float vertial, bool jump)
	{
		movement.RecieveMovementInput(horizontal, vertial, jump);
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
