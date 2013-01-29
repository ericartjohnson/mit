using UnityEngine;
using System;
using System.Collections;

public class EraGeometry : MonoBehaviour {
	
	private Action<object> eraChangedAction;
	
	public TIME_ERA livingEra;
	
	// Use this for initialization
	void Start () {
		this.onEraChanged(null);
		eraChangedAction = o => onEraChanged(o);	 
		BroadcastCenter.addListener(eraChangedAction,"eraChanged");
		//BroadcastCenter.addListener(
	}
	
	// Update is called once per frame
	void Update () {
		float a = (TimeController.signedTimeWeightForEra(livingEra) + 1f)/2f;
		
		if(renderer){
			Color c = renderer.material.color;
			c.a = a;
			renderer.material.color = c;
		}
		
		Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in renderers){
			//renderer.enabled = TimeController.currentEra == livingEra;
			Color cl = r.material.color;
			//c.a = TimeController.normalizedWeightForEra(livingEra);
			cl.a = a;
			r.material.color = cl;
		}
	}
	
	public void onEraChanged(object data){
		BoxCollider[] boxColliders = this.GetComponentsInChildren<BoxCollider>();
		foreach(BoxCollider boxCollider in boxColliders){
			boxCollider.enabled = TimeController.currentEra == livingEra;
		}
	}
}
