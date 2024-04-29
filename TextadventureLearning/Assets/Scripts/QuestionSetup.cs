using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField] private List<QuestionData> questions;
    private QuestionData currentQuestion;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private AnswerButton[] answerButtons;

    [SerializeField] private int correctAnswerChoice;

    public EnterTrigger TriggerScript;
    private QuestHandler questScript;

    private void Awake()
    {
        questScript = FindObjectOfType<QuestHandler>();
        //GetQuestionAssets();
    }

    private void Start()
    {
        //SelectNewQuestion();
        //SetQuestionValues();
        //SetAnswerValues();
    }

    public void GetQuestionAssets()
    {
        if (TriggerScript.IsPanulaan == true)
        {
            questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("QuestionsPanulaan"));
            questScript.GotBook = true;
        }

        if (TriggerScript.IsPagsuyo == true)
        {
            questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("QuestionsPagsuyo"));
        }

        if (TriggerScript.IsTanim == true)
        {
            questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("QuestionsTanim"));
        }

        if (TriggerScript.IsHayop == true)
        {
            questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("QuestionsHayop"));
        }

        if (TriggerScript.IsLupa == true)
        {
            questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("QuestionsLupa"));
        }

        if (TriggerScript.IsYari == true)
        {
            questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("QuestionsYari"));
        }
    }

    public void SelectNewQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomQuestionIndex];
        questions.RemoveAt(randomQuestionIndex);
    }

    public void SetQuestionValues()
    {
        questionText.text = currentQuestion.Question;
    }

    public void SetAnswerValues()
    {
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.Answers));

        for (int i = 0; i < answerButtons.Length; i++)
        {
            bool isCorrect = false;

            if (i == correctAnswerChoice)
            {
                isCorrect = true;
            }

            answerButtons[i].SetIsCorrect(isCorrect);
            answerButtons[i].SetAnswerText(answers[i]);
        }
    }

    private List<string> RandomizeAnswers(List<string> originalList)
    {
        bool correctAnswerChosen = false;

        List<string> newList = new List<string>();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int random = Random.Range(0, originalList.Count);

            if (random == 0 && correctAnswerChosen == false)
            {
                correctAnswerChoice = i;
                correctAnswerChosen = true;
            }

            newList.Add(originalList[random]);
            originalList.RemoveAt(random);
        }

        return newList;
    }
}
