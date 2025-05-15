using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    public GameObject settingPanel;
    public Button[] keys;

    private bool wasTimePaused = false;
    public KeyCode[] playerKeys;
    private bool isHearingKey = false;
    public TextMeshProUGUI[] keyTexts;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Initialized();
    }

    private void Initialized()
    {
        playerKeys = new KeyCode[3]
        {
            KeyCode.J, KeyCode.K, KeyCode.LeftShift
        };

        for (int i = 0; i < 3; i++)
        {
            keyTexts[i].text = playerKeys[i].ToSafeString();
        }
    }

    public void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
        if (Time.timeScale > 0f)
        {
            wasTimePaused = false;
            Time.timeScale = 0f;
        }
        else
        {
            wasTimePaused = true;
        }
        Player.instance.enabled = false;
    }

    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);

        if (!wasTimePaused)
        {
            Time.timeScale = 1f;
        }
        Player.instance.enabled = true;
    }

    public void ChangeKeys(int index)
    {
        StartCoroutine(HearKeys(index));
    }

    IEnumerator HearKeys(int index)
    {
        isHearingKey =false;
        yield return null;
        
        while (!isHearingKey)
        {           
            // 遍历所有可能的 KeyCode
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    playerKeys[index] = keyCode;
                    keyTexts[index].text = keyCode.ToString();
                    Player.instance.keyCodes[index] = keyCode;
                    isHearingKey = true;
                    break;
                }
            }
            yield return null; // 等待下一帧
        }

        
    }
}
