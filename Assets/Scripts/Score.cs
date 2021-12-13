using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    
    public Text scoreText;
    public Text highscoreText;

    private int score = 0;
    private int highscore = 0;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        if (highscore < score)
        {
           // PlayerPrefs.SetInt("highscore", score);
            highscore = score;
        }
        UpdateText();
    }

    private void UpdateText()
    {
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
    public void Reset()
    {
        score = 0;
        UpdateText();
    }
}
