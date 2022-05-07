using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cm;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        cm = this.gameObject.GetComponentInChildren<Camera>();
    }

    private void OnLook(InputValue input) {
        Vector2 inputVector = input.Get<Vector2>();
        
    }
    private void OnExit()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnMouseLeft()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
