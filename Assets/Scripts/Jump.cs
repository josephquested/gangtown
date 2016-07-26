using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	Rigidbody rb;
  GameObject body;
  float distToGround;
  public float jumpHeight;

	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
    body = transform.Find("Body").gameObject;
	}

  void Start ()
  {
    distToGround = body.GetComponent<Collider>().bounds.extents.y;
  }

  public void ProcessJump ()
  {
    if(IsGrounded())
    {
      rb.AddForce(Vector3.up * jumpHeight);
    }
  }

  bool IsGrounded ()
  {
    return Physics.Raycast(body.transform.position, -Vector3.up, distToGround + 0.1f);
  }
}
