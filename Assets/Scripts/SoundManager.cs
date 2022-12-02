using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource audioSource;

    //AudioClips
    [SerializeField] private AudioClip flipCardSound;
    [SerializeField] private AudioClip matchSound;
    [SerializeField] private AudioClip incorrectMatchSound;
    [SerializeField] private AudioClip winSound;

    public void PlayFlipCardSound()
    {
        audioSource.PlayOneShot(flipCardSound);
    }

    public void PlayMatchSound()
    {
        audioSource.PlayOneShot(matchSound);
    }

    public void PlayIncorrectMatchSound()
    {
        audioSource.PlayOneShot(incorrectMatchSound);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }
}
