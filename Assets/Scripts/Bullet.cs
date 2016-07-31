using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	bool active;

	void Awake ()
	{
		Destroy(gameObject, 5f);
	}

	void OnTriggerEnter (Collider collider)
	{
		if (active)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Solid") Destroy(gameObject);
		active = true;
	}
}
