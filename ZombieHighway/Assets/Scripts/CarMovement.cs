using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Keyboard keyboard;

    private float horizontalInput;
    private float currentSideSpeed;

    public float forwardSpeed = 10f;
    public float sideSpeed = 5f;
    public float smoothTime = 0.1f;

    public float minBoundaryX = -4.25f;
    public float maxBoundaryX = 4.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        keyboard = Keyboard.current;
    }

    void Update()
    {
        if (keyboard == null) return;

        // Get input
        bool leftPressed = keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed;
        bool rightPressed = keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed;

        // Get horizontal movement multiplier
        if (leftPressed && !rightPressed)
            horizontalInput = -1;
        else if (rightPressed && !leftPressed)
            horizontalInput = 1;
        else
            horizontalInput = 0;
    }

    void FixedUpdate()
    {
        // Smooth movement
        float targetSpeed = horizontalInput * sideSpeed;
        currentSideSpeed = Mathf.MoveTowards(currentSideSpeed, targetSpeed, sideSpeed * smoothTime);

        // Check boundaries
        if ((rb.position.x <= minBoundaryX && horizontalInput < 0) || (rb.position.x >= maxBoundaryX && horizontalInput > 0))
        {
            currentSideSpeed = 0;
            rb.linearVelocity = new Vector2(0, forwardSpeed);
            return;
        }

        // Apply movement
        rb.linearVelocity = new Vector2(currentSideSpeed, forwardSpeed);
    }
}