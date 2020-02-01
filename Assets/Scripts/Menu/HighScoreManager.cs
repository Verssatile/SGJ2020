using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager
{
    private static string highscore = "HighScore";

    public static void SetHighScore(int score)
    {
       if(PlayerPrefs.HasKey(highscore) && score>= PlayerPrefs.GetInt(highscore))
        {
            PlayerPrefs.SetInt(highscore, score);
            PlayerPrefs.Save();
        }
    }
    public static int GetHighScore()
    {
        return PlayerPrefs.HasKey(highscore) ? PlayerPrefs.GetInt(highscore) : 0;
    }

}