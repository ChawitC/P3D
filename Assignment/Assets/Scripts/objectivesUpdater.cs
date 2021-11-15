using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectivesUpdater : MonoBehaviour
{
	[SerializeField] private Text objectiveText;
	public static bool obj1 = false; //checking if player has gone through the door
	public static bool obj2 = false; //checking if player has spawned a ball
	public static bool obj3 = false; //checking if player player has dropped a ball into the pot
	public static bool obj4 = false; //checking if player has touched the radio
	
    // Start is called before the first frame update
    void Start()
    {
        // maybe ill need start later
		//objectiveText.text = "- Objectives -\n [ ] Go through sliding doors]\n [ ] Ask for a coal ball from the reception\n [ ] Play a music on the radio"; 
    }

    // Update is called once per frame
    void Update()
    {
		objectiveText.text = "- Objectives -\n";
		
        if (!obj1) {objectiveText.text = objectiveText.text + "[   ] Go through sliding doors\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Go through sliding doors\n";}
		
		if (!obj2) {objectiveText.text = objectiveText.text + "[   ] Ask for a coal ball from the reception\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Ask for a coal ball from the reception\n";}
		
		if (!obj3) {objectiveText.text = objectiveText.text + "[   ] Drop a coal ball into the pot\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Drop a coal ball into the pot\n";}
		
		if (!obj4) {objectiveText.text = objectiveText.text + "[   ] Play a music on the radio\n";} 
		else {objectiveText.text = objectiveText.text + "[✓] Play a music on the radio\n";}
		
	
	//\n [ ] Ask for a coal ball from the reception\n [ ] Play a music on the radio";
		
    }
}
