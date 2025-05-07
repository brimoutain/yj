using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause instance;

    public GameObject pauseMenu;
    public bool isPaused;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }
    public void PauseGame()
    {
        if (!PopupManager.instance.isPopupVisible)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }
    }
    public void UnpauseGame()
    {
        if (!PopupManager.instance.isPopupVisible)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}
