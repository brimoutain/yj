using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExitManager1 : MonoBehaviour
{
    public static RoomExitManager1 instance;

    private bool hasExited = false;
    public string sceneToLoad;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasExited) return;

        if (other.CompareTag("Player"))
        {
            RoomTimerManager.instance.SetRoomExited();
            hasExited = true;
        }
    }
}
