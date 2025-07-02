using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CollectionGetting : MonoBehaviour
{
    public RectTransform pos;
    public Image collection;
    public TextMeshProUGUI showText;
    [Header("‘§¥Ê–≈œ¢")]
    public List<Vector2> desPos;
    public List<string> desText;
    private Dictionary<int,string> textDic;
    // Start is called before the first frame update
    void Start()
    {
        pos.anchoredPosition = desPos[0];

        textDic = new Dictionary<int, string>();
        for(int i = 0; i< desText.Count; i++)
        {
            textDic.Add(i, desText[i]);
        }
    }

    public void ShowCollection(int n)
    {
        if (textDic.ContainsKey(n))
        {
            showText.text = textDic[n];
        }

        pos.DOAnchorPosX(desPos[1].x, .5f).OnComplete(()=>StartCoroutine(StayAndEndShowing()));
    }

    IEnumerator StayAndEndShowing()
    {
        yield return new WaitForSeconds (3);

        pos.DOAnchorPosX(desPos[0].x,.5f);
    }
}
