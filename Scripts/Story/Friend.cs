using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Friend : MonoBehaviour {
    bool Approached = false;

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player" && !Approached) {
            Approached = true;
            FindObjectOfType<DialogueCommander>().StateCounter++;
        }
    }
}