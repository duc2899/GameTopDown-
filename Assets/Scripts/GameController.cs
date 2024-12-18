using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject doubleScoreBall;
    public GameObject decrementScoreBall;
    public float spawnTime;
    public float doubleScoreDuration = 10f;

    float m_spawnTime;
    int m_score;
    bool m_isGameOver;
    bool m_isGameStart;
    bool m_isDoubleScoreActivate;
    float m_doubleScoreTimer;



    UIManager m_UIManager;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_UIManager = FindObjectOfType<UIManager>();
        m_UIManager.SetScore(m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameStart)
        {
            m_spawnTime -= Time.deltaTime;
            if (m_isGameOver)
            {
                m_spawnTime = 0;
                m_UIManager.ShowGameOverPanel(true);
                return;
            }
            if (m_spawnTime <= 0)
            {
                SpawBall();
                m_spawnTime = spawnTime;
            }
            if (m_isDoubleScoreActivate)
            {
                m_doubleScoreTimer -= Time.deltaTime;
                m_UIManager.SetDoubleScoreTime(Mathf.CeilToInt(m_doubleScoreTimer));

                if (m_doubleScoreTimer <= 0)
                {
                    EndDoubleScore();
                }
            }
        }
        
    }

    public void SpawBall() {
        Vector2 spawnPos = new Vector2(Random.Range(-7, 7), 6);
        GameObject spawnedBall = null;
        Ball ballScript = null;

        // 20% cơ hội xuất hiện bóng x2 điểm
        if (Random.Range(0, 10) < 1)
        {
            spawnedBall = Instantiate(doubleScoreBall, spawnPos, Quaternion.identity);
            ballScript = spawnedBall.GetComponent<Ball>();
            ballScript.typeBall = "DOUBLE"; // Đặt thành bóng x2 điểm
        }
        // 30% cơ hội xuất hiện bóng giảm điểm
        else if (Random.Range(0, 10) < 3)
        {
            spawnedBall = Instantiate(decrementScoreBall, spawnPos, Quaternion.identity);
            ballScript = spawnedBall.GetComponent<Ball>();
            ballScript.typeBall = "DESTROY"; // Đặt thành bóng giảm điểm
        }
        // Còn lại là bóng bình thường
        else
        {
            spawnedBall = Instantiate(ball, spawnPos, Quaternion.identity);
            ballScript = spawnedBall.GetComponent<Ball>();
            ballScript.typeBall = "NORMAL";
        }

    }

    public void Replay() {
        m_score = 0;
        m_isGameOver = false;
        m_UIManager.SetScore(m_score);
        m_UIManager.ShowGameOverPanel(false);
      
        EndDoubleScore();
    }

    public void SetScore (int score) {  m_score = score; }

    public int GetScore() { 
        return m_score;
    }

    public void IncrementScore() {
        if (m_isDoubleScoreActivate) {
            m_score += 2;
        }
        else
        {
            m_score++;
        }
        m_UIManager.SetScore(m_score);
    }

    public void DecrementScore() { 
        m_score--;
        if(m_score <= 0)
        {
            m_score = 0;
        }
        m_UIManager.SetScore(m_score);
    }

    public bool GetStateIsGameOver() { 
        return m_isGameOver;
    }

    public void SetStateIsGameOver (bool state) { m_isGameOver = state; }

    public void ActivateDoubleScore()
    {
        m_isDoubleScoreActivate = true;
        m_doubleScoreTimer += doubleScoreDuration;
        m_UIManager.ShowDoubleScoreIndicator(true);
       
    }

    public void EndDoubleScore() {
        m_isDoubleScoreActivate = false;
        m_UIManager.ShowDoubleScoreIndicator(false);
        m_doubleScoreTimer = 0;
    }

    public void SetStartGame()
    {
        m_isGameStart = true;
        m_UIManager.ShowGameStartPanel(false);
    }
    
    public bool GetStartGame()
    {
        return m_isGameStart;
    }
}
