using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UncoverDecorations : MonoBehaviour {
    public DialogueTrigger UncoveredDecorations;
    public GameObject Decorations;
    SpriteRenderer SelfSprite;
    bool Uncovered = false;

    void Start() {
        SelfSprite = gameObject.GetComponent<SpriteRenderer>();
        SelfSprite.enabled = false;
        Decorations.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player" && !Uncovered) {
            Uncovered = true;
            UncoveredDecorations.TriggerDialogue();
            SelfSprite.enabled = true;
            Decorations.SetActive(true);
        }
    }
}