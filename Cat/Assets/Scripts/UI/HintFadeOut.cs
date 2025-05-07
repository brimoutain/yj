using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFadeOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float delay = 1f;         // �ȴ�ʱ��
    public float fadeDuration = 1f;  // ��������ʱ��

    private void Start()
    {
        // ������ʾ����
        StartCoroutine(FadeOutHint());
    }

    private System.Collections.IEnumerator FadeOutHint()
    {
        // ��ʼ״̬����ȫ�ɼ�
        canvasGroup.alpha = 1f;

        // �ȴ� delay ��
        yield return new WaitForSeconds(delay);

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        gameObject.SetActive(false); // ��ѡ��ȫ����
    }
}
