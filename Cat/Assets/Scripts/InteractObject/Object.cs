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
    [SerializeField] private bool isInteracted = false;

    public Sprite originObj;
    public Sprite enterObj;
    public Sprite brokenObj;

    protected PlayerState playerState;
    public bool canInteractedMore = false;
    public int interactedNum;

    public Sprite currentObj;

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
        Zero = 0,
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
    [SerializeField] private bool isPlayerInTrigger;

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
        currentObj = sprite.sprite;
        if(isPlayerInTrigger && Input.GetKeyDown(Player.instance.keyCodes[1]))
        {
            if (!canInteractedMore)
            {
                isInteracted = true;
            }
            Player.instance.stateMachine.ChangeState(playerState);
        }

        if (Player.instance.triggerCalled && (isInteracted || playerState == Player.instance.slideState))
        {
            sprite.sprite = brokenObj;
            Player.instance.stateMachine.ChangeState(Player.instance.idleState);
            //玩家动画结束
            if (interactedNum < 1)
            {
                CollectionManager.instance.brokenNum += (int)addNum;
                CollectionManager.instance.CheckNum();
            }
            if(canInteractedMore)
                interactedNum++;
            Player.instance.triggerCalled = false;            
        }


        if(!isPlayerInTrigger && !isInteracted)
        {
            sprite.sprite = originObj;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
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
        else if (isInteracted)
        {
            sprite.sprite = brokenObj;
            col.enabled = false;
        }
        if(interactedNum == 8)
        {
            PageManager.TriggerCollectionEvent(5);
        }
        isPlayerInTrigger = false;  
    }
}
