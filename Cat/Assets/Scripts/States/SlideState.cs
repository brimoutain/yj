using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        player.transform.DOMove(new Vector3(10, 0, 0) + player.transform.position, 0.35f);
        if(!player.facingRight)
            player.Flip();
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
