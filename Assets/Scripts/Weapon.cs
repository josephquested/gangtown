using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
  Animator animator;

  public string type = "stab";

  void Start ()
  {
    animator = GetComponent<Animator>();
  }

  public void RecieveAttackInput ()
  {
    print("stab!");
    animator.SetTrigger(type);
  }
}
