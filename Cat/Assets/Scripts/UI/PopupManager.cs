using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;

    public GameObject popupPanel;
    public GameObject background;

    public bool isPopupVisible;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        popupPanel.SetActive(false);
        background.SetActive(false);
        isPopupVisible = false;
    }

    public void TogglePopup()
    {
        if (!Pause.instance.isPaused)
        {
           if (isPopupVisible)
           {
            // �رյ���
            popupPanel.SetActive(false);
            background.SetActive(false);
            Time.timeScale = 1;
            isPopupVisible = false;
           }
           else
           {
                // ��ʾ����
                popupPanel.SetActive(true);
                background.SetActive(true);
                Time.timeScale = 0;
                isPopupVisible = true;
           }
        }
    }
}
