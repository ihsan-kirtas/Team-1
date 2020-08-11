using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFountain : MonoBehaviour
{
    private AudioSource audioData;
    public Animator animationController;

    void Start()
    {
        // Link Audio
        audioData = GetComponent<AudioSource>();

        // Start playing sopund clip, then pause
        audioData.Play(0);
        audioData.Pause();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Animation - Play
            animationController.SetBool("PlayLeverDown", true);

            // Particles - Play
            GetComponent<ParticleSystem>().Play();

            // Sound - Un-Pause
            audioData.UnPause();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Animation - Stop
            animationController.SetBool("PlayLeverDown", false);

            // Particles - Stop
            GetComponent<ParticleSystem>().Stop();

            // Sound - Pause
            audioData.Pause();
        }
    }
}
