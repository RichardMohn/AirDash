using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed at which the obstacles move

    void Update()
    {
        // Move the obstacles to the left each frame
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // If the obstacle is off-screen (to the left), destroy it
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}