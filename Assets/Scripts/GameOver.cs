using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private Score score;
    private void OnEnable()
    {
        currentScore.text = score.GetCurrentScore();
        bestScore.text = score.GetBestScore();
    }
}
