using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupController : MonoBehaviour
{
	public List<GameObject> pickups = new List<GameObject>();

	public void PickupClosest (Hand hand)
	{
		if (pickups.Count > 0 && ClosestPickup(hand) != null)
		{
			hand.Equip(ClosestPickup(hand));
		}
	}

	Weapon ClosestPickup (Hand hand)
	{
		Weapon closestPickup = pickups[0].GetComponent<Weapon>();
 		float dist = Vector3.Distance(transform.parent.transform.position, pickups[0].transform.position);
		for (int i = 0; i < pickups.Count; i++)
		{
			Weapon weapon = pickups[i].GetComponent<Weapon>();
			if (!weapon.equipped && weapon != hand.lastThrown)
			{
				float tempDist = Vector3.Distance(transform.parent.transform.position, pickups[i].transform.position);
				if (tempDist < dist) closestPickup = weapon;
			}
		}
		if (closestPickup == hand.lastThrown || closestPickup.equipped) return null;
		return closestPickup;
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Pickup")
		{
			pickups.Add(collider.gameObject);
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Pickup")
		{
			pickups.Remove(collider.gameObject);
		}
	}
}
