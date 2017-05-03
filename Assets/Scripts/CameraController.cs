using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float damping;
	public float height;
	public float zoom;

	private Vector3 offset;

	void Start ()
	{
		transform.position.Set (player.transform.position.x, player.transform.position.y + height, player.transform.position.z - zoom);

		offset = player.transform.position - transform.position;
	}

	void LateUpdate ()
	{
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = player.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

		Quaternion rotation = Quaternion.Euler(0, angle, 0);
//		Vector3 before = transform.position;
		transform.position = player.transform.position - (rotation * offset);

//		if (before != transform.position)
//			transform.hasChanged.Equals (true);

		transform.LookAt(player.transform);
	}
}