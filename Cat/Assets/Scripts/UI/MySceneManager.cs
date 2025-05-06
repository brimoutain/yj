using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    public SceneFader fader; 

    public void StartGame()
    {
        fader.FadeToScene("GameScene");
    }

    public void OpenAchievements()
    {
        fader.FadeToScene("AchievementsScene");
    }
    public void QuitGame()
    {
        Debug.Log("ÍË³öÓÎÏ·");
        Application.Quit();
    }
}
