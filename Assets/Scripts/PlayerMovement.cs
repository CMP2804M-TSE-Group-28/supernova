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

    private Camera cm;

    /// <summary>
    /// Exposed config.
    /// </summary>
    public float jumpForce; // Defines the upwards force of a jump. DEFAULT: 30
    public float movementSpeed; // Defines how fast the player moves. DEFAULT: 100
    private Vector2 currentMouseLookVector = Vector2.zero; // Representation of mouse movement.
    [SerializeField] public float sensitivity = 0.5f; // Mouse sensitivity.

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cm = this.gameObject.GetComponentInChildren<Camera>();
    }

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

    public void OnLook(InputValue input)
    {
        // Cursor is locked, we can do mouse movement :)
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float posX = input.Get<Vector2>().x * sensitivity;
            float posY = input.Get<Vector2>().y * sensitivity;

            // Horizontal camera
            Vector3 targetRotationX = new Vector3(0.0f, posX);
            rb.transform.eulerAngles += targetRotationX;

            // Vertical camera - with clamping
            Vector3 targetRotationY = new Vector3(-posY, 0.0f);
            targetRotationY.y += Mathf.Clamp(targetRotationY.y, 0f, 90f);
            cm.transform.eulerAngles += targetRotationY;
        }

    }

    private void OnPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnFire()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}