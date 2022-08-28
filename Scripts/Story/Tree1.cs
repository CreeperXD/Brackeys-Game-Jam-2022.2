using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tree1 : MonoBehaviour {
    public DialogueTrigger Childhood;
    bool Uncovered = false;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player" && !Uncovered) {
            Uncovered = true;
            Childhood.TriggerDialogue();
        }
    }
}
