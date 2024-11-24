using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void SettingsMenu()
    {
        Time.timeScale = 0;
    }

    public void BackSettingsMenu()
    {
        Time.timeScale = 1;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
