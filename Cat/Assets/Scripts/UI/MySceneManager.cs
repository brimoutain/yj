using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public SceneFader fader;
    public GameObject pageGroup;
    public GameObject tabGroup;

    public void StartGame()
    {
        fader.FadeToScene("GameScene");
    }

    public void OpenAchievements()
    {
        pageGroup.SetActive(true);
        tabGroup.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("ÍË³öÓÎÏ·");
        Application.Quit();
    }
}
