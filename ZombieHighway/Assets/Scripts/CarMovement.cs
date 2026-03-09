using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Keyboard keyboard;

    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    public float minBoundaryX = -4.25f;
    public float maxBoundaryX = 4.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        keyboard = Keyboard.current;
    }

    void FixedUpdate()
    {
        Console.WriteLine("should be moving");
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

        // Check if at boundary
        if ((rb.position.x <= minBoundaryX && horizontalInput < 0) || (rb.position.x >= maxBoundaryX && horizontalInput > 0))
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