using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupCollider : MonoBehaviour
{
	public List<GameObject> pickups = new List<GameObject>();

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
