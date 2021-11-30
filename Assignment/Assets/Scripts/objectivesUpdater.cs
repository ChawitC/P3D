using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectivesUpdater : MonoBehaviour
{
	[SerializeField] private Text objectiveText;


	private bool obj1 = false; //checking if player has stepped on the "Narrative Zone"
	private bool obj2 = false; //checking if player has gone through the door
	private bool obj3 = false; //checking if player has spawned a ball
	private bool obj4 = false; //checking if player player has dropped a ball into the pot
	private bool obj5 = false; //checking if player has touched the radio
	
    // Update is called once per frame
    void Update()
    {
		// Write to the text field and keep appending
		objectiveText.text = "- Objectives -\n";
	
		if (!obj1) {objectiveText.text = objectiveText.text + "[   ] Step on a rock slab and listen to the welcome message\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Step on a rock slab and listen to the welcome message\n";}
	
        if (!obj2) {objectiveText.text = objectiveText.text + "[   ] Go through sliding doors\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Go through sliding doors\n";}
		
		if (!obj3) {objectiveText.text = objectiveText.text + "[   ] Ask for a coal ball from the reception\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Ask for a coal ball from the reception\n";}
		
		if (!obj4) {objectiveText.text = objectiveText.text + "[   ] Drop a coal ball into the pot\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Drop a coal ball into the pot\n";}
		
		if (!obj5) {objectiveText.text = objectiveText.text + "[   ] Play a music on the radio\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Play a music on the radio\n";}
		
    }
	
	//to be called from narrativeZone.cs
	public bool Obj1done { 
		get { return obj1; }
		set { obj1 = value; }
	}
	
	//to be called from doorsMotion.cs
	public bool Obj2done { 
		get { return obj2; }
		set { obj2 = value; }
	}
	
	//to be called from spawnObjects.cs
	public bool Obj3done { 
		get { return obj3; }
		set { obj3 = value; }
	}
	
	//to be called from spawnObjects.cs
	public bool Obj4done { 
		get { return obj4; }
		set { obj4 = value; }
	}
	
	//to be called from selectableRadio.cs
	public bool Obj5done { 
		get { return obj5; }
		set { obj5 = value; }
	}
	
	
}
