using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    public Sound[] Sounds;

    public static AudioManager Instance;

    void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in Sounds) {
            //This will go to the children of the AudioManager "AudioSources"
            s.audioSource = gameObject.transform.GetChild(0).gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.Volume;
            s.audioSource.pitch = s.Pitch;
            s.audioSource.loop = s.Loop;
        }
    }

    public void PlaySound(string Name) {
        Sound s = Array.Find(Sounds, sound => sound.Name == Name);
        s.audioSource.Play();
    }
}
