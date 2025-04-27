using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object : MonoBehaviour
{
    // 物体通用播放动画
    //protected Animator anim;
    protected Collider2D col;
    protected SpriteRenderer sprite;
    protected bool isInteracted = false;

    public Sprite originObj;
    public Sprite enterObj;
    public GameObject brokenObj;
    void Start()
    {
        //anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        col.isTrigger = true;
        originObj = sprite.sprite;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 检查进入触发器的物体是否是特定类型
        if (collision.CompareTag("Player") && isInteracted == false)
        {
            //玩家进入检测范围，且没有被破坏过时变成白边
            sprite.sprite = enterObj;
            if (Input.GetKeyDown(KeyCode.K))
            {
                //玩家按下k键，可以控制播放动画等操作，这里变为破坏物体
                isInteracted = true;
                Player.instance.stateMachine.ChangeState(Player.instance.grabState);
            }
            if (Player.instance.triggerCalled)
            {
                brokenObj.SetActive(true);
                Destroy(gameObject);
                Player.instance.triggerCalled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isInteracted)
        {
            //如果离开时也没有按下k键，则变回原样
            sprite.sprite = originObj;
        }
    }
}
