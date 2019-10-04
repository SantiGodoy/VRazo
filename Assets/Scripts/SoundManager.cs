using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip robotSound;
    static AudioSource audioSource;

    void Start()
    {
        robotSound = Resources.Load<AudioClip>("robot");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public static void PlaySound()
    {
        audioSource.PlayOneShot(robotSound);
    }

    public static void StopSound()
    {
        audioSource.Stop();
    }

    public static bool isPlaying()
    {
        return audioSource.isPlaying;
    }
}
