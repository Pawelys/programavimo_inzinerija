using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Keyboard keyboard;

    // Speed
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    // Boundaries
    public float minBoundaryX = -4.25f;
    public float maxBoundaryY = 4.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        keyboard = Keyboard.current;
    }

    void FixedUpdate()
    {
        if (keyboard == null) return;

        // Check what is pressed
        bool leftPressed = keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed;
        bool rightPressed = keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed;

        // Get horizontal input
        float horizontalInput = 0;
        if (leftPressed && rightPressed)
        {
            horizontalInput = 0;
        }
        else if (leftPressed)
        {
            horizontalInput = -1;
        }
        else if (rightPressed)
        {
            horizontalInput = 1;
        }

        // Check if at boundary and trying to move further out
        if ((rb.position.x <= minBoundaryX && horizontalInput < 0) || (rb.position.x >= maxBoundaryY && horizontalInput > 0))
        {
            horizontalInput = 0;
        }

        // Forward velocity (always moving forward)
        Vector2 forwardVelocity = (Vector2)transform.up * forwardSpeed;

        // Side velocity from input
        Vector2 sideVelocity = (Vector2)transform.right * horizontalInput * sideSpeed;

        // Combine velocities
        rb.linearVelocity = forwardVelocity + sideVelocity;
    }
}