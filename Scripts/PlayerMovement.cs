using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float MovementSpeed = 5f;
    public Rigidbody2D Player;
    Vector2 MoveDirection;

    //Update is called once per frame, but inconsistent, so not suitable for physics.
    void Update() {
        //Inputs
        MoveDirection.x = Input.GetAxisRaw("Horizontal");
        MoveDirection.y = Input.GetAxisRaw("Vertical");
    }

    //FixedUpdate is called once per frame, and is consistent, so suitable for physics.
    void FixedUpdate() {
        //Movements
        Player.MovePosition(Player.position + MoveDirection * MovementSpeed * Time.fixedDeltaTime);
    }
}
