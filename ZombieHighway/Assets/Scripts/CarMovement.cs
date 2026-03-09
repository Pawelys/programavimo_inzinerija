using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
    }
}
