using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UncoverHearing : MonoBehaviour {
    public DialogueTrigger UncoveredHearing;
    SpriteRenderer SelfSprite;
    bool Uncovered = false;

    void Start() {
        SelfSprite = gameObject.GetComponent<SpriteRenderer>();
        SelfSprite.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player" && !Uncovered) {
            Uncovered = true;
            UncoveredHearing.TriggerDialogue();
            SelfSprite.enabled = true;
            Settings settings = FindObjectOfType<Settings>();
            settings.SetMasterVolume(0f);
        }
    }
}