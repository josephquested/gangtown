using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	void OnTriggerEnter (Collider collider)
	{
		Destroy(gameObject);
	}
}
