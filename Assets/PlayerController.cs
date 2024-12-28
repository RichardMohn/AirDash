using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dashSpeed = 5f; // Speed of the dash
    public float fallSpeed = 2f; // Speed of falling (adjust to slow it down)
    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;
    private bool isSwiping = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the player's Rigidbody2D
    }

    void Update()
    {
        HandleSwipe();
        ApplyGravity();
    }

    private void HandleSwipe()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the player starts the swipe (touch or click)
        {
            swipeStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get starting position
            isSwiping = true;
        }

        if (Input.GetMouseButtonUp(0) && isSwiping) // When the player releases the swipe
        {
            swipeEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get end position

            // Calculate direction
            Vector2 swipeDirection = swipeEndPos - swipeStartPos;

            // Make the dash longer by scaling the swipe direction (you can adjust the multiplier)
            Vector2 dashVector = swipeDirection.normalized * dashSpeed;
            rb.velocity = new Vector2(dashVector.x, dashVector.y);

            isSwiping = false;
        }
    }

    private void ApplyGravity()
    {
        // Slow down the falling by reducing gravity (you can adjust the multiplier here)
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * fallSpeed * Time.deltaTime; // Apply custom gravity to slow fall
        }
    }
}