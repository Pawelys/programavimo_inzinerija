using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    // Speed
    public float forwardSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Forward velocity (always moving forward)
        rb.linearVelocity = transform.up * forwardSpeed;
    }
}