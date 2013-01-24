using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]

public class FieldCharacterMovement : MonoBehaviour {

	public float speed = 6.0f;
	public float crouchSpeed = 3.0f;
	public float jumpSpeed = 8.0f;
	public float jumpBoost = 4.0f;
	public float gravity = 20.0f;
	public float inAirModifier = 3.0f;
	//public bool highJumpReady = false;
	//public float highJumpTimeout = 3.0f;
	
	private bool grounded;
	private bool headHit;
//	private float highJumpCurTimeout;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		//highJumpCurTimeout = highJumpTimeout;
	}//Start
	
	// Update is called once per frame
	void Update(){
		UpdateTimeTravel();
		UpdateMovement();
	}
	
	void UpdateTimeTravel(){
		if(Input.GetKeyUp("f")){
			switch(TimeController.currentEra){
			case TIME_ERA.PAST: TimeController.currentEra = TIME_ERA.FUTURE; break;
			case TIME_ERA.FUTURE: TimeController.currentEra = TIME_ERA.PAST; break;
			}
		}
	}
	
	void UpdateMovement (){
		CharacterController controller = GetComponent<CharacterController>();
	    if (grounded) {
	        // We are grounded, so recalculate
	        // move direction directly from axes
	        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
	        moveDirection = transform.TransformDirection(moveDirection);

	        float s = speed;
			/*
	        if(Input.GetButton("Crouch")){
	        	s = crouchSpeed;
	        	highJumpCurTimeout -= Time.deltaTime;
	        	if(highJumpCurTimeout <= 0){
	        		highJumpReady = true;
	        		highJumpCurTimeout = highJumpTimeout;
	        	}
	        }else{
	        	highJumpReady = false;
	        	highJumpCurTimeout = highJumpTimeout;
	        }
	        */
	  
	        moveDirection *= s;

	        if (Input.GetButton ("Jump")) {
	            moveDirection.y = jumpSpeed;
	            //if(highJumpReady) moveDirection.y += jumpBoost;
	           // highJumpReady = false;
	            //highJumpCurTimeout = highJumpTimeout;

	            BroadcastCenter.broadcastMessage("userJumped", "test data");
	        }
	    }else if(headHit){
			moveDirection = new Vector3(Input.GetAxis("Horizontal"),-2, 0);
	        moveDirection = transform.TransformDirection(moveDirection);
	        moveDirection = new Vector3(moveDirection.x * speed, moveDirection.y,0);
	        moveDirection.y -= gravity * Time.deltaTime;
		}else{
	    	moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, 0);
	        moveDirection = transform.TransformDirection(moveDirection);
	        moveDirection = new Vector3(moveDirection.x * speed, moveDirection.y,0);
	        moveDirection.y -= gravity * Time.deltaTime;
	    }
		
		if(grounded){
			RaycastHit hit;
			Vector3 slopeAdjust = Vector3.zero;
			
			if(Physics.Raycast(transform.position,-Vector3.up, out hit)){
				if(hit.distance < 2.0){
					slopeAdjust.y = hit.distance-controller.height/2;
				}
			}
			
			moveDirection -= slopeAdjust / Time.deltaTime;
		}
	    // Apply gravity
	    //moveDirection.y -= gravity * Time.deltaTime;
	    
	    // Move the controller
		Debug.Log(Time.deltaTime);
		if(Time.deltaTime > 0){
		    CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
			
			headHit = (flags & CollisionFlags.CollidedAbove) != 0;
			grounded = (flags & CollisionFlags.CollidedBelow) != 0;
		}
	}//UpdateMovement

}//FieldCharacterMovement