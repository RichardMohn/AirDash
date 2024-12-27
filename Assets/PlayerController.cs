using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dashSpeed = 10f;  // Speed of the dash
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isTouching = false;

    void Update()
    {
        // Check for touch input (for mobile)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Record the start position of the touch
                startTouchPosition = touch.position;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Ended && isTouching)
            {
                // Record the end position of the touch
                endTouchPosition = touch.position;

                // Call Dash method based on swipe direction
                Dash();
                isTouching = false;
            }
        }
    }

    void Dash()
    {
        // Get the swipe direction by calculating the difference between the start and end touch positions
        Vector2 swipeDirection = endTouchPosition - startTouchPosition;

        // Normalize the swipe direction to get a unit vector (to avoid scaling issues)
        swipeDirection.Normalize();

        // Dash the player in the direction of the swipe
        if (swipeDirection.x > 0)
        {
            // Dash right
            transform.Translate(Vector3.right * dashSpeed * Time.deltaTime);
        }
        else if (swipeDirection.x < 0)
        {
            // Dash left
            transform.Translate(Vector3.left * dashSpeed * Time.deltaTime);
        }

        if (swipeDirection.y > 0)
        {
            // Dash up
            transform.Translate(Vector3.up * dashSpeed * Time.deltaTime);
        }
        else if (swipeDirection.y < 0)
        {
            // Dash down
            transform.Translate(Vector3.down * dashSpeed * Time.deltaTime);
        }
    }
}