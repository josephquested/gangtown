using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
  Animator animator;
  Weapon weapon;
  public Weapon rightWeapon;
  public Weapon leftWeapon;

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

  public void Equip (Weapon weapon, string hand)
  {
    if (hand == "right") rightWeapon = weapon;
    if (hand == "left") leftWeapon = weapon;
    weapon.Pickup(gameObject);
  }
}
