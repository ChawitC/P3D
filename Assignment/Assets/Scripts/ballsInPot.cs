using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class ballsInPot : MonoBehaviour
{
	int objects = 0;
	[SerializeField] private string ballTag;
	[SerializeField] private Text ballcountText;
	[SerializeField] private objectivesUpdater objective; //Exposing objectiveUpdater script
	[SerializeField] private Light potLight;
	AudioSource audioSource;
	VisualEffect visualEffect;
	private float smokeRateCalc;
	private float splinterRateCalc;
	
    // Update is called once per frame
	void Start()
    {
        audioSource = GetComponent<AudioSource>();
		visualEffect = GetComponent<VisualEffect>();	
    }
	
    void Update()
    {
		potLight.intensity = 5000000f + (objects*3000000f); //increase intensity based on number of balls in the pot
		smokeRateCalc = 1f + (objects*.2f); // Calculate rate of smoke effect spawning based on number of balls in the pot
		splinterRateCalc = 10f + (objects*20f); // Calculate rate of splinter effect spawning based on number of balls in the pot
		visualEffect.SetFloat("smokeRate",smokeRateCalc);
		visualEffect.SetFloat("splinterRate",splinterRateCalc);
		ballcountText.text = objects.ToString("#");
    }
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == ballTag)
		{
		PlayFireAudio();
		objects++;
		objective.Obj3done = true; //Updating objective, since player has dropped the ball into the pot
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
			audioSource.PlayOneShot(audioSource.clip);
	}
}
