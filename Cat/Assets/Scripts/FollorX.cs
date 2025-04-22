using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollorX : MonoBehaviour
{
        public Transform target;
        public float fixedY = 5f;
        public float fixedZ = -10f;

    void LateUpdate()
    {
        if (target == null) return;
        if (target.position.x - 1.93 < 0.01)
        {
            transform.position = new Vector3(1.93f, fixedY, fixedZ);
        }
        else
        {
            transform.position = new Vector3(target.position.x, fixedY, fixedZ);
        }
    }

}
