using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    [SerializeField] private GameObject uiObject;
    public bool IsSpacable;

    private QuestHandler questScript;

    private void Awake()
    {
        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsSpacable = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (questScript.HasQuestStarted == true && questScript.LevelTwo == false)
        {
            uiObject.SetActive(true);
        }

        else if (collision.gameObject.tag == "Houses")
        {
            uiObject.SetActive(true);
        }

        else if (IsSpacable == true)
        {
            uiObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uiObject.SetActive(false);
    }
}
