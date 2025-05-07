using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class RoomTimerManager : MonoBehaviour
{
    public static RoomTimerManager instance;

    public TMP_Text timerText;
    public GameObject dialogBox;        // 对话框 UI
    public GameObject FirstroomBarrier;        // 房间1出口阻挡器
    public GameObject SecondroomBarrier;        // 房间2出口阻挡器
    public float countdownTime = 60f;   // 倒计时秒数
    public int currentRoom = 1;        // 当前房间

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        dialogBox.SetActive(false);
        FirstroomBarrier.SetActive(true);
        CountdownStart();
    }

    public void CountdownStart()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        float timeLeft = countdownTime;

        while (timeLeft > 0)
        {
            timerText.text = Mathf.CeilToInt(timeLeft).ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        timerText.text = "0";

        if (currentRoom == 1)
        {
            RemoveBarrier1();
        }
        else if (currentRoom == 2)
        {
            RemoveBarrier2();
        }
        else
        {
            ShowCG();
        }
    }

    public void RemoveBarrier1()
    {
        FirstroomBarrier.SetActive(false);   // 移除出口障碍
        SecondroomBarrier.SetActive(true);   // 显示房间2出口障碍
        DialogManager.instance.ShowDialog1();     // 显示对话框
        currentRoom ++;        // 切换房间
    }

    public void RemoveBarrier2()
    {
        SecondroomBarrier.SetActive(false);   // 移除出口障碍
        DialogManager.instance.ShowDialog1();     // 显示对话框
    }

    public void ShowCG()
    {

    }
}
