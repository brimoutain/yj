using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause instance;

    [Header("UI 控制")]
    public GameObject pauseMenu;       // 暂停菜单 UI
    public GameObject dimBackground;   // 黑色半透明背景

    [HideInInspector]
    public bool isPaused { get; private set; }

    private void Awake()
    {
        // 单例赋值
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
        if (dimBackground != null)
            dimBackground.SetActive(false);

        isPaused = false;
    }

    private void Update()
    {
        // ESC 键切换暂停
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    /// <summary>
    /// 切换暂停状态
    /// </summary>
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            // 若笔记本正在打开，则不允许暂停
            if (PageManager.instance != null && PageManager.instance.notebookWindow.activeSelf)
                return;

            PauseGame();
        }
    }

    /// <summary>
    /// 暂停游戏
    /// </summary>
    public void PauseGame()
    {
        if (isPaused) return;

        isPaused = true;
        Time.timeScale = 0f;

        if (pauseMenu != null)
            pauseMenu.SetActive(true);
        if (dimBackground != null)
            dimBackground.SetActive(true);
    }

    /// <summary>
    /// 取消暂停
    /// </summary>
    public void ResumeGame()
    {
        if (!isPaused) return;

        isPaused = false;
        Time.timeScale = 1f;

        if (pauseMenu != null)
            pauseMenu.SetActive(false);
        if (dimBackground != null)
            dimBackground.SetActive(false);
    }
}
