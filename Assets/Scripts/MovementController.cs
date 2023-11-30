using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;

    // holds the 2D position of the character in space
    Vector2 movement = new Vector2();

    // reference character rigidbody2D component
    Rigidbody2D rb2D;


    // Start is called before the first frame update
    private void Start()
    {
        //gets references to game object component at game startup
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    // called at fixed intervals by Unity engine
    // may be called less frequently upon framerate drop on slower hardware
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        // get user input
        // GetAxisRaw parameter specifies which axis we're interested in
        // Returns 1 = right key or "d" (up key or "w")
        //        -1 = left key or "a"  (down key or "s")
        //         0 = no key pressed
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // player moves at same rate of speed in all directions
        movement.Normalize();

        // set RigidBody2D velocity and move it
        rb2D.velocity = movement * movementSpeed;
    }
}
