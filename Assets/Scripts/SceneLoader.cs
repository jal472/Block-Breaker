using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private Block blocks;

	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Lose Screen" || currentScene.name == "Win Screen")
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Block.blockCount = 0;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BlockDestroyed()
    {
        if (Block.blockCount == 0)
        {
            LoadNextScene();
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level 5");
    }
}
