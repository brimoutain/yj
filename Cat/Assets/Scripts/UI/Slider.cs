using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public RectTransform slider;

    private void Start()
    {
        slider = GetComponent<RectTransform>();
    }

    void Update()
    {
        float newWidth = 128.7f * ObjManager.instance.brokenNum * 0.01f;
        slider.sizeDelta = new Vector2(newWidth, slider.sizeDelta.y);
    }
}
