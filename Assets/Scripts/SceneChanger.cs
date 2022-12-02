using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        EditorSceneManager.LoadScene(sceneName);
    }

    public void LoadCredits()
    {
        EditorSceneManager.LoadScene("Credits");
    }

    public void LoadMainMenu()
    {
        EditorSceneManager.LoadScene("MainMenu");
    }

    public void LoadMainScene()
    {
        EditorSceneManager.LoadScene("MainScene");
    }
}
