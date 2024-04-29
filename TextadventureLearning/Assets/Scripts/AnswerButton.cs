using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;

    private QuestionSetup questionScript;
    private QuestHandler questScript;

    private void Awake()
    {
        questionScript = FindObjectOfType<QuestionSetup>();
        questScript = FindObjectOfType<QuestHandler>();
    }

    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        if (isCorrect == true)
        {
            Debug.Log("C");
            questionScript.SelectNewQuestion();
            questionScript.SetQuestionValues();
            questionScript.SetAnswerValues();
            questScript.Lvl2Count++;
        }

        else
        {
            Debug.Log("w");
        }
    }
}
