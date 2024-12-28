using UnityEngine;
using UnityEngine.SceneManagement;  // Required for Scene reloading
using UnityEngine.UI;  // Required for UI elements like buttons and text

public class GameController : MonoBehaviour
{
    public GameObject gameOverCanvas;  // Reference to the Game Over screen Canvas
    public Text scoreText;  // Reference to score UI Text
    private int score;  // Player's score

    void Start()
    {
        score = 0;
        gameOverCanvas.SetActive(false);  // Hide Game Over screen initially
    }

    // Call this method when the player collides with an obstacle
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);  // Show the Game Over screen
        scoreText.text = "Score: " + score.ToString();  // Display the score on Game Over screen
        Time.timeScale = 0f;  // Stop the game (pause it)
    }

    // Call this method to reset the game and reload the scene
    public void ResetGame()
    {
        Time.timeScale = 1f;  // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene to reset everything
    }

    // Method to increment the score whenever the player passes an obstacle
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();  // Update the score UI
    }
}