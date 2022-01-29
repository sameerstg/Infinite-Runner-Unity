using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
    public AudioSource audioSource;
    public AudioSource audioSourceForFx;

    public AudioClip bg;
    public AudioClip coinCollect;
    void Awake()
    {
        _instance = this;
    }
    public void PlayBackgroundMusic()
    {
        audioSource.clip = bg;
        audioSource.Play();
    }
    public void PlayCoinCollectSfx()
    {
        audioSourceForFx.clip = coinCollect;
        audioSourceForFx.Play();
    }

}
