using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    public bool triggerCalled = false;

    public float moveSpeed;

    #region State
    public PlayerStateMachine stateMachine {  get; private set; }
    public IdleState idleState { get; private set; }
    public WalkState WalkState { get; private set; }
    #endregion

    #region Component
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    #endregion

    private void Awake()//������״̬
    {
        stateMachine = new PlayerStateMachine();


        idleState = new IdleState(this, stateMachine, "Idle");
        WalkState = new WalkState(this, stateMachine, "Walk");
    }
    private void Start()//��ȡ���
    {
        stateMachine.Initialized(idleState);
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        Vector3 theScale = anim.gameObject.transform.localScale;
        theScale.x = facingRight ? 1 : -1;
        anim.gameObject.transform.localScale = theScale;
    }//��ת����

    public virtual void FlipController(float _x)//Ŀǰ����x��Ŀ��ʱ���ڿ���ʱҲ��ת��
    {
        if (_x > 0 && !facingRight)//���ٶȴ���0��û�г���ʱ����ת
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion

    #region Velocity
    public void SetZeroVelocity()
    {
        //if (isKnocked) return;
        rb.velocity = new Vector2(0, 0);
    }

    public void SetVelocity(float _xVelociuty, float _yVelociuty)
    {
        //if (isKnocked) return;

        rb.velocity = new Vector2(_xVelociuty, _yVelociuty);
        FlipController(_xVelociuty);
    }
    #endregion
    
    public void AnimationFinished(Player player)
    {
        player.triggerCalled = true;
    }
}