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
			print(pickups[0].GetComponent<Weapon>());
			print(hand);
			attack.Equip(pickups[0].GetComponent<Weapon>(), hand);
		}
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
