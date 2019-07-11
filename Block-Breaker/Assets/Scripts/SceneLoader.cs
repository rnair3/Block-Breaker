using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //int totalScene = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((currentSceneIndex + 1));// % totalScene);
        
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
