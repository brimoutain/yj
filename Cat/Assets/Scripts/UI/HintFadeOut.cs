using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFadeOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float initialDelay = 1f;     // 等待多久再开始显示
    public float fadeInDuration = 1f;   // 渐显持续时间
    public float visibleDelay = 1f;     // 显示后保持多久
    public float fadeOutDuration = 1f;  // 渐隐持续时间

    private void Start()
    {
        // 启动完整流程
        StartCoroutine(DelayedFadeInAndOut());
    }

    private System.Collections.IEnumerator DelayedFadeInAndOut()
    {
        // 初始透明
        canvasGroup.alpha = 0f;

        // 等待一段时间再开始渐显
        yield return new WaitForSeconds(initialDelay);

        // 渐显过程
        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;

        // 保持可见一段时间
        yield return new WaitForSeconds(visibleDelay);

        // 渐隐过程
        t = 0f;
        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeOutDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        gameObject.SetActive(false); // 隐藏对象（可选）
    }
}
