using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static Object;

public class ObjectForBedroom : MonoBehaviour
{
    // 物体通用播放动画
    //protected Animator anim;
    protected Collider2D col;
    protected bool isInteracted = false;

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
    void Start()
    {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 检查进入触发器的物体是否是特定类型
        if (collision.CompareTag("Player"))
        {
            //玩家进入检测范围，且没有被破坏过时变成白边
            enterObj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.K) && isInteracted == false)
            {
                //玩家按下k键，可以控制播放动画等操作，这里变为破坏物体
                isInteracted = true;
                //准备播放动画
                Player.instance.stateMachine.ChangeState(playerState);
            }
            if (Player.instance.triggerCalled && isInteracted == true)
            {
                //玩家动画结束
                enterObj.SetActive(false);
                brokenObj.SetActive(true);
                Player.instance.triggerCalled = false;
                ObjManager.instance.brokenNum += (int)addNum;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isInteracted)
        {
            //如果离开时也没有按下k键，则变回原样
            enterObj.SetActive(false);
        }
    }
}
