using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public static ObjManager instance;
    public int brokenNum = 0;
    private void Start()
    {
        instance = this;
    }
}

