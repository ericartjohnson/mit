using UnityEngine;
using System.Collections;

public class TimeInteraction : MonoBehaviour {
	
	public float sensitivity = 2f;
	public float fastJumpSpeed = 0.08f;
	private float timeVelocity = 0f;
	private float jumpSpeed;
	private float jumpWeight = -1f;
	
	// Use this for initialization
	void Start () {
		jumpSpeed = fastJumpSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		bool timeJump = Input.GetButtonUp("Time Jump");
		if(timeJump){
			Time.timeScale = 1f;
			jumpWeight = TimeController.currentEra == TIME_ERA.PAST ? 1f : -1f;
			jumpSpeed = fastJumpSpeed;
		}
		
		if(TimeController.timeWeight != jumpWeight)
			TimeController.timeWeight = Mathf.SmoothDamp(TimeController.timeWeight, jumpWeight, ref timeVelocity, jumpSpeed);
	}
}