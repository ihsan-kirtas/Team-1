using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFountain : MonoBehaviour
{
    private AudioSource audioData;

    void Start()
    {
        // Dont play particles
        GetComponent<ParticleSystem>().Stop();

        // Find Audio
        audioData = GetComponent<AudioSource>();

        // Start playing sopund clip
        audioData.Play(0);

        // Pause sound clip
        audioData.Pause();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Animation
            GetComponent<Animation>().Play("start animation");

            // Find and play the particles
            GetComponent<ParticleSystem>().Play();

            // Un-pause the audio clip
            audioData.UnPause();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Animation
            GetComponent<Animation>().Play("end animation");

            // stop the particles
            GetComponent<ParticleSystem>().Stop();

            // pause the sound
            audioData.Pause();
        }
    }
}
