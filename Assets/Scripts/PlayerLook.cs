using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cm;

    private Vector2 currentMouseLookVector = Vector2.zero;

    [SerializeField] public float sensitivity = 0.5f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        cm = this.gameObject.GetComponentInChildren<Camera>();
    }

    private void OnLook(InputValue input) {
        // Cursor is locked, we can do mouse movement :)
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            currentMouseLookVector = input.Get<Vector2>();
            this.gameObject.transform.Rotate(0,currentMouseLookVector.x * sensitivity,0);
        }
        
    }

    private void OnPause()
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
