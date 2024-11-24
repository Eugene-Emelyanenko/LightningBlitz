using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Push : MonoBehaviour
{
    [SerializeField] private InputText answer;
    [SerializeField] private Circles circles;
    [SerializeField] private RowMovement rowMovement;
    [SerializeField] private Score score;
    [SerializeField] private Image redImpulseImage;
    public float fadeInDuration = 1f;
    public float fadeOutDuration = 1f;
    public float increaseTime = 10f;

    private Timer timer;

    private void Awake()
    {
        timer = GameObject.Find("TimerManager").GetComponent<Timer>();
    }

    public void PushPressed()
    {
        if (answer.GetAnswer() == circles.CalculateSumOfNumbers().ToString())
            CorrectAnswer();
        else
            InCorrectAnswer();
    }

    private void CorrectAnswer()
    {
        timer.IncreaseTimer(increaseTime);
        rowMovement.ShiftObjects();
        score.IncreaseScore(circles.CalculateSumOfNumbers() + circles.CalculateBonuses());
        AudioManager.instance.Play("CorrectAnswer");
    }

    private void InCorrectAnswer()
    {
        rowMovement.ShiftObjects();
        StartCoroutine(FadeImpulse());
        Vibration.Vibrate();
        AudioManager.instance.Play("InCorrectAnswer");
    }
    
    private IEnumerator FadeImpulse()
    {
        float elapsedTime = 0f;
        Color startColor = redImpulseImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0.25f); // Целевой цвет (прозрачность 0.25)

        // Увеличиваем прозрачность до 0.25
        while (elapsedTime < fadeInDuration)
        {
            redImpulseImage.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Устанавливаем прозрачность на точное значение
        redImpulseImage.color = targetColor;

        // Плавно уменьшаем прозрачность до 0
        elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            redImpulseImage.color = Color.Lerp(targetColor, new Color(startColor.r, startColor.g, startColor.b, 0f), elapsedTime / fadeOutDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Устанавливаем прозрачность на точное значение
        redImpulseImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
}
