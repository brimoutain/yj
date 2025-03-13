using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object : MonoBehaviour
{
    // ����ͨ�ò��Ŷ���
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
        // �����봥�����������Ƿ����ض�����
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
