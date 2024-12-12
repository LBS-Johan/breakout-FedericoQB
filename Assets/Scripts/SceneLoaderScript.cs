using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseCanvas;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseMenu();
        }
    }
    public void LoadMainGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        HealthScript.health = 3;
        SceneManager.LoadScene(0);
        BallScript.amountOfBallsTotal = 1;
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void PauseMenu()
    {
        if (isPaused != true)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
    }
}
