using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Object : MonoBehaviour
{
    // ����ͨ�ò��Ŷ���
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


    // 1. ����һ��ö��������Ϊѡ��
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
    // 2. �� Inspector ����ʾΪ�����˵�
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
            //��Ҷ�������
            sprite.sprite = brokenObj;
            ObjManager.instance.CheckNum((int)addNum);
            Player.instance.triggerCalled = false;
            //�������������˰�
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
        //// �����봥�����������Ƿ����ض�����
        //if (collision.CompareTag("Player") && isInteracted == false)
        //{
        //    //��ҽ����ⷶΧ����û�б��ƻ���ʱ��ɰױ�
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
            isPlayerInTrigger = true; // �������ڴ�������
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (!isInteracted)
        {
            //����뿪ʱҲû�а���k��������ԭ��
            sprite.sprite = originObj;
        }
        if(interactedNum == 8)
        {
            PageManager.TriggerCollectionEvent(5);
        }
        isPlayerInTrigger = false;
    }
}
