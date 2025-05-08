using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStyleChanger : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite clickedSprite;

    private Image img;
    private bool isClicked = false;

    void Start()
    {
        img = GetComponent<Image>();
        if (normalSprite != null)
        {
            img.sprite = normalSprite;
        }
    }

    public void ChangeToClickedStyle()
    {
        if (clickedSprite != null && img != null)
        {
            img.sprite = clickedSprite;
            isClicked = true;
        }
    }

    private void OnMouseUp()
    {
        ResetStyle();
    }

    public void ResetStyle()
    {
        if (normalSprite != null && img != null)
        {
            img.sprite = normalSprite;
            isClicked = false;
        }
    }
}
