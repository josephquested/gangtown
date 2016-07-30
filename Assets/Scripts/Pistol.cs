using UnityEngine;
using System.Collections;

public class Pistol : Weapon
{
  public override void RecieveAttackInput (Hand hand)
  {
    print("pistol attack input!");
  }

  public override void Throw (Transform parentTransform, Transform throwSpawn)
  {
    transform.rotation = Quaternion.Euler(90, parentTransform.eulerAngles.y, parentTransform.rotation.z);
    transform.position = throwSpawn.position;
    rb.velocity = Vector3.zero;
    rb.AddForce(transform.up * throwSpeed);
  }
}
