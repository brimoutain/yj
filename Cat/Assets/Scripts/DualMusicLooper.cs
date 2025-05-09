using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DualMusicLooper : MonoBehaviour
{
    public AudioClip music1;
    public AudioClip music2;
    public float fadeDuration = 2f;
    public float volume = 0.5f;
    public bool dontDestroyOnLoad = false;

    private AudioSource audioSource;
    private AudioClip currentClip;
    private bool isPlayingMusic1 = true;
    private Coroutine loopCoroutine;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
        audioSource.loop = false;
        audioSource.playOnAwake = false;

        if (dontDestroyOnLoad)
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (music1 != null && music2 != null)
        {
            loopCoroutine = StartCoroutine(PlayMusicLoop());
        }
    }

    private IEnumerator PlayMusicLoop()
    {
        while (true)
        {
            currentClip = isPlayingMusic1 ? music1 : music2;
            isPlayingMusic1 = !isPlayingMusic1;

            audioSource.clip = currentClip;
            audioSource.Play();

            yield return StartCoroutine(FadeAudio(volume));

            yield return new WaitForSeconds(currentClip.length - fadeDuration); // 播放中大部分时长

            yield return StartCoroutine(FadeAudio(0f));
            audioSource.Stop();
        }
    }

    private IEnumerator FadeAudio(float targetVolume)
    {
        float startVolume = audioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
}
