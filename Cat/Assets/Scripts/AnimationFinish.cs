using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFinish : MonoBehaviour
{
    public delegate void AnimationFinishDelegate(Player player);

    public event AnimationFinishDelegate animationFinish;

    public void TriggerCalled()
    {
        //Debug.Log("TriggerCall");
        //this.animationFinish += Player.instance.AnimationFinished;
        //animationFinish.Invoke(Player.instance);
        Player.instance.AnimationFinished();
    }
}
