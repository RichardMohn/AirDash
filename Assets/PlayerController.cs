using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dashSpeed = 5f;  // Speed of the dash
    public float gravityScale = 1f;  // How fast gravity affects the player
    public int totalSwipes = 10;  // Total number of allowed swipes
    private int remainingSwipes;  // Track the number of remaining swipes
    private Vector2 swipeStartPos;  // Store swipe start position
    private Rigidbody2D rb;  // Rigidbody for player physics
    private bool isDashing = false;  // If the player is currently dashing

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainingSwipes = totalSwipes;  // Set the initial swipe count
    }

    void Update()
    {
        if (remainingSwipes > 0)
        {
            if (Input.touchCount > 0)
            {
                HandleTouchInput();
            }
        }

        if (isDashing)
        {
            rb.gravityScale = 0;  // Disable gravity while dashing
        }
        else
        {
            rb.gravityScale = gravityScale;  // Apply gravity when not dashing
        }
    }

    void HandleTouchInput()
    {
        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                swipeStartPos = touch.position;  // Save the swipe start position
                break;
            
            case TouchPhase.Moved:
                if (remainingSwipes > 0 && !isDashing)
                {
                    Vector2 swipeDirection = touch.position - swipeStartPos;
                    Dash(swipeDirection);
                }
                break;

            case TouchPhase.Ended:
                break;
        }
    }

    void Dash(Vector2 swipeDirection)
    {
        // Normalize the swipe direction and apply the dash force
        Vector2 dashDirection = swipeDirection.normalized;
        rb.velocity = dashDirection * dashSpeed;

        // Reduce the remaining swipes by 1
        remainingSwipes--;

        // Trigger dash cooldown effect
        isDashing = true;
        Invoke("EndDash", 0.5f);  // End the dash after 0.5 seconds (you can tweak this)
    }

    void EndDash()
    {
        isDashing = false;
        rb.velocity = Vector2.zero;  // Stop the dash movement
    }

    public void ResetSwipes()
    {
        remainingSwipes = totalSwipes;  // Reset swipes count when the game restarts
    }

    public void IncreaseSwipes(int amount)
    {
        remainingSwipes += amount;  // Increase swipes if needed
    }
}