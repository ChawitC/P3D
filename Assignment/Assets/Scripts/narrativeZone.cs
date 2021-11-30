using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class narrativeZone : MonoBehaviour
{
    // Start is called before the first frame update
	[SerializeField] private string playerTag;
	[SerializeField] private Text contextText;
	[Header("Audio")]
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private int ZoneNumber;
	[SerializeField] private objectivesUpdater objective; //Exposing objectiveUpdater script
	
	private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerTag)
        {
			if (ZoneNumber == 1) {contextText.text = "Welcome to the Sleeping Fox Inn! Please enter the building through the sliding doors.\nOur dining room will be on your left and the bedroom on your right.";}
			else if (ZoneNumber == 2) {contextText.text = "It's getting cold !\nPlease help add coal balls into the pot to keep the inn warm!";}
			audioSource.Play();
			objective.Obj1done = true; //Updating objective, since player has stepped in the zone
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
			contextText.text = " "; //reset contextual text
			audioSource.Stop();
        }
    }
}
