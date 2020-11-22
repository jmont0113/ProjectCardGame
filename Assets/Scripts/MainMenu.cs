using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("CardGame");
    }

    public void CollectionScene()
    {
        SceneManager.LoadScene("Collection");
    }

    public void ExitGameScene()
    {
        Application.Quit();
    }

    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
