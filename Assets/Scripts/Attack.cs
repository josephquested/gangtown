using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
  Animator animator;
  Weapon weapon;
  public Weapon rightWeapon;
  public Weapon leftWeapon;
  public Transform throwSpawn;

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
    if (hand == "right")
    {
      if (rightWeapon != null) Throw(rightWeapon);
      rightWeapon = weapon;
    }
    if (hand == "left")
    {
      if (leftWeapon != null) Throw(leftWeapon);
      leftWeapon = weapon;
    }
    weapon.Pickup(gameObject);
  }

  void Throw (Weapon oldWeapon)
  {
    oldWeapon.Unequip();
    oldWeapon.transform.rotation = Quaternion.Euler(90, transform.eulerAngles.y, transform.rotation.z);
    oldWeapon.transform.position = throwSpawn.position;
    var vForce = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.forward) * Vector3.right;
    weapon.GetComponent<Rigidbody>().AddForce(vForce * 100);
  }
}
