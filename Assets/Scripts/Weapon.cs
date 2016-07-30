using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
  Animator animator;
  protected Rigidbody rb;
  public string type;
  public float throwSpeed;
  public bool equipped = false;

  void Start ()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody>();
  }

  public void Unequip ()
  {
    equipped = false;
    animator.Rebind();
    animator.enabled = false;
    transform.parent = null;
  }

  public void Pickup (GameObject parent, string hand)
  {
    equipped = true;
    transform.parent = parent.transform;
    animator.SetTrigger(hand);
    animator.enabled = true;
  }

  public virtual void RecieveAttackInput (string hand)
  {
    animator.SetTrigger(type);
    animator.SetTrigger(hand);
  }

  public virtual void Throw (Transform parentTransform, Transform throwSpawn)
  {
    // override me
  }

  public void Attack ()
  {
    print("attack!");
  }
}
