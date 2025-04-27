using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object : MonoBehaviour
{
    // ����ͨ�ò��Ŷ���
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
        // �����봥�����������Ƿ����ض�����
        if (collision.CompareTag("Player") && isInteracted == false)
        {
            //��ҽ����ⷶΧ����û�б��ƻ���ʱ��ɰױ�
            sprite.sprite = enterObj;
            if (Input.GetKeyDown(KeyCode.K))
            {
                //��Ұ���k�������Կ��Ʋ��Ŷ����Ȳ����������Ϊ�ƻ�����
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
            //����뿪ʱҲû�а���k��������ԭ��
            sprite.sprite = originObj;
        }
    }
}
