using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverUI; // Assign your Game Over UI in the Inspector

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R)) // Press 'R' to reset (useful for testing on PC)
        {
            ResetGame();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0; // Pause the game
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Show the Game Over UI
        }
    }

    public void ResetGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}