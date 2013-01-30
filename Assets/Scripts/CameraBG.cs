using UnityEngine;
using System.Collections;

public class CameraBG : MonoBehaviour {
	
	public Color pastColor;
	public Color futureColor;
	
	// Use this for initialization
	void Start () {
		camera.backgroundColor = pastColor;
	}
	
	// Update is called once per frame
	void Update () {
		float t = (TimeController.signedTimeWeightForEra(TIME_ERA.FUTURE) + 1f)/2f;
		float r = Mathf.Lerp(pastColor.r,futureColor.r,t);
		float g = Mathf.Lerp(pastColor.g,futureColor.g,t);
		float b = Mathf.Lerp(pastColor.b,futureColor.b,t);
		camera.backgroundColor = new Color(r,g,b);
	}
}
