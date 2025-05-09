using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExitManager3 : MonoBehaviour
{
    public static RoomExitManager3 instance;

    private bool hasExited = false;
    public string sceneToLoad;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasExited) return;

        if (other.CompareTag("Player"))
        {
            RoomTimerManager.instance.SetRoomExited();
            hasExited = true;
        }
    }
}
