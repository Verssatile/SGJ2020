using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonsController : MonoBehaviour
{
    Button startGameButton;
    Button highScoreButton;



    void Start()
    {
        startGameButton = GameObject.Find("StartGame").GetComponent<Button>();
        highScoreButton = GameObject.Find("HighScore").GetComponent<Button>();

        startGameButton.onClick.AddListener(StartGame);
        highScoreButton.onClick.AddListener(ShowHighScore);
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void ShowHighScore()
    {

    }
}
