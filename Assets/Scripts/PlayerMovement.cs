using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player movement controller.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveVector;
    private bool canJump = false;

    /// <summary>
    /// Exposed config.
    /// </summary>
    public float jumpForce; // Defines the upwards force of a jump. DEFAULT: 30
    public float movementSpeed; // Defines how fast the player moves. DEFAULT: 100

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // private void Update()
    // {
    //     print("Movement is " + moveVector);
    // }
    
    private void FixedUpdate()
    {
        // Apply Movement onto player, accounting for drag and momentum.
        rb.AddRelativeForce(moveVector * movementSpeed);
    }

    // Player Movement (Called from the Input Action)
    private void OnMove(InputValue input)
    {
        // Everytime the player moves, capture what they have done, 
        // convert to move vector format, stored as the move vector.
        Vector2 inputVector = input.Get<Vector2>();
        
        moveVector = new Vector3(inputVector.x, 0, inputVector.y);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        canJump = false;
    }

    /// <summary>
    /// Called on jump event.
    /// </summary>
    private void OnJump(InputValue input)
    {
        // Add upwards force.
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    private void OnCrouch()
    {
        Debug.Log("Crouch");
        // 2.327121
    }
}