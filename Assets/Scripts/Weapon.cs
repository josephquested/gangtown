using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
  Animator animator;
  public string type = "stab";

  void Start ()
  {
    animator = GetComponent<Animator>();
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
}
