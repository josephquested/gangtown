using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour
{
	Animator animator;
	PickupController pickupController;

	public Weapon weapon;
	public string whichHand;
	public Transform throwSpawn;
	public Weapon lastThrown;

	void Start ()
	{
		animator = GetComponent<Animator>();
		pickupController = GameObject.Find("Pickup Controller").GetComponent<PickupController>();
	}

	public void RecieveHandInput ()
	{
		Throw();
		pickupController.PickupClosest(this);
		lastThrown = null;
	}

	public void Equip (Weapon newWeapon)
	{
		weapon = newWeapon;
		SetIdleAnimation(weapon.type);
		weapon.Pickup(transform.parent.gameObject, whichHand);
	}

	void Throw ()
	{
    if (weapon != null)
    {
      Weapon throwWeapon = weapon;
      weapon = null;
      ResetAnimator();
      throwWeapon.Unequip();
      throwWeapon.Throw(transform, throwSpawn);
      lastThrown = throwWeapon;
    }
  }

	public void AnimateAttack (string type)
  {
    animator.SetTrigger(type);
  }

	public void SetIdleAnimation (string type)
	{
		ResetAnimator();
		animator.SetTrigger(type);
	}

	public void ResetAnimator ()
	{
		animator.Rebind();
	}
}
