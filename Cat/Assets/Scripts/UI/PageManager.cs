using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public static PageManager instance;

    [Header("ҳ��ͱ�ǩ��ť")]
    public GameObject[] pages;
    public Button[] tabButtons;

    [Header("�ⲿUI����")]
    public GameObject notebookWindow;
    public GameObject dimBackground;
    public Button noteButton; // �� ����������Notebook�����İ�ť

    private int currentPageIndex = 0;
    private bool wasTimePaused = false;

    void Start()
    {
        instance = this;
        ShowPage(0);

        // ��ǩҳ��ť��
        for (int i = 0; i < tabButtons.Length; i++)
        {
            int index = i;
            tabButtons[i].onClick.AddListener(() => ShowPage(index));
        }

        // NoteButton��
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

        ShowPage(0); // Ĭ����ʾ��һҳ
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
