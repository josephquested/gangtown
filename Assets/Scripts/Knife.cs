using UnityEngine;
using System.Collections;

public class Knife : Weapon
{
  public bool airborne = false;

  public override void RecieveAttackInput (Hand hand)
  {
    animator.SetTrigger(actionAnimation);
    animator.SetTrigger(hand.whichHand);
  }

  public override void Throw (Transform parentTransform, Transform throwSpawn)
  {
    airborne = true;
    transform.rotation = Quaternion.Euler(90, parentTransform.eulerAngles.y, parentTransform.rotation.z);
    transform.position = throwSpawn.position;
    rb.velocity = Vector3.zero;
    rb.AddForce(transform.up * throwSpeed);
  }

  void OnTriggerEnter (Collider collider)
  {
    if (collider.tag == "Solid")
    {
      if (!equipped && airborne)
      {
        airborne = false;
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
      }
    }
    if (equipped)
    {
      rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
      rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
    }
  }
}
