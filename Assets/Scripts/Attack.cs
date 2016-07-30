using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
  public void RecieveAttackInput (Hand hand)
  {
    if (hand.weapon == null)
    {
      Melee(hand);
      return;
    }
    hand.AnimateAttack(hand.weapon.type);
    hand.weapon.RecieveAttackInput(hand);
  }

  void Melee (Hand hand)
  {
    hand.AnimateAttack("stab");
  }
}
