using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuest : MonoBehaviour
{
    [SerializeField] private GameObject uiObject;
    [SerializeField] private bool conditionLess;

    private TaskManager taskScript;
    private StandardMovement movementScript;
    private QuestHandler questScript;

    private bool questStartable;
    public bool questDone;
    private bool inTrigger;

    private void Awake()
    {
        taskScript = FindObjectOfType<TaskManager>();
        movementScript = FindObjectOfType<StandardMovement>();
        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && questStartable == true)
        {
            uiObject.SetActive(true);
            movementScript.enabled = false;
            questScript.HasQuestStarted = true;
        }

        if (questScript.QuestFinished == true)
        {
            questScript.HasQuestStarted = false;
            questDone = true;

            Invoke("UIOff", 1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        questDone = false;

        if (taskScript.BookCount >= 10)
        {
            questStartable = true;
        }

        if (taskScript.DrumCount >= 3)
        {
            questStartable = true;
        }

        if (conditionLess == true && questScript.HasQuestStarted == true)
        {
            questStartable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        questStartable = false;

        if (questDone == true)
        {
            questDone = false;
            questScript.QuestFinished = false;
            Destroy(gameObject);
        }
    }

    private void UIOff()
    {
        uiObject.SetActive(false);
        movementScript.enabled = true;
    }
}
