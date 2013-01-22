using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public CharacterController controller;
	public float heightOffset = 5.0f;
	public float lookVerticalOffset = 2.0f;
	public float zDistance = -10f;

	// Use this for initialization
	void Start () {

	}
	
	// LateUpdate is called once per frame after all other Update calls
	void LateUpdate () {
		Transform targetTransform = controller.transform;
		float z = zDistance;// - Mathf.Abs(controller.velocity.x);
		transform.position = new Vector3(targetTransform.position.x,targetTransform.position.y + heightOffset, z);
		Vector3 lookVector = new Vector3(controller.transform.position.x, controller.transform.position.y + lookVerticalOffset, controller.transform.position.z);
		transform.LookAt(lookVector);
	}
}