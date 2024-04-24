using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    //[SerializeField] private GameObject uiObject;

    public int BookCount;
    public int DrumCount;
    public bool QuestDoable;

    private QuestHandler questScript;

    private void Awake()
    {
        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (questScript.HasQuestStarted == true && collision.gameObject.tag == "QuestObject")
        {
            collision.gameObject.GetComponent<PickUp>().IsPickable = true;
            //uiObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "QuestObject")
        {
            collision.gameObject.GetComponent<PickUp>().IsPickable = false;
            //uiObject.SetActive(false);
        }
    }
}
