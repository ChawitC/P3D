using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorsMotion : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private string closeTrigger;
    [SerializeField] private string openTrigger;
	[SerializeField] private Text contextText;
	
	[Header("Audio")]
	[Tooltip("An array of footstep sounds. One gets randonly selected to play")]
	[SerializeField] private AudioClip[] doorOpenSounds;  
	[SerializeField] private AudioClip[] doorCloseSounds; 
	[SerializeField] private objectivesUpdater objective; //Exposing objectiveUpdater script
	
	[Header("Variables")]
	[SerializeField] private float timerSet; //count down timer to delay animation

    private Animator animator;
    private bool inTrigger = false;
	private bool doorShouldBeOpened = false; //represent if door has been opened
	private bool doorNowClosed = true; // represent if door is current closed
	private string initText = " ";
	private AudioSource audioSource;
	private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
		audioSource = GetComponent<AudioSource>();
		contextText.text = initText;
    }
	
    // Update is called once per frame
    void Update()
    {
		if((Input.GetKeyDown(KeyCode.E)) && inTrigger && !doorShouldBeOpened) 
			// last part is to ensure that the condition isn't triggered twice, breaking the code
        {
            animator.SetTrigger(openTrigger);
			if (!doorShouldBeOpened) {PlayOpenAudio(); doorNowClosed = false;} // Only open door once
			doorShouldBeOpened = true; // if door is open you can't open again
			
			objective.Obj1done = true; //Updating objective, since player has already opened the door
			
        }
		
		if (inTrigger) {contextText.text = "Press E to open the Doors";} 
		
		if(timer > 0.0f) {timer -= Time.deltaTime;} //countdown time by substracting current time
		if(timer < 0.0f && !doorShouldBeOpened) //if timer is out and door is not opened
		{
				
			if (!doorNowClosed) // if the door isn't closed
			{
				PlayCloseAudio();
				animator.SetTrigger(closeTrigger);
				doorNowClosed = true;
			}
        }
		  
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerTag)
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
			inTrigger = false;
			timer += timerSet; // Timer is added by seconds
			doorShouldBeOpened = false; //after the leaving trigger, the door should NOT be opened, timer starts
			contextText.text = " "; //reset contextual text
        }
    }
	
	private void PlayOpenAudio()
	{	
			audioSource.clip = doorOpenSounds[0];
			audioSource.PlayOneShot(audioSource.clip);
	}
	
	private void PlayCloseAudio()
	{	
			audioSource.clip = doorCloseSounds[0];
			audioSource.PlayOneShot(audioSource.clip);
	}
}