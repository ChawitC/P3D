using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private string otherTag;
	[SerializeField] private AudioClip[] scoreSounds;
	private AudioSource audioSource2;
	
    private void OnTriggerEnter(Collider other)
    {
		
		audioSource2 = GetComponent<AudioSource>();
		audioSource2.clip = scoreSounds[0];
		
        if(other.gameObject.tag == otherTag )
        {
            Destroy(other.gameObject);
			audioSource2.PlayOneShot(audioSource2.clip);
        }
    }
}