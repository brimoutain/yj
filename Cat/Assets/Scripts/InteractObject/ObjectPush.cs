using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPush : Object
{
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

    protected override void Start()
    {
        base.Start();
        playerState = Player.instance.pushState;
    }
}
