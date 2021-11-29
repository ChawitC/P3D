using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pickUpObjects : MonoBehaviour
{
	[SerializeField] private Transform Player;
	[SerializeField] private Transform PlayerCam;
	[SerializeField] private Transform theDest;
    
	private bool hasBall = false; //check if player is holding this given ball
	private float dist = 0f;
	
	void Update()
    {
		dist = Vector3.Distance(GetComponent<Transform>().position,theDest.transform.position); //distance of the balls from the player

        if (Input.GetKey(KeyCode.F) && (dist <= 2f)) //only pick up this ball that are within the distance of 2 away from the player.
        {
			// these sets of code became redundant due to the object being made Kinematic
			//GetComponent<Rigidbody>().useGravity = false;
			//GetComponent<Rigidbody>().freezeRotation = true; 
			//GetComponent<Rigidbody>().detectCollisions = true;
			
			GetComponent<Rigidbody>().isKinematic = true;
			this.transform.position = theDest.position;
			this.transform.parent = GameObject.Find("Destination").transform;
			hasBall = true; 
        }
		else if (Input.GetKey(KeyCode.Mouse0) && hasBall) //Detect if the left mouse button is pressed and that the ball can only be thrown if the ball is in hand
        {
			this.transform.parent = null;
			
			// these sets of code became redundant due to the object being made Kinematic
			//GetComponent<Rigidbody>().useGravity = true;
			//GetComponent<Rigidbody>().freezeRotation = false; 
			
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity; // Inherit player's velocity and apply to the ball, isn't really noticeable
			GetComponent<Rigidbody>().AddForce(PlayerCam.forward*10,ForceMode.Impulse); //force applicable is this is throwing the ball
			hasBall = false;
        }
		else if (Input.GetKey(KeyCode.Mouse1) && hasBall) //Detect if the right mouse button is pressed and that the ball can only be dropped if the ball is in hand
		 {
			this.transform.parent = null;
			
			// these sets of code became redundant due to the object being made Kinematic
			//GetComponent<Rigidbody>().useGravity = true;
			//GetComponent<Rigidbody>().freezeRotation = false; 
			
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity; // Inherit player's velocity and apply to the ball, isn't really noticeable
			// no force applicable since this is dropping the ball straight down
			hasBall = false;
        }
		
    }
 
}
