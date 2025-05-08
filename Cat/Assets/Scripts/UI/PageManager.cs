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
    public GameObject pageGroup;
    public GameObject tabGroup;
    public GameObject dimBackground;
    public Button noteButton; // �� ����������Notebook�����İ�ť

    public GameObject[] collections;
    private bool[] gotcollections;

    private int currentPageIndex = 0;
    private bool wasTimePaused = false;

    void Start()
    {
        instance = this;
        gotcollections = new bool[8];
        if (pageGroup != null)
            pageGroup.SetActive(false);
        if (dimBackground != null)
            dimBackground.SetActive(false);
        // ��ǩҳ��ť��

        for (int i = 0; i < tabButtons.Length; i++)
        {
            int index = i;
            tabButtons[i].onClick.AddListener(() => ShowPage(index));
        }

        CollectionGetEventHandler += AddCollections;
    }

    public void ShowPage(int index)
    {
        currentPageIndex = index;

        for (int i = 0; i < pages.Length; i++)
            pages[i].SetActive(i == index);
    }

    public void OpenNotebook()
    {
        pageGroup.SetActive(true);
        tabGroup.SetActive(true);
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
        pageGroup.SetActive(false);
        tabGroup.SetActive(false);
        if (dimBackground != null)
            dimBackground.SetActive(false);

        if (!wasTimePaused)
        {
            Time.timeScale = 1f;
        }
    }

    public void GetCollections()
    {
        if (ObjManager.instance.brokenNum >= 30 )
        {
            if (!gotcollections[6])
                CollectionGetEventHandler.Invoke(6);
            if (ObjManager.instance.brokenNum >= 60 && !gotcollections[7])
                CollectionGetEventHandler.Invoke(7);
            if (ObjManager.instance.brokenNum == 100 && !gotcollections[0])
                CollectionGetEventHandler.Invoke(0);          
        }
        
    }

    public void AddCollections(int index)
    {
        if (!gotcollections[index])
        {
            collections[index].SetActive(true);
            gotcollections[index] = true;
        }
    }

    public static void TriggerCollectionEvent(int index)
    {
        CollectionGetEventHandler?.Invoke(index);
    }

    public delegate void CollectionGet(int index);

    public static event CollectionGet CollectionGetEventHandler;
}
