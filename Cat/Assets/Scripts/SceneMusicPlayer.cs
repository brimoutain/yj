using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SceneMusicFader : MonoBehaviour
{
    public AudioClip musicClip;
    public float targetVolume = 0.5f;
    public float fadeDuration = 2f;
    public bool playOnStart = true;
    public bool loop = true;
    public bool dontDestroyOnLoad = false;

    private AudioSource audioSource;
    private Coroutine fadeCoroutine;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.volume = 0f;
        audioSource.loop = loop;
        audioSource.playOnAwake = false;

        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }

        if (playOnStart && musicClip != null)
        {
            audioSource.Play();
            FadeIn();
        }
    }

    public void FadeIn()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeAudio(targetVolume));
    }

    public void FadeOut()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeAudio(0f));
    }

    private IEnumerator FadeAudio(float targetVol)
    {
        float startVolume = audioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVol, elapsed / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVol;

        if (Mathf.Approximately(targetVol, 0f))
        {
            audioSource.Stop();
        }
    }
}
