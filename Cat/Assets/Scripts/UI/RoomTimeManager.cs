using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class RoomTimerManager : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject dialogBox;        // 对话框 UI
    public GameObject roomBarrier;        // 房间出口阻挡器
    public float countdownTime = 60f;   // 倒计时秒数

    private void Start()
    {
        dialogBox.SetActive(false);
        roomBarrier.SetActive(false);
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
        roomBarrier.SetActive(true);   // 移除出口障碍
        dialogBox.SetActive(true);     // 显示对话框
    }
}
