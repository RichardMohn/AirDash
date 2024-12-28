using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;  // Speed at which the obstacle moves to the left
    private bool isMoving = true;  // Flag to control if the obstacle should move

    void Update()
    {
        if (isMoving)
        {
            MoveObstacle();
        }
    }

    void MoveObstacle()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);  // Move obstacle to the left
    }

    public void StopObstacle()
    {
        isMoving = false;  // Stop the obstacle from moving
    }

    public void ResetObstacle()
    {
        isMoving = true;  // Start moving the obstacle again
        transform.position = new Vector2(10, transform.position.y);  // Reset obstacle position (adjust as needed)
    }
}