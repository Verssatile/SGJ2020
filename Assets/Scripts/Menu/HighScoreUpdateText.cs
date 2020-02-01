using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreUpdateText : MonoBehaviour
{
    private void Awake()
    {
        var highscoreText = GetComponent<TextMeshProUGUI>();
        highscoreText.text = HighScoreManager.GetHighScore().ToString();
    }
}
