using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour {
    public AudioMixer Mixer;
    [Range(1, 50)]
    public float textSpeed;
    [TextArea(1, 5)]
    public string TestSentence;
    public TextMeshProUGUI TestSentenceText;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void SetTextSpeed(float TextSpeed) {
        StopAllCoroutines();
        textSpeed = TextSpeed;
        StartCoroutine(TypeTestSentece(TestSentence));
    }

    IEnumerator TypeTestSentece(string TestSentence) {
        TestSentenceText.text = "";
        foreach(char Letter in TestSentence.ToCharArray()) {
            TestSentenceText.text += Letter;
            yield return new WaitForSeconds(1 / textSpeed);
        }
    }

    public void SetMasterVolume(float MasterVolume) {
        Mixer.SetFloat("MasterVolume", MasterVolume);
    }

    public void SetMusicVolume(float MusicVolume) {
        Mixer.SetFloat("MusicVolume", MusicVolume);
    }

    public void SetSoundEffectsVolume(float SoundEffectsVolume) {
        Mixer.SetFloat("SoundEffectsVolume", SoundEffectsVolume);
        FindObjectOfType<AudioManager>().PlaySound("Button hover");
    }
}