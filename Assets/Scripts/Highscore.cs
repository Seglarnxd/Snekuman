using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public static int score = 0;
    public static int highscore;

    private Text text;
    
    
    void Start()
    {
        text = GetComponent<Text>();

        score = 0;

        highscore = PlayerPrefs.GetInt("highscore", highscore);
        text.text = highscore.ToString();
    }

    void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            text.text = "" + score;
            
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void Reset()
    {
        score = 0;
    }
    
    void OnDestroy()
    {
        PlayerPrefs.SetInt ("highscore", highscore);
        PlayerPrefs.Save();
    }
}
