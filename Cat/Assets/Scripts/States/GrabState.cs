using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabState : PlayerState
{
    public GrabState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //����ץ�겼���뾲ֹ��Ҳ���Բ�����������
        if(player.triggerCalled) 
            stateMachine.ChangeState(player.idleState);
    }
}
