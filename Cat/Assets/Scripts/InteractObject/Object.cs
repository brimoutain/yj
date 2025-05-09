using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Object : MonoBehaviour
{
    // 物体通用播放动画
    //protected Animator anim;
    protected Collider2D col;
    protected SpriteRenderer sprite;
    protected bool isInteracted = false;

    public Sprite originObj;
    public Sprite enterObj;
    public Sprite brokenObj;

    protected PlayerState playerState;
    public bool canInteractedMore = false;
    public static int interactedNum;


    // 1. 定义一个枚举类型作为选项
    public enum StateType
    {
        grab,
        push,
        doumaobang,
        slide
    }

    public enum AddNum
    {
        Three = 3,
        Six = 6,
        Ten = 10,
        Twelve = 12
    }
    // 2. 在 Inspector 中显示为下拉菜单
    [SerializeField]
    private StateType selectedState;
    [SerializeField]
    private AddNum addNum;
    private bool isPlayerInTrigger;

    protected virtual void Start()
    {
        //anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        interactedNum = 0;
        isInteracted =false;

        switch (selectedState)
        {
            case StateType.grab:
                playerState = Player.instance.grabState;
                break;
            case StateType.push:
                playerState = Player.instance.pushState;
                break;
            case StateType.doumaobang:
                playerState = Player.instance.playState;
                break;
            case StateType.slide:
                playerState= Player.instance.slideState;
                canInteractedMore = true;
                break;
            default:
                return;
        }
    }

    private void Update()
    {
        if (Player.instance.triggerCalled=true && isInteracted == true)
        {
            Player.instance.stateMachine.ChangeState(Player.instance.idleState);
            //玩家动画结束
            sprite.sprite = brokenObj;
            ObjManager.instance.CheckNum((int)addNum);
            Player.instance.triggerCalled = false;
            //其他动画到不了八
            interactedNum++;
            if (canInteractedMore)
                isInteracted = false;
        }

        if(isPlayerInTrigger && Input.GetKeyDown(KeyCode.K))
        {
            isInteracted = true;
            Player.instance.stateMachine.ChangeState(playerState);
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        //// 检查进入触发器的物体是否是特定类型
        //if (collision.CompareTag("Player") && isInteracted == false)
        //{
        //    //玩家进入检测范围，且没有被破坏过时变成白边
        //    sprite.sprite = enterObj;
        //    if (Input.GetKeyDown(KeyCode.K) )
        //    {
        //        isInteracted = true;
        //        Player.instance.stateMachine.ChangeState(playerState);
        //    }
            
        //}

        if (collision.CompareTag("Player") && !isInteracted)
        {
            sprite.sprite = enterObj;
            isPlayerInTrigger = true; // 标记玩家在触发区域
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (!isInteracted)
        {
            //如果离开时也没有按下k键，则变回原样
            sprite.sprite = originObj;
        }
        if(interactedNum == 8)
        {
            PageManager.TriggerCollectionEvent(5);
        }
        isPlayerInTrigger = false;
    }
}
