using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OK()
    {
        SceneManager.LoadScene(0);
    }
}
