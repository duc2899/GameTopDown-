using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text doubleScoreTime;
    public GameObject gameOverPannel;
    public GameObject gameStartPannel;
    
    public void SetScore(int score) { 
        if(scoreText)
            scoreText.text = "Score: " + (score < 10 ? "0" + score : score);

    }

    public void SetDoubleScoreTime(int time)
    {
        if (doubleScoreTime)
            doubleScoreTime.text = "x2 Time Left: " + (time < 10 ? "0" + time : time) + " s";
    }
    public void ShowGameOverPanel (bool isShow)
    {
        if(gameOverPannel)
            gameOverPannel.SetActive(isShow);
    }

    public void ShowGameStartPanel(bool isShow)
    {
        if (gameStartPannel)
            gameStartPannel.SetActive(isShow);
    }

    public void ShowDoubleScoreIndicator (bool isShow)
    {
        doubleScoreTime.gameObject.SetActive(isShow);
    }


}
