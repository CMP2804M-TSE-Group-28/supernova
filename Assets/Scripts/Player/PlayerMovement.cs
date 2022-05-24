using System;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

/// <summary>
/// Player movement controller.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveVector;

    private Camera cm;
    private Transform cmTransform;

    public Transform player;
    private bool isCrouching = false;
    private float nonCrouchHeight;
    public float crouchHeight;
    
    /// <summary>
    /// Exposed config.
    /// </summary>
    public float jumpForce; // Defines the upwards force of a jump. DEFAULT: 30
    public float movementSpeed = 100; // Defines how fast the player moves. DEFAULT: 100
    [SerializeField] public float sensitivity = 0.5f; // Mouse sensitivity.

    private void Start()
    {
        // Grab our GameObjects.
        rb = GetComponent<Rigidbody>(); // Player body.
        cm = this.gameObject.GetComponentInChildren<Camera>(); // Camera

        cmTransform = cm.transform;
        
        // Set init non crouching height
        nonCrouchHeight = player.localScale.y;
        print("Set the players normal height to " + nonCrouchHeight);
    }

    private void FixedUpdate()
    {
        // Apply Movement onto player, given movement speed.
        rb.AddRelativeForce(moveVector.normalized * (movementSpeed - rb.velocity.magnitude));
    }

    // Player Movement (Called from the Input Action)
    private void OnMove(InputValue input)
    {
        // Everytime the player moves, capture what they have done, 
        // convert to move vector format, stored as the move vector.
        Vector2 inputVector = input.Get<Vector2>();
        moveVector = new Vector3(inputVector.x, 0, inputVector.y);
    }

    /// <summary>
    /// Called on jump event. Still a bit buggy.
    /// </summary>
    private void OnJump(InputValue input)
    {
        // Add upwards force.
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
    
    private bool IsGrounded()  {
        return Physics.Raycast(rb.transform.position, -Vector3.up, 1.5f);
    }

    /// <summary>
    /// Crouching functionality, not yet implemented.
    /// Don't add NotImplementedException, we don't want the game to crash.
    /// </summary>
    private void OnCrouch()
    {
        isCrouching = !isCrouching;
        
        if (isCrouching)
        {
            player.localScale = new Vector3(player.localScale.x, crouchHeight, player.localScale.z);
            movementSpeed = 75;
        }
        else
        {
            player.localScale = new Vector3(player.localScale.x, nonCrouchHeight, player.localScale.z);
            movementSpeed = 100;
        }
    }

    /// <summary>
    /// Called whenever a mouse / joystick movement is detected for moving the camera.
    /// </summary>
    /// <param name="input"></param>
    public void OnLook(InputValue input)
    {
        // Cursor is locked, we can do mouse movement :)
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Vector2 InputVector = input.Get<Vector2>() * sensitivity; // Make input respective to sensitivity
            rb.transform.Rotate(0.0f, InputVector.x, 0.0f);
        }
    }

    /// <summary>
    /// Relieves player of game control.
    /// </summary>
    private void OnPause()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    /// <summary>
    /// Handle Mouse 1, focus game window and lock mouse or firing.
    /// </summary>
    private void OnFire()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            return; // Don't fire if we're only focusing, too many games forget this.
        }
        // TODO: Handle firing here, Josh.
        // Matt, firing is handled in the weapons holder.
    }
}