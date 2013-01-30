using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour {
	
	private bool readyToExit;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(readyToExit && Input.GetKeyUp("w")){
			Application.LoadLevel("testScene");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		readyToExit = true;
	}
	
	void OnTriggerExit(Collider other) {
		readyToExit = false;
	}
}
