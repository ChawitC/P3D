using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pickUpObjects : MonoBehaviour
{
	[SerializeField] private Transform Player;
	[SerializeField] private Transform PlayerCam;
	[SerializeField] private Transform theDest;
	private bool hasBall = false;
	private float dist = 0f;
	
	void Update()
    {
		dist = Vector3.Distance(GetComponent<Transform>().position,theDest.transform.position); //distance of the balls from the player
		//Debug.Log(dist.ToString("#.##"));
        //Detect if the left mouse button is pressed
        if (Input.GetKey(KeyCode.F) && (dist <= 2f))
        {
            Debug.Log("Picking up");
			//GetComponent<Rigidbody>().useGravity = false;
			//GetComponent<Rigidbody>().freezeRotation = true; 
			GetComponent<Rigidbody>().isKinematic = true;
			//GetComponent<Rigidbody>().detectCollisions = true;
			this.transform.position = theDest.position;
			this.transform.parent = GameObject.Find("Destination").transform;
			hasBall = true;
        }
		else if (Input.GetKey(KeyCode.Mouse0) && hasBall)
        {
            Debug.Log("Throwing");
			this.transform.parent = null;
			//GetComponent<Rigidbody>().useGravity = true;
			//GetComponent<Rigidbody>().freezeRotation = false; 
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity; //Doesn't work
			//GetComponent<Rigidbody>().AddForce(new Vector3(10,0,0),ForceMode.Impulse);
			GetComponent<Rigidbody>().AddForce(PlayerCam.forward*10,ForceMode.Impulse); //Doesn't work
			//GetComponent<Rigidbody>().detectCollisions = true;
			hasBall = false;
        }
		else if (Input.GetKey(KeyCode.Mouse1) && hasBall)
		 {
            Debug.Log("Dropping");
			this.transform.parent = null;
			//GetComponent<Rigidbody>().useGravity = true;
			//GetComponent<Rigidbody>().freezeRotation = false; 
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity; //Doesn't work
			//GetComponent<Rigidbody>().AddForce(new Vector3(10,0,0),ForceMode.Impulse);
			//GetComponent<Rigidbody>().detectCollisions = true;
			hasBall = false;
        }
		
    }
    // Start is called before the first frame update
    /*void OnMouseDown()
    {
        //GetComponent<Rigidbody>().useGravity = false;
		//GetComponent<Rigidbody>().freezeRotation = true; 
		GetComponent<Rigidbody>().isKinematic = true;
        //GetComponent<Rigidbody>().detectCollisions = true;
		this.transform.position = theDest.position;
		this.transform.parent = GameObject.Find("Destination").transform;
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        this.transform.parent = null;
		//GetComponent<Rigidbody>().useGravity = true;
		//GetComponent<Rigidbody>().freezeRotation = false; 
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity; //Doesn't work
		//GetComponent<Rigidbody>().AddForce(new Vector3(10,0,0),ForceMode.Impulse);
		GetComponent<Rigidbody>().AddForce(PlayerCam.forward*10,ForceMode.Impulse); //Doesn't work
        //GetComponent<Rigidbody>().detectCollisions = true;
    }*/
	
}
