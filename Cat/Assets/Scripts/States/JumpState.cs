using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.rb.AddForce(new Vector2(0, player.jumpforce));
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(player.isGroundDetected && player.rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
