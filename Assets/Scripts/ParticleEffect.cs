using UnityEngine;
using System.Collections;
using System;

public class ParticleEffect : MonoBehaviour {
	
	public Transform target;
	private Action<object> eraChangedAction;
	
	// Use this for initialization
	void Start () {
		eraChangedAction = o => onEraChanged(o);	 
		BroadcastCenter.addListener(eraChangedAction,"eraChanged");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.transform.position;
	}
	
	public void onEraChanged(object data){
		particleSystem.Play();
	}
}
