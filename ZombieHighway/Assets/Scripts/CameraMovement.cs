using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float forwardSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.linearVelocity = new Vector2(0, forwardSpeed);
    }
}