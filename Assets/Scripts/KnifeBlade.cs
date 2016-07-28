using UnityEngine;
using System.Collections;

public class KnifeBlade : MonoBehaviour {
  Weapon weapon;
  Rigidbody rb;

  void Start ()
  {
    rb = transform.parent.gameObject.GetComponent<Rigidbody>();
    weapon = transform.parent.gameObject.GetComponent<Weapon>();
  }

  void Update ()
  {
    if (!weapon.equipped && rb.velocity == Vector3.zero)
    {
      rb.mass = 10000;
    }
    if (weapon.equipped)
    {
      rb.mass = 1;
    }
  }
}
