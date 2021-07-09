using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates {
    Initializing, Playing, GameWin, GameOver
}

public class GameController : SingleOnScene<GameController>
{
    [SerializeField] private GameStates mGameState = GameStates.Initializing;

    private void Start()
    {
        StartCoroutine(StartLevelAfterDelay());
    }

    IEnumerator StartLevelAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);
        GameState = GameStates.Playing;
    }

    public GameStates GameState
    {
        get => mGameState;
        set => mGameState = value;
    }

    public void GameWin()
    {
        GameState = GameStates.GameWin;
        int currentLevel = PlayerPrefs.GetInt(Constants.CURRENT_LEVEL, 1) + 1;
        PlayerPrefs.SetInt(Constants.CURRENT_LEVEL, currentLevel);
        //PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt(Constants.CURRENT_LEVEL, 1));
        
        UserInterfaceController.Instance.ShowGameWinScreen();
        
    }

    public void GameOver()
    {
        GameState = GameStates.GameOver;
        UserInterfaceController.Instance.ShowGameOverScreen();
    }

}
