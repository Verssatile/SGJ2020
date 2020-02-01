using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    public GameObject highscoreUI;
    public GameObject menuButtons;

    public void ShowHighscoreUI()
    {
        menuButtons.SetActive(false);
        highscoreUI.SetActive(true);
    }

    public void HideHighscoreUI()
    {
        highscoreUI.SetActive(false);
        menuButtons.SetActive(true);
    }

}
