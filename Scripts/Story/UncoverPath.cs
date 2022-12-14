using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UncoverPath : MonoBehaviour {
    TilemapRenderer PathTilemapRenderer;
    public DialogueTrigger UncoveredPath;
    bool Uncovered = false;

    void Start() {
        PathTilemapRenderer = gameObject.GetComponent<TilemapRenderer>();
        PathTilemapRenderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player" && !Uncovered) {
            Uncovered = true;
            UncoveredPath.TriggerDialogue();
            PathTilemapRenderer.enabled = true;
        }
    }
}
