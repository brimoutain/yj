using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.U2D;
using static Object;

public class ObjectForBedroom : MonoBehaviour
{
    // 物体通用播放动画
    //protected Animator anim;
    protected Collider2D col;
    protected bool isInteracted = false;

    public GameObject originObj;
    public GameObject enterObj;
    public GameObject brokenObj;
    protected PlayerState playerState;
    public enum StateType
    {
        grab,
        push,
        yaodianxian
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
    private bool isPlayerInTrigger;

    void Start()
    {
        originObj.SetActive(true);
        //anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();

        switch (selectedState)
        {
            case StateType.grab:
                playerState = Player.instance.grabState;
                break;
            case StateType.push:
                playerState = Player.instance.pushState;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (Player.instance.triggerCalled && isInteracted)
        {
            //玩家动画结束
            originObj.SetActive(false);
            enterObj.SetActive(false);//关闭白边
            brokenObj.SetActive(true);//打开破坏
            Player.instance.stateMachine.ChangeState(Player.instance.idleState);
            ObjManager.instance.brokenNum += (int)addNum;
            ObjManager.instance.CheckNum();
            Player.instance.triggerCalled = false;
            
        }

        if (isPlayerInTrigger && Input.GetKeyDown(Player.instance.keyCodes[1]))
        {
            isInteracted = true;
            Player.instance.stateMachine.ChangeState(playerState);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isInteracted)
        {
            enterObj.SetActive(true);
            isPlayerInTrigger = true; // 标记玩家在触发区域
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isInteracted)
        {
            //如果离开时也没有按下k键，则变回原样
            enterObj.SetActive(false);
        }
        else if (isInteracted)
        {
            //玩家动画结束
            originObj.SetActive(false);
            enterObj.SetActive(false);//关闭白边
            brokenObj.SetActive(true);//打开破坏
        }
        isPlayerInTrigger = false;  
    }
}
