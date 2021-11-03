using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObjects : MonoBehaviour
{
	[SerializeField] private Transform Player;
	[SerializeField] private Transform theDest;
	
    // Start is called before the first frame update
    void OnMouseDown()
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
		GetComponent<Rigidbody>().AddForce(Player.forward); //, ForceMode.Impulse); //Doesn't work
        //GetComponent<Rigidbody>().detectCollisions = true;
    }
	
}
