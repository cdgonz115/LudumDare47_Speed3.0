using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    private string menuSceneName = "MainMenu";

    public GameObject pauseMenuUI;

    public GameObject startPos;

    private void Start()
    {
        gameIsPaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameIsPaused = true;
    }

    public void TPtoStart()
    { 
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = startPos.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
        Resume();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
