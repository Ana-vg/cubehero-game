using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
