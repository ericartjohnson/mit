using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 10.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xTranslation = Input.GetAxis("Horizontal") * speed;
		xTranslation *= Time.deltaTime;
		transform.Translate(xTranslation,0,0);
	}
}
