using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestHayop : MonoBehaviour
{
    public float XCoordinate;
    public float YCoordinate;

    private GameObject interactText;
    private GameObject player;

    [SerializeField] private bool inTrigger;
    private bool isActively = true;

    [SerializeField] private DialogueManagement dialogueScript;
    private QuestHandler questScript;


    private void Awake()
    {
        //interactText = GameObject.Find("InteractText");

        player = GameObject.Find("Player");
        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Update()
    {
        if (inTrigger == true & Input.GetKeyDown(KeyCode.Space) && dialogueScript.TextTwo == true)
        {
            player.transform.position = new Vector2(XCoordinate, YCoordinate);
            inTrigger = false;
        }

        if (inTrigger == true & Input.GetKeyDown(KeyCode.Space) && questScript.HayopQuestCount >= 7)
        {
            player.transform.position = new Vector2(XCoordinate, YCoordinate);
            inTrigger = false;

            dialogueScript = GameObject.Find("Hayop").GetComponentInChildren<DialogueManagement>();
            dialogueScript.TextTwo = false;
            dialogueScript.TextThree = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;

        if (gameObject.tag == "Dreampet" && isActively == true)
        {
            questScript.HayopQuestCount++;
            isActively = false;
        }

        if (questScript.HayopQuestCount >= 7)
        {
            //UI an
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
        //interactText.SetActive(false);

        if (gameObject.tag != "Dreampet" && questScript.HayopQuestCount >= 7)
        {
            questScript.QuestCount++;
            questScript.HasQuestStarted = false;
            questScript.HayopQuestCount = 0;
            Destroy(gameObject);
        }
    }
}

