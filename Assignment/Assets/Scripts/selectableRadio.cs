using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class selectableRadio : MonoBehaviour
{
	[SerializeField] private string playerTag;
	[SerializeField] private Text contextText;
	[Header("Audio")]
	[SerializeField] private AudioClip[] songTracks;  
	[SerializeField] private objectivesUpdater objective; //Exposing objectiveUpdater script
	
	AudioSource audioSource;
	private bool inTrigger;
	private int lastPlayed;
	
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
		inTrigger = false;
		lastPlayed = 4; // 4 means no track selected
    }

    // Update is called once per frame
    void Update()
    {
        if((inTrigger))
        {
           if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		   {
			   contextText.text = "Track 1 Selected"; 
			   if (lastPlayed != 0) 
			   {
			   PlaySongAudio(0);
			   }
			   else {contextText.text ="Track 1 was already selected\nYou can't play the same track consecutively!";}
			   objective.Obj5done = true; //Updating objective, since player has already played the music
		   }
		   else if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
		   {
			   contextText.text = "Track 2 Selected"; 
			   if (lastPlayed != 1) 
			   {
			   PlaySongAudio(1);
			   }
			   else {contextText.text ="Track 2 was already selected\nYou can't play the same track consecutively!";}
			   objective.Obj5done = true; //Updating objective, since player has already played the music
		   }
		   else if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
		   {
			   contextText.text = "Track 3 Selected"; 
			   if (lastPlayed != 2) 
			   {
			   PlaySongAudio(2);
			   }
			   else {contextText.text ="Track 3 was already selected\nYou can't play the same track consecutively!";}
			   objective.Obj5done = true; //Updating objective, since player has already played the music
		   }
		   else if(Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
		   {
			   contextText.text = "Radio Off"; 
			   StopSongAudio();
			   lastPlayed = 4;
		   }
        }
    }
	
	private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerTag)
        {
            inTrigger = true;
			contextText.text = "Press number 1-3 to select a music track\nPress 0 to turn the radio off";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
			inTrigger = false;
			contextText.text = " "; //reset contextual text
        }
    }
	
	private void PlaySongAudio(int num)
	{	
			audioSource.clip = songTracks[num];
			audioSource.Play();
			lastPlayed = num;
	}
	private void StopSongAudio()
	{	
			audioSource.Stop();
	}
}
