using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] private Text answerText;
    void Start()
    {
        ClearAnswerText();
    }

    public void AddNumberToAnswer(string number)
    {
        answerText.text += number;
    }

    public void ClearAnswerText()
    {
        answerText.text = string.Empty;
    }

    public string GetAnswer() => answerText.text;
}
