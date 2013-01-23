using UnityEngine;
using System.Collections;

public class TimeInteraction : MonoBehaviour {
	
	public float sensitivity = 2f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float wheelTurn = Input.GetAxis("Mouse ScrollWheel");
		if(wheelTurn != 0) TimeController.timeWeight += wheelTurn/sensitivity;
		Debug.Log(TimeController.timeWeight);
	}
}
