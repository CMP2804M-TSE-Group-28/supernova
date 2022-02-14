using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Global to this class, but only this class.
    private Rigidbody _rigidbody;
    private Vector3 _moveVector;

    // Exposed config
    public float movementSpeed = 20f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        // Apply Movement onto player
        _rigidbody.AddRelativeForce(_moveVector * movementSpeed);
    }

    // Player Movement (Called from the Input Action)
    private void OnMove(InputValue input)
    {
        // Everytime the player moves, capture what they have done, 
        // convert to move vector format, stored as the move vector.
        Vector2 inputVector = input.Get<Vector2>();
        _moveVector = new Vector3(inputVector.x, 0, inputVector.y);
    }
}