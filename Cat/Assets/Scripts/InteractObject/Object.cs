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

    protected virtual void Start()
    {
        //anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();

        switch (selectedState)
        {
            case StateType.grab:
                playerState = Player.instance.grabState;
                break;
            case StateType.push:
                playerState = Player.instance.pushState;
                break;
            default:
                return;
        }
    }

    private void Update()
    {
        if (Player.instance.triggerCalled && isInteracted == true)
        {
            Debug.Log("End");
            Player.instance.stateMachine.ChangeState(Player.instance.idleState);
            //玩家动画结束
            sprite.sprite = brokenObj;
            ObjManager.instance.brokenNum += (int)addNum;
            Player.instance.triggerCalled = false;
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        // 检查进入触发器的物体是否是特定类型
        if (collision.CompareTag("Player") && isInteracted == false)
        {
            //玩家进入检测范围，且没有被破坏过时变成白边
            sprite.sprite = enterObj;
            if (Input.GetKeyDown(KeyCode.K) )
            {
                //玩家按下k键，可以控制播放动画等操作，这里变为破坏物体
                isInteracted = true;
                //准备播放动画
                Player.instance.stateMachine.ChangeState(playerState);
            }
            
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (!isInteracted)
        {
            //如果离开时也没有按下k键，则变回原样
            sprite.sprite = originObj;
        }
    }
}
