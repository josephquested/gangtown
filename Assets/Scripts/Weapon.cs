using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
  Animator weaponAnimator;

  public string type = "stab";

  void Start ()
  {
    weaponAnimator = GetComponent<Animator>();
  }

  public void RecieveAttackInput ()
  {
    print("weapon attack!");
  }
}
