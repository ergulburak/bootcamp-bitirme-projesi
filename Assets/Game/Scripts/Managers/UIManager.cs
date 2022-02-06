using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using System;

public class UIManager : Singleton<UIManager>
{
    [FoldoutGroup("Panels")]
    [SerializeField]
    private GameObject prepareGamePanel;

    [FoldoutGroup("Panels")]
    [SerializeField]
    private GameObject mainGamePanel;

    [FoldoutGroup("Panels")]
    [SerializeField]
    private GameObject winGamePanel;

    public event EventHandler OnGameStart;

    public void SetStartingUI()
    {
        prepareGamePanel.SetActive(true);
        mainGamePanel.SetActive(false);
        winGamePanel.SetActive(false);
    }

    public void StartGame()
    {
        OnGameStart?.Invoke(this, EventArgs.Empty);
    }

    public void RetryButton()
    {
        Scene currenScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currenScene.buildIndex);
    }

    public void OpenInGamePanel()
    {
        prepareGamePanel.SetActive(false);
        winGamePanel.SetActive(false);
        mainGamePanel.SetActive(true);
    }

    public void OpenLevelSuccessPanel()
    {
        prepareGamePanel.SetActive(false);
        winGamePanel.SetActive(true);
        mainGamePanel.SetActive(false);
    }

}
