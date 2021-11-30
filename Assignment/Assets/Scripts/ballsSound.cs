using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsSound : MonoBehaviour
{
     private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
		if (collision.relativeVelocity.magnitude >= 2) //if velocity is more than 2, play sound as maximum level possible
		{
			audioSource.volume = 1.0f;
		}
        else // otherwise set sound volume at half the velocity (e.g. Velocity 1.6 will means sound volume at 0.8), the effect is working but not very significantly audible
		{
			audioSource.volume = collision.relativeVelocity.magnitude / 2 ; 
		}
		audioSource.Play();
    }
}
