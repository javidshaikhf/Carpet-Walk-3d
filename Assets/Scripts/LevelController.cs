using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : SingleOnScene<LevelController>
{
    public void LoadHomeLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt(Constants.START_LEVEL_NAME));
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt(Constants.CURRENT_LEVEL, 1));
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("1");
    }

}
