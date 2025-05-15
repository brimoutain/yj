using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    public GroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        if (xInput != 0)
        {
            stateMachine.ChangeState(player.walkState);
        }
        else if (xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
        if (Input.GetKeyDown(player.keyCodes[0]))
        {
            stateMachine.ChangeState(player.JumpState);
        }
    }
}
