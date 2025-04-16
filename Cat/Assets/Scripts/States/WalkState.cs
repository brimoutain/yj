using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerState
{
    private float speedMultiplier = 1f; // 默认速度倍率
    private float sprintMultiplier = 1.5f; // 加速倍率

    public WalkState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        : base(_player, _stateMachine, _animBoolName)
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

        // 检测是否按住左Shift键
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMultiplier = sprintMultiplier;
        }
        else
        {
            speedMultiplier = 1f;
        }

        player.SetVelocity(xInput * player.moveSpeed * speedMultiplier, rb.velocity.y);

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
