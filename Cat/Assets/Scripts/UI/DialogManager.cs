using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public GameObject dialogBox1;
    public GameObject dialogBox2;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        dialogBox1.SetActive(false);
        dialogBox2.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (dialogBox1.activeSelf)
            {
                ShowDialog2();
            }
            else if (dialogBox2.activeSelf)
            {
                EnterNextRoom();
            }
        }
    }

    public void ShowDialog1()
    {
        dialogBox1.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowDialog2()
    {
        dialogBox1.SetActive(false);
        dialogBox2.SetActive(true);
    }

    public void EnterNextRoom()
    {
        dialogBox2.SetActive(false);
        Time.timeScale = 1f;
        RoomTimerManager.instance.CountdownStart();
    }
}
