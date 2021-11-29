using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsSound : MonoBehaviour
{
     AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.5)
            audioSource.Play();
    }
}
