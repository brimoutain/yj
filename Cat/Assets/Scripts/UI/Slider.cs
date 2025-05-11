using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public RectTransform slider;
    public RectTransform layer;

    private void Start()
    {
        slider = GetComponent<RectTransform>();
    }

    public void AddNum()
    {
        float newWidth = 128.7f * ObjManager.instance.brokenNum * 0.01f;
        slider.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
    }
}
