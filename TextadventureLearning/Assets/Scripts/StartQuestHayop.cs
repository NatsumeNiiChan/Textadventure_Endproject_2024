using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestHayop : MonoBehaviour
{
    public float XCoordinate;
    public float YCoordinate;

    private GameObject player;

    [SerializeField] private bool inTrigger;
    [SerializeField] private bool isAnimal;
    private bool isActively = true;
    public bool PetGettable;

    [SerializeField] private DialogueManagement dialogueScript;
    private QuestHandler questScript;


    private void Awake()
    {
        player = GameObject.Find("Player");
        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Update()
    {
        if (inTrigger == true & Input.GetKeyDown(KeyCode.Space) && dialogueScript.TextTwo == true && isAnimal == false)
        {
            player.transform.position = new Vector2(XCoordinate, YCoordinate);
            inTrigger = false;
        }

        if (inTrigger == true & Input.GetKeyDown(KeyCode.Space) && questScript.HayopQuestCount >= 7 && PetGettable == true)
        {
            player.transform.position = new Vector2(XCoordinate, YCoordinate);
            inTrigger = false;
            questScript.HayopQuestCount = 0;
            questScript.GotPet = true;

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

        if (gameObject.tag != "Dreampet" && questScript.GotPet == true)
        {
            questScript.QuestCount++;
            questScript.HasQuestStarted = false;
            Destroy(gameObject);
        }
    }
}

