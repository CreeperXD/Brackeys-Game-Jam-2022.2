using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UncoverBoundary : MonoBehaviour {
    TilemapRenderer WallTilemapRenderer;
    public DialogueTrigger UncoveredBoundary;
    bool Uncovered = false;

    void Start() {
        WallTilemapRenderer = gameObject.GetComponent<TilemapRenderer>();
        WallTilemapRenderer.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player" && !Uncovered) {
            Uncovered = true;
            UncoveredBoundary.TriggerDialogue();
            WallTilemapRenderer.enabled = true;
        }
    }
}
