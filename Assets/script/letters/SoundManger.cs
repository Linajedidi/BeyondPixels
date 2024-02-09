using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public static SoundManger Instance { get; private set; }
    private AudioSource Source;
    private void Awake()
    {
        Instance = this;
        Source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip _sound)
    {
        Source.PlayOneShot(_sound);
    }
}
