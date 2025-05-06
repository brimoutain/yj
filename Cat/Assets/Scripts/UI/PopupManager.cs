using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;   
    public GameObject background;  

    void Start()
    {
        popupPanel.SetActive(false);
        background.SetActive(false);
    }

    public void ShowPopup()
    {
        popupPanel.SetActive(true);
        background.SetActive(true);
        Time.timeScale = 0;
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1;
    }
}
