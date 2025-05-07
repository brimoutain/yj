using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFadeOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float delay = 1f;         // 等待时间
    public float fadeDuration = 1f;  // 渐隐持续时间

    private void Start()
    {
        // 启动提示渐隐
        StartCoroutine(FadeOutHint());
    }

    private System.Collections.IEnumerator FadeOutHint()
    {
        // 初始状态：完全可见
        canvasGroup.alpha = 1f;

        // 等待 delay 秒
        yield return new WaitForSeconds(delay);

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        gameObject.SetActive(false); // 可选完全隐藏
    }
}
