using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.U2D;
using static Object;

public class ObjectForBedroom : MonoBehaviour
{
    // ����ͨ�ò��Ŷ���
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
    // 2. �� Inspector ����ʾΪ�����˵�
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
            //��Ҷ�������
            originObj.SetActive(false);
            enterObj.SetActive(false);//�رհױ�
            brokenObj.SetActive(true);//���ƻ�
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
            isPlayerInTrigger = true; // �������ڴ�������
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isInteracted)
        {
            //����뿪ʱҲû�а���k��������ԭ��
            enterObj.SetActive(false);
        }
        else if (isInteracted)
        {
            //��Ҷ�������
            originObj.SetActive(false);
            enterObj.SetActive(false);//�رհױ�
            brokenObj.SetActive(true);//���ƻ�
        }
        isPlayerInTrigger = false;  
    }
}
