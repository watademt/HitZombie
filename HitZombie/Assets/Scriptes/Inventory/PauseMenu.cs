using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Text timeText;
    public GameObject UIBG;
    public FirstPersonLook firstPersonLook;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!UIBG.activeSelf)
            {
                firstPersonLook.enabled = false;
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        firstPersonLook.enabled = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }

    public void ExitMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}