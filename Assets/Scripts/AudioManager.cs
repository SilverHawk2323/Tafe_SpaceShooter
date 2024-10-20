using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musiceScore;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip death;
    public AudioClip plasma;
    public AudioClip laser;
    public AudioClip bomb;

    public void Start()
    {
        musiceScore.clip = background;
        musiceScore.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
