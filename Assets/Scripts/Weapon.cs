using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
  Animator weaponAnimator;
  Animator parentAnimator;

  void Start ()
  {
    weaponAnimator = GetComponent<Animator>();
    parentAnimator = transform.parent.GetComponent<Animator>();
  }

  public void RecieveFireInput ()
  {
    parentAnimator.SetTrigger("melee");
  }
}
