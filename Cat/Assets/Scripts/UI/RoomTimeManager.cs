using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class RoomTimerManager : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject dialogBox;        // �Ի��� UI
    public GameObject roomBarrier;        // ��������赲��
    public float countdownTime = 60f;   // ����ʱ����

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
        roomBarrier.SetActive(true);   // �Ƴ������ϰ�
        dialogBox.SetActive(true);     // ��ʾ�Ի���
    }
}
