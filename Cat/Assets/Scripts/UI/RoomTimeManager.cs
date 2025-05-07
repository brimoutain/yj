using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class RoomTimerManager : MonoBehaviour
{
    public static RoomTimerManager instance;

    public TMP_Text timerText;
    public GameObject dialogBox;        // �Ի��� UI
    public GameObject FirstroomBarrier;        // ����1�����赲��
    public GameObject SecondroomBarrier;        // ����2�����赲��
    public float countdownTime = 60f;   // ����ʱ����
    public int currentRoom = 1;        // ��ǰ����

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
        FirstroomBarrier.SetActive(false);   // �Ƴ������ϰ�
        SecondroomBarrier.SetActive(true);   // ��ʾ����2�����ϰ�
        DialogManager.instance.ShowDialog1();     // ��ʾ�Ի���
        currentRoom ++;        // �л�����
    }

    public void RemoveBarrier2()
    {
        SecondroomBarrier.SetActive(false);   // �Ƴ������ϰ�
        DialogManager.instance.ShowDialog1();     // ��ʾ�Ի���
    }

    public void ShowCG()
    {

    }
}
