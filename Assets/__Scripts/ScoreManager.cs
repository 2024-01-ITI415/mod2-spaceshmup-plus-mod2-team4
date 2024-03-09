using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private int highScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Load high score from player preferences
        highScore = PlayerPrefs.GetInt("HighScore: ", 0);
        UpdateHighScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        // Check if it's a new high score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore: ", highScore);
            UpdateHighScoreText();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

}
