using UnityEngine;
using System.Collections;

public class EraLight : MonoBehaviour {
	
	public TIME_ERA livingEra;
	public float liveIntensity = 1f;
	public float deadIntensity = 0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float t = (TimeController.signedTimeWeightForEra(livingEra) + 1f)/2f;
		light.intensity = Mathf.Lerp(deadIntensity,liveIntensity,t);
	}
}
