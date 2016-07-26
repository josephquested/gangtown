using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	Transform target;
	public bool trackPlayer;
  public int minZoom = 1;
  public int maxZoom = 6;

	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
	}

	void FixedUpdate ()
	{
		if (trackPlayer)
		{
			transform.position = new Vector3(
			target.position.x,
			20,
			target.position.z - 20
			);
		}
    UpdateZoom();
	}

  void UpdateZoom ()
  {
    if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
    {
      Camera.main.orthographicSize++;
    }
    if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
    {
      Camera.main.orthographicSize--;
    }
    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
  }
}
