using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject playerUI;

    public void Pause()
    {
        if (GamePaused == false)
        {
            playerUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            playerUI.SetActive(true);
            Time.timeScale = 1f;
            GamePaused = false;
        }
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
