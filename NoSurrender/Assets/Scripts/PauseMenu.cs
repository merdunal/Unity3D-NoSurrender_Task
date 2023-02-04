using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuScreen;
    public GameObject gameOverScreen;
    public static bool gameisPaused;


    void Start()
    {
        // It makes sure that time is not freezed when the game starts
        Time.timeScale = 1f;
    }


    void Update()
    {

        // If the game is over, freezes the time and activates the game over menu.
        if(PlayerController.isGameOver == true)
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
            pauseMenuScreen.SetActive(false);
        }
    }

    // Freezes the time activates the pause menu. 
    public void PauseGame()
    {
        gameisPaused = true;
        pauseMenuScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    
    // Restarts the time and deactivates the pause menu.
    public void ResumeGame()
    {
        gameisPaused = false;
        Time.timeScale = 1f;
        pauseMenuScreen.SetActive(false);
    }

    // Reloads the active scene and clears the player score. 
    public void ReplayGame()
    {
        gameisPaused = false;
        PlayerController.power = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Loads the Main Menu scene.
    public void GoToMenu()
    {
        gameisPaused = false;
        SceneManager.LoadScene("MainMenu");
    }


}
