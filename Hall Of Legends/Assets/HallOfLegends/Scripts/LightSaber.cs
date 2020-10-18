using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    public AudioClip beamSound;

    AudioSource audioSource;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource =  GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerBeam()
    {
        bool isOn = animator.GetBool("LightSaberOn");
        if (!isOn)
        {
            audioSource.PlayOneShot(beamSound);
        }else
            {
                audioSource.Stop();
            }

        animator.SetBool("LightSaberOn", !isOn);    
    }
}
