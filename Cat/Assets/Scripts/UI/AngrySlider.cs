using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngrySlider : MonoBehaviour
{
    public RectTransform slider;
    public RectTransform layer;

    private void Start()
    {
        slider = GetComponent<RectTransform>();
    }

    public void AddNum()
    {
        float newWidth = 128.7f * CollectionManager.instance.brokenNum * 0.01f;
        slider.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
    }
}
