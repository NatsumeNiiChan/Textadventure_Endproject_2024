using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    public bool IsPanulaan;
    public bool IsPagsuyo;
    public bool IsTanim;
    public bool IsYari;
    public bool IsHayop;
    public bool IsLupa;

    private bool questDoable = true;

    [SerializeField] private GameObject uiObject;
    [SerializeField] private GameObject questUI;
    [SerializeField] private DialogueManagement dialogueScript;
    private QuestionSetup questionScript;
    private StandardMovement movementScript;
    private QuestHandler questScript;

    private void Awake()
    {
        questionScript = FindObjectOfType<QuestionSetup>();
        movementScript = FindObjectOfType<StandardMovement>();
        //dialogueScript = GetComponent<DialogueManagement>();
        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Update()
    {
        if (questScript.Lvl2Count >= 5)
        {
            questUI.SetActive(false);
            dialogueScript.enabled = true;
            Debug.Log("diaOn");
            questScript.QuestCount++;
            questScript.Lvl2Count = 0;
            movementScript.enabled = true;
            movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //uiObject.SetActive(true);
        questionScript.TriggerScript = gameObject.GetComponent<EnterTrigger>();
        
        questionScript.GetQuestionAssets();
        dialogueScript.enabled = true;

        //if (dialogueScript.TextTwo == true && questDoable == true)
        //{
        //    movementScript.enabled = false;
        //    questUI.SetActive(true);
        //    questionScript.SelectNewQuestion();
        //    questionScript.SetQuestionValues();
        //    questionScript.SetAnswerValues();
        //    questDoable = false;
        //    questScript.DialogueScript = dialogueScript;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //uiObject.SetActive(false);

        
    }

    public void StartQuiz()
    {
        questUI.SetActive(true);
        questionScript.SelectNewQuestion();
        questionScript.SetQuestionValues();
        questionScript.SetAnswerValues();
        questDoable = false;
        dialogueScript.enabled = false;
        dialogueScript.TextOne = false;
        dialogueScript.TextTwo = true;
        dialogueScript.CharacterArt.SetActive(false);
        dialogueScript.TextBox.SetActive(false);
        movementScript.enabled = false;

        Destroy(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.gameObject);
    }
}
