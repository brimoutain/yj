using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFadeOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float initialDelay = 1f;     // �ȴ�����ٿ�ʼ��ʾ
    public float fadeInDuration = 1f;   // ���Գ���ʱ��
    public float visibleDelay = 1f;     // ��ʾ�󱣳ֶ��
    public float fadeOutDuration = 1f;  // ��������ʱ��

    private void Start()
    {
        // ������������
        StartCoroutine(DelayedFadeInAndOut());
    }

    private System.Collections.IEnumerator DelayedFadeInAndOut()
    {
        // ��ʼ͸��
        canvasGroup.alpha = 0f;

        // �ȴ�һ��ʱ���ٿ�ʼ����
        yield return new WaitForSeconds(initialDelay);

        // ���Թ���
        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;

        // ���ֿɼ�һ��ʱ��
        yield return new WaitForSeconds(visibleDelay);

        // ��������
        t = 0f;
        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeOutDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        gameObject.SetActive(false); // ���ض��󣨿�ѡ��
    }
}
