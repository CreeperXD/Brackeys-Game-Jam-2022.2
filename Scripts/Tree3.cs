using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tree3 : MonoBehaviour {
    public DialogueTrigger Adulthood;
    bool Unconvered = false;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player" && !Unconvered) {
            Unconvered = true;
            Adulthood.TriggerDialogue();
        }
    }
}
