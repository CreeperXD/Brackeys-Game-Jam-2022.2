using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    public Sound[] Sounds;

    public static AudioManager Instance;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in Sounds) {
            //This will go to the children of the AudioManager "AudioSources"
            s.audioSource = gameObject.transform.GetChild(0).gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.outputAudioMixerGroup = s.MixerGroup;
            s.audioSource.volume = s.Volume;
            s.audioSource.pitch = s.Pitch;
            s.audioSource.loop = s.Loop;
        }

        PlaySound("Main menu");
    }

    public void PlaySound(string Name) {
        Sound s = Array.Find(Sounds, sound => sound.Name == Name);
        if(s == null) {
            Debug.Log("not found music");
            return;
        }
        s.audioSource.Play();
    }
}
