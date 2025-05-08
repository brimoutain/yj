using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public static PageManager instance;

    [Header("页面和标签按钮")]
    public GameObject[] pages;
    public Button[] tabButtons;

    [Header("外部UI控制")]
    public GameObject notebookWindow;
    public GameObject dimBackground;
    public Button noteButton; // ← 新增：控制Notebook弹出的按钮

    private int currentPageIndex = 0;
    private bool wasTimePaused = false;

    void Start()
    {
        instance = this;
        ShowPage(0);

        // 标签页按钮绑定
        for (int i = 0; i < tabButtons.Length; i++)
        {
            int index = i;
            tabButtons[i].onClick.AddListener(() => ShowPage(index));
        }

        // NoteButton绑定
        if (noteButton != null)
        {
            noteButton.onClick.AddListener(OpenNotebook);
        }

        if (notebookWindow != null)
            notebookWindow.SetActive(false);
        if (dimBackground != null)
            dimBackground.SetActive(false);
    }

    public void ShowPage(int index)
    {
        currentPageIndex = index;

        for (int i = 0; i < pages.Length; i++)
            pages[i].SetActive(i == index);
    }

    public void OpenNotebook()
    {
        notebookWindow.SetActive(true);
        if (dimBackground != null)
            dimBackground.SetActive(true);

        if (Time.timeScale > 0f)
        {
            wasTimePaused = false;
            Time.timeScale = 0f;
        }
        else
        {
            wasTimePaused = true;
        }

        ShowPage(0); // 默认显示第一页
    }

    public void CloseNotebook()
    {
        notebookWindow.SetActive(false);
        if (dimBackground != null)
            dimBackground.SetActive(false);

        if (!wasTimePaused)
        {
            Time.timeScale = 1f;
        }
    }
}
