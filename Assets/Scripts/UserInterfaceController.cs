using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterfaceController : SingleOnScene<UserInterfaceController>
{
    public GameObject gameOverScreen, gameWinScreen;
    
    public void ShowGameOverScreen() {
        gameOverScreen.SetActive(true);
    }
    
    public void ShowGameWinScreen() {
        gameWinScreen.SetActive(true);
    }

    public void NextLevelButton()
    {
        LevelController.Instance.LoadNextLevel();
    }

    public void HomeButton()
    {
        LevelController.Instance.LoadHomeLevel();
    }

    public void ReplayButton()
    {
        LevelController.Instance.LoadCurrentLevel();
    }

}
