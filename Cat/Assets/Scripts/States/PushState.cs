using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushState : PlayerState
{
    public PushState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (player.triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
