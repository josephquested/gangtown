using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour
{
	public Weapon weapon;
	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator>();
	}

	public void SetWeapon (Weapon newWeapon)
	{
		weapon = newWeapon;
	}

	public void AnimateAttack (string type)
  {
    animator.SetTrigger(type);
  }
}
