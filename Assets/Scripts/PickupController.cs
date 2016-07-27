using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupController : MonoBehaviour
{
	Attack attack;
	public List<GameObject> pickups = new List<GameObject>();

	void Start ()
	{
		attack = transform.parent.GetComponent<Attack>();
	}

	public void PickupClosest (string hand)
	{
		if (pickups.Count > 0)
		{
			attack.Equip(ClosestPickup(), hand);
		}
	}

	Weapon ClosestPickup ()
	{
		Weapon closestPickup = pickups[0].GetComponent<Weapon>();
 		float dist = Vector3.Distance(transform.parent.transform.position, pickups[0].transform.position);
		for (int i = 0; i < pickups.Count; i++)
		{
			float tempDist = Vector3.Distance(transform.parent.transform.position, pickups[i].transform.position);
			if (tempDist < dist) closestPickup = pickups[i].GetComponent<Weapon>();
		}
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
