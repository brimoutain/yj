using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFinish : MonoBehaviour
{
    public delegate void AnimationFinishDelegate(Player player);

    [SerializeField] private Player player;

    public event AnimationFinishDelegate animationFinish;

    public void TriggerCalled(Player player)
    {
        this.animationFinish += player.AnimationFinished;
        animationFinish.Invoke(player);
    }
}
