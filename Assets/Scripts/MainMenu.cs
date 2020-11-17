using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("CardGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
