using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
  Animator animator;
  public string type = "stab";

  void Start ()
  {
    animator = GetComponent<Animator>();
  }

  void Update ()
  {
    if (Input.GetButtonDown("Jump"))
    {
      Pickup(GameObject.FindWithTag("Player"));
    }
  }

  void Pickup (GameObject parent)
  {
    transform.parent = parent.transform;
    animator.enabled = true;
  }

  public void RecieveAttackInput ()
  {
    print("stab!");
    animator.SetTrigger(type);
  }
}
