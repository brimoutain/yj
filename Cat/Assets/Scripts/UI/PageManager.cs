using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public static PageManager instance;

    [Header("页面和标签按钮")]
    public GameObject[] pages;
    public Button[] tabButtons;

    [Header("外部UI控制")]
    public GameObject pageGroup;
    public GameObject tabGroup;
    public GameObject dimBackground;
    public Button noteButton; // ← 新增：控制Notebook弹出的按钮

    public GameObject[] collections;
    public bool[] gotcollections;
    public CollectionGetting colGet;
    [SerializeField] private List<Sprite> colImage;
    private Dictionary<int, Sprite> spriteDict;

    private int currentPageIndex = 0;
    private bool wasTimePaused = false;

    void Start()
    {
        InitializeCollections();
        if(instance != null && instance != this)
        {
            Destroy(instance);
        } 
        instance = this;
        if (pageGroup != null) pageGroup.SetActive(false);
        if (dimBackground != null) dimBackground.SetActive(false);

        // 绑定按钮事件
        for (int i = 0; i < tabButtons.Length; i++)
        {
            if (tabButtons[i] == null)
            {
                Debug.LogError($"tabButtons[{i}] 未赋值！");
                continue;
            }
            int index = i;
            tabButtons[i].onClick.AddListener(() => ShowPage(index));
        }

        InitDictionary();
        CollectionGetEventHandler += AddCollections;//添加事件
    }

    void InitDictionary()
    {
        spriteDict = new Dictionary<int, Sprite>();

        for (int i = 0; i < colImage.Count; i++)
        {
            spriteDict.Add(i, colImage[i]);
        }
    }

    void ShowPopup(int colNum)
    {
        if (spriteDict.ContainsKey(colNum))
        {
            colGet.collection.sprite = spriteDict[colNum];
            colGet.ShowCollection(colNum);
        }
    }

    private void InitializeCollections()
    {
        gotcollections = new bool[8];
        gotcollections = CollectionsSave.instance.gotcollections;
        for (int i = 0;i < 8; i++)
        {
            if (gotcollections[i])
            {
                collections[i].SetActive(true);
            }
        }
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
        
        ShowPage(0); // 默认显示第一页
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

    public void AddCollections(int index)
    {
        if (!gotcollections[index])
        {
            
            collections[index].SetActive(true);
            gotcollections[index] = true;
            CollectionsSave.instance.gotcollections[index] = true;
            ShowPopup(index);
        }
    }

    public static void TriggerCollectionEvent(int index)
    {
        CollectionGetEventHandler?.Invoke(index);
    }

    public delegate void CollectionGet(int index);

    public static event CollectionGet CollectionGetEventHandler;

    void OnDestroy()
    {
        CollectionGetEventHandler -= AddCollections;
    }

}
