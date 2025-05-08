using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameControlUI : MonoBehaviour
{
    public Button restartButton;
    public Button endButton;
    public Image fadeImage; 
    public float fadeDuration = 1f;

    private void Start()
    {
        if (restartButton != null)
            restartButton.onClick.AddListener(() => StartCoroutine(FadeAndLoadScene("GameScene")));
        else
            Debug.LogWarning("Restart Button Œ¥…Ë÷√");

        if (endButton != null)
            endButton.onClick.AddListener(() => StartCoroutine(FadeAndLoadScene("StartScene")));
        else
            Debug.LogWarning("End Button Œ¥…Ë÷√");

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
        else
        {
            Debug.LogWarning("Fade Image Œ¥…Ë÷√");
        }
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        if (fadeImage != null)
        {
            // Ω•“˛
            float timer = 0f;
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                float alpha = Mathf.Clamp01(timer / fadeDuration);
                Color c = fadeImage.color;
                c.a = alpha;
                fadeImage.color = c;
                yield return null;
            }
        }

        SceneManager.LoadScene(sceneName);
    }
}
