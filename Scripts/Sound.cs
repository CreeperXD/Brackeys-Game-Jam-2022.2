using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {
    public string Name;
    public AudioClip audioClip;
    public AudioMixerGroup MixerGroup;
    [Range(0f, 1f)]
    public float Volume;
    [Range(0.1f, 3f)]
    public float Pitch;
    public bool Loop;
    [HideInInspector]
    public AudioSource audioSource;
}
