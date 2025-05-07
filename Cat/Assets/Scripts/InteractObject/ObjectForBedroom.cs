using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static Object;

public class ObjectForBedroom : MonoBehaviour
{
    // ����ͨ�ò��Ŷ���
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
    // 2. �� Inspector ����ʾΪ�����˵�
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
        // �����봥�����������Ƿ����ض�����
        if (collision.CompareTag("Player"))
        {
            //��ҽ����ⷶΧ����û�б��ƻ���ʱ��ɰױ�
            enterObj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.K) && isInteracted == false)
            {
                //��Ұ���k�������Կ��Ʋ��Ŷ����Ȳ����������Ϊ�ƻ�����
                isInteracted = true;
                //׼�����Ŷ���
                Player.instance.stateMachine.ChangeState(playerState);
            }
            if (Player.instance.triggerCalled && isInteracted == true)
            {
                //��Ҷ�������
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
            //����뿪ʱҲû�а���k��������ԭ��
            enterObj.SetActive(false);
        }
    }
}
