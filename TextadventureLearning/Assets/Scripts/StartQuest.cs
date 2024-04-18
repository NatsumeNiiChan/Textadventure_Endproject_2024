using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuest : MonoBehaviour
{
    [SerializeField] private GameObject uiObject;

    private TaskManager taskScript;
    private StandardMovement movementScript;

    private bool questStartable;

    private void Awake()
    {
        taskScript = FindObjectOfType<TaskManager>();
        movementScript = FindObjectOfType<StandardMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && questStartable == true)
        {
            uiObject.SetActive(true);
            movementScript.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (taskScript.BookCount >= 10)
        {
            questStartable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        questStartable = false;
    }
}
