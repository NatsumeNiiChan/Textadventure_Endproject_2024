using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    //[SerializeField] private GameObject uiObject;

    public int BookCount;
    public int DrumCount;
    public bool QuestDoable;

    [SerializeField] private bool level2;

    private QuestHandler questScript;
    private StandardMovement movementScript;

    private void Awake()
    {
        questScript = FindObjectOfType<QuestHandler>();
        movementScript = GetComponent<StandardMovement>();
    }

    private void Start()
    {
        movementScript.enabled = true;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (questScript.HasQuestStarted == true && collision.gameObject.tag == "QuestObject" && level2 == false)
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
