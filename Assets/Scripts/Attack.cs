using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
  Animator animator;
  Weapon weapon;
  public Hand leftHand;
  public Hand rightHand;
  public Transform throwSpawn;
  public Weapon lastThrown;

  void Start ()
  {
    animator = GetComponent<Animator>();
  }

  public void RecieveAttackInput (string input)
  {
    Hand hand = GetHandFromString(input);
    if (hand.weapon == null)
    {
      Melee(hand);
      return;
    }
    hand.AnimateAttack(hand.weapon.type);
    hand.weapon.RecieveAttackInput(input);
  }

  void Melee (Hand hand)
  {
    hand.AnimateAttack("stab");
  }

  public void Equip (Weapon newWeapon, string input)
  {
    Hand hand = GetHandFromString(input);
    hand.weapon = newWeapon;
    hand.SetIdleAnimation(newWeapon.type);
    newWeapon.Pickup(gameObject, input);
  }

  public void Throw (string input)
  {
    Hand hand = GetHandFromString(input);
    if (hand.weapon != null)
    {
      Weapon throwWeapon = hand.weapon;
      hand.weapon = null;
      hand.ResetAnimator();
      throwWeapon.Unequip();
      throwWeapon.Throw(transform, throwSpawn);
      lastThrown = throwWeapon;
    }
  }

  Hand GetHandFromString (string input)
  {
    if (input == "right") return rightHand;
    if (input == "left") return leftHand;
    return null;
  }
}
