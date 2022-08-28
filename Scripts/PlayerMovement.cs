using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public GameObject ClickCirclePrefab;
    public float MovementSpeed = 5f;
    public Rigidbody2D Player;
    public new Camera camera;
    Vector2 TargetPosition;

    //Update is called once per frame, but inconsistent, so not suitable for physics.
    void Update() {
        /*
            Inputs
        */

        if(Input.GetMouseButtonDown(0)) {
            TargetPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            GameObject ClickCircle = Instantiate(ClickCirclePrefab, TargetPosition, Quaternion.identity);
            Destroy(ClickCircle, 1);
        }
    }

    //FixedUpdate is called once per frame, and is consistent, so suitable for physics.
    void FixedUpdate() {
        /*
            Movements
        */

        Player.position = Vector2.MoveTowards(Player.position, TargetPosition, MovementSpeed * Time.fixedDeltaTime);
    }
}