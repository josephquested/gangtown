using UnityEngine;
using System.Collections;

public class Pistol : Weapon
{
  public GameObject bulletPrefab;
  public Transform bulletSpawn;

  public override void RecieveAttackInput (Hand hand)
  {
    Fire();
    animator.SetTrigger(actionAnimation);
  }

  void Fire ()
  {
    GameObject bullet = (GameObject)Instantiate(
      bulletPrefab,
      bulletSpawn.position,
      Quaternion.Euler(
        90,
        transform.parent.rotation.y,
        0
      )
    );
    print(bullet.transform.rotation);
    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
  }

  public override void Throw (Transform parentTransform, Transform throwSpawn)
  {
    transform.rotation = Quaternion.Euler(90, parentTransform.eulerAngles.y, parentTransform.rotation.z);
    transform.position = throwSpawn.position;
    rb.velocity = Vector3.zero;
    rb.AddForce(transform.up * throwSpeed);
  }
}
