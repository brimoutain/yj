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
        //这里抓完布进入静止，也可以播放其他动画
        if(player.triggerCalled) 
            stateMachine.ChangeState(player.idleState);
    }
}
