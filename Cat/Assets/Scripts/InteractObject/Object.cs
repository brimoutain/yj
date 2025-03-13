using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object : MonoBehaviour
{
    // 物体通用播放动画
    protected Animator anim;
    protected Collider2D collider;
    protected Sprite sprite; 
    protected bool isInteracted = false;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<Sprite>();
        collider.isTrigger = true;
    }

    protected void OnTriggerStay(Collider other)
    {
        // 检查进入触发器的物体是否是特定类型
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.K) && isInteracted == false)
            {
                    isInteracted = true;
                    Debug.Log("TriggerCall");
            }
        }
    }
}
