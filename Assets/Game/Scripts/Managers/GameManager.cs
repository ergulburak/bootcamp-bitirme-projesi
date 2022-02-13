using UnityEngine;
using Sirenix.OdinInspector;
using System;
using Game.Scripts.Player;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] [ReadOnly] private GameStates state = GameStates.PrepareGame;

    private void Start()
    {
        HandleStates();
        UIManager.Instance.OnGameStart += StartGame;
        Player.Instance.OnFinish += OnWin;
    }

    private void OnWin(object sender, EventArgs e)
    {
        state = GameStates.LevelSuccess;
        HandleStates();
    }

    private void StartGame(object sender, EventArgs e)
    {
        state = GameStates.MainGame;
        HandleStates();
    }

    private void HandleStates()
    {
        switch (state)
        {
            case GameStates.PrepareGame:
                UIManager.Instance.SetStartingUI();
                break;
            case GameStates.MainGame:
                Player.Instance.PlayerCanMove = true;
                UIManager.Instance.OpenInGamePanel();
                break;
            case GameStates.LevelSuccess:
                Player.Instance.PlayerCanMove = false;
                UIManager.Instance.OpenLevelSuccessPanel();
                break;
           
        }
    }
}
