﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonsController : MonoBehaviour
{
    public Button startGameButton;
    public Button highScoreButton;
    public Button tutorialButton;
    public Button highScoreUIClose;
    private HighScoreUI highScoreUI;



    void Start()
    {
        highScoreUI = GetComponent<HighScoreUI>();
        startGameButton.onClick.AddListener(StartGame);
        highScoreButton.onClick.AddListener(highScoreUI.ShowHighscoreUI);
        highScoreUIClose.onClick.AddListener(highScoreUI.HideHighscoreUI);
        tutorialButton.onClick.AddListener(ShowTutorial);

    }
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void ShowTutorial()
    {

    }
   
}
