using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;

    private int currentScore;
    private int bestScore;
    void Start()
    {
        currentScore = 0;
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        currentScoreText.text = currentScore.ToString();
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;
        currentScoreText.text = currentScore.ToString();

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }

    public string GetCurrentScore() => currentScore.ToString();

    public string GetBestScore() => bestScore.ToString();
}
