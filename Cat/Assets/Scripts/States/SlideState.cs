using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : PlayerState
{
    public SlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetZeroVelocity();
        player.transform.position = GameObject.Find("SlidePoint").transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
