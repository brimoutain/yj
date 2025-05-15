using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWatcher : MonoBehaviour
{
    void OnDestroy()
    {
        Debug.Log($"[DestroyWatcher] {gameObject.name} ±ªœ˙ªŸ¡À£°");
    }
}
