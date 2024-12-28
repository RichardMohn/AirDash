using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;  // Reference to the player object
    public GameObject[] obstacles;  // Array of obstacle objects
    public GameObject gameOverUI; // A UI element that shows when the game is over
    private bool isGameOver = false; // A flag to check if the game is over

    void Start()
    {
        gameOverUI.SetActive(false); // Hide the game over screen at the start
    }

    void Update()
    {
        // If the game is over, do not allow further player input or movement
        if (isGameOver)
        {
            return;
        }
    }

    public void GameOver()
    {
        isGameOver = true;  // Set the game state to over
        gameOverUI.SetActive(true);  // Show the game over UI
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;  // Stop the player's movement
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().StopObstacle();  // Stop obstacles from moving
        }
    }

    public void ResetGame()
    {
        isGameOver = false;  // Reset game state
        gameOverUI.SetActive(false);  // Hide the game over UI
        player.transform.position = new Vector2(0, 0);  // Reset player position
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;  // Reset velocity
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().ResetObstacle();  // Reset obstacles
        }
    }
}