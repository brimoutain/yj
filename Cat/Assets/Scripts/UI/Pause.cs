using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause instance;

    [Header("UI ����")]
    public GameObject pauseMenu;       // ��ͣ�˵� UI
    public GameObject dimBackground;   // ��ɫ��͸������

    [HideInInspector]
    public bool isPaused { get; private set; }

    private void Awake()
    {
        // ������ֵ
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
        // ESC ���л���ͣ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    /// <summary>
    /// �л���ͣ״̬
    /// </summary>
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            // ���ʼǱ����ڴ򿪣���������ͣ
            if (PageManager.instance != null && PageManager.instance.notebookWindow.activeSelf)
                return;

            PauseGame();
        }
    }

    /// <summary>
    /// ��ͣ��Ϸ
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
    /// ȡ����ͣ
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
