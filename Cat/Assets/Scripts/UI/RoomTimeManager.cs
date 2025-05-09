using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RoomTimerManager : MonoBehaviour
{
    public static RoomTimerManager instance;

    public TMP_Text timerText;
    public GameObject dialogBox;
    public GameObject FirstroomBarrier;
    public GameObject SecondroomBarrier;
    public GameObject ThirdroomBarrier;
    public float countdownTime = 60f;
    public int currentRoom = 1;
    public string loadScene;

    private bool hasExitedRoom = false;

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
        else if (currentRoom == 3)
        {
            RemoveBarrier3();
        }
    }

    public void SetRoomExited()
    {
        hasExitedRoom = true;
        Debug.Log("玩家已离开房间！");
    }

    public void RemoveBarrier1()
    {
        hasExitedRoom = false;
        FirstroomBarrier.SetActive(false);
        SecondroomBarrier.SetActive(true);
        DialogManager.instance.ShowDialog1();
        currentRoom++;
        StartCoroutine(CheckRoomExitAfterTimeout());
        loadScene = RoomExitManager1.instance.sceneToLoad;
    }

    public void RemoveBarrier2()
    {
        hasExitedRoom = false;
        SecondroomBarrier.SetActive(false);
        DialogManager.instance.ShowDialog1();
        currentRoom++;
        StartCoroutine(CheckRoomExitAfterTimeout());
        loadScene = RoomExitManager2.instance.sceneToLoad;
    }

    public void RemoveBarrier3()
    {
        hasExitedRoom = false;
        ThirdroomBarrier.SetActive(false);
        DialogManager.instance.ShowDialog1();
        //进入阳台时若没破坏任何东西
        if (ObjManager.instance.brokenNum == 0)
        {
            PageManager.TriggerCollectionEvent(1);
        }
        loadScene = RoomExitManager3.instance.sceneToLoad;
    }

    private IEnumerator CheckRoomExitAfterTimeout()
    {
        float waitTime = 5f;
        float timer = 0f;

        while (timer < waitTime)
        {
            if (hasExitedRoom)
            {
                Debug.Log("玩家已离开房间，取消跳转。");
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }
        PageManager.TriggerCollectionEvent(3);
        Debug.Log("玩家未离开房间，跳转场景！");
        SceneManager.LoadScene(loadScene); 
    }
}
