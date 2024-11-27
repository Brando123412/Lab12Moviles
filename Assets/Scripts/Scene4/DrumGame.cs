using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumGame : MonoBehaviour
{
    public AudioClip drum1Sound;
    public AudioClip drum2Sound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Drum1"))
        {
            audioSource.PlayOneShot(drum1Sound);
        }
        else if (gameObject.CompareTag("Drum2"))
        {
            audioSource.PlayOneShot(drum2Sound);
        }
    }
}
