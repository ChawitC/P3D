using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballsInPotCounter : MonoBehaviour
{
	int objects = 0;
	[SerializeField] private string ballTag;
	[SerializeField] private Text ballcountText;
	[SerializeField] private objectivesUpdater objective; //Exposing objectiveUpdater script
	[SerializeField] private Light potLight;
	//[SerializeField] private AudioClip[] fireSounds;
	AudioSource audioSource;
	
    // Update is called once per frame
	void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
    void Update()
    {
        //Debug.Log("Balls in pot: " + objects);
		potLight.intensity = 5000000f + (objects*3000000f);
		ballcountText.text = objects.ToString("#");
    }
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == ballTag)
		{
		PlayFireAudio();
		objects++;
		//objectivesUpdater.obj3 = true; //Updating objective, since player has dropped the ball into the pot
		objective.Obj3done = true;
		}
	}


	private void OnTriggerExit(Collider other)
	{
		if(other.tag == ballTag)
		{
		objects--;
		}
	}
	private void PlayFireAudio()
	{	
			//audioSource.clip = fireSounds[0];
			audioSource.PlayOneShot(audioSource.clip);
	}
}
