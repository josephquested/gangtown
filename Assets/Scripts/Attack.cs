using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
  Animator animator;
  Weapon weapon;
  public Weapon rightWeapon;
  public Weapon leftWeapon;
  public Transform throwSpawn;
  public Weapon lastThrown;

  void Start ()
  {
    animator = GetComponent<Animator>();
  }

  public void RecieveAttackInput (string hand)
  {
    if (hand == "right") weapon = rightWeapon;
    if (hand == "left") weapon = leftWeapon;
    if (weapon == null)
    {
      Melee(hand);
      return;
    }
    AnimateAttack(hand, weapon.type);
    weapon.RecieveAttackInput();
  }

  void AnimateAttack (string hand, string type)
  {
    animator.SetTrigger(hand);
    animator.SetTrigger(type);
  }

  void Melee (string hand)
  {
    animator.SetTrigger(hand);
    animator.SetTrigger("stab");
  }

  public void Equip (Weapon newWeapon, string hand)
  {
    if (hand == "right") rightWeapon = newWeapon;
    if (hand == "left") leftWeapon = newWeapon;
    newWeapon.Pickup(gameObject);
  }

  public void Throw (string hand)
  {
    Weapon throwWeapon = null;
    if (hand == "left" && leftWeapon != null)
    {
      throwWeapon = leftWeapon;
      leftWeapon = null;
    }
    if (hand == "right" && rightWeapon != null)
    {
      throwWeapon = rightWeapon;
      rightWeapon = null;
    }
    if (throwWeapon != null)
    {
      throwWeapon.Unequip();
      throwWeapon.Throw(transform, throwSpawn);
      lastThrown = throwWeapon;
    }
  }
}
