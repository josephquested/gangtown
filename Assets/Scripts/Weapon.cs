using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
  Animator animator;
  Rigidbody rb;
  public string type = "stab";
  public float throwSpeed;

  void Start ()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody>();
  }

  public void Unequip ()
  {
    animator.enabled = false;
    transform.parent = null;
  }

  public void Pickup (GameObject parent)
  {
    transform.parent = parent.transform;
    animator.enabled = true;
  }

  public void RecieveAttackInput ()
  {
    animator.SetTrigger(type);
  }

  public void Throw (Transform parentTransform, Transform throwSpawn)
  {
    transform.rotation = Quaternion.Euler(90, parentTransform.eulerAngles.y, parentTransform.rotation.z);
    transform.position = throwSpawn.position;
    rb.velocity = Vector3.zero;
    rb.AddForce(transform.up * throwSpeed);
  }
}
