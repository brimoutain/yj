using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public Transform slider;

    private void Start()
    {
        slider = GetComponent<Transform>();
    }

    void Update()
    {
        slider.localScale = new Vector3(ObjManager.instance.brokenNum/100,1,1);
    }
}
